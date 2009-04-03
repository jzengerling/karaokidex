using System;
using System.Windows.Forms;
using System.IO;
using Karaokidex.Views;
using System.Drawing;
using System.Threading;

namespace Karaokidex.ApplicationControllers
{
    public partial class Controller
    {
        #region Members
        private CreateDatabaseView _CreateDatabaseView;
        #endregion

        #region Methods
        private void CreateDatabaseView_Show()
        {
            // Instantiate an instance
            this._CreateDatabaseView = new CreateDatabaseView();

            this._CreateDatabaseView.buttonSourceDirectory.Click += 
                new EventHandler(CreateDatabaseView_buttonSourceDirectory_Click);
            this._CreateDatabaseView.buttonTargetFile.Click +=
                new EventHandler(CreateDatabaseView_buttonTargetFile_Click);
            this._CreateDatabaseView.buttonOK.Click +=
                new EventHandler(CreateDatabaseView_buttonOK_Click);
            this._CreateDatabaseView.buttonCancel.Click +=
                new EventHandler(CreateDatabaseView_buttonCancel_Click);

            // Show the form
            this._CreateDatabaseView.ShowDialog(this._MainView);
        }

        #region Event Handlers
        private void CreateDatabaseView_buttonSourceDirectory_Click(
            object sender, 
            EventArgs e)
        {
            Button theSourceDirectoryButton =
                sender as Button;
            CreateDatabaseView theParentView =
                theSourceDirectoryButton.FindForm() as CreateDatabaseView;

            switch (theParentView.FolderBrowserDialog.ShowDialog())
            {
                case DialogResult.Cancel:
                    return;
            }

            theParentView.textboxSourceDirectory.Text =
                theParentView.FolderBrowserDialog.SelectedPath;

            Controller.ToggleOKButton(theParentView);
        }

        private void CreateDatabaseView_buttonTargetFile_Click(
            object sender,
            EventArgs e)
        {
            Button theTargetFileButton =
                sender as Button;
            CreateDatabaseView theParentView =
                theTargetFileButton.FindForm() as CreateDatabaseView;

            switch (theParentView.SaveFileDialog.ShowDialog())
            {
                case DialogResult.Cancel:
                    return;
            }

            theParentView.textboxTargetFile.Text =
                theParentView.SaveFileDialog.FileName;

            Controller.ToggleOKButton(theParentView);
        }

        private void CreateDatabaseView_buttonOK_Click(
            object sender, 
            EventArgs e)
        {
            Button theOKButton =
                sender as Button;
            CreateDatabaseView theParentView =
                theOKButton.FindForm() as CreateDatabaseView;

            theParentView.DisableView();

            FileInfo theTargetFileInfo =
                new FileInfo(theParentView.textboxTargetFile.Text);

            if (theTargetFileInfo.Exists)
            {
                switch (MessageBox.Show(
                    theParentView,
                    "A database file exists with this filename\n\n" +
                        "Do you want to overwrite it?",
                    theParentView.Text,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button2))
                {
                    case DialogResult.No:
                        Application.DoEvents();
                        return;
                }

                theTargetFileInfo.Delete();
                Application.DoEvents();
            }

            // Create database
            DatabaseLayer.CreateDatabase(
                new FileInfo(theParentView.textboxTargetFile.Text));

            CreateDatabaseAgent theAgent = new CreateDatabaseAgent(
                new DirectoryInfo(theParentView.textboxSourceDirectory.Text));
            
            theAgent.Inserting += 
                new EventHandler(CreateDatabaseAgent_Inserting);
            theAgent.Completed += 
                new EventHandler(CreateDatabaseAgent_Completed);

            Thread thisThread = 
                new Thread(new ThreadStart(theAgent.Start));

            thisThread.Start();
        }

        private void CreateDatabaseView_buttonCancel_Click(
            object sender, 
            EventArgs e)
        {
            Button theCancelButton =
                sender as Button;
            CreateDatabaseView theParentView =
                theCancelButton.FindForm() as CreateDatabaseView;

            theParentView.Close();
        }
        #endregion

        #region Private Helpers
        public void OnCreateDatabaseAgentInserting(
            DirectoryInfo theDirectoryInfo)
        {
            // InvokeRequired compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this._MainView.InvokeRequired)
            {
                this._MainView.Invoke(
                    new CreateDatabaseAgentInsertingHandler(
                        this.OnCreateDatabaseAgentInserting),
                    theDirectoryInfo);
            }
            else
            {
                this._CreateDatabaseView.Cursor = Cursors.WaitCursor;

                string theDirectoryFullName = 
                    theDirectoryInfo.FullName.Replace(
                        this._CreateDatabaseView.textboxSourceDirectory.Text, 
                        String.Empty);

                TextRenderer.MeasureText(
                    theDirectoryFullName, 
                    this._CreateDatabaseView.labelProgressCaption.Font, 
                    new Size(
                            this._CreateDatabaseView.labelProgressCaption.Width, 
                            this._CreateDatabaseView.labelProgressCaption.Height), 
                    TextFormatFlags.ModifyString | TextFormatFlags.PathEllipsis);

                this._CreateDatabaseView.labelProgressCaption.Text =
                    theDirectoryFullName;

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
                this._CreateDatabaseView.Cursor = Cursors.Default;

                this._CreateDatabaseView.labelProgressCaption.Text =
                    "Database created successfully";

                this._CreateDatabaseView.buttonCancel.Text = "&Close";

                this._CreateDatabaseView.buttonCancel.Enabled = true;

                Application.DoEvents();
            }
        }
        
        private static void ToggleOKButton(
            CreateDatabaseView theView)
        {
            theView.buttonOK.Enabled =
                !String.IsNullOrEmpty(theView.textboxSourceDirectory.Text) &&
                !String.IsNullOrEmpty(theView.textboxTargetFile.Text);
        }
        #endregion
        #endregion

        #region Delegates
        private delegate void CreateDatabaseAgentInsertingHandler(DirectoryInfo theDirectoryInfo);
        private delegate void CreateDatabaseAgentCompletedHandler();
        #endregion
    }
}
