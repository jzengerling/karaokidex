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
        private Thread _Thread;
        #endregion

        #region Methods
        public void CreateDatabaseAgentView_ShowForKaraoke(
            CreateDatabaseView theCallingView,
            DirectoryInfo theSourceDirectoryInfo,
            FileInfo theTargetFileInfo)
        {
            CreateDatabaseAgentView theView = 
                new CreateDatabaseAgentView(
                    theSourceDirectoryInfo,
                    theTargetFileInfo);

            theView.FormClosing += 
                new FormClosingEventHandler(CreateDatabaseAgentView_FormClosing);

            CreateKaraokeDatabaseAgent theAgent = 
                new CreateKaraokeDatabaseAgent(
                    theView,
                    theTargetFileInfo,
                    theSourceDirectoryInfo);

            theAgent.Inserting +=
                new EventHandler(CreateDatabaseAgent_Inserting);
            theAgent.Updating +=
                new EventHandler(CreateDatabaseAgent_Updating);
            theAgent.Completed +=
                new EventHandler(CreateDatabaseAgent_Completed);

            RegistryAgent.LastKaraokeDatabase =
                theTargetFileInfo.FullName;

            this._CurrentKaraokeDatabaseFileInfo =
                new FileInfo(theTargetFileInfo.FullName);

            this._Thread = new Thread(
                new ThreadStart(theAgent.Start));

            this._Thread.Start();

            theView.ShowDialog(
                theCallingView);

            theCallingView.Close();

            this.OpenDatabase();
        }

        public void CreateDatabaseAgentView_ShowForMusic(
            CreateDatabaseView theCallingView,
            DirectoryInfo theSourceDirectoryInfo,
            FileInfo theTargetFileInfo)
        {
            CreateDatabaseAgentView theView = 
                new CreateDatabaseAgentView(
                    theSourceDirectoryInfo,
                    theTargetFileInfo);

            theView.FormClosing +=
                new FormClosingEventHandler(CreateDatabaseAgentView_FormClosing);

            CreateMusicDatabaseAgent theAgent =
                new CreateMusicDatabaseAgent(
                    theView,
                    theTargetFileInfo,
                    theSourceDirectoryInfo);

            theAgent.Inserting +=
                new EventHandler(CreateDatabaseAgent_Inserting);
            theAgent.Updating +=
                new EventHandler(CreateDatabaseAgent_Updating);
            theAgent.Completed +=
                new EventHandler(CreateDatabaseAgent_Completed);

            RegistryAgent.LastMusicDatabase =
                theTargetFileInfo.FullName;

            this._CurrentMusicDatabaseFileInfo =
                new FileInfo(theTargetFileInfo.FullName);

            this._Thread = new Thread(
                new ThreadStart(theAgent.Start));

            this._Thread.Start();

            theView.ShowDialog(
                theCallingView);

            theCallingView.Close();

            this.OpenDatabase();
        }

        #region Event Handlers
        private void CreateDatabaseAgentView_FormClosing(
            object sender, 
            FormClosingEventArgs e)
        {
            try { this._Thread.Abort(); }
            catch (ThreadAbortException) { }
        }
        #endregion

        #region Private Helpers
        public void OnCreateDatabaseAgentInserting(
            CreateDatabaseAgentView theView,
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
                    theView,
                    theFileInfo);
            }
            else
            {
                theView.Cursor = 
                    Cursors.WaitCursor;

                string theCurrentDirectory = 
                    theFileInfo.DirectoryName.Replace(
                        theView.SourceDirectoryInfo.FullName,
                        String.Empty);

                TextRenderer.MeasureText(
                    theCurrentDirectory,
                    theView.labelCurrentDirectory.Font,
                    new Size(
                        theView.labelCurrentDirectory.Width,
                        theView.labelCurrentDirectory.Height),
                    TextFormatFlags.ModifyString | TextFormatFlags.PathEllipsis);

                theView.labelCurrentDirectory.Text =
                    theCurrentDirectory;

                string theCurrentFile =
                    "Inserting " + theFileInfo.Name;

                TextRenderer.MeasureText(
                    theCurrentFile,
                    theView.labelCurrentFile.Font,
                    new Size(
                        theView.labelCurrentFile.Width,
                        theView.labelCurrentFile.Height),
                    TextFormatFlags.ModifyString | TextFormatFlags.PathEllipsis);

                theView.labelCurrentFile.Text =
                    theCurrentFile; 
                
                Application.DoEvents();
            }
        }

        public void OnCreateDatabaseAgentUpdating(
            CreateDatabaseAgentView theView,
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
                    theView,
                    theFileInfo);
            }
            else
            {
                theView.Cursor =
                    Cursors.WaitCursor;

                string theCurrentDirectory = 
                    theFileInfo.DirectoryName.Replace(
                        theView.SourceDirectoryInfo.FullName,
                        String.Empty);

                TextRenderer.MeasureText(
                    theCurrentDirectory,
                    theView.labelCurrentDirectory.Font,
                    new Size(
                        theView.labelCurrentDirectory.Width,
                        theView.labelCurrentDirectory.Height),
                    TextFormatFlags.ModifyString | TextFormatFlags.PathEllipsis);

                theView.labelCurrentDirectory.Text =
                    theCurrentDirectory;

                string theCurrentFile =
                    "Updating " + theFileInfo.Name;

                TextRenderer.MeasureText(
                    theCurrentFile,
                    theView.labelCurrentFile.Font,
                    new Size(
                            theView.labelCurrentFile.Width,
                            theView.labelCurrentFile.Height),
                    TextFormatFlags.ModifyString | TextFormatFlags.PathEllipsis);

                theView.labelCurrentFile.Text =
                    theCurrentFile;

                Application.DoEvents();
            }
        }

        public void OnCreateDatabaseAgentCompleted(
            CreateDatabaseAgentView theView)
        {
            // InvokeRequired compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this._MainView.InvokeRequired)
            {
                this._MainView.Invoke(
                    new CreateDatabaseAgentCompletedHandler(
                        this.OnCreateDatabaseAgentCompleted),
                    theView);
            }
            else
            {
                theView.Close();
            }
        }
        #endregion
        #endregion

        #region Delegates
        private delegate void CreateDatabaseAgentInsertingHandler(
            CreateDatabaseAgentView theView, 
            FileInfo theFileInfo);
        private delegate void CreateDatabaseAgentUpdatingHandler(
            CreateDatabaseAgentView theView,
            FileInfo theFileInfo);
        private delegate void CreateDatabaseAgentCompletedHandler(
            CreateDatabaseAgentView theView);
        #endregion
    }
}
