using System;
using System.Text;
using System.Data.SQLite;
using System.Globalization;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;

namespace Karaokidex
{
    public class CreateDatabaseAgent
    {
        #region Members
        private DirectoryInfo _SourceDirectoryInfo;
        private DirectoryInfo _CurrentDirectoryInfo;
        #endregion

        #region Properties
        public DirectoryInfo CurrentDirectoryInfo
        {
            get { return this._CurrentDirectoryInfo; }
        }
        #endregion

        #region Methods
        public CreateDatabaseAgent(
            DirectoryInfo theDirectoryInfo)
        {
            this._SourceDirectoryInfo = theDirectoryInfo;
        }

        #region Private Helpers
        public void Start()
        {
            using (SQLiteConnection theConnection = 
                new SQLiteConnection(DatabaseLayer.ConnectionString))
            {
                try
                {
                    theConnection.Open();

                    using (SQLiteCommand theCommand = theConnection.CreateCommand())
                    {
                        theCommand.CommandText = 
                            "INSERT INTO [Settings] ([Key], [Value]) VALUES (?, ?)";

                        SQLiteParameter theKeyParameter = theCommand.CreateParameter();
                        theCommand.Parameters.Add(theKeyParameter);
                        SQLiteParameter theValueParameter = theCommand.CreateParameter();
                        theCommand.Parameters.Add(theValueParameter);

                        theKeyParameter.Value = "Source Directory";
                        theValueParameter.Value = this._SourceDirectoryInfo.ToString();

                        theCommand.ExecuteNonQuery();
                    } 
                    
                    using (SQLiteTransaction theTransaction = 
                        theConnection.BeginTransaction())
                    {
                        this.GenerateListing(
                            this._SourceDirectoryInfo,
                            theConnection,
                            this._SourceDirectoryInfo);

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
                            using (SQLiteCommand theCommand = theConnection.CreateCommand())
                            {
                                theCommand.CommandText = 
                                    "INSERT INTO [Tracks] ([Path], [Details], [Extension]) VALUES (?, ?, ?)";

                                SQLiteParameter thePathParameter = theCommand.CreateParameter();
                                theCommand.Parameters.Add(thePathParameter);
                                SQLiteParameter theDetailsParameter = theCommand.CreateParameter();
                                theCommand.Parameters.Add(theDetailsParameter);
                                SQLiteParameter theExtensionParameter = theCommand.CreateParameter();
                                theCommand.Parameters.Add(theExtensionParameter);

                                thePathParameter.Value = thisFileInfo.DirectoryName
                                    .Replace(thisSourceDirectoryInfo.FullName, String.Empty);
                                theDetailsParameter.Value = thisFileInfo.Name
                                    .Replace(thisFileInfo.Extension, String.Empty);
                                theExtensionParameter.Value = thisFileInfo.Extension;

                                theCommand.ExecuteNonQuery();
                            }

                            if (null != this.Inserting)
                            {
                                this.Inserting(this, new EventArgs());
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
        public event EventHandler Completed;
        #endregion
    }
}
