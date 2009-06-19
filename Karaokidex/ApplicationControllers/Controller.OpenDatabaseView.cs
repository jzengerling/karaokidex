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

            theView.textboxDatabaseFile.Leave += 
                new EventHandler(OpenDatabaseView_textboxDatabaseFile_Leave);
            theView.buttonDatabaseFile.Click +=
                new EventHandler(OpenDatabaseView_buttonDatabaseFile_Click);
            theView.textboxSourceDirectory.Leave += 
                new EventHandler(OpenDatabaseView_textboxSourceDirectory_Leave);
            theView.buttonSourceDirectory.Click +=
                new EventHandler(OpenDatabaseView_buttonSourceDirectory_Click);
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

            theView.textboxSourceDirectory.Leave +=
                new EventHandler(OpenDatabaseView_textboxSourceDirectory_Leave);
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

                Controller.IsViewValid(theView);
            }

            // Show the form
            theView.ShowDialog(this._MainView);
        }

        #region Event Handlers
        private void OpenDatabaseView_textboxDatabaseFile_Leave(
            object sender, 
            EventArgs e)
        {
            TextBox theDatabaseFileTextBox =
                sender as TextBox;
            OpenDatabaseView theParentView =
                theDatabaseFileTextBox.FindForm() as OpenDatabaseView;

            FileInfo theDatabaseFileInfo =
                new FileInfo(theDatabaseFileTextBox.Text);

            if (!theDatabaseFileInfo.Exists)
            {
                MessageBox.Show(
                    theParentView,
                    "The specified database file does not exist",
                    theParentView.Text,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Stop,
                    MessageBoxDefaultButton.Button1);

                Application.DoEvents();

                theDatabaseFileTextBox.Focus();
                return;
            }

            theParentView.textboxSourceDirectory.Text =
                DatabaseLayer.GetSourceDirectory(
                    new FileInfo(theParentView.OpenFileDialog.FileName));

            Controller.IsViewValid(theParentView);
        }

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

            Controller.IsViewValid(theParentView);
        }

        private void OpenDatabaseView_textboxSourceDirectory_Leave(
            object sender, 
            EventArgs e)
        {
            TextBox theSourceDirectoryTextBox =
                sender as TextBox;
            OpenDatabaseView theParentView =
                theSourceDirectoryTextBox.FindForm() as OpenDatabaseView;

            Controller.IsViewValid(theParentView);
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

            Controller.IsViewValid(theParentView);
        }

        private void OpenDatabaseView_buttonOK_Click(
            object sender, 
            EventArgs e)
        {
            Button theOKButton =
                sender as Button;
            OpenDatabaseView theParentView =
                theOKButton.FindForm() as OpenDatabaseView;

            FileInfo theDatabaseFileInfo =
                new FileInfo(theParentView.textboxDatabaseFile.Text);

            if (!theDatabaseFileInfo.Exists)
            {
                MessageBox.Show(
                    theParentView,
                    "The specified database file does not exist",
                    theParentView.Text,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Stop,
                    MessageBoxDefaultButton.Button1);

                Application.DoEvents();

                theParentView.textboxDatabaseFile.Focus();
                return;
            }

            DirectoryInfo theSourceDirectoryInfo =
                new DirectoryInfo(theParentView.textboxSourceDirectory.Text);

            if (!theSourceDirectoryInfo.Exists)
            {
                MessageBox.Show(
                    theParentView,
                    "The specified directory does not exist",
                    theParentView.Text,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Stop,
                    MessageBoxDefaultButton.Button1);

                Application.DoEvents();

                theParentView.textboxSourceDirectory.Focus();
                return;
            } 
            
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
        private static void IsViewValid(
            OpenDatabaseView theView)
        {
            theView.buttonOK.Enabled = false;

            if (String.IsNullOrEmpty(theView.textboxSourceDirectory.Text) ||
                String.IsNullOrEmpty(theView.textboxDatabaseFile.Text))
            {
                return;
            }

            if (!File.Exists(theView.textboxDatabaseFile.Text))
            {
                MessageBox.Show(
                    theView,
                    "The database file specified does not exist",
                    theView.Text,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Stop,
                    MessageBoxDefaultButton.Button1);

                Application.DoEvents();
                return;
            } 
            if (!Directory.Exists(theView.textboxSourceDirectory.Text))
            {
                MessageBox.Show(
                    theView,
                    "The source directory specified does not exist",
                    theView.Text,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Stop,
                    MessageBoxDefaultButton.Button1);

                Application.DoEvents();
                return;
            }

            theView.buttonOK.Enabled = true;
        }
        #endregion
        #endregion
    }
}
