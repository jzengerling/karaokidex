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
        private void CreateDatabaseView_Show(
            DatabaseMode theMode)
        {
            // Instantiate an instance
            CreateDatabaseView theView = new CreateDatabaseView();

            theView.buttonSourceDirectory.Click += 
                new EventHandler(CreateDatabaseView_buttonSourceDirectory_Click);
            theView.buttonTargetFile.Click +=
                new EventHandler(CreateDatabaseView_buttonTargetFile_Click);
            theView.buttonOK.Click +=
                new EventHandler(CreateDatabaseView_buttonOK_Click);
            theView.buttonCancel.Click +=
                new EventHandler(CreateDatabaseView_buttonCancel_Click);

            switch (theMode)
            {
                case DatabaseMode.Refresh:
                    theView.textboxSourceDirectory.Text = 
                        DatabaseLayer.GetSourceDirectory(
                            new FileInfo(RegistryAgent.LastDatabase));
                    theView.textboxTargetFile.Text =
                        RegistryAgent.LastDatabase;

                    theView.Text = "Refresh Database";
                    break;
                default:
                    theView.Text = "Create a Database";
                    break;
            }

            Controller.ToggleOKButton(theView);

            // Show the form
            theView.ShowDialog(this._MainView);
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

            this.CreateDatabaseAgentView_Show(
                theParentView,
                new DirectoryInfo(theParentView.textboxSourceDirectory.Text),
                new FileInfo(theParentView.textboxTargetFile.Text));
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
        private static void ToggleOKButton(
            CreateDatabaseView theView)
        {
            theView.buttonOK.Enabled =
                !String.IsNullOrEmpty(theView.textboxSourceDirectory.Text) &&
                !String.IsNullOrEmpty(theView.textboxTargetFile.Text);
        }
        #endregion
        #endregion
    }
}
