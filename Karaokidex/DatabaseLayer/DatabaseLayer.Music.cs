﻿using System;
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
        public static void CreateMusicDatabase(
            FileInfo theDatabaseFileInfo)
        {
            SQLiteConnection.CreateFile(theDatabaseFileInfo.FullName);

            using (SQLiteConnection theConnection = new SQLiteConnection(
                DatabaseLayer.ToConnectionString(theDatabaseFileInfo)))
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
                        theCommandText.Append("[Extension] [text])");

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

        public static DataTable SearchMusicDatabase(
            FileInfo theDatabaseFileInfo,
            string theCriteria)
        {
            using (DataSet theDataSet = new DataSet())
            {
                using (SQLiteConnection theConnection = new SQLiteConnection(
                    DatabaseLayer.ToConnectionString(theDatabaseFileInfo)))
                {
                    try
                    {
                        theConnection.Open();

                        using (SQLiteCommand theCommand = theConnection.CreateCommand())
                        {
                            StringBuilder theCommandBuilder = new StringBuilder(
                                "SELECT [ID], [Path], [Details], [Extension], 0, " +
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
                                theCommandBuilder.Append("([Details] LIKE ? OR [Path] LIKE ?)");

                                SQLiteParameter thisCriteriaParameter = theCommand.CreateParameter();
                                theCommand.Parameters.Add(thisCriteriaParameter);
                                theCommand.Parameters.Add(thisCriteriaParameter);

                                thisCriteriaParameter.Value = String.Format(
                                    CultureInfo.CurrentCulture,
                                    "%{0}%",
                                    thisCriteria.ToString());

                                IsFirstParameter = false;
                            }

                            theCommandBuilder.Append(" ORDER BY [Path], [Details]");

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
        #endregion
    }
}
