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
        public static void CreateKaraokeDatabase(
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
        
        public static DataTable SearchKaraokeDatabase(
            FileInfo theDatabaseFileInfo,
            string theCriteria,
            bool ShowOnlyRatedTracks)
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

                            if (ShowOnlyRatedTracks)
                            {
                                theCommandBuilder.Append(" AND [Rating] > 0");
                            }
                            else
                            {
                                theCommandBuilder.Append(" AND [Rating] > -1");
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

        public static DataTable ListValidTracks(
            FileInfo theDatabaseFileInfo)
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
                                "SELECT [Path] || '\\' || [Details] || [Extension] AS [FullPath] ");
                            theCommandBuilder.Append("FROM [Tracks] ");
                            theCommandBuilder.Append("WHERE [Rating] >= 0 ");
                            theCommandBuilder.Append("ORDER BY [Path], [Details]");

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
        
        public static DataTable ListInvalidTracks(
            FileInfo theDatabaseFileInfo)
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
                                "SELECT [ID], [Path], [Details], [Extension], [Rating], " +
                                    "[Path] || '\\' || [Details] || [Extension] AS [FullPath] ");
                            theCommandBuilder.Append("FROM [Tracks] ");
                            theCommandBuilder.Append("WHERE [Rating] = -1 ");
                            theCommandBuilder.Append("ORDER BY [Path], [Details]");

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
            FileInfo theDatabaseFileInfo,
            long theTrackID,
            TrackRating theTrackRating)
        {
            using (SQLiteConnection theConnection = new SQLiteConnection(
                DatabaseLayer.ToConnectionString(theDatabaseFileInfo)))
            {
                try
                {
                    theConnection.Open();

                    using (SQLiteCommand theCommand = theConnection.CreateCommand())
                    {
                        theCommand.CommandText =
                            "UPDATE [Tracks] " +
                            "SET [Rating] = ? " +
                            "WHERE [ID] = ?";

                        SQLiteParameter theRatingParameter = theCommand.CreateParameter();
                        theCommand.Parameters.Add(theRatingParameter);
                        SQLiteParameter theTrackIDParameter = theCommand.CreateParameter();
                        theCommand.Parameters.Add(theTrackIDParameter);

                        theRatingParameter.Value =
                            (int)theTrackRating;
                        theTrackIDParameter.Value =
                            theTrackID;

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
