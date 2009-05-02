using System;
using System.Windows.Forms;
using System.Globalization;
using System.IO;
using Karaokidex.Views;
using System.Diagnostics;
using System.Data;
using Karaokidex.Properties;
using System.Runtime.InteropServices;
using System.Text;
using Karaokidex.Enumerators;
using System.Drawing;

namespace Karaokidex.ApplicationControllers
{
    public partial class Controller
    {
        //[DllImport("user32.dll")]
        //public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        //[DllImport("user32.dll")]
        //public static extern int SetForegroundWindow(IntPtr hwnd);
 
        #region Members
        private MainView _MainView;
        //private bool _IsPaused = false;
        #endregion

        #region Methods
        private void MainView_Show()
        {
            // Instantiate an instance
            this._MainView = new MainView();

            this._MainView.buttonOpenDatabase.Click +=
                new EventHandler(MainView_buttonOpenDatabase_Click);
            this._MainView.buttonCreateDatabase.Click +=
                new EventHandler(MainView_buttonCreateDatabase_Click);
            this._MainView.buttonRefreshDatabase.Click += 
                new EventHandler(MainView_buttonRefreshDatabase_Click);
            this._MainView.buttonKaraFun.Click += 
                new EventHandler(MainView_buttonKaraFun_Click);
            this._MainView.buttonSearch.Click += 
                new EventHandler(MainView_buttonSearch_Click);
            this._MainView.buttonExit.Click += 
                new EventHandler(MainView_buttonExit_Click);
            this._MainView.gridResults.MouseUp += 
                new MouseEventHandler(MainView_gridResults_MouseUp);
            this._MainView.gridResults.DoubleClick += 
                new EventHandler(MainView_gridResults_DoubleClick);
            this._MainView.gridResults.KeyDown += 
                new KeyEventHandler(MainView_gridResults_KeyDown);
            this._MainView.gridResults.SelectionChanged +=
                new EventHandler(MainView_gridResults_SelectionChanged);
            this._MainView.menuitemEnqueueInKaraFun.Click += 
                new EventHandler(MainView_menuitemEnqueueInKaraFun_Click);
            this._MainView.menuitemPlayInKaraFun.Click += 
                new EventHandler(MainView_menuitemPlayInKaraFun_Click);
            this._MainView.menuitemEditTrackRating.Click += 
                new EventHandler(MainView_menuitemEditTrackRating_Click);
            this._MainView.buttonOpenContainingFolder.Click += 
                new EventHandler(MainView_buttonOpenContainingFolder_Click);

            this._AppContext.MainForm = this._MainView;

            this._MainView.Show();

            if (!String.IsNullOrEmpty(RegistryAgent.LastDatabase))
            {
                this.OpenDatabaseView_Show(
                    new FileInfo(RegistryAgent.LastDatabase));
            }

            if (RegistryAgent.IsKaraFunInstalled)
            {
                this._MainView.Text = "Karaokidex for KaraFun";
            }
            else
            {
                this._MainView.buttonKaraFun.ToolTipText = "Get KaraFun";
            }
        }

        #region Event Handlers
        private void MainView_buttonOpenDatabase_Click(
            object sender, 
            EventArgs e)
        {
            Application.DoEvents();

            if (!String.IsNullOrEmpty(RegistryAgent.LastDatabase))
            {
                this.OpenDatabaseView_Show(
                    new FileInfo(RegistryAgent.LastDatabase));
            }
            else
            {
                this.OpenDatabaseView_Show();
            }
        }

        private void MainView_buttonCreateDatabase_Click(
            object sender, 
            EventArgs e)
        {
            Application.DoEvents();

            this.CreateDatabaseView_Show(DatabaseMode.Create);
        }

        private void MainView_buttonRefreshDatabase_Click(
            object sender, 
            EventArgs e)
        {
            Application.DoEvents();

            this.CreateDatabaseView_Show(DatabaseMode.Refresh);
        }

        private void MainView_buttonKaraFun_Click(
            object sender, 
            EventArgs e)
        {
            Application.DoEvents();

            ToolStripButton theKaraFunButton =
                sender as ToolStripButton;

            switch (theKaraFunButton.ToolTipText)
            {
                case "Get KaraFun":
                    Process.Start("http://www.karafun.com/karaokeplayer/");
                    break;
                default:
                    Process.Start(RegistryAgent.KaraFunExecutablePath);
                    break;
            }
        }

        private void MainView_buttonSearch_Click(
            object sender, 
            EventArgs e)
        {
            Application.DoEvents();

            Button theSearchButton =
                sender as Button;
            MainView theParentView =
                theSearchButton.FindForm() as MainView;

            theParentView.buttonSearch.Enabled = false;
            theParentView.gridResults.Rows.Clear();

            theParentView.Cursor = 
                Cursors.WaitCursor;

            foreach (DataRow thisRow in DatabaseLayer.SearchDatabase(
                    theParentView.textboxCriteria.Text,
                    theParentView.checkboxShowOnlyRatedTracks.Checked)
                .Rows)
            {
                string thisExtension = Convert.ToString(
                    thisRow["Extension"],
                    CultureInfo.CurrentCulture);
                int thisRating = Convert.ToInt32(
                    thisRow["Rating"],
                    CultureInfo.CurrentCulture);

                Bitmap theExtensionImage = Resources.mp3g;
                switch (thisExtension)
                {
                    case ".zip":
                        theExtensionImage = Resources.mp3g_zipped;
                        break;
                    default:
                        theExtensionImage = Resources.mp3g;
                        break;
                }

                Bitmap theRatingImage = Resources.no_stars;
                switch (thisRating)
                {
                    case 1:
                        theRatingImage = Resources._1_star;
                        break;
                    case 2:
                        theRatingImage = Resources._2_stars;
                        break;
                    case 3:
                        theRatingImage = Resources._3_stars;
                        break;
                    case 4:
                        theRatingImage = Resources._4_stars;
                        break;
                    case 5:
                        theRatingImage = Resources._5_stars;
                        break;
                    default:
                        theRatingImage = Resources.no_stars;
                        break;
                }

                    theParentView.gridResults.Rows.Add(
                        Convert.ToInt64(thisRow["ID"], CultureInfo.CurrentCulture),
                        theExtensionImage,
                        Convert.ToString(thisRow["Details"], CultureInfo.CurrentCulture),
                        theRatingImage,
                        thisRating,
                        Convert.ToString(thisRow["Path"], CultureInfo.CurrentCulture),
                        Convert.ToString(thisRow["FullPath"], CultureInfo.CurrentCulture));

                Application.DoEvents();
            }
            
            theParentView.labelResults.Text = String.Format(
                CultureInfo.CurrentCulture,
                "{0:N0} results",
                theParentView.gridResults.Rows.Count);

            theParentView.buttonSearch.Enabled = true;

            if (!theParentView.gridResults.Rows.Count.Equals(0))
            {
                theParentView.gridResults.Focus();
            }

            theParentView.Cursor =
                Cursors.Default;
        }

        private void MainView_buttonExit_Click(
            object sender,
            EventArgs e)
        {
            Application.DoEvents();

            Button theExitButton =
                sender as Button;
            MainView theParentView =
                theExitButton.FindForm() as MainView;

            Application.Exit();
        }

        private void MainView_gridResults_MouseUp(
            object sender, 
            MouseEventArgs e)
        {
            Application.DoEvents();

            DataGridView theResultsGrid =
                sender as DataGridView;
            MainView theParentView =
                theResultsGrid.FindForm() as MainView;

            theParentView.menuitemEnqueueInKaraFun.Enabled =
                theParentView.menuitemPlayInKaraFun.Enabled =
                    RegistryAgent.IsKaraFunInstalled;

            if (!theResultsGrid.SelectedRows.Count.Equals(0))
            {
                FileInfo theTrackFileInfo = new FileInfo(
                    DatabaseLayer.GetSourceDirectory(new FileInfo(RegistryAgent.LastDatabase)) +
                    "\\" + theResultsGrid.SelectedRows[0].Cells["_columnFullPath"].Value);

                theParentView.menuitemEditTrackRating.Enabled =
                    theTrackFileInfo.Exists;
            }
        }

        private void MainView_gridResults_KeyDown(
            object sender, 
            KeyEventArgs e)
        {
            Application.DoEvents();

            if (e.KeyCode.Equals(Keys.Enter))
            {
                e.Handled = true;

                if (RegistryAgent.IsKaraFunInstalled)
                {
                    this.MainView_gridResults_DoubleClick(
                        sender, new EventArgs());
                }
            }
        }

        private void MainView_gridResults_DoubleClick(
            object sender, 
            EventArgs e)
        {
            Application.DoEvents();

            DataGridView theResultsGrid =
                sender as DataGridView;
            MainView theParentView =
                theResultsGrid.FindForm() as MainView;

            if (!theResultsGrid.SelectedRows.Count.Equals(0))
            {
                FileInfo theTrackFileInfo = new FileInfo(
                    DatabaseLayer.GetSourceDirectory(new FileInfo(RegistryAgent.LastDatabase)) + 
                    "\\" + theResultsGrid.SelectedRows[0].Cells["_columnFullPath"].Value);

                if (theTrackFileInfo.Exists)
                {
                    this._MainView.Cursor =
                        Cursors.WaitCursor;

                    string[] theCommand =
                        RegistryAgent.KaraFunEnqueueCommand.Replace(
                            "%1",
                            theTrackFileInfo.FullName)
                            .Split(new Char[] { '"' }, 3, StringSplitOptions.RemoveEmptyEntries);

                    ProcessStartInfo theInfo = new ProcessStartInfo();
                    theInfo.FileName = theCommand[0];
                    theInfo.Arguments = theCommand[1].Trim() + " \"" + theCommand[2].Trim() + '"';

                    Process theProcess = new Process();
                    theProcess.StartInfo = theInfo;

                    theProcess.Start();

                    this._MainView.Cursor =
                        Cursors.Default;
                }
                else
                {
                    MessageBox.Show(
                        theParentView,
                        String.Format(
                            CultureInfo.CurrentCulture,
                            "{0}\n\nThe selected track does not exist",
                            theTrackFileInfo.ToString()),
                            theParentView.Text,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1);

                    Application.DoEvents();
                }
            }
        }

        private void MainView_gridResults_SelectionChanged(
            object sender, 
            EventArgs e)
        {
            Application.DoEvents();

            DataGridView theResultsGrid =
                sender as DataGridView;
            MainView theParentView =
                theResultsGrid.FindForm() as MainView;

            if (!theResultsGrid.SelectedRows.Count.Equals(0))
            {
                theParentView.labelSelectedTrackPath.Text =
                    theResultsGrid.SelectedRows[0].Cells["_columnPath"].Value.ToString();

                theParentView.buttonOpenContainingFolder.Enabled =
                    !String.IsNullOrEmpty(theParentView.labelSelectedTrackPath.Text);
            }
        }

        private void MainView_menuitemEnqueueInKaraFun_Click(
            object sender, 
            EventArgs e)
        {
            Application.DoEvents();

            ToolStripMenuItem theOpenContainingFolder =
                sender as ToolStripMenuItem;
            ContextMenuStrip theContextMenuStrip =
                theOpenContainingFolder.Owner as ContextMenuStrip;
            MainView theParentView =
                theContextMenuStrip.SourceControl.FindForm() as MainView;

            this.MainView_gridResults_DoubleClick(
                theParentView.gridResults, new EventArgs());
        }

        private void MainView_menuitemPlayInKaraFun_Click(
            object sender, 
            EventArgs e)
        {
            Application.DoEvents();

            ToolStripMenuItem theOpenContainingFolder =
                sender as ToolStripMenuItem;
            ContextMenuStrip theContextMenuStrip =
                theOpenContainingFolder.Owner as ContextMenuStrip;
            MainView theParentView =
                theContextMenuStrip.SourceControl.FindForm() as MainView;

            if (!theParentView.gridResults.SelectedRows.Count.Equals(0))
            {
                FileInfo theTrackFileInfo = new FileInfo(
                    DatabaseLayer.GetSourceDirectory(new FileInfo(RegistryAgent.LastDatabase)) + 
                    "\\" + theParentView.gridResults.SelectedRows[0].Cells["_columnFullPath"].Value);

                if (theTrackFileInfo.Exists)
                {
                    this._MainView.Cursor =
                        Cursors.WaitCursor;

                    string[] theCommand =
                        RegistryAgent.KaraFunPlayCommand.Replace(
                            "%1",
                            theTrackFileInfo.ToString())
                            .Split(new Char[] { '"' }, 3, StringSplitOptions.RemoveEmptyEntries);

                    Process.Start(
                        theCommand[0],
                        theCommand[1].Trim() + " \"" + theCommand[2].Trim() + '"');

                    this._MainView.Cursor =
                        Cursors.Default;
                }
                else
                {
                    MessageBox.Show(
                        theParentView,
                        String.Format(
                            CultureInfo.CurrentCulture,
                            "{0}\n\nThe selected track does not exist",
                            theTrackFileInfo.ToString()),
                            theParentView.Text,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1);

                    Application.DoEvents();
                }
            }
        }

        private void MainView_menuitemEditTrackRating_Click(
            object sender, 
            EventArgs e)
        {
            Application.DoEvents();

            ToolStripMenuItem theOpenContainingFolder =
                sender as ToolStripMenuItem;
            ContextMenuStrip theContextMenuStrip =
                theOpenContainingFolder.Owner as ContextMenuStrip;
            MainView theParentView =
                theContextMenuStrip.SourceControl.FindForm() as MainView;

            if (!theParentView.gridResults.SelectedRows.Count.Equals(0))
            {
                FileInfo theTrackFileInfo = new FileInfo(
                    DatabaseLayer.GetSourceDirectory(new FileInfo(RegistryAgent.LastDatabase)) +
                    "\\" + theParentView.gridResults.SelectedRows[0].Cells["_columnFullPath"].Value);

                if (theTrackFileInfo.Exists)
                {
                    string theTrackChecksum =
                        CreateDatabaseAgent.GetMD5HashFromFile(
                            theTrackFileInfo.FullName);
                    int theTrackRating =
                        Convert.ToInt32(
                            theParentView.gridResults.SelectedRows[0].Cells["_columnRating"].Value,
                            CultureInfo.CurrentCulture);

                    this.TrackRatingView_Show(
                        theTrackChecksum,
                        theTrackRating);
                }
            }
        }

        private void MainView_buttonOpenContainingFolder_Click(
            object sender,
            EventArgs e)
        {
            Application.DoEvents();

            Button theOpenContainingFolderButton =
                sender as Button;
            MainView theParentView =
                theOpenContainingFolderButton.FindForm() as MainView;

            DirectoryInfo theTrackDirectoryInfo = new DirectoryInfo(
                DatabaseLayer.GetSourceDirectory(new FileInfo(RegistryAgent.LastDatabase)) +
                "\\" + theParentView.gridResults.SelectedRows[0].Cells["_columnPath"].Value);

            if (theTrackDirectoryInfo.Exists)
            {
                this._MainView.Cursor =
                    Cursors.WaitCursor;

                Process.Start(
                    "explorer.exe",
                    String.Format(
                        CultureInfo.CurrentCulture,
                        "/e,/root,{0}",
                        theTrackDirectoryInfo.FullName));

                this._MainView.Cursor =
                    Cursors.Default;
            }
            else
            {
                MessageBox.Show(
                    theParentView,
                    String.Format(
                        CultureInfo.CurrentCulture,
                        "{0}\n\nThe selected directory does not exist",
                        theTrackDirectoryInfo.ToString()),
                        theParentView.Text,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1);

                Application.DoEvents();
            }
        }
        #endregion

        #region Private Helpers
        private void OpenDatabase()
        {
            if (File.Exists(RegistryAgent.LastDatabase))
            {
                DatabaseLayer.ConnectionString = String.Format(
                    CultureInfo.CurrentCulture,
                    "Data Source={0}; UTF8Encoding=True; Version=3; Pooling=True",
                    RegistryAgent.LastDatabase);

                this._MainView.labelTrackCount.Text = String.Format(
                    CultureInfo.CurrentCulture,
                    "{0:N0} tracks",
                    DatabaseLayer.NumberOfTracksInDatabase);

                this._MainView.labelDatabaseLocation.Text =
                    RegistryAgent.LastDatabase;

                this._MainView.buttonRefreshDatabase.Enabled =
                    this._MainView.textboxCriteria.Enabled =
                    this._MainView.buttonSearch.Enabled =
                    this._MainView.gridResults.Enabled =
                        true;
            }
        }
        #endregion
        #endregion
    }
}
