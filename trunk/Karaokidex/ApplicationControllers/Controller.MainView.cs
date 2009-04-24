using System;
using System.Windows.Forms;
using System.Globalization;
using System.IO;
using Karaokidex.Views;
using System.Diagnostics;
using System.Data;
using Karaokidex.Properties;

namespace Karaokidex.ApplicationControllers
{
    public partial class Controller
    {
        #region Members
        private MainView _MainView;
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
            this._MainView.buttonSearch.Click += 
                new EventHandler(MainView_buttonSearch_Click);
            this._MainView.buttonExit.Click += 
                new EventHandler(MainView_buttonExit_Click);
            this._MainView.gridResults.MouseUp += 
                new MouseEventHandler(MainView_gridResults_MouseUp);
            this._MainView.gridResults.DoubleClick += 
                new EventHandler(MainView_gridResults_DoubleClick);
            this._MainView.menuitemOpenContainingFolder.Click += 
                new EventHandler(MainView_menuitemOpenContainingFolder_Click);

            // Attach the ListingGenerationView to the Application Context
            this._AppContext.MainForm = this._MainView;

            // Show the form
            this._MainView.Show();

            if (!String.IsNullOrEmpty(RegistryAgent.LastDatabase))
            {
                this.OpenDatabase();
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
                            Convert.ToString(thisRow["Path"], CultureInfo.CurrentCulture));
                        break;
                    case ".cdg":
                        theParentView.gridResults.Rows.Add(
                            Convert.ToInt64(thisRow["ID"], CultureInfo.CurrentCulture),
                            Resources.mp3g,
                            Convert.ToString(thisRow["Details"], CultureInfo.CurrentCulture),
                            Convert.ToString(thisRow["Path"], CultureInfo.CurrentCulture));
                        break;
                }

                Application.DoEvents();
            }

            theParentView.labelResults.Text = String.Format(
                CultureInfo.CurrentCulture,
                "{0:N0} results",
                theParentView.gridResults.Rows.Count);

            theParentView.gridResults.ClearSelection();
            theParentView.buttonSearch.Enabled = true;

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

            theParentView.menuitemOpenContainingFolder.Enabled =
                theResultsGrid.SelectedRows.Count.Equals(1);
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

            DirectoryInfo theTrackDirectoryInfo = new DirectoryInfo(
                DatabaseLayer.GetSourceDirectory +
                theResultsGrid.SelectedRows[0].Cells["_columnPath"].Value);

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

        private void MainView_menuitemOpenContainingFolder_Click(
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
                theParentView.gridResults, e);
        }
        #endregion

        #region Private Helpers
        private void OpenDatabase()
        {
            this._MainView.labelDatabaseLocation.Text =
                RegistryAgent.LastDatabase;

            DatabaseLayer.ConnectionString = String.Format(
                CultureInfo.CurrentCulture,
                "Data Source={0}; UTF8Encoding=True; Version=3; Pooling=True",
                RegistryAgent.LastDatabase);

            this._MainView.buttonSearch.Enabled = true;

            this._MainView.labelTrackCount.Text = String.Format(
                CultureInfo.CurrentCulture,
                "{0:N0} tracks",
                DatabaseLayer.NumberOfTracksInDatabase);

            this._MainView.buttonRefreshDatabase.Enabled =
                this._MainView.textboxCriteria.Enabled =
                this._MainView.buttonSearch.Enabled = 
                this._MainView.gridResults.Enabled =
                    true;
        }
        #endregion
        #endregion
    }
}
