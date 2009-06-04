using System;
using System.Windows.Forms;
using System.Globalization;
using System.IO;
using Karaokidex.Views;
using System.Diagnostics;
using System.Data;
using Karaokidex.Properties;
using Karaokidex.Enumerators;
using System.Drawing;

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

            this._MainView.menuitemLaunchKaraFun.Click +=
                new EventHandler(MainView_menuitemLaunchKaraFun_Click);
            this._MainView.menuitemExit.Click +=
                new EventHandler(MainView_menuitemExit_Click);

            this._MainView.menuitemOpenKaraokeDatabase.Click +=
                new EventHandler(MainView_menuitemOpenKaraokeDatabase_Click);
            this._MainView.menuitemCreateKaraokeDatabase.Click +=
                new EventHandler(MainView_menuitemCreateKaraokeDatabase_Click);
            this._MainView.menuitemRefreshKaraokeDatabase.Click +=
                new EventHandler(MainView_menuitemRefreshKaraokeDatabase_Click);
            this._MainView.menuitemListInvalidKaraokeTracks.Click +=
                new EventHandler(MainView_menuitemListInvalidKaraokeTracks_Click);

            this._MainView.menuitemOpenMusicDatabase.Click +=
                new EventHandler(MainView_menuitemOpenMusicDatabase_Click);
            this._MainView.menuitemCreateMusicDatabase.Click +=
                new EventHandler(MainView_menuitemCreateMusicDatabase_Click);
            this._MainView.menuitemRefreshMusicDatabase.Click += 
                new EventHandler(MainView_menuitemRefreshMusicDatabase_Click);

            this._MainView.menuitemOpenKaraokeRequestSheet.Click += 
                new EventHandler(MainView_menuitemOpenKaraokeRequestSheet_Click);
            this._MainView.menuitemCreateKaraokeTrackCatalogue.Click +=
                new EventHandler(MainView_menuitemCreateKaraokeTrackCatalogue_Click);

            this._MainView.menuitemAbout.Click += 
                new EventHandler(MainView_menuitemAbout_Click);

            this._MainView.buttonSearch.Click += 
                new EventHandler(MainView_buttonSearch_Click);
            this._MainView.buttonClear.Click += 
                new EventHandler(MainView_buttonClear_Click);
            this._MainView.radioSearchKaraokeDatabase.CheckedChanged +=
                new EventHandler(MainView_radioSearchKaraokeDatabase_CheckedChanged);
            this._MainView.radioSearchMusicDatabase.CheckedChanged +=
                new EventHandler(MainView_radioSearchMusicDatabase_CheckedChanged);

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
            this._MainView.menuitemMarkTrackAsInvalid.Click +=
                new EventHandler(MainView_menuitemMarkTrackAsInvalid_Click);
            this._MainView.buttonOpenContainingFolder.Click += 
                new EventHandler(MainView_buttonOpenContainingFolder_Click);

            this._AppContext.MainForm = this._MainView;

            this._MainView.Show();

            if (!String.IsNullOrEmpty(RegistryAgent.LastKaraokeDatabase))
            {
                this.OpenDatabaseView_Show(
                    DatabaseMode.OpenKaraokeDatabase,
                    new FileInfo(RegistryAgent.LastKaraokeDatabase));
            }

            if (!String.IsNullOrEmpty(RegistryAgent.LastMusicDatabase))
            {
                this.OpenDatabaseView_Show(
                    DatabaseMode.OpenMusicDatabase,
                    new FileInfo(RegistryAgent.LastMusicDatabase));
            }

            this.MainView_radioSearchKaraokeDatabase_CheckedChanged(
                this._MainView.radioSearchKaraokeDatabase,
                new EventArgs());

            if (RegistryAgent.IsKaraFunInstalled)
            {
                this._MainView.Text = "Karaokidex for KaraFun";
            }
            else
            {
                this._MainView.menuitemLaunchKaraFun.ToolTipText = "Get &KaraFun";
            }
        }

        #region Event Handlers
        #region File Menu
        private void MainView_menuitemLaunchKaraFun_Click(
            object sender,
            EventArgs e)
        {
            Application.DoEvents();

            ToolStripMenuItem theKaraFunMenuItem =
                sender as ToolStripMenuItem;

            switch (theKaraFunMenuItem.ToolTipText)
            {
                case "Get KaraFun":
                    Process.Start("http://www.karafun.com/karaokeplayer/");
                    break;
                default:
                    Process.Start(RegistryAgent.KaraFunExecutablePath);
                    break;
            }
        }

        private void MainView_menuitemExit_Click(
            object sender,
            EventArgs e)
        {
            Application.DoEvents();

            Application.Exit();
        }
        #endregion

        #region Karaoke Menu
        private void MainView_menuitemOpenKaraokeDatabase_Click(
            object sender, 
            EventArgs e)
        {
            Application.DoEvents();

            if (!String.IsNullOrEmpty(RegistryAgent.LastKaraokeDatabase))
            {
                this.OpenDatabaseView_Show(
                    DatabaseMode.OpenKaraokeDatabase,
                    new FileInfo(RegistryAgent.LastKaraokeDatabase));
            }
            else
            {
                this.OpenDatabaseView_Show(
                    DatabaseMode.OpenKaraokeDatabase);
            }
        }

        private void MainView_menuitemCreateKaraokeDatabase_Click(
            object sender, 
            EventArgs e)
        {
            Application.DoEvents();

            this.CreateDatabaseView_Show(
                DatabaseMode.CreateKaraokeDatabase);
        }

        private void MainView_menuitemRefreshKaraokeDatabase_Click(
            object sender, 
            EventArgs e)
        {
            Application.DoEvents();

            this.CreateDatabaseView_Show(
                DatabaseMode.RefreshKaraokeDatabase);
        }

        private void MainView_menuitemListInvalidKaraokeTracks_Click(
            object sender, 
            EventArgs e)
        {
            Application.DoEvents();

            this._MainView.gridResults.Rows.Clear();

            foreach (DataRow thisRow in DatabaseLayer.ListInvalidTracks(
                this._CurrentKaraokeDatabaseFileInfo).Rows)
            {
                string thisExtension = Convert.ToString(
                    thisRow["Extension"],
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

                this._MainView.gridResults.Rows.Add(
                    Convert.ToInt64(thisRow["ID"], CultureInfo.CurrentCulture),
                    theExtensionImage,
                    Convert.ToString(thisRow["Details"], CultureInfo.CurrentCulture),
                    Resources.invalid,
                    Convert.ToInt32(thisRow["Rating"], CultureInfo.CurrentCulture),
                    Convert.ToString(thisRow["Path"], CultureInfo.CurrentCulture),
                    Convert.ToString(thisRow["FullPath"], CultureInfo.CurrentCulture));

                Application.DoEvents();
            }

            this._MainView.labelResults.Text = String.Format(
                CultureInfo.CurrentCulture,
                "{0:N0} results",
                this._MainView.gridResults.Rows.Count);

            if (!this._MainView.gridResults.Rows.Count.Equals(0))
            {
                this._MainView.gridResults.ClearSelection();
                this._MainView.gridResults.Focus();
            }
        }
        #endregion

        #region Music Menu
        private void MainView_menuitemOpenMusicDatabase_Click(
            object sender, 
            EventArgs e)
        {
            Application.DoEvents();

            if (!String.IsNullOrEmpty(RegistryAgent.LastMusicDatabase))
            {
                this.OpenDatabaseView_Show(
                    DatabaseMode.OpenMusicDatabase,
                    new FileInfo(RegistryAgent.LastMusicDatabase));
            }
            else
            {
                this.OpenDatabaseView_Show(
                    DatabaseMode.OpenMusicDatabase);
            }
        }

        private void MainView_menuitemCreateMusicDatabase_Click(
            object sender, 
            EventArgs e)
        {
            Application.DoEvents();

            this.CreateDatabaseView_Show(
                DatabaseMode.CreateMusicDatabase);
        }

        private void MainView_menuitemRefreshMusicDatabase_Click(
            object sender, 
            EventArgs e)
        {
            Application.DoEvents();

            this.CreateDatabaseView_Show(
                DatabaseMode.RefreshMusicDatabase);
        }
        #endregion

        #region Documents Menu
        private void MainView_menuitemOpenKaraokeRequestSheet_Click(
            object sender, 
            EventArgs e)
        {
            Application.DoEvents();

            if (String.IsNullOrEmpty(FileAssociation.Get(".pdf")))
            {
                Process.Start("http://get.adobe.com/uk/reader/");
            }
            else
            {
                Process.Start("KaraokeRequest.pdf");
            }
        }

        private void MainView_menuitemCreateKaraokeTrackCatalogue_Click(
            object sender, 
            EventArgs e)
        {
            Application.DoEvents();

            this._MainView.SaveFileDialog.FileName = String.Format(
                CultureInfo.CurrentCulture,
                "TrackListing_{0}.txt",
                DateTime.Now.ToString("yyyyMMdd_HHmm"));

            switch (this._MainView.SaveFileDialog.ShowDialog(
                this._MainView))
            {
                case DialogResult.Cancel:
                    Application.DoEvents();
                    return;
            }

            this._MainView.Cursor =
                Cursors.WaitCursor;

            Application.DoEvents();

            if (File.Exists(this._MainView.SaveFileDialog.FileName))
            {
                File.Delete(this._MainView.SaveFileDialog.FileName);
            }

            using (StreamWriter theStreamWriter = File.AppendText(
                this._MainView.SaveFileDialog.FileName))
            {
                theStreamWriter.WriteLine("Track Listing created using Karaokidex");
                theStreamWriter.WriteLine("http://code.google.com/p/karaokidex");
                theStreamWriter.WriteLine("");

                foreach (DataRow thisRow in DatabaseLayer.ListValidTracks(
                    this._CurrentKaraokeDatabaseFileInfo).Rows)
                {
                    theStreamWriter.WriteLine(thisRow[0].ToString());
                    Application.DoEvents();
                }

                theStreamWriter.WriteLine("");
                theStreamWriter.WriteLine(String.Format(
                    CultureInfo.CurrentCulture,
                    "Listing generated on {0}",
                    DateTime.Now.ToString("dd MMMM yyyy @ HH:mm")));
                theStreamWriter.WriteLine(String.Format(
                    CultureInfo.CurrentCulture,
                    "{0} tracks in database",
                    DatabaseLayer.ListValidTracks(
                    this._CurrentKaraokeDatabaseFileInfo).Rows.Count));

                theStreamWriter.Close();
            }

            this._MainView.Cursor =
                Cursors.Default;
        }
        #endregion

        #region About Menu
        private void MainView_menuitemAbout_Click(
            object sender, 
            EventArgs e)
        {
            this.AboutView_Show();
        }
        #endregion

        private void MainView_buttonSearch_Click(
            object sender, 
            EventArgs e)
        {
            Application.DoEvents();

            Button theSearchButton =
                sender as Button;
            MainView theParentView =
                theSearchButton.FindForm() as MainView;

            theParentView.Cursor =
                Cursors.WaitCursor;

            theParentView.gridResults.Rows.Clear();

            if (String.IsNullOrEmpty(theParentView.textboxCriteria.Text))
            {
                switch (MessageBox.Show(
                    theParentView,
                    "There is no search criteria specified\n\n" +
                        "Do you want to return all tracks",
                    theParentView.Text,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button2))
                {
                    case DialogResult.No:
                        Application.DoEvents();
                        return;
                }

                Application.DoEvents();
            }

            theParentView.buttonSearch.Enabled = 
                theParentView.buttonClear.Enabled =
                    false;

            theParentView.gridResults.Rows.Clear();

            switch (theParentView.Mode)
            {
                case DatabaseMode.SearchMusicDatabase:
                    theParentView.gridResults.Columns["_columnRatingImage"].Visible = false;
                    theParentView.labelSelectedTrackPath.Text = String.Empty;

                    foreach (DataRow thisRow in DatabaseLayer.SearchMusicDatabase(
                        this._CurrentMusicDatabaseFileInfo,
                        theParentView.textboxCriteria.Text).Rows)
                    {
                        string thisExtension = Convert.ToString(
                            thisRow["Extension"],
                            CultureInfo.CurrentCulture);

                        Bitmap theExtensionImage = Resources.mp3;
                        switch (thisExtension)
                        {
                            case ".wav":
                                theExtensionImage = Resources.wav;
                                break;
                            case ".flac":
                                theExtensionImage = Resources.flac;
                                break;
                            default:
                                theExtensionImage = Resources.mp3;
                                break;
                        }

                        theParentView.gridResults.Rows.Add(
                            Convert.ToInt64(thisRow["ID"], CultureInfo.CurrentCulture),
                            theExtensionImage,
                            Convert.ToString(thisRow["Details"], CultureInfo.CurrentCulture),
                            null, // Rating image
                            0, // Rating value
                            Convert.ToString(thisRow["Path"], CultureInfo.CurrentCulture),
                            Convert.ToString(thisRow["FullPath"], CultureInfo.CurrentCulture));

                        Application.DoEvents();
                    }
                    break;
                default:
                    theParentView.gridResults.Columns["_columnRatingImage"].Visible = true;
                    theParentView.labelSelectedTrackPath.Text = String.Empty;
                    
                    foreach (DataRow thisRow in DatabaseLayer.SearchKaraokeDatabase(
                        this._CurrentKaraokeDatabaseFileInfo,
                        theParentView.textboxCriteria.Text,
                        theParentView.checkboxShowOnlyRatedTracks.Checked).Rows)
                    {
                        string thisExtension = Convert.ToString(
                            thisRow["Extension"],
                            CultureInfo.CurrentCulture);
                        TrackRating thisRating = (TrackRating)Convert.ToInt32(
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
                            case TrackRating.OneStar:
                                theRatingImage = Resources._1_star;
                                break;
                            case TrackRating.TwoStar:
                                theRatingImage = Resources._2_stars;
                                break;
                            case TrackRating.ThreeStar:
                                theRatingImage = Resources._3_stars;
                                break;
                            case TrackRating.FourStar:
                                theRatingImage = Resources._4_stars;
                                break;
                            case TrackRating.FiveStar:
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
                            Convert.ToInt32(thisRow["Rating"], CultureInfo.CurrentCulture),
                            Convert.ToString(thisRow["Path"], CultureInfo.CurrentCulture),
                            Convert.ToString(thisRow["FullPath"], CultureInfo.CurrentCulture));

                        Application.DoEvents();
                    }
                    break;
            }

            theParentView.labelResults.Text = String.Format(
                CultureInfo.CurrentCulture,
                "{0:N0} results",
                theParentView.gridResults.Rows.Count);

            theParentView.buttonSearch.Enabled = true;

            if (!theParentView.gridResults.Rows.Count.Equals(0))
            {
                theParentView.buttonClear.Enabled = true;
                theParentView.gridResults.Focus();
            }

            theParentView.Cursor =
                Cursors.Default;
        }

        private void MainView_buttonClear_Click(
            object sender, 
            EventArgs e)
        {
            Application.DoEvents();

            Button theClearButton =
                sender as Button;
            MainView theParentView =
                theClearButton.FindForm() as MainView;

            theParentView.gridResults.Rows.Clear();
        }

        private void MainView_radioSearchKaraokeDatabase_CheckedChanged(
            object sender, 
            EventArgs e)
        {
            Application.DoEvents();

            RadioButton theSearchKaraokeRadioButton =
                sender as RadioButton;
            MainView theParentView =
                theSearchKaraokeRadioButton.FindForm() as MainView;

            if (theSearchKaraokeRadioButton.Checked)
            {
                theParentView.buttonSearch.Enabled =
                    !String.IsNullOrEmpty(
                        RegistryAgent.LastKaraokeDatabase);
            }
        }

        private void MainView_radioSearchMusicDatabase_CheckedChanged(
            object sender,
            EventArgs e)
        {
            Application.DoEvents();

            RadioButton theSearchMusicRadioButton =
                sender as RadioButton;
            MainView theParentView =
                theSearchMusicRadioButton.FindForm() as MainView;

            if (theSearchMusicRadioButton.Checked)
            {
                theParentView.buttonSearch.Enabled =
                    !String.IsNullOrEmpty(
                        RegistryAgent.LastMusicDatabase);
            }
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
                    false;

            if (!theResultsGrid.SelectedRows.Count.Equals(0))
            {
                theParentView.menuitemEnqueueInKaraFun.Enabled =
                    theParentView.menuitemPlayInKaraFun.Enabled =
                        RegistryAgent.IsKaraFunInstalled;
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
                FileInfo theTrackFileInfo;

                switch (theParentView.Mode)
                {
                    case DatabaseMode.SearchMusicDatabase:
                        theTrackFileInfo = new FileInfo(
                            DatabaseLayer.GetSourceDirectory(new FileInfo(RegistryAgent.LastMusicDatabase)) +
                            "\\" + theResultsGrid.SelectedRows[0].Cells["_columnFullPath"].Value);
                        break;
                    default:
                        theTrackFileInfo = new FileInfo(
                            DatabaseLayer.GetSourceDirectory(new FileInfo(RegistryAgent.LastKaraokeDatabase)) +
                            "\\" + theResultsGrid.SelectedRows[0].Cells["_columnFullPath"].Value);
                        break;
                }

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
                null == theContextMenuStrip.SourceControl
                ? this._MainView
                : theContextMenuStrip.SourceControl.FindForm() as MainView;

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
                null == theContextMenuStrip.SourceControl
                ? this._MainView
                : theContextMenuStrip.SourceControl.FindForm() as MainView;

            if (!theParentView.gridResults.SelectedRows.Count.Equals(0))
            {
                FileInfo theTrackFileInfo;

                switch (theParentView.Mode)
                {
                    case DatabaseMode.SearchMusicDatabase:
                        theTrackFileInfo = new FileInfo(
                            DatabaseLayer.GetSourceDirectory(new FileInfo(RegistryAgent.LastMusicDatabase)) +
                            "\\" + theParentView.gridResults.SelectedRows[0].Cells["_columnFullPath"].Value);
                        break;
                    default:
                        theTrackFileInfo = new FileInfo(
                            DatabaseLayer.GetSourceDirectory(new FileInfo(RegistryAgent.LastKaraokeDatabase)) +
                            "\\" + theParentView.gridResults.SelectedRows[0].Cells["_columnFullPath"].Value);
                        break;
                }

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
                null == theContextMenuStrip.SourceControl 
                ? this._MainView
                : theContextMenuStrip.SourceControl.FindForm() as MainView;

            if (!theParentView.gridResults.SelectedRows.Count.Equals(0))
            {
                long theTrackID = Convert.ToInt64(
                    theParentView.gridResults.SelectedRows[0].Cells["_columnID"].Value,
                    CultureInfo.CurrentCulture);

                TrackRating theTrackRating =
                    (TrackRating)Convert.ToInt32(
                        theParentView.gridResults.SelectedRows[0].Cells["_columnRating"].Value,
                        CultureInfo.CurrentCulture);

                this.TrackRatingView_Show(
                    theTrackID,
                    theTrackRating);
            }
        }

        private void MainView_menuitemMarkTrackAsInvalid_Click(
            object sender, 
            EventArgs e)
        {
            Application.DoEvents();

            ToolStripMenuItem theOpenContainingFolder =
                sender as ToolStripMenuItem;
            ContextMenuStrip theContextMenuStrip =
                theOpenContainingFolder.Owner as ContextMenuStrip;
            MainView theParentView =
                null == theContextMenuStrip.SourceControl
                ? this._MainView
                : theContextMenuStrip.SourceControl.FindForm() as MainView;

            if (!theParentView.gridResults.SelectedRows.Count.Equals(0))
            {
                FileInfo theTrackFileInfo = new FileInfo(
                    DatabaseLayer.GetSourceDirectory(new FileInfo(RegistryAgent.LastKaraokeDatabase)) +
                    "\\" + theParentView.gridResults.SelectedRows[0].Cells["_columnFullPath"].Value);

                if (theTrackFileInfo.Exists)
                {
                    switch (MessageBox.Show(
                        theParentView,
                        "Are you sure you want to mark this track as invalid?",
                        theParentView.Text,
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning,
                        MessageBoxDefaultButton.Button2))
                    {
                        case DialogResult.No:
                            Application.DoEvents();
                            return;
                    }

                    Application.DoEvents();

                    long theTrackID = Convert.ToInt64(
                        theParentView.gridResults.SelectedRows[0].Cells["_columnID"].Value,
                        CultureInfo.CurrentCulture);

                    DatabaseLayer.UpdateTrackRating(
                        this._CurrentKaraokeDatabaseFileInfo,
                        theTrackID,
                        TrackRating.Invalid);

                    this.MainView_buttonSearch_Click(
                        theParentView.buttonSearch,
                        new EventArgs());
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

            if (theParentView.gridResults.SelectedRows.Count.Equals(1))
            {
                DirectoryInfo theTrackDirectoryInfo;

                switch (theParentView.Mode)
                {
                    case DatabaseMode.SearchMusicDatabase:
                        theTrackDirectoryInfo = new DirectoryInfo(
                            DatabaseLayer.GetSourceDirectory(new FileInfo(RegistryAgent.LastMusicDatabase)) +
                            "\\" + theParentView.gridResults.SelectedRows[0].Cells["_columnPath"].Value);
                        break;
                    default:
                        theTrackDirectoryInfo = new DirectoryInfo(
                            DatabaseLayer.GetSourceDirectory(new FileInfo(RegistryAgent.LastKaraokeDatabase)) +
                            "\\" + theParentView.gridResults.SelectedRows[0].Cells["_columnPath"].Value);
                        break;
                }

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
        }
        #endregion

        #region Private Helpers
        private void OpenDatabase()
        {
            this._MainView.menuitemRefreshKaraokeDatabase.Enabled =
                this._MainView.menuitemCreateKaraokeTrackCatalogue.Enabled =
                this._MainView.menuitemListInvalidKaraokeTracks.Enabled =
                this._MainView.menuitemRefreshMusicDatabase.Enabled = 
                this._MainView.radioSearchKaraokeDatabase.Enabled =
                this._MainView.radioSearchMusicDatabase.Enabled =
                this._MainView.checkboxShowOnlyRatedTracks.Enabled =
                this._MainView.buttonSearch.Enabled =
                    false;

            if (null != this._CurrentKaraokeDatabaseFileInfo)
            {
                if (this._CurrentKaraokeDatabaseFileInfo.Exists)
                {
                    this._MainView.menuitemRefreshKaraokeDatabase.Enabled =
                        this._MainView.menuitemCreateKaraokeTrackCatalogue.Enabled =
                        this._MainView.menuitemListInvalidKaraokeTracks.Enabled =
                        this._MainView.radioSearchKaraokeDatabase.Enabled =
                            true;
                }
            } 
            
            if (null != this._CurrentMusicDatabaseFileInfo)
            {
                if (this._CurrentMusicDatabaseFileInfo.Exists)
                {
                    this._MainView.menuitemRefreshMusicDatabase.Enabled = 
                        this._MainView.radioSearchMusicDatabase.Enabled =
                            true;
                }
            }

            if (this._MainView.radioSearchKaraokeDatabase.Enabled)
            {
                this._MainView.radioSearchKaraokeDatabase.Checked =
                    this._MainView.checkboxShowOnlyRatedTracks.Enabled =
                        true;
            }
            else
            {
                this._MainView.radioSearchMusicDatabase.Checked =
                    true;
            }
        }
        #endregion
        #endregion
    }
}
