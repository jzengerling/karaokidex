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
        #region Methods
        private void OpenDatabaseView_Show()
        {
            // Instantiate an instance
            OpenDatabaseView theView = new OpenDatabaseView();

            theView.buttonSourceDirectory.Click +=
                new EventHandler(OpenDatabaseView_buttonSourceDirectory_Click);
            theView.buttonDatabaseFile.Click +=
                new EventHandler(OpenDatabaseView_buttonDatabaseFile_Click);
            theView.buttonOK.Click +=
                new EventHandler(OpenDatabaseView_buttonOK_Click);
            theView.buttonCancel.Click +=
                new EventHandler(OpenDatabaseView_buttonCancel_Click);

            // Show the form
            theView.ShowDialog(this._MainView);
        }
        
        private void OpenDatabaseView_Show(
            FileInfo theDatabaseFileInfo)
        {
            // Instantiate an instance
            OpenDatabaseView theView = new OpenDatabaseView();

            theView.buttonSourceDirectory.Click += 
                new EventHandler(OpenDatabaseView_buttonSourceDirectory_Click);
            theView.buttonDatabaseFile.Click +=
                new EventHandler(OpenDatabaseView_buttonDatabaseFile_Click);
            theView.buttonOK.Click +=
                new EventHandler(OpenDatabaseView_buttonOK_Click);
            theView.buttonCancel.Click +=
                new EventHandler(OpenDatabaseView_buttonCancel_Click);

            theView.textboxDatabaseFile.Text =
                theDatabaseFileInfo.FullName;

            theView.textboxSourceDirectory.Text = DatabaseLayer.GetSourceDirectory(
                new FileInfo(theDatabaseFileInfo.FullName));

            Controller.ToggleOKButton(theView);

            // Show the form
            theView.ShowDialog(this._MainView);
        }

        #region Event Handlers
        private void OpenDatabaseView_buttonDatabaseFile_Click(
            object sender,
            EventArgs e)
        {
            Button theDatabaseFileButton =
                sender as Button;
            OpenDatabaseView theParentView =
                theDatabaseFileButton.FindForm() as OpenDatabaseView;

            switch (theParentView.OpenFileDialog.ShowDialog())
            {
                case DialogResult.Cancel:
                    return;
            }

            theParentView.textboxDatabaseFile.Text =
                theParentView.OpenFileDialog.FileName;

            theParentView.textboxSourceDirectory.Text = DatabaseLayer.GetSourceDirectory(
                new FileInfo(theParentView.OpenFileDialog.FileName));

            Controller.ToggleOKButton(theParentView);
        }
        
        private void OpenDatabaseView_buttonSourceDirectory_Click(
            object sender, 
            EventArgs e)
        {
            Button theSourceDirectoryButton =
                sender as Button;
            OpenDatabaseView theParentView =
                theSourceDirectoryButton.FindForm() as OpenDatabaseView;

            theParentView.FolderBrowserDialog.SelectedPath =
                theParentView.textboxSourceDirectory.Text;

            switch (theParentView.FolderBrowserDialog.ShowDialog())
            {
                case DialogResult.Cancel:
                    return;
            }

            theParentView.textboxSourceDirectory.Text =
                theParentView.FolderBrowserDialog.SelectedPath;

            Controller.ToggleOKButton(theParentView);
        }

        private void OpenDatabaseView_buttonOK_Click(
            object sender, 
            EventArgs e)
        {
            Button theOKButton =
                sender as Button;
            OpenDatabaseView theParentView =
                theOKButton.FindForm() as OpenDatabaseView;

            RegistryAgent.LastDatabase =
                theParentView.textboxDatabaseFile.Text;

            DatabaseLayer.SetSourceDirectory(
                new FileInfo(RegistryAgent.LastDatabase),
                new DirectoryInfo(theParentView.textboxSourceDirectory.Text));

            this.OpenDatabase();

            this._MainView.buttonSearch.Enabled = true;

            theParentView.Close();
        }

        private void OpenDatabaseView_buttonCancel_Click(
            object sender, 
            EventArgs e)
        {
            Button theCancelButton =
                sender as Button;
            OpenDatabaseView theParentView =
                theCancelButton.FindForm() as OpenDatabaseView;

            theParentView.Close();
        }
        #endregion

        #region Private Helpers
        private static void ToggleOKButton(
            OpenDatabaseView theView)
        {
            theView.buttonOK.Enabled =
                !String.IsNullOrEmpty(theView.textboxSourceDirectory.Text) &&
                !String.IsNullOrEmpty(theView.textboxDatabaseFile.Text);
        }
        #endregion
        #endregion
    }
}
