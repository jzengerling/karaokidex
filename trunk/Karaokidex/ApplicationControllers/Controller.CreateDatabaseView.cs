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
            CreateDatabaseView theView = new CreateDatabaseView(theMode);

            theView.textboxSourceDirectory.Leave += 
                new EventHandler(CreateDatabaseView_textboxSourceDirectory_Leave);
            theView.buttonSourceDirectory.Click += 
                new EventHandler(CreateDatabaseView_buttonSourceDirectory_Click);
            theView.textboxTargetFile.Leave +=
                new EventHandler(CreateDatabaseView_textboxTargetFile_Leave);
            theView.buttonTargetFile.Click +=
                new EventHandler(CreateDatabaseView_buttonTargetFile_Click);
            theView.buttonOK.Click +=
                new EventHandler(CreateDatabaseView_buttonOK_Click);

            switch (theMode)
            {
                case DatabaseMode.CreateMusicDatabase:
                case DatabaseMode.RefreshMusicDatabase:
                    theView.SaveFileDialog.Filter =
                        "Karaokidex Music Databases (*.kmdb)|*.kmdb";
                    theView.SaveFileDialog.DefaultExt =
                        "kmdb";

                    if (!String.IsNullOrEmpty(RegistryAgent.LastMusicDatabase))
                    {
                        theView.textboxSourceDirectory.Text =
                            DatabaseLayer.GetSourceDirectory(
                                new FileInfo(RegistryAgent.LastMusicDatabase));

                        theView.textboxTargetFile.Text =
                            RegistryAgent.LastMusicDatabase;
                    }
                    break;
                default:
                    theView.SaveFileDialog.Filter =
                        "Karaokidex Karokie Databases (*.kkdb)|*.kkdb";
                    theView.SaveFileDialog.DefaultExt =
                        "kkdb";

                    if (!String.IsNullOrEmpty(RegistryAgent.LastKaraokeDatabase))
                    {
                        theView.textboxSourceDirectory.Text =
                            DatabaseLayer.GetSourceDirectory(
                                new FileInfo(RegistryAgent.LastKaraokeDatabase));

                        theView.textboxTargetFile.Text =
                            RegistryAgent.LastKaraokeDatabase;
                    }
                    break;
            }

            Controller.IsViewValid(theView);

            // Show the form
            theView.ShowDialog(this._MainView);
        }

        #region Event Handlers
        private void CreateDatabaseView_textboxSourceDirectory_Leave(
            object sender, 
            EventArgs e)
        {
            TextBox theSourceDirectoryTextBox =
                sender as TextBox;
            CreateDatabaseView theParentView =
                theSourceDirectoryTextBox.FindForm() as CreateDatabaseView;

            Controller.IsViewValid(theParentView);
        }

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

            Controller.IsViewValid(theParentView);
        }

        private void CreateDatabaseView_textboxTargetFile_Leave(
            object sender, 
            EventArgs e)
        {
            TextBox theTargetFileTextBox =
                sender as TextBox;
            CreateDatabaseView theParentView =
                theTargetFileTextBox.FindForm() as CreateDatabaseView;

            Controller.IsViewValid(theParentView);
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

            Controller.IsViewValid(theParentView);
        }

        private void CreateDatabaseView_buttonOK_Click(
            object sender, 
            EventArgs e)
        {
            Button theOKButton =
                sender as Button;
            CreateDatabaseView theParentView =
                theOKButton.FindForm() as CreateDatabaseView;

            DirectoryInfo theSourceDirectoryInfo =
                new DirectoryInfo(theParentView.textboxSourceDirectory.Text);

            if (!theSourceDirectoryInfo.Exists)
            {
                MessageBox.Show(
                    theParentView,
                    "The specified source directory does not exist",
                    theParentView.Text,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Stop,
                    MessageBoxDefaultButton.Button1);

                Application.DoEvents();

                theParentView.textboxSourceDirectory.Focus();
                return;
            }

            FileInfo theTargetFileInfo =
                new FileInfo(theParentView.textboxTargetFile.Text);
            
            theParentView.DisableView();

            switch (theParentView.Mode)
            {
                case DatabaseMode.CreateMusicDatabase:
                    DatabaseLayer.CreateMusicDatabase(
                        theTargetFileInfo);

                    this.CreateDatabaseAgentView_ShowForMusic(
                        theParentView,
                        theSourceDirectoryInfo,
                        theTargetFileInfo);
                    break;
                case DatabaseMode.RefreshMusicDatabase:
                    this.CreateDatabaseAgentView_ShowForMusic(
                        theParentView,
                        theSourceDirectoryInfo,
                        theTargetFileInfo);
                    break;
                case DatabaseMode.CreateKaraokeDatabase:
                    DatabaseLayer.CreateKaraokeDatabase(
                        theTargetFileInfo);

                    this.CreateDatabaseAgentView_ShowForKaraoke(
                        theParentView,
                        theSourceDirectoryInfo,
                        theTargetFileInfo);
                    break;
                default:
                    this.CreateDatabaseAgentView_ShowForKaraoke(
                        theParentView,
                        theSourceDirectoryInfo,
                        theTargetFileInfo);
                    break;
            }
        }
        #endregion

        #region Private Helpers
        private static void IsViewValid(
            CreateDatabaseView theView)
        {
            theView.buttonOK.Enabled = false;

            if (String.IsNullOrEmpty(theView.textboxSourceDirectory.Text) ||
                String.IsNullOrEmpty(theView.textboxTargetFile.Text))
            {
                return;
            }

            if (!File.Exists(theView.textboxTargetFile.Text))
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
