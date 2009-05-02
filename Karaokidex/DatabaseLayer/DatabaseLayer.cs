using System;
using System.Data.SQLite;
using System.Globalization;
using System.IO;
using System.Text;
using System.Data;

namespace Karaokidex
{
    public static partial class DatabaseLayer
    {
        #region Members
        public static string ConnectionString = String.Empty;
        #endregion

        #region Properties
        public static int NumberOfTracksInDatabase
        {
            get
            {
                if (!String.IsNullOrEmpty(DatabaseLayer.ConnectionString))
                {
                    using (SQLiteConnection theConnection = new SQLiteConnection(DatabaseLayer.ConnectionString))
                    {
                        try
                        {
                            theConnection.Open();

                            using (SQLiteCommand theCommand = theConnection.CreateCommand())
                            {
                                theCommand.CommandText =
                                    "SELECT COUNT(*) " +
                                    "FROM [Tracks]";

                                return Convert.ToInt32(
                                    theCommand.ExecuteScalar(),
                                    CultureInfo.CurrentCulture);
                            }
                        }
                        catch
                        {
                            return 0;
                        }
                        finally
                        {
                            theConnection.Close();
                        }
                    }
                }
                return 0;
            }
        }
        #endregion

        #region Methods
        public static void CreateDatabase(
            FileInfo theDatabaseFileInfo)
        {
            SQLiteConnection.CreateFile(theDatabaseFileInfo.FullName);

            DatabaseLayer.ConnectionString = String.Format(
                CultureInfo.CurrentCulture,
                "Data Source={0}; UTF8Encoding=True; Version=3; Pooling=True",
                theDatabaseFileInfo.FullName);

            using (SQLiteConnection theConnection = new SQLiteConnection(DatabaseLayer.ConnectionString))
            {
                try
                {
                    theConnection.Open();

                    using (SQLiteCommand theCommand = theConnection.CreateCommand())
                    {
                        StringBuilder theCommandText = new StringBuilder();

                        theCommandText.Append("CREATE TABLE [Settings] (");
                        theCommandText.Append("[ID] [integer] PRIMARY KEY AUTOINCREMENT,");
                        theCommandText.Append("[Key] [text],");
                        theCommandText.Append("[Value] [text])");

                        theCommand.CommandText = theCommandText.ToString();

                        theCommand.ExecuteNonQuery();
                    }

                    using (SQLiteCommand theCommand = theConnection.CreateCommand())
                    {
                        StringBuilder theCommandText = new StringBuilder();

                        theCommandText.Append("CREATE TABLE [Tracks] (");
                        theCommandText.Append("[ID] [integer] PRIMARY KEY AUTOINCREMENT,");
                        theCommandText.Append("[Path] [text],");
                        theCommandText.Append("[Details] [text],");
                        theCommandText.Append("[Extension] [text],");
                        theCommandText.Append("[Rating] [integer] DEFAULT 0,");
                        theCommandText.Append("[Checksum] [text],");
                        theCommandText.Append("[ToBeDeleted] [boolean] DEFAULT 0)");

                        theCommand.CommandText = theCommandText.ToString();

                        theCommand.ExecuteNonQuery();
                    }
                }
                finally
                {
                    theConnection.Close();
                }
            }
        }

        public static string GetSourceDirectory(
            FileInfo theDatabaseFileInfo)
        {
            DatabaseLayer.ConnectionString = String.Format(
                CultureInfo.CurrentCulture,
                "Data Source={0}; UTF8Encoding=True; Version=3; Pooling=True",
                theDatabaseFileInfo.FullName);

            using (SQLiteConnection theConnection = new SQLiteConnection(DatabaseLayer.ConnectionString))
            {
                try
                {
                    theConnection.Open();

                    using (SQLiteCommand theCommand = theConnection.CreateCommand())
                    {
                        theCommand.CommandText = 
                            "SELECT [Value] " +
                            "FROM [Settings] " +
                            "WHERE [Key] = 'Source Directory'";

                        return Convert.ToString(
                            theCommand.ExecuteScalar(),
                            CultureInfo.CurrentCulture);
                    }
                }
                finally
                {
                    theConnection.Close();
                }
            }
        }

        public static void SetSourceDirectory(
            FileInfo theDatabaseFileInfo,
            DirectoryInfo theSourceDirectory)
        {
            DatabaseLayer.ConnectionString = String.Format(
                CultureInfo.CurrentCulture,
                "Data Source={0}; UTF8Encoding=True; Version=3; Pooling=True",
                theDatabaseFileInfo.FullName);

            using (SQLiteConnection theConnection = new SQLiteConnection(DatabaseLayer.ConnectionString))
            {
                try
                {
                    theConnection.Open();

                    using (SQLiteCommand theCommand = theConnection.CreateCommand())
                    {
                        theCommand.CommandText =
                            "UPDATE [Settings] " +
                            "SET [Value] = ? " +
                            "WHERE [Key] = 'Source Directory'";

                        SQLiteParameter theSourceDirectortParameter = theCommand.CreateParameter();
                        theCommand.Parameters.Add(theSourceDirectortParameter);

                        theSourceDirectortParameter.Value =
                            theSourceDirectory.FullName;

                        theCommand.ExecuteNonQuery();
                    }
                }
                finally
                {
                    theConnection.Close();
                }
            }
        }
        
        public static DataTable SearchDatabase(
            string theCriteria,
            bool ShowOnlyRatedTracks)
        {
            using (DataSet theDataSet = new DataSet())
            {
                using (SQLiteConnection theConnection = new SQLiteConnection(DatabaseLayer.ConnectionString))
                {
                    try
                    {
                        theConnection.Open();

                        using (SQLiteCommand theCommand = theConnection.CreateCommand())
                        {
                            StringBuilder theCommandBuilder = new StringBuilder(
                                "SELECT [ID], [Path], [Details], [Extension], [Rating], " +
                                    "[Path] || '\\' || [Details] || [Extension] AS [FullPath] ");
                            theCommandBuilder.Append("FROM [Tracks] ");
                            theCommandBuilder.Append("WHERE ");

                            bool IsFirstParameter = true;
                            foreach (string thisCriteria in theCriteria.Split(' '))
                            {
                                if (!IsFirstParameter)
                                {
                                    theCommandBuilder.Append(" AND ");
                                }
                                theCommandBuilder.Append("[Details] LIKE ?");

                                SQLiteParameter thisCriteriaParameter = theCommand.CreateParameter();
                                theCommand.Parameters.Add(thisCriteriaParameter);

                                thisCriteriaParameter.Value = String.Format(
                                    CultureInfo.CurrentCulture,
                                    "%{0}%",
                                    thisCriteria.ToString());

                                IsFirstParameter = false;
                            }

                            if (ShowOnlyRatedTracks)
                            {
                                theCommandBuilder.Append(" AND [Rating] > 0");
                            }

                            theCommandBuilder.Append(" ORDER BY [Rating] DESC, [Path], [Details]");

                            theCommand.CommandText = theCommandBuilder.ToString();

                            using (SQLiteDataAdapter theAdapter = new SQLiteDataAdapter(theCommand))
                            {
                                theAdapter.Fill(theDataSet);
                            }
                        }
                    }
                    finally
                    {
                        theConnection.Close();
                    }
                }
                return theDataSet.Tables[0];
            }
        }

        public static void UpdateTrackRating(
            string theChecksum,
            int theTrackRating)
        {
            using (SQLiteConnection theConnection = new SQLiteConnection(DatabaseLayer.ConnectionString))
            {
                try
                {
                    theConnection.Open();

                    using (SQLiteCommand theCommand = theConnection.CreateCommand())
                    {
                        theCommand.CommandText =
                            "UPDATE [Tracks] " +
                            "SET [Rating] = ? " +
                            "WHERE [Checksum] = ?";

                        SQLiteParameter theRatingParameter = theCommand.CreateParameter();
                        theCommand.Parameters.Add(theRatingParameter);
                        SQLiteParameter theChecksumParameter = theCommand.CreateParameter();
                        theCommand.Parameters.Add(theChecksumParameter);

                        theRatingParameter.Value =
                            theTrackRating;
                        theChecksumParameter.Value =
                            theChecksum;

                        theCommand.ExecuteNonQuery();
                    }
                }
                finally
                {
                    theConnection.Close();
                }
            }
        }
        #endregion
    }
}
