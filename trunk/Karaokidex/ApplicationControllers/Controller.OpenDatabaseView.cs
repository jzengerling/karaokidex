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
        private void OpenDatabaseView_Show(
            DatabaseMode theMode)
        {
            // Instantiate an instance
            OpenDatabaseView theView = new OpenDatabaseView(theMode);

            theView.buttonSourceDirectory.Click +=
                new EventHandler(OpenDatabaseView_buttonSourceDirectory_Click);
            theView.buttonDatabaseFile.Click +=
                new EventHandler(OpenDatabaseView_buttonDatabaseFile_Click);
            theView.buttonOK.Click +=
                new EventHandler(OpenDatabaseView_buttonOK_Click);

            switch (theMode)
            {
                case DatabaseMode.OpenMusicDatabase:
                    theView.OpenFileDialog.Filter =
                        "Karakidex Music Databases|*.kmdb";
                    theView.OpenFileDialog.DefaultExt =
                        "kmdb";
                    break;
                default:
                    theView.OpenFileDialog.Filter =
                        "Karakidex Karaoke Databases|*.kkdb";
                    theView.OpenFileDialog.DefaultExt =
                        "kkdb";
                    break;
            }

            // Show the form
            theView.ShowDialog(this._MainView);
        }
        
        private void OpenDatabaseView_Show(
            DatabaseMode theMode,
            FileInfo theDatabaseFileInfo)
        {
            // Instantiate an instance
            OpenDatabaseView theView = new OpenDatabaseView(theMode);

            theView.buttonSourceDirectory.Click += 
                new EventHandler(OpenDatabaseView_buttonSourceDirectory_Click);
            theView.buttonDatabaseFile.Click +=
                new EventHandler(OpenDatabaseView_buttonDatabaseFile_Click);
            theView.buttonOK.Click +=
                new EventHandler(OpenDatabaseView_buttonOK_Click);

            switch (theView.Mode)
            {
                case DatabaseMode.OpenMusicDatabase:
                    theView.Text = "Open Music Database";

                    theView.OpenFileDialog.Filter =
                        "Karakidex Music Databases|*.kmdb";
                    theView.OpenFileDialog.DefaultExt =
                        "kmdb";
                    break;
                default:
                    theView.Text = "Open Karaoke Database";

                    theView.OpenFileDialog.Filter =
                        "Karakidex Karaoke Databases|*.kkdb";
                    theView.OpenFileDialog.DefaultExt =
                        "kkdb";
                    break;
            }

            if (theDatabaseFileInfo.Exists)
            {
                theView.textboxDatabaseFile.Text =
                    theDatabaseFileInfo.FullName;

                theView.textboxSourceDirectory.Text =
                    DatabaseLayer.GetSourceDirectory(
                        new FileInfo(theDatabaseFileInfo.FullName));

                Controller.ToggleOKButton(theView);
            }

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

            theParentView.textboxSourceDirectory.Text =
                DatabaseLayer.GetSourceDirectory(
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

            switch (theParentView.Mode)
            {
                case DatabaseMode.OpenMusicDatabase:
                    RegistryAgent.LastMusicDatabase =
                        theParentView.textboxDatabaseFile.Text;

                    DatabaseLayer.SetSourceDirectory(
                        new FileInfo(RegistryAgent.LastMusicDatabase),
                        new DirectoryInfo(theParentView.textboxSourceDirectory.Text));

                    this._CurrentMusicDatabaseFileInfo = new FileInfo(
                        theParentView.textboxDatabaseFile.Text);

                    this.OpenDatabase();
                    break;
                default:
                    RegistryAgent.LastKaraokeDatabase =
                        theParentView.textboxDatabaseFile.Text;

                    DatabaseLayer.SetSourceDirectory(
                        new FileInfo(RegistryAgent.LastKaraokeDatabase),
                        new DirectoryInfo(theParentView.textboxSourceDirectory.Text));

                    this._CurrentKaraokeDatabaseFileInfo = new FileInfo(
                        theParentView.textboxDatabaseFile.Text);

                    this.OpenDatabase();
                    break;
            }

            this._MainView.buttonSearch.Enabled = true;

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
