namespace Karaokidex.Views
{
    partial class MainView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            this._StatusStrip = new System.Windows.Forms.StatusStrip();
            this._labelVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this._labelKaraokeDatabase = new System.Windows.Forms.ToolStripStatusLabel();
            this._labelMusicDatabase = new System.Windows.Forms.ToolStripStatusLabel();
            this._labelResults = new System.Windows.Forms.ToolStripStatusLabel();
            this._SplitContainer = new System.Windows.Forms.SplitContainer();
            this._radioSearchMusicDatabase = new System.Windows.Forms.RadioButton();
            this._radioSearchKaraokeDatabase = new System.Windows.Forms.RadioButton();
            this._buttonClear = new System.Windows.Forms.Button();
            this._checkboxShowOnlyRatedTracks = new System.Windows.Forms.CheckBox();
            this._textboxCriteria = new System.Windows.Forms.TextBox();
            this._labelCriteria = new System.Windows.Forms.Label();
            this._buttonSearch = new System.Windows.Forms.Button();
            this._gridResults = new System.Windows.Forms.DataGridView();
            this._columnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._columnImage = new System.Windows.Forms.DataGridViewImageColumn();
            this._columnTrack = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._columnRatingImage = new System.Windows.Forms.DataGridViewImageColumn();
            this._columnRating = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._columnPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._columnFullPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._menuitemEnqueueInKaraFun = new System.Windows.Forms.ToolStripMenuItem();
            this._menuitemPlayInKaraFun = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this._menuitemEditTrackRating = new System.Windows.Forms.ToolStripMenuItem();
            this._menuitemMarkTrackAsInvalid = new System.Windows.Forms.ToolStripMenuItem();
            this._TableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this._buttonOpenContainingFolder = new System.Windows.Forms.Button();
            this._labelSelectedTrackPath = new System.Windows.Forms.Label();
            this._SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._menuitemLaunchKaraFun = new System.Windows.Forms.ToolStripMenuItem();
            this._separator1 = new System.Windows.Forms.ToolStripSeparator();
            this._menuitemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.karaokeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._menuitemOpenKaraokeDatabase = new System.Windows.Forms.ToolStripMenuItem();
            this._menuitemCreateKaraokeDatabase = new System.Windows.Forms.ToolStripMenuItem();
            this._menuitemRefreshKaraokeDatabase = new System.Windows.Forms.ToolStripMenuItem();
            this._separator2 = new System.Windows.Forms.ToolStripSeparator();
            this._menuitemListInvalidKaraokeTracks = new System.Windows.Forms.ToolStripMenuItem();
            this.musicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._menuitemOpenMusicDatabase = new System.Windows.Forms.ToolStripMenuItem();
            this._menuitemCreateMusicDatabase = new System.Windows.Forms.ToolStripMenuItem();
            this._menuitemRefreshMusicDatabase = new System.Windows.Forms.ToolStripMenuItem();
            this.documentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._menuitemOpenKaraokeRequestSheet = new System.Windows.Forms.ToolStripMenuItem();
            this._menuitemCreateKaraokeTrackCatalogue = new System.Windows.Forms.ToolStripMenuItem();
            this._StatusStrip.SuspendLayout();
            this._SplitContainer.Panel1.SuspendLayout();
            this._SplitContainer.Panel2.SuspendLayout();
            this._SplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._gridResults)).BeginInit();
            this._ContextMenuStrip.SuspendLayout();
            this._TableLayoutPanel.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _StatusStrip
            // 
            this._StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._labelVersion,
            this._labelKaraokeDatabase,
            this._labelMusicDatabase,
            this._labelResults});
            this._StatusStrip.Location = new System.Drawing.Point(0, 260);
            this._StatusStrip.Name = "_StatusStrip";
            this._StatusStrip.Size = new System.Drawing.Size(784, 24);
            this._StatusStrip.TabIndex = 0;
            this._StatusStrip.Text = "statusStrip1";
            // 
            // _labelVersion
            // 
            this._labelVersion.Name = "_labelVersion";
            this._labelVersion.Size = new System.Drawing.Size(66, 19);
            this._labelVersion.Text = "Version: {0}";
            // 
            // _labelKaraokeDatabase
            // 
            this._labelKaraokeDatabase.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this._labelKaraokeDatabase.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this._labelKaraokeDatabase.Name = "_labelKaraokeDatabase";
            this._labelKaraokeDatabase.Size = new System.Drawing.Size(120, 19);
            this._labelKaraokeDatabase.Text = "No database opened";
            // 
            // _labelMusicDatabase
            // 
            this._labelMusicDatabase.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this._labelMusicDatabase.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this._labelMusicDatabase.Name = "_labelMusicDatabase";
            this._labelMusicDatabase.Size = new System.Drawing.Size(120, 19);
            this._labelMusicDatabase.Text = "No database opened";
            // 
            // _labelResults
            // 
            this._labelResults.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this._labelResults.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this._labelResults.Name = "_labelResults";
            this._labelResults.Size = new System.Drawing.Size(54, 19);
            this._labelResults.Text = "0 results";
            // 
            // _SplitContainer
            // 
            this._SplitContainer.BackColor = System.Drawing.Color.White;
            this._SplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this._SplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this._SplitContainer.IsSplitterFixed = true;
            this._SplitContainer.Location = new System.Drawing.Point(0, 24);
            this._SplitContainer.Name = "_SplitContainer";
            this._SplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // _SplitContainer.Panel1
            // 
            this._SplitContainer.Panel1.BackColor = System.Drawing.Color.White;
            this._SplitContainer.Panel1.Controls.Add(this._radioSearchMusicDatabase);
            this._SplitContainer.Panel1.Controls.Add(this._radioSearchKaraokeDatabase);
            this._SplitContainer.Panel1.Controls.Add(this._buttonClear);
            this._SplitContainer.Panel1.Controls.Add(this._checkboxShowOnlyRatedTracks);
            this._SplitContainer.Panel1.Controls.Add(this._textboxCriteria);
            this._SplitContainer.Panel1.Controls.Add(this._labelCriteria);
            this._SplitContainer.Panel1.Controls.Add(this._buttonSearch);
            this._SplitContainer.Panel1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // _SplitContainer.Panel2
            // 
            this._SplitContainer.Panel2.Controls.Add(this._gridResults);
            this._SplitContainer.Panel2.Controls.Add(this._TableLayoutPanel);
            this._SplitContainer.Size = new System.Drawing.Size(784, 236);
            this._SplitContainer.SplitterDistance = 70;
            this._SplitContainer.TabIndex = 0;
            this._SplitContainer.TabStop = false;
            // 
            // _radioSearchMusicDatabase
            // 
            this._radioSearchMusicDatabase.AutoSize = true;
            this._radioSearchMusicDatabase.Location = new System.Drawing.Point(192, 41);
            this._radioSearchMusicDatabase.Name = "_radioSearchMusicDatabase";
            this._radioSearchMusicDatabase.Size = new System.Drawing.Size(66, 23);
            this._radioSearchMusicDatabase.TabIndex = 9;
            this._radioSearchMusicDatabase.Text = "&Music";
            this._radioSearchMusicDatabase.UseVisualStyleBackColor = true;
            this._radioSearchMusicDatabase.CheckedChanged += new System.EventHandler(this._RadioButtonMode_CheckedChanged);
            // 
            // _radioSearchKaraokeDatabase
            // 
            this._radioSearchKaraokeDatabase.AutoSize = true;
            this._radioSearchKaraokeDatabase.Checked = true;
            this._radioSearchKaraokeDatabase.Location = new System.Drawing.Point(103, 41);
            this._radioSearchKaraokeDatabase.Name = "_radioSearchKaraokeDatabase";
            this._radioSearchKaraokeDatabase.Size = new System.Drawing.Size(83, 23);
            this._radioSearchKaraokeDatabase.TabIndex = 8;
            this._radioSearchKaraokeDatabase.TabStop = true;
            this._radioSearchKaraokeDatabase.Text = "&Karaoke";
            this._radioSearchKaraokeDatabase.UseVisualStyleBackColor = true;
            this._radioSearchKaraokeDatabase.CheckedChanged += new System.EventHandler(this._RadioButtonMode_CheckedChanged);
            // 
            // _buttonClear
            // 
            this._buttonClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._buttonClear.AutoSize = true;
            this._buttonClear.Enabled = false;
            this._buttonClear.Image = global::Karaokidex.Properties.Resources.page_white;
            this._buttonClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._buttonClear.Location = new System.Drawing.Point(680, 38);
            this._buttonClear.Name = "_buttonClear";
            this._buttonClear.Size = new System.Drawing.Size(100, 29);
            this._buttonClear.TabIndex = 7;
            this._buttonClear.Text = "&Clear";
            this._buttonClear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._buttonClear.UseVisualStyleBackColor = true;
            // 
            // _checkboxShowOnlyRatedTracks
            // 
            this._checkboxShowOnlyRatedTracks.AutoSize = true;
            this._checkboxShowOnlyRatedTracks.Location = new System.Drawing.Point(473, 42);
            this._checkboxShowOnlyRatedTracks.Name = "_checkboxShowOnlyRatedTracks";
            this._checkboxShowOnlyRatedTracks.Size = new System.Drawing.Size(201, 23);
            this._checkboxShowOnlyRatedTracks.TabIndex = 6;
            this._checkboxShowOnlyRatedTracks.Text = "Show Only &Rated Tracks";
            this._checkboxShowOnlyRatedTracks.UseVisualStyleBackColor = true;
            // 
            // _textboxCriteria
            // 
            this._textboxCriteria.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._textboxCriteria.Location = new System.Drawing.Point(103, 5);
            this._textboxCriteria.Name = "_textboxCriteria";
            this._textboxCriteria.Size = new System.Drawing.Size(571, 27);
            this._textboxCriteria.TabIndex = 4;
            // 
            // _labelCriteria
            // 
            this._labelCriteria.AutoSize = true;
            this._labelCriteria.Location = new System.Drawing.Point(3, 8);
            this._labelCriteria.Name = "_labelCriteria";
            this._labelCriteria.Size = new System.Drawing.Size(94, 19);
            this._labelCriteria.TabIndex = 3;
            this._labelCriteria.Text = "Artist / Title";
            // 
            // _buttonSearch
            // 
            this._buttonSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._buttonSearch.AutoSize = true;
            this._buttonSearch.Enabled = false;
            this._buttonSearch.Image = global::Karaokidex.Properties.Resources.find;
            this._buttonSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._buttonSearch.Location = new System.Drawing.Point(680, 3);
            this._buttonSearch.Name = "_buttonSearch";
            this._buttonSearch.Size = new System.Drawing.Size(100, 29);
            this._buttonSearch.TabIndex = 5;
            this._buttonSearch.Text = "&Search";
            this._buttonSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._buttonSearch.UseVisualStyleBackColor = true;
            // 
            // _gridResults
            // 
            this._gridResults.AllowUserToAddRows = false;
            this._gridResults.AllowUserToDeleteRows = false;
            this._gridResults.AllowUserToResizeRows = false;
            this._gridResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._gridResults.ColumnHeadersVisible = false;
            this._gridResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._columnID,
            this._columnImage,
            this._columnTrack,
            this._columnRatingImage,
            this._columnRating,
            this._columnPath,
            this._columnFullPath});
            this._gridResults.ContextMenuStrip = this._ContextMenuStrip;
            this._gridResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this._gridResults.Location = new System.Drawing.Point(0, 0);
            this._gridResults.MultiSelect = false;
            this._gridResults.Name = "_gridResults";
            this._gridResults.ReadOnly = true;
            this._gridResults.RowHeadersVisible = false;
            this._gridResults.RowTemplate.Height = 30;
            this._gridResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._gridResults.Size = new System.Drawing.Size(784, 128);
            this._gridResults.StandardTab = true;
            this._gridResults.TabIndex = 4;
            // 
            // _columnID
            // 
            this._columnID.DataPropertyName = "ID";
            this._columnID.HeaderText = "ID";
            this._columnID.Name = "_columnID";
            this._columnID.ReadOnly = true;
            this._columnID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this._columnID.Visible = false;
            // 
            // _columnImage
            // 
            this._columnImage.FillWeight = 30F;
            this._columnImage.HeaderText = "";
            this._columnImage.Name = "_columnImage";
            this._columnImage.ReadOnly = true;
            this._columnImage.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this._columnImage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this._columnImage.Width = 30;
            // 
            // _columnTrack
            // 
            this._columnTrack.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this._columnTrack.DataPropertyName = "Details";
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._columnTrack.DefaultCellStyle = dataGridViewCellStyle1;
            this._columnTrack.HeaderText = "Track";
            this._columnTrack.Name = "_columnTrack";
            this._columnTrack.ReadOnly = true;
            // 
            // _columnRatingImage
            // 
            this._columnRatingImage.FillWeight = 85F;
            this._columnRatingImage.HeaderText = "Rating";
            this._columnRatingImage.Name = "_columnRatingImage";
            this._columnRatingImage.ReadOnly = true;
            this._columnRatingImage.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this._columnRatingImage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this._columnRatingImage.Width = 85;
            // 
            // _columnRating
            // 
            this._columnRating.HeaderText = "Rating";
            this._columnRating.Name = "_columnRating";
            this._columnRating.ReadOnly = true;
            this._columnRating.Visible = false;
            // 
            // _columnPath
            // 
            this._columnPath.DataPropertyName = "Path";
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Silver;
            this._columnPath.DefaultCellStyle = dataGridViewCellStyle2;
            this._columnPath.FillWeight = 300F;
            this._columnPath.HeaderText = "Path";
            this._columnPath.Name = "_columnPath";
            this._columnPath.ReadOnly = true;
            this._columnPath.Visible = false;
            this._columnPath.Width = 300;
            // 
            // _columnFullPath
            // 
            this._columnFullPath.HeaderText = "Full Path";
            this._columnFullPath.Name = "_columnFullPath";
            this._columnFullPath.ReadOnly = true;
            this._columnFullPath.Visible = false;
            // 
            // _ContextMenuStrip
            // 
            this._ContextMenuStrip.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuitemEnqueueInKaraFun,
            this._menuitemPlayInKaraFun,
            this.toolStripSeparator2,
            this._menuitemEditTrackRating,
            this._menuitemMarkTrackAsInvalid});
            this._ContextMenuStrip.Name = "_ContextMenuStrip";
            this._ContextMenuStrip.Size = new System.Drawing.Size(227, 98);
            // 
            // _menuitemEnqueueInKaraFun
            // 
            this._menuitemEnqueueInKaraFun.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._menuitemEnqueueInKaraFun.Name = "_menuitemEnqueueInKaraFun";
            this._menuitemEnqueueInKaraFun.Size = new System.Drawing.Size(226, 22);
            this._menuitemEnqueueInKaraFun.Text = "En&queue in KaraFun";
            // 
            // _menuitemPlayInKaraFun
            // 
            this._menuitemPlayInKaraFun.Name = "_menuitemPlayInKaraFun";
            this._menuitemPlayInKaraFun.Size = new System.Drawing.Size(226, 22);
            this._menuitemPlayInKaraFun.Text = "&Play in KaraFun";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(223, 6);
            // 
            // _menuitemEditTrackRating
            // 
            this._menuitemEditTrackRating.Name = "_menuitemEditTrackRating";
            this._menuitemEditTrackRating.ShortcutKeys = System.Windows.Forms.Keys.F10;
            this._menuitemEditTrackRating.Size = new System.Drawing.Size(226, 22);
            this._menuitemEditTrackRating.Text = "Edit Track &Rating";
            // 
            // _menuitemMarkTrackAsInvalid
            // 
            this._menuitemMarkTrackAsInvalid.Name = "_menuitemMarkTrackAsInvalid";
            this._menuitemMarkTrackAsInvalid.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F11)));
            this._menuitemMarkTrackAsInvalid.Size = new System.Drawing.Size(226, 22);
            this._menuitemMarkTrackAsInvalid.Text = "Mark Track As Invalid";
            // 
            // _TableLayoutPanel
            // 
            this._TableLayoutPanel.BackColor = System.Drawing.SystemColors.Control;
            this._TableLayoutPanel.ColumnCount = 2;
            this._TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 95.40816F));
            this._TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.591837F));
            this._TableLayoutPanel.Controls.Add(this._buttonOpenContainingFolder, 0, 0);
            this._TableLayoutPanel.Controls.Add(this._labelSelectedTrackPath, 0, 0);
            this._TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._TableLayoutPanel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._TableLayoutPanel.Location = new System.Drawing.Point(0, 128);
            this._TableLayoutPanel.Name = "_TableLayoutPanel";
            this._TableLayoutPanel.RowCount = 1;
            this._TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._TableLayoutPanel.Size = new System.Drawing.Size(784, 34);
            this._TableLayoutPanel.TabIndex = 1;
            // 
            // _buttonOpenContainingFolder
            // 
            this._buttonOpenContainingFolder.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._buttonOpenContainingFolder.Enabled = false;
            this._buttonOpenContainingFolder.Image = global::Karaokidex.Properties.Resources.folder;
            this._buttonOpenContainingFolder.Location = new System.Drawing.Point(751, 3);
            this._buttonOpenContainingFolder.Name = "_buttonOpenContainingFolder";
            this._buttonOpenContainingFolder.Size = new System.Drawing.Size(29, 28);
            this._buttonOpenContainingFolder.TabIndex = 5;
            this._buttonOpenContainingFolder.UseVisualStyleBackColor = true;
            // 
            // _labelSelectedTrackPath
            // 
            this._labelSelectedTrackPath.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._labelSelectedTrackPath.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._labelSelectedTrackPath.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._labelSelectedTrackPath.Location = new System.Drawing.Point(3, 3);
            this._labelSelectedTrackPath.Margin = new System.Windows.Forms.Padding(3);
            this._labelSelectedTrackPath.Name = "_labelSelectedTrackPath";
            this._labelSelectedTrackPath.Size = new System.Drawing.Size(742, 28);
            this._labelSelectedTrackPath.TabIndex = 6;
            this._labelSelectedTrackPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._labelSelectedTrackPath.UseMnemonic = false;
            // 
            // _SaveFileDialog
            // 
            this._SaveFileDialog.DefaultExt = "txt";
            this._SaveFileDialog.Filter = "Text files|*.txt";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.karaokeToolStripMenuItem,
            this.musicToolStripMenuItem,
            this.documentsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuitemLaunchKaraFun,
            this._separator1,
            this._menuitemExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // _menuitemLaunchKaraFun
            // 
            this._menuitemLaunchKaraFun.Image = global::Karaokidex.Properties.Resources.KaraFun_16x16x32;
            this._menuitemLaunchKaraFun.Name = "_menuitemLaunchKaraFun";
            this._menuitemLaunchKaraFun.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this._menuitemLaunchKaraFun.Size = new System.Drawing.Size(178, 22);
            this._menuitemLaunchKaraFun.Text = "Launch &KaraFun";
            // 
            // _separator1
            // 
            this._separator1.Name = "_separator1";
            this._separator1.Size = new System.Drawing.Size(175, 6);
            // 
            // _menuitemExit
            // 
            this._menuitemExit.Image = global::Karaokidex.Properties.Resources.door_in;
            this._menuitemExit.Name = "_menuitemExit";
            this._menuitemExit.Size = new System.Drawing.Size(178, 22);
            this._menuitemExit.Text = "E&xit";
            // 
            // karaokeToolStripMenuItem
            // 
            this.karaokeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuitemOpenKaraokeDatabase,
            this._menuitemCreateKaraokeDatabase,
            this._menuitemRefreshKaraokeDatabase,
            this._separator2,
            this._menuitemListInvalidKaraokeTracks});
            this.karaokeToolStripMenuItem.Name = "karaokeToolStripMenuItem";
            this.karaokeToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.karaokeToolStripMenuItem.Text = "K&araoke";
            // 
            // _menuitemOpenKaraokeDatabase
            // 
            this._menuitemOpenKaraokeDatabase.Image = global::Karaokidex.Properties.Resources.database_connect;
            this._menuitemOpenKaraokeDatabase.Name = "_menuitemOpenKaraokeDatabase";
            this._menuitemOpenKaraokeDatabase.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this._menuitemOpenKaraokeDatabase.Size = new System.Drawing.Size(186, 22);
            this._menuitemOpenKaraokeDatabase.Text = "&Open Database";
            // 
            // _menuitemCreateKaraokeDatabase
            // 
            this._menuitemCreateKaraokeDatabase.Image = global::Karaokidex.Properties.Resources.database_lightning;
            this._menuitemCreateKaraokeDatabase.Name = "_menuitemCreateKaraokeDatabase";
            this._menuitemCreateKaraokeDatabase.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this._menuitemCreateKaraokeDatabase.Size = new System.Drawing.Size(186, 22);
            this._menuitemCreateKaraokeDatabase.Text = "&Create Database";
            // 
            // _menuitemRefreshKaraokeDatabase
            // 
            this._menuitemRefreshKaraokeDatabase.Image = global::Karaokidex.Properties.Resources.database_refresh;
            this._menuitemRefreshKaraokeDatabase.Name = "_menuitemRefreshKaraokeDatabase";
            this._menuitemRefreshKaraokeDatabase.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this._menuitemRefreshKaraokeDatabase.Size = new System.Drawing.Size(186, 22);
            this._menuitemRefreshKaraokeDatabase.Text = "&Refresh Database";
            // 
            // _separator2
            // 
            this._separator2.Name = "_separator2";
            this._separator2.Size = new System.Drawing.Size(183, 6);
            // 
            // _menuitemListInvalidKaraokeTracks
            // 
            this._menuitemListInvalidKaraokeTracks.Image = global::Karaokidex.Properties.Resources.page_white_delete;
            this._menuitemListInvalidKaraokeTracks.Name = "_menuitemListInvalidKaraokeTracks";
            this._menuitemListInvalidKaraokeTracks.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this._menuitemListInvalidKaraokeTracks.Size = new System.Drawing.Size(186, 22);
            this._menuitemListInvalidKaraokeTracks.Text = "List &Invalid Tracks";
            // 
            // musicToolStripMenuItem
            // 
            this.musicToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuitemOpenMusicDatabase,
            this._menuitemCreateMusicDatabase,
            this._menuitemRefreshMusicDatabase});
            this.musicToolStripMenuItem.Name = "musicToolStripMenuItem";
            this.musicToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.musicToolStripMenuItem.Text = "M&usic";
            // 
            // _menuitemOpenMusicDatabase
            // 
            this._menuitemOpenMusicDatabase.Image = global::Karaokidex.Properties.Resources.database_connect;
            this._menuitemOpenMusicDatabase.Name = "_menuitemOpenMusicDatabase";
            this._menuitemOpenMusicDatabase.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F2)));
            this._menuitemOpenMusicDatabase.Size = new System.Drawing.Size(206, 22);
            this._menuitemOpenMusicDatabase.Text = "&Open Database";
            // 
            // _menuitemCreateMusicDatabase
            // 
            this._menuitemCreateMusicDatabase.Image = global::Karaokidex.Properties.Resources.database_lightning;
            this._menuitemCreateMusicDatabase.Name = "_menuitemCreateMusicDatabase";
            this._menuitemCreateMusicDatabase.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F3)));
            this._menuitemCreateMusicDatabase.Size = new System.Drawing.Size(206, 22);
            this._menuitemCreateMusicDatabase.Text = "&Create Database";
            // 
            // _menuitemRefreshMusicDatabase
            // 
            this._menuitemRefreshMusicDatabase.Image = global::Karaokidex.Properties.Resources.database_refresh;
            this._menuitemRefreshMusicDatabase.Name = "_menuitemRefreshMusicDatabase";
            this._menuitemRefreshMusicDatabase.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this._menuitemRefreshMusicDatabase.Size = new System.Drawing.Size(206, 22);
            this._menuitemRefreshMusicDatabase.Text = "&Refresh Database";
            // 
            // documentsToolStripMenuItem
            // 
            this.documentsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuitemOpenKaraokeRequestSheet,
            this._menuitemCreateKaraokeTrackCatalogue});
            this.documentsToolStripMenuItem.Name = "documentsToolStripMenuItem";
            this.documentsToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.documentsToolStripMenuItem.Text = "&Documents";
            // 
            // _menuitemOpenKaraokeRequestSheet
            // 
            this._menuitemOpenKaraokeRequestSheet.Image = global::Karaokidex.Properties.Resources.page_white_acrobat;
            this._menuitemOpenKaraokeRequestSheet.Name = "_menuitemOpenKaraokeRequestSheet";
            this._menuitemOpenKaraokeRequestSheet.ShortcutKeys = System.Windows.Forms.Keys.F7;
            this._menuitemOpenKaraokeRequestSheet.Size = new System.Drawing.Size(261, 22);
            this._menuitemOpenKaraokeRequestSheet.Text = "&Open Karaoke Request Sheet";
            // 
            // _menuitemCreateKaraokeTrackCatalogue
            // 
            this._menuitemCreateKaraokeTrackCatalogue.Enabled = false;
            this._menuitemCreateKaraokeTrackCatalogue.Image = global::Karaokidex.Properties.Resources.page_white_text;
            this._menuitemCreateKaraokeTrackCatalogue.Name = "_menuitemCreateKaraokeTrackCatalogue";
            this._menuitemCreateKaraokeTrackCatalogue.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this._menuitemCreateKaraokeTrackCatalogue.Size = new System.Drawing.Size(261, 22);
            this._menuitemCreateKaraokeTrackCatalogue.Text = "&Create Karaoke Track Catalogue";
            // 
            // MainView
            // 
            this.AcceptButton = this._buttonSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 284);
            this.Controls.Add(this._SplitContainer);
            this.Controls.Add(this._StatusStrip);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainView";
            this.Text = "Karaokidex";
            this._StatusStrip.ResumeLayout(false);
            this._StatusStrip.PerformLayout();
            this._SplitContainer.Panel1.ResumeLayout(false);
            this._SplitContainer.Panel1.PerformLayout();
            this._SplitContainer.Panel2.ResumeLayout(false);
            this._SplitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._gridResults)).EndInit();
            this._ContextMenuStrip.ResumeLayout(false);
            this._TableLayoutPanel.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip _StatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel _labelKaraokeDatabase;
        private System.Windows.Forms.SplitContainer _SplitContainer;
        private System.Windows.Forms.DataGridView _gridResults;
        private System.Windows.Forms.ContextMenuStrip _ContextMenuStrip;
        private System.Windows.Forms.ToolStripStatusLabel _labelResults;
        private System.Windows.Forms.ToolStripMenuItem _menuitemEnqueueInKaraFun;
        private System.Windows.Forms.ToolStripMenuItem _menuitemPlayInKaraFun;
        private System.Windows.Forms.TableLayoutPanel _TableLayoutPanel;
        private System.Windows.Forms.Button _buttonOpenContainingFolder;
        private System.Windows.Forms.Label _labelSelectedTrackPath;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem _menuitemEditTrackRating;
        private System.Windows.Forms.DataGridViewTextBoxColumn _columnID;
        private System.Windows.Forms.DataGridViewImageColumn _columnImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn _columnTrack;
        private System.Windows.Forms.DataGridViewImageColumn _columnRatingImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn _columnRating;
        private System.Windows.Forms.DataGridViewTextBoxColumn _columnPath;
        private System.Windows.Forms.DataGridViewTextBoxColumn _columnFullPath;
        private System.Windows.Forms.ToolStripMenuItem _menuitemMarkTrackAsInvalid;
        private System.Windows.Forms.CheckBox _checkboxShowOnlyRatedTracks;
        private System.Windows.Forms.TextBox _textboxCriteria;
        private System.Windows.Forms.Label _labelCriteria;
        private System.Windows.Forms.Button _buttonSearch;
        private System.Windows.Forms.Button _buttonClear;
        private System.Windows.Forms.ToolStripStatusLabel _labelVersion;
        private System.Windows.Forms.SaveFileDialog _SaveFileDialog;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem karaokeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _menuitemOpenKaraokeDatabase;
        private System.Windows.Forms.ToolStripMenuItem _menuitemCreateKaraokeDatabase;
        private System.Windows.Forms.ToolStripMenuItem _menuitemRefreshKaraokeDatabase;
        private System.Windows.Forms.ToolStripSeparator _separator2;
        private System.Windows.Forms.ToolStripMenuItem _menuitemListInvalidKaraokeTracks;
        private System.Windows.Forms.ToolStripMenuItem musicToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _menuitemOpenMusicDatabase;
        private System.Windows.Forms.ToolStripMenuItem _menuitemCreateMusicDatabase;
        private System.Windows.Forms.ToolStripMenuItem _menuitemRefreshMusicDatabase;
        private System.Windows.Forms.ToolStripMenuItem documentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _menuitemOpenKaraokeRequestSheet;
        private System.Windows.Forms.ToolStripMenuItem _menuitemCreateKaraokeTrackCatalogue;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _menuitemLaunchKaraFun;
        private System.Windows.Forms.ToolStripSeparator _separator1;
        private System.Windows.Forms.ToolStripMenuItem _menuitemExit;
        private System.Windows.Forms.ToolStripStatusLabel _labelMusicDatabase;
        private System.Windows.Forms.RadioButton _radioSearchKaraokeDatabase;
        private System.Windows.Forms.RadioButton _radioSearchMusicDatabase;
    }
}