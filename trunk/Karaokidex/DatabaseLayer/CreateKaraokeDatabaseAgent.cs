using System;
using System.Data.SQLite;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;
using Karaokidex.Views;

namespace Karaokidex
{
    public class CreateKaraokeDatabaseAgent : ICreateDatabaseAgent
    {
        #region Members
        private CreateDatabaseAgentView _CallingView;
        private FileInfo _DatabaseInfo;
        private DirectoryInfo _SourceDirectoryInfo;
        private DirectoryInfo _CurrentDirectoryInfo;
        private FileInfo _CurrentFileInfo;
        #endregion

        #region Properties
        public CreateDatabaseAgentView CallingView
        {
            get { return this._CallingView; }
        }

        public DirectoryInfo CurrentDirectoryInfo
        {
            get { return this._CurrentDirectoryInfo; }
        }

        public FileInfo CurrentFileInfo
        {
            get { return this._CurrentFileInfo; }
        }
        #endregion

        #region Methods
        public CreateKaraokeDatabaseAgent(
            CreateDatabaseAgentView theCallingView,
            FileInfo theDatabaseInfo,
            DirectoryInfo theSourceDirectoryInfo)
        {
            this._CallingView = theCallingView;
            this._DatabaseInfo = theDatabaseInfo;
            this._SourceDirectoryInfo = theSourceDirectoryInfo;
        }

        #region Private Helpers
        public void Start()
        {
            using (SQLiteConnection theConnection = new SQLiteConnection(
                DatabaseLayer.ToConnectionString(this._DatabaseInfo)))
            {
                try
                {
                    theConnection.Open();

                    long theSettingID = 0;

                    using (SQLiteCommand theCommand = theConnection.CreateCommand())
                    {
                        theCommand.CommandText =
                            "SELECT [ID] " +
                            "FROM [Settings] " +
                            "WHERE [Key] = ?";

                        SQLiteParameter theKeyParameter = theCommand.CreateParameter();
                        theCommand.Parameters.Add(theKeyParameter);

                        theKeyParameter.Value = "Source Directory";

                        theSettingID = Convert.ToInt64(theCommand.ExecuteScalar());
                    }

                    using (SQLiteCommand theCommand = theConnection.CreateCommand())
                    {
                        if (theSettingID.Equals(0))
                        {
                            theCommand.CommandText =
                                "INSERT INTO [Settings] ([Key], [Value]) " +
                                "VALUES (?, ?)";

                            SQLiteParameter theKeyParameter = theCommand.CreateParameter();
                            theCommand.Parameters.Add(theKeyParameter);
                            SQLiteParameter theValueParameter = theCommand.CreateParameter();
                            theCommand.Parameters.Add(theValueParameter);

                            theKeyParameter.Value = "Source Directory";
                            theValueParameter.Value = this._SourceDirectoryInfo.ToString();
                        }
                        else
                        {
                            theCommand.CommandText =
                                "UPDATE [Settings] " +
                                "SET [Value] = ? " +
                                "WHERE [Key] = ?";

                            SQLiteParameter theValueParameter = theCommand.CreateParameter();
                            theCommand.Parameters.Add(theValueParameter);
                            SQLiteParameter theKeyParameter = theCommand.CreateParameter();
                            theCommand.Parameters.Add(theKeyParameter);

                            theKeyParameter.Value = "Source Directory";
                            theValueParameter.Value = this._SourceDirectoryInfo.ToString();
                        }

                        theCommand.ExecuteNonQuery();
                    }

                    using (SQLiteTransaction theTransaction = 
                        theConnection.BeginTransaction())
                    {
                        using (SQLiteCommand theCommand = theConnection.CreateCommand())
                        {
                            theCommand.CommandText =
                                "UPDATE [Tracks] " +
                                "SET [ToBeDeleted] = 1";

                            theCommand.ExecuteNonQuery();
                        }
                        
                        this.GenerateListing(
                            this._SourceDirectoryInfo,
                            theConnection,
                            this._SourceDirectoryInfo);

                        using (SQLiteCommand theCommand = theConnection.CreateCommand())
                        {
                            theCommand.CommandText =
                                "DELETE " +
                                "FROM [Tracks] " +
                                "WHERE [ToBeDeleted] = 1";

                            theCommand.ExecuteNonQuery();
                        }
                        
                        theTransaction.Commit();

                        if (null != this.Completed)
                        {
                            this.Completed(this, new EventArgs());
                        }
                    }
                }
                finally
                {
                    theConnection.Close();
                }
            }
        }

        private void GenerateListing(
            DirectoryInfo thisSourceDirectoryInfo,
            SQLiteConnection theConnection,
            DirectoryInfo thisDirectoryInfo)
        {
            try
            {
                DirectoryInfo[] theSubDirectories =
                    thisDirectoryInfo.GetDirectories();

                Array.Sort(
                    theSubDirectories,
                    0,
                    theSubDirectories.Length,
                    new DirectorySort());

                foreach (DirectoryInfo thisSubDirectoryInfo in
                    theSubDirectories)
                {
                    this.GenerateListing(
                        thisSourceDirectoryInfo,
                        theConnection,
                        thisSubDirectoryInfo);
                }

                this._CurrentDirectoryInfo = thisDirectoryInfo;

                if (!thisDirectoryInfo.GetFiles("*.cdg").Length.Equals(0) ||
                    !thisDirectoryInfo.GetFiles("*.zip").Length.Equals(0))
                {
                    FileInfo[] theFiles =
                        thisDirectoryInfo.GetFiles();

                    Array.Sort(
                        theFiles,
                        0,
                        theFiles.Length,
                        new FileSort());

                    foreach (FileInfo thisFileInfo in theFiles)
                    {
                        this._CurrentFileInfo = thisFileInfo;

                        bool theArchiveContainsCDG = false;

                        if (thisFileInfo.Extension.Contains("zip"))
                        {
                            using (ZipFile theArchive = new ZipFile(thisFileInfo.FullName))
                            {
                                theArchiveContainsCDG =
                                    !theArchive.FindEntry("*.cdg", true).Equals(0);
                            }
                        }

                        if (thisFileInfo.Extension.Contains("cdg") || theArchiveContainsCDG)
                        {
                            string thisChecksum = 
                                IOOperations.GetMD5HashFromFile(
                                    thisFileInfo.FullName);
                            long thisTrackID = 0;

                            using (SQLiteCommand theCommand = theConnection.CreateCommand())
                            {
                                theCommand.CommandText = 
                                    "SELECT [ID] " +
                                    "FROM [Tracks] " +
                                    "WHERE [Checksum] = ?";

                                SQLiteParameter theChecksumParameter = theCommand.CreateParameter();
                                theCommand.Parameters.Add(theChecksumParameter);

                                theChecksumParameter.Value = thisChecksum;

                                thisTrackID = Convert.ToInt64(theCommand.ExecuteScalar());
                            }

                            if (thisTrackID.Equals(0))
                            {
                                using (SQLiteCommand theCommand = theConnection.CreateCommand())
                                {
                                    theCommand.CommandText =
                                        "INSERT INTO [Tracks] ([Path], [Details], [Extension], [Checksum]) " +
                                        "VALUES (?, ?, ?, ?)";

                                    SQLiteParameter thePathParameter = theCommand.CreateParameter();
                                    theCommand.Parameters.Add(thePathParameter);
                                    SQLiteParameter theDetailsParameter = theCommand.CreateParameter();
                                    theCommand.Parameters.Add(theDetailsParameter);
                                    SQLiteParameter theExtensionParameter = theCommand.CreateParameter();
                                    theCommand.Parameters.Add(theExtensionParameter);
                                    SQLiteParameter theChecksumParameter = theCommand.CreateParameter();
                                    theCommand.Parameters.Add(theChecksumParameter);

                                    thePathParameter.Value = thisFileInfo.DirectoryName
                                        .Replace(thisSourceDirectoryInfo.FullName, String.Empty);
                                    theDetailsParameter.Value = thisFileInfo.Name
                                        .Replace(thisFileInfo.Extension, String.Empty);
                                    theExtensionParameter.Value =
                                        thisFileInfo.Extension;
                                    theChecksumParameter.Value =
                                        IOOperations.GetMD5HashFromFile(
                                            thisFileInfo.FullName);

                                    theCommand.ExecuteNonQuery();
                                }

                                if (null != this.Inserting)
                                {
                                    this.Inserting(this, new EventArgs());
                                }
                            }
                            else
                            {
                                using (SQLiteCommand theCommand = theConnection.CreateCommand())
                                {
                                    theCommand.CommandText =
                                        "UPDATE [Tracks] " +
                                        "SET [Path] = ?, " +
                                            "[Details] = ?, " +
                                            "[Extension] = ?, " +
                                            "[ToBeDeleted] = 0 " +
                                        "WHERE [ID] = ?";

                                    SQLiteParameter thePathParameter = theCommand.CreateParameter();
                                    theCommand.Parameters.Add(thePathParameter);
                                    SQLiteParameter theDetailsParameter = theCommand.CreateParameter();
                                    theCommand.Parameters.Add(theDetailsParameter);
                                    SQLiteParameter theExtensionParameter = theCommand.CreateParameter();
                                    theCommand.Parameters.Add(theExtensionParameter);
                                    SQLiteParameter theIDParameter = theCommand.CreateParameter();
                                    theCommand.Parameters.Add(theIDParameter);

                                    thePathParameter.Value = thisFileInfo.DirectoryName
                                        .Replace(thisSourceDirectoryInfo.FullName, String.Empty);
                                    theDetailsParameter.Value = thisFileInfo.Name
                                        .Replace(thisFileInfo.Extension, String.Empty);
                                    theExtensionParameter.Value =
                                        thisFileInfo.Extension;
                                    theIDParameter.Value = 
                                        thisTrackID;

                                    theCommand.ExecuteNonQuery();
                                }

                                if (null != this.Updating)
                                {
                                    this.Updating(this, new EventArgs());
                                }
                            }
                        }
                    }
                }
            }
            catch { }
        }
        #endregion
        #endregion

        #region Events
        public event EventHandler Inserting;
        public event EventHandler Updating;
        public event EventHandler Completed;
        #endregion
    }
}
