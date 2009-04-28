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
            this._MainView.buttonLaunchKaraFun.Click += 
                new EventHandler(MainView_buttonLaunchKaraFun_Click);
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
            this._MainView.buttonOpenContainingFolder.Click += 
                new EventHandler(MainView_buttonOpenContainingFolder_Click);

            // Attach the ListingGenerationView to the Application Context
            this._AppContext.MainForm = this._MainView;

            // Show the form
            this._MainView.Show();

            if (!String.IsNullOrEmpty(RegistryAgent.LastDatabase))
            {
                this.OpenDatabase();
            }

            if (RegistryAgent.IsKaraFunInstalled)
            {
                this._MainView.Text = "Karaokidex for KaraFun";

                this._MainView.buttonLaunchKaraFun.Enabled = true;
            //    string[] theCommand = RegistryAgent.KaraFunEnqueueCommand
            //        .Split(new Char[] { '"' }, 3, StringSplitOptions.RemoveEmptyEntries);

            //    ProcessStartInfo theInfo = new ProcessStartInfo();
            //    theInfo.FileName = theCommand[0];

            //    Process thePlayerProcess = new Process();
            //    thePlayerProcess.StartInfo = theInfo;

            //    thePlayerProcess.Start();
            }
        }

        #region Event Handlers
        private void MainView_buttonOpenDatabase_Click(
            object sender, 
            EventArgs e)
        {
            Application.DoEvents();

            switch (this._MainView.OpenFileDialog.ShowDialog(this._MainView))
            {
                case DialogResult.Cancel:
                    Application.DoEvents();
                    return;
            }

            if (!String.IsNullOrEmpty(this._MainView.OpenFileDialog.FileName))
            {
                RegistryAgent.LastDatabase =
                    this._MainView.OpenFileDialog.FileName;

                this.OpenDatabase();
            }
            else
            {
                this._MainView.buttonSearch.Enabled = false;
            }
        }

        private void MainView_buttonCreateDatabase_Click(
            object sender, 
            EventArgs e)
        {
            Application.DoEvents();

            this.CreateDatabaseView_Show();
        }

        private void MainView_buttonRefreshDatabase_Click(
            object sender, 
            EventArgs e)
        {
            Application.DoEvents();

            this.CreateDatabaseAgentView_Show(
                this._MainView,
                new DirectoryInfo(DatabaseLayer.GetSourceDirectory),
                new FileInfo(RegistryAgent.LastDatabase));
        }

        private void MainView_buttonLaunchKaraFun_Click(
            object sender, 
            EventArgs e)
        {
            Application.DoEvents();

            Process.Start(RegistryAgent.KaraFunExecutablePath);
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
                theParentView.textboxCriteria.Text).Rows)
            {
                string thisExtension = Convert.ToString(
                    thisRow["Extension"],
                    CultureInfo.CurrentCulture);

                switch(thisExtension)
                {
                    case ".zip":
                        theParentView.gridResults.Rows.Add(
                            Convert.ToInt64(thisRow["ID"], CultureInfo.CurrentCulture),
                            Resources.mp3g_zipped,
                            Convert.ToString(thisRow["Details"], CultureInfo.CurrentCulture),
                            Convert.ToString(thisRow["Path"], CultureInfo.CurrentCulture),
                            Convert.ToString(thisRow["FullPath"], CultureInfo.CurrentCulture));
                        break;
                    case ".cdg":
                        theParentView.gridResults.Rows.Add(
                            Convert.ToInt64(thisRow["ID"], CultureInfo.CurrentCulture),
                            Resources.mp3g,
                            Convert.ToString(thisRow["Details"], CultureInfo.CurrentCulture),
                            Convert.ToString(thisRow["Path"], CultureInfo.CurrentCulture),
                            Convert.ToString(thisRow["FullPath"], CultureInfo.CurrentCulture));
                        break;
                }

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
                FileInfo theTrackDirectoryInfo = new FileInfo(
                    DatabaseLayer.GetSourceDirectory + "\\" +
                    theResultsGrid.SelectedRows[0].Cells["_columnFullPath"].Value);

                if (theTrackDirectoryInfo.Exists)
                {
                    this._MainView.Cursor =
                        Cursors.WaitCursor;

                    string[] theCommand =
                        RegistryAgent.KaraFunEnqueueCommand.Replace(
                            "%1",
                            theTrackDirectoryInfo.ToString())
                            .Split(new Char[] { '"' }, 3, StringSplitOptions.RemoveEmptyEntries);

                    ProcessStartInfo theInfo = new ProcessStartInfo();
                    theInfo.FileName = theCommand[0];
                    theInfo.Arguments = theCommand[1].Trim() + " \"" + theCommand[2].Trim() + '"';

                    Process theProcess = new Process();
                    theProcess.StartInfo = theInfo;

                    theProcess.Start();

                    //theProcess.WaitForInputIdle();

                    //if (!this._IsPaused)
                    //{
                    //    IntPtr iApplication = FindWindow(null, "KaraFun Player");

                    //    if (!iApplication.Equals(IntPtr.Zero))
                    //    {
                    //        SetForegroundWindow(iApplication);
                    //        SendKeys.Send(" ");
                    //        this._IsPaused = true;
                    //    }
                    //}

                    this._MainView.Cursor =
                        Cursors.Default;
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

            this.MainView_gridResults_DoubleClick(
                sender, new EventArgs());
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
                FileInfo theTrackDirectoryInfo = new FileInfo(
                    DatabaseLayer.GetSourceDirectory + "\\" +
                    theParentView.gridResults.SelectedRows[0].Cells["_columnFullPath"].Value);

                if (theTrackDirectoryInfo.Exists)
                {
                    this._MainView.Cursor =
                        Cursors.WaitCursor;

                    string[] theCommand =
                        RegistryAgent.KaraFunPlayCommand.Replace(
                            "%1",
                            theTrackDirectoryInfo.ToString())
                            .Split(new Char[] { '"' }, 3, StringSplitOptions.RemoveEmptyEntries);

                    Process.Start(
                        theCommand[0],
                        theCommand[1].Trim() + " \"" + theCommand[2].Trim() + '"');

                    this._MainView.Cursor =
                        Cursors.Default;
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
                DatabaseLayer.GetSourceDirectory +
                theParentView.gridResults.SelectedRows[0].Cells["_columnPath"].Value);

            if (theTrackDirectoryInfo.Exists)
            {
                this._MainView.Cursor =
                    Cursors.WaitCursor;

                Process.Start(
                    "explorer.exe",
                    String.Format(
                        CultureInfo.CurrentCulture,
                        "/e,/root,{0}",
                        theTrackDirectoryInfo.ToString()));

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