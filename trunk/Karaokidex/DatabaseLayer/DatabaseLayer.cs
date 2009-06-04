using System;
using System.Data.SQLite;
using System.Globalization;
using System.IO;
using System.Text;
using System.Data;
using Karaokidex.Enumerators;

namespace Karaokidex
{
    public static partial class DatabaseLayer
    {
        #region Methods
        public static string ToConnectionString(
            FileInfo theDatabaseFileInfo)
        {
            return String.Format(
                CultureInfo.CurrentCulture,
                "Data Source={0}; UTF8Encoding=True; Version=3; Pooling=True",
                theDatabaseFileInfo.FullName);
        }

        public static int GetNumberOfTracksInDatabase(
            FileInfo theDatabaseFileInfo) 
        {
            string theConnectionString = String.Format(
                CultureInfo.CurrentCulture,
                "Data Source={0}; UTF8Encoding=True; Version=3; Pooling=True",
                theDatabaseFileInfo.FullName);

            if (!String.IsNullOrEmpty(theConnectionString))
            {
                using (SQLiteConnection theConnection = new SQLiteConnection(theConnectionString))
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

        public static string GetSourceDirectory(
            FileInfo theDatabaseFileInfo)
        {
            string theConnectionString = String.Format(
                CultureInfo.CurrentCulture,
                "Data Source={0}; UTF8Encoding=True; Version=3; Pooling=True",
                theDatabaseFileInfo.FullName);

            using (SQLiteConnection theConnection = new SQLiteConnection(theConnectionString))
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
                catch
                {
                    return String.Empty;
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
            string theConnectionString = String.Format(
                CultureInfo.CurrentCulture,
                "Data Source={0}; UTF8Encoding=True; Version=3; Pooling=True",
                theDatabaseFileInfo.FullName);

            using (SQLiteConnection theConnection = new SQLiteConnection(theConnectionString))
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
        #endregion
    }
}
