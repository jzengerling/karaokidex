using System;
using System.Windows.Forms;
using System.IO;
using Karaokidex.Views;
using System.Drawing;
using System.Threading;
using Karaokidex.Enumerators;

namespace Karaokidex.ApplicationControllers
{
    public partial class Controller
    {
        #region Members
        private CreateDatabaseAgentView _CreateDatabaseAgentView;
        #endregion

        #region Methods
        public void CreateDatabaseAgentView_Show(
            CreateDatabaseView theCallingView,
            DirectoryInfo theSourceDirectoryInfo,
            FileInfo theTargetFileInfo)
        {
            this._CreateDatabaseAgentView = 
                new CreateDatabaseAgentView(
                    theSourceDirectoryInfo,
                    theTargetFileInfo);

            CreateDatabaseAgent theAgent = 
                new CreateDatabaseAgent(theSourceDirectoryInfo);

            theAgent.Inserting +=
                new EventHandler(CreateDatabaseAgent_Inserting);
            theAgent.Updating +=
                new EventHandler(CreateDatabaseAgent_Updating);
            theAgent.Completed +=
                new EventHandler(CreateDatabaseAgent_Completed);

            switch (theCallingView.Mode)
            {
                case DatabaseMode.CreateMusic:
                case DatabaseMode.RefreshMusic:
                    RegistryAgent.LastMusicDatabase = 
                        theTargetFileInfo.FullName;
                    break;
                default:
                    RegistryAgent.LastKaraokeDatabase =
                        theTargetFileInfo.FullName;
                    break;
            }

            Thread thisThread = new Thread(
                new ThreadStart(theAgent.Start));

            thisThread.Start();

            this._CreateDatabaseAgentView.ShowDialog(
                theCallingView);

            theCallingView.Close();

            this.OpenDatabase();
        }

        #region Private Helpers
        public void OnCreateDatabaseAgentInserting(
            FileInfo theFileInfo)
        {
            // InvokeRequired compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this._MainView.InvokeRequired)
            {
                this._MainView.Invoke(
                    new CreateDatabaseAgentInsertingHandler(
                        this.OnCreateDatabaseAgentInserting),
                    theFileInfo);
            }
            else
            {
                this._CreateDatabaseAgentView.Cursor = 
                    Cursors.WaitCursor;

                string theCurrentDirectory = 
                    theFileInfo.DirectoryName.Replace(
                        this._CreateDatabaseAgentView.SourceDirectoryInfo.FullName,
                        String.Empty);

                TextRenderer.MeasureText(
                    theCurrentDirectory,
                    this._CreateDatabaseAgentView.labelCurrentDirectory.Font,
                    new Size(
                            this._CreateDatabaseAgentView.labelCurrentDirectory.Width,
                            this._CreateDatabaseAgentView.labelCurrentDirectory.Height),
                    TextFormatFlags.ModifyString | TextFormatFlags.PathEllipsis);

                this._CreateDatabaseAgentView.labelCurrentDirectory.Text =
                    theCurrentDirectory;

                string theCurrentFile =
                    "Inserting " + theFileInfo.Name;

                TextRenderer.MeasureText(
                    theCurrentFile,
                    this._CreateDatabaseAgentView.labelCurrentFile.Font,
                    new Size(
                            this._CreateDatabaseAgentView.labelCurrentFile.Width,
                            this._CreateDatabaseAgentView.labelCurrentFile.Height),
                    TextFormatFlags.ModifyString | TextFormatFlags.PathEllipsis);

                this._CreateDatabaseAgentView.labelCurrentFile.Text =
                    theCurrentFile; 
                
                Application.DoEvents();
            }
        }

        public void OnCreateDatabaseAgentUpdating(
            FileInfo theFileInfo)
        {
            // InvokeRequired compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this._MainView.InvokeRequired)
            {
                this._MainView.Invoke(
                    new CreateDatabaseAgentUpdatingHandler(
                        this.OnCreateDatabaseAgentUpdating),
                    theFileInfo);
            }
            else
            {
                this._CreateDatabaseAgentView.Cursor =
                    Cursors.WaitCursor;

                string theCurrentDirectory = 
                    theFileInfo.DirectoryName.Replace(
                        this._CreateDatabaseAgentView.SourceDirectoryInfo.FullName,
                        String.Empty);

                TextRenderer.MeasureText(
                    theCurrentDirectory,
                    this._CreateDatabaseAgentView.labelCurrentDirectory.Font,
                    new Size(
                            this._CreateDatabaseAgentView.labelCurrentDirectory.Width,
                            this._CreateDatabaseAgentView.labelCurrentDirectory.Height),
                    TextFormatFlags.ModifyString | TextFormatFlags.PathEllipsis);

                this._CreateDatabaseAgentView.labelCurrentDirectory.Text =
                    theCurrentDirectory;

                string theCurrentFile =
                    "Updating " + theFileInfo.Name;

                TextRenderer.MeasureText(
                    theCurrentFile,
                    this._CreateDatabaseAgentView.labelCurrentFile.Font,
                    new Size(
                            this._CreateDatabaseAgentView.labelCurrentFile.Width,
                            this._CreateDatabaseAgentView.labelCurrentFile.Height),
                    TextFormatFlags.ModifyString | TextFormatFlags.PathEllipsis);

                this._CreateDatabaseAgentView.labelCurrentFile.Text =
                    theCurrentFile;

                Application.DoEvents();
            }
        }

        public void OnCreateDatabaseAgentCompleted()
        {
            // InvokeRequired compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this._MainView.InvokeRequired)
            {
                this._MainView.Invoke(
                    new CreateDatabaseAgentCompletedHandler(
                        this.OnCreateDatabaseAgentCompleted));
            }
            else
            {
                this._CreateDatabaseAgentView.Close();
            }
        }
        #endregion
        #endregion

        #region Delegates
        private delegate void CreateDatabaseAgentInsertingHandler(FileInfo theFileInfo);
        private delegate void CreateDatabaseAgentUpdatingHandler(FileInfo theFileInfo);
        private delegate void CreateDatabaseAgentCompletedHandler();
        #endregion
    }
}
