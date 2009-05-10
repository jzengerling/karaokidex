﻿namespace Karaokidex.Views
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
            this._ToolStrip = new System.Windows.Forms.ToolStrip();
            this._buttonOpenDatabase = new System.Windows.Forms.ToolStripButton();
            this._buttonCreateDatabase = new System.Windows.Forms.ToolStripButton();
            this._buttonRefreshDatabase = new System.Windows.Forms.ToolStripButton();
            this._separator1 = new System.Windows.Forms.ToolStripSeparator();
            this._buttonListInvalidTracks = new System.Windows.Forms.ToolStripButton();
            this._separator2 = new System.Windows.Forms.ToolStripSeparator();
            this._buttonKaraFun = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this._buttonExit = new System.Windows.Forms.ToolStripButton();
            this._StatusStrip = new System.Windows.Forms.StatusStrip();
            this._labelDatabaseLocation = new System.Windows.Forms.ToolStripStatusLabel();
            this._labelTrackCount = new System.Windows.Forms.ToolStripStatusLabel();
            this._labelResults = new System.Windows.Forms.ToolStripStatusLabel();
            this._SplitContainer = new System.Windows.Forms.SplitContainer();
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
            this._ToolStrip.SuspendLayout();
            this._StatusStrip.SuspendLayout();
            this._SplitContainer.Panel1.SuspendLayout();
            this._SplitContainer.Panel2.SuspendLayout();
            this._SplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._gridResults)).BeginInit();
            this._ContextMenuStrip.SuspendLayout();
            this._TableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _ToolStrip
            // 
            this._ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._buttonOpenDatabase,
            this._buttonCreateDatabase,
            this._buttonRefreshDatabase,
            this._separator1,
            this._buttonListInvalidTracks,
            this._separator2,
            this._buttonKaraFun,
            this.toolStripSeparator1,
            this._buttonExit});
            this._ToolStrip.Location = new System.Drawing.Point(0, 0);
            this._ToolStrip.Name = "_ToolStrip";
            this._ToolStrip.Size = new System.Drawing.Size(784, 25);
            this._ToolStrip.TabIndex = 0;
            this._ToolStrip.Text = "toolStrip1";
            // 
            // _buttonOpenDatabase
            // 
            this._buttonOpenDatabase.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._buttonOpenDatabase.Image = global::Karaokidex.Properties.Resources.database_connect;
            this._buttonOpenDatabase.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._buttonOpenDatabase.Name = "_buttonOpenDatabase";
            this._buttonOpenDatabase.Size = new System.Drawing.Size(23, 22);
            this._buttonOpenDatabase.ToolTipText = "Connect to a database (F2)";
            // 
            // _buttonCreateDatabase
            // 
            this._buttonCreateDatabase.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._buttonCreateDatabase.Image = global::Karaokidex.Properties.Resources.database_lightning;
            this._buttonCreateDatabase.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._buttonCreateDatabase.Name = "_buttonCreateDatabase";
            this._buttonCreateDatabase.Size = new System.Drawing.Size(23, 22);
            this._buttonCreateDatabase.ToolTipText = "Create a database (F3)";
            // 
            // _buttonRefreshDatabase
            // 
            this._buttonRefreshDatabase.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._buttonRefreshDatabase.Enabled = false;
            this._buttonRefreshDatabase.Image = global::Karaokidex.Properties.Resources.database_refresh;
            this._buttonRefreshDatabase.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._buttonRefreshDatabase.Name = "_buttonRefreshDatabase";
            this._buttonRefreshDatabase.Size = new System.Drawing.Size(23, 22);
            this._buttonRefreshDatabase.ToolTipText = "Refresh the current database (F4)";
            // 
            // _separator1
            // 
            this._separator1.Name = "_separator1";
            this._separator1.Size = new System.Drawing.Size(6, 25);
            // 
            // _buttonListInvalidTracks
            // 
            this._buttonListInvalidTracks.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._buttonListInvalidTracks.Image = global::Karaokidex.Properties.Resources.page_white_delete;
            this._buttonListInvalidTracks.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._buttonListInvalidTracks.Name = "_buttonListInvalidTracks";
            this._buttonListInvalidTracks.Size = new System.Drawing.Size(23, 22);
            this._buttonListInvalidTracks.Text = "List invalid tracks (F5)";
            // 
            // _separator2
            // 
            this._separator2.Name = "_separator2";
            this._separator2.Size = new System.Drawing.Size(6, 25);
            // 
            // _buttonKaraFun
            // 
            this._buttonKaraFun.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._buttonKaraFun.Image = global::Karaokidex.Properties.Resources.KaraFun_16x16x32;
            this._buttonKaraFun.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._buttonKaraFun.Name = "_buttonKaraFun";
            this._buttonKaraFun.Size = new System.Drawing.Size(23, 22);
            this._buttonKaraFun.Text = "Launch KaraFun (F6)";
            this._buttonKaraFun.ToolTipText = "Launch KaraFun";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // _buttonExit
            // 
            this._buttonExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._buttonExit.Image = global::Karaokidex.Properties.Resources.door_in;
            this._buttonExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._buttonExit.Name = "_buttonExit";
            this._buttonExit.Size = new System.Drawing.Size(23, 22);
            this._buttonExit.Text = "Exit Karaokidex";
            // 
            // _StatusStrip
            // 
            this._StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._labelDatabaseLocation,
            this._labelTrackCount,
            this._labelResults});
            this._StatusStrip.Location = new System.Drawing.Point(0, 420);
            this._StatusStrip.Name = "_StatusStrip";
            this._StatusStrip.Size = new System.Drawing.Size(784, 24);
            this._StatusStrip.TabIndex = 0;
            this._StatusStrip.Text = "statusStrip1";
            // 
            // _labelDatabaseLocation
            // 
            this._labelDatabaseLocation.Name = "_labelDatabaseLocation";
            this._labelDatabaseLocation.Size = new System.Drawing.Size(116, 19);
            this._labelDatabaseLocation.Text = "No database opened";
            // 
            // _labelTrackCount
            // 
            this._labelTrackCount.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this._labelTrackCount.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this._labelTrackCount.Name = "_labelTrackCount";
            this._labelTrackCount.Size = new System.Drawing.Size(51, 19);
            this._labelTrackCount.Text = "0 tracks";
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
            this._SplitContainer.Location = new System.Drawing.Point(0, 25);
            this._SplitContainer.Name = "_SplitContainer";
            this._SplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // _SplitContainer.Panel1
            // 
            this._SplitContainer.Panel1.BackColor = System.Drawing.Color.White;
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
            this._SplitContainer.Size = new System.Drawing.Size(784, 395);
            this._SplitContainer.SplitterDistance = 64;
            this._SplitContainer.TabIndex = 0;
            this._SplitContainer.TabStop = false;
            // 
            // _checkboxShowOnlyRatedTracks
            // 
            this._checkboxShowOnlyRatedTracks.AutoSize = true;
            this._checkboxShowOnlyRatedTracks.Location = new System.Drawing.Point(103, 38);
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
            this._gridResults.Size = new System.Drawing.Size(784, 293);
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
            this._TableLayoutPanel.Location = new System.Drawing.Point(0, 293);
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
            // 
            // MainView
            // 
            this.AcceptButton = this._buttonSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 444);
            this.Controls.Add(this._SplitContainer);
            this.Controls.Add(this._StatusStrip);
            this.Controls.Add(this._ToolStrip);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "MainView";
            this.Text = "Karaokidex";
            this._ToolStrip.ResumeLayout(false);
            this._ToolStrip.PerformLayout();
            this._StatusStrip.ResumeLayout(false);
            this._StatusStrip.PerformLayout();
            this._SplitContainer.Panel1.ResumeLayout(false);
            this._SplitContainer.Panel1.PerformLayout();
            this._SplitContainer.Panel2.ResumeLayout(false);
            this._SplitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._gridResults)).EndInit();
            this._ContextMenuStrip.ResumeLayout(false);
            this._TableLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip _ToolStrip;
        private System.Windows.Forms.ToolStripButton _buttonOpenDatabase;
        private System.Windows.Forms.ToolStripButton _buttonCreateDatabase;
        private System.Windows.Forms.StatusStrip _StatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel _labelDatabaseLocation;
        private System.Windows.Forms.SplitContainer _SplitContainer;
        private System.Windows.Forms.DataGridView _gridResults;
        private System.Windows.Forms.ToolStripStatusLabel _labelTrackCount;
        private System.Windows.Forms.ContextMenuStrip _ContextMenuStrip;
        private System.Windows.Forms.ToolStripStatusLabel _labelResults;
        private System.Windows.Forms.ToolStripButton _buttonRefreshDatabase;
        private System.Windows.Forms.ToolStripMenuItem _menuitemEnqueueInKaraFun;
        private System.Windows.Forms.ToolStripMenuItem _menuitemPlayInKaraFun;
        private System.Windows.Forms.TableLayoutPanel _TableLayoutPanel;
        private System.Windows.Forms.Button _buttonOpenContainingFolder;
        private System.Windows.Forms.Label _labelSelectedTrackPath;
        private System.Windows.Forms.ToolStripSeparator _separator2;
        private System.Windows.Forms.ToolStripButton _buttonKaraFun;
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
        private System.Windows.Forms.ToolStripSeparator _separator1;
        private System.Windows.Forms.ToolStripButton _buttonListInvalidTracks;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton _buttonExit;
        private System.Windows.Forms.CheckBox _checkboxShowOnlyRatedTracks;
        private System.Windows.Forms.TextBox _textboxCriteria;
        private System.Windows.Forms.Label _labelCriteria;
        private System.Windows.Forms.Button _buttonSearch;
    }
}