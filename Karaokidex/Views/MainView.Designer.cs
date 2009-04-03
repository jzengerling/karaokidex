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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            this._ToolStrip = new System.Windows.Forms.ToolStrip();
            this._buttonOpenDatabase = new System.Windows.Forms.ToolStripButton();
            this._buttonCreateDatabase = new System.Windows.Forms.ToolStripButton();
            this._StatusStrip = new System.Windows.Forms.StatusStrip();
            this._labelDatabaseLocation = new System.Windows.Forms.ToolStripStatusLabel();
            this._labelTrackCount = new System.Windows.Forms.ToolStripStatusLabel();
            this._labelResults = new System.Windows.Forms.ToolStripStatusLabel();
            this._OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this._SplitContainer = new System.Windows.Forms.SplitContainer();
            this._groupboxCriteria = new System.Windows.Forms.GroupBox();
            this._textboxCriteria = new System.Windows.Forms.TextBox();
            this._labelCriteria = new System.Windows.Forms.Label();
            this._ButtonContainer = new System.Windows.Forms.FlowLayoutPanel();
            this._buttonExit = new System.Windows.Forms.Button();
            this._buttonSearch = new System.Windows.Forms.Button();
            this._gridResults = new System.Windows.Forms.DataGridView();
            this._columnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._columnImage = new System.Windows.Forms.DataGridViewImageColumn();
            this._columnTrack = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._columnPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._menuitemOpenContainingFolder = new System.Windows.Forms.ToolStripMenuItem();
            this._ToolStrip.SuspendLayout();
            this._StatusStrip.SuspendLayout();
            this._SplitContainer.Panel1.SuspendLayout();
            this._SplitContainer.Panel2.SuspendLayout();
            this._SplitContainer.SuspendLayout();
            this._groupboxCriteria.SuspendLayout();
            this._ButtonContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._gridResults)).BeginInit();
            this._ContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // _ToolStrip
            // 
            this._ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._buttonOpenDatabase,
            this._buttonCreateDatabase});
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
            // 
            // _buttonCreateDatabase
            // 
            this._buttonCreateDatabase.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._buttonCreateDatabase.Image = global::Karaokidex.Properties.Resources.database_lightning;
            this._buttonCreateDatabase.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._buttonCreateDatabase.Name = "_buttonCreateDatabase";
            this._buttonCreateDatabase.Size = new System.Drawing.Size(23, 22);
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
            this._labelDatabaseLocation.Size = new System.Drawing.Size(0, 19);
            // 
            // _labelTrackCount
            // 
            this._labelTrackCount.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this._labelTrackCount.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this._labelTrackCount.Name = "_labelTrackCount";
            this._labelTrackCount.Size = new System.Drawing.Size(4, 19);
            // 
            // _labelResults
            // 
            this._labelResults.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this._labelResults.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this._labelResults.Name = "_labelResults";
            this._labelResults.Size = new System.Drawing.Size(54, 19);
            this._labelResults.Text = "0 results";
            // 
            // _OpenFileDialog
            // 
            this._OpenFileDialog.DefaultExt = "kdb";
            this._OpenFileDialog.Filter = "Database files (*.kdb)|*.kdb";
            // 
            // _SplitContainer
            // 
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
            this._SplitContainer.Panel1.Controls.Add(this._groupboxCriteria);
            this._SplitContainer.Panel1.Controls.Add(this._ButtonContainer);
            // 
            // _SplitContainer.Panel2
            // 
            this._SplitContainer.Panel2.Controls.Add(this._gridResults);
            this._SplitContainer.Size = new System.Drawing.Size(784, 395);
            this._SplitContainer.SplitterDistance = 108;
            this._SplitContainer.TabIndex = 0;
            this._SplitContainer.TabStop = false;
            // 
            // _groupboxCriteria
            // 
            this._groupboxCriteria.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._groupboxCriteria.Controls.Add(this._textboxCriteria);
            this._groupboxCriteria.Controls.Add(this._labelCriteria);
            this._groupboxCriteria.Location = new System.Drawing.Point(12, 12);
            this._groupboxCriteria.Margin = new System.Windows.Forms.Padding(3, 3, 3, 8);
            this._groupboxCriteria.Name = "_groupboxCriteria";
            this._groupboxCriteria.Size = new System.Drawing.Size(760, 54);
            this._groupboxCriteria.TabIndex = 0;
            this._groupboxCriteria.TabStop = false;
            this._groupboxCriteria.Text = "Criteria";
            // 
            // _textboxCriteria
            // 
            this._textboxCriteria.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._textboxCriteria.Location = new System.Drawing.Point(75, 20);
            this._textboxCriteria.Name = "_textboxCriteria";
            this._textboxCriteria.Size = new System.Drawing.Size(679, 21);
            this._textboxCriteria.TabIndex = 1;
            // 
            // _labelCriteria
            // 
            this._labelCriteria.AutoSize = true;
            this._labelCriteria.Location = new System.Drawing.Point(6, 23);
            this._labelCriteria.Name = "_labelCriteria";
            this._labelCriteria.Size = new System.Drawing.Size(63, 13);
            this._labelCriteria.TabIndex = 0;
            this._labelCriteria.Text = "Artist / Title";
            // 
            // _ButtonContainer
            // 
            this._ButtonContainer.BackColor = System.Drawing.SystemColors.Control;
            this._ButtonContainer.Controls.Add(this._buttonExit);
            this._ButtonContainer.Controls.Add(this._buttonSearch);
            this._ButtonContainer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._ButtonContainer.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this._ButtonContainer.Location = new System.Drawing.Point(0, 76);
            this._ButtonContainer.Name = "_ButtonContainer";
            this._ButtonContainer.Size = new System.Drawing.Size(784, 32);
            this._ButtonContainer.TabIndex = 0;
            // 
            // _buttonExit
            // 
            this._buttonExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._buttonExit.Image = global::Karaokidex.Properties.Resources.door_in;
            this._buttonExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._buttonExit.Location = new System.Drawing.Point(706, 3);
            this._buttonExit.Name = "_buttonExit";
            this._buttonExit.Size = new System.Drawing.Size(75, 27);
            this._buttonExit.TabIndex = 3;
            this._buttonExit.Text = "E&xit";
            this._buttonExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._buttonExit.UseVisualStyleBackColor = true;
            // 
            // _buttonSearch
            // 
            this._buttonSearch.Enabled = false;
            this._buttonSearch.Image = global::Karaokidex.Properties.Resources.find;
            this._buttonSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._buttonSearch.Location = new System.Drawing.Point(625, 3);
            this._buttonSearch.Name = "_buttonSearch";
            this._buttonSearch.Size = new System.Drawing.Size(75, 27);
            this._buttonSearch.TabIndex = 2;
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
            this._gridResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._columnID,
            this._columnImage,
            this._columnTrack,
            this._columnPath});
            this._gridResults.ContextMenuStrip = this._ContextMenuStrip;
            this._gridResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this._gridResults.Location = new System.Drawing.Point(0, 0);
            this._gridResults.Name = "_gridResults";
            this._gridResults.ReadOnly = true;
            this._gridResults.RowHeadersVisible = false;
            this._gridResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._gridResults.Size = new System.Drawing.Size(784, 283);
            this._gridResults.TabIndex = 0;
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
            this._columnTrack.HeaderText = "Track";
            this._columnTrack.Name = "_columnTrack";
            this._columnTrack.ReadOnly = true;
            // 
            // _columnPath
            // 
            this._columnPath.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this._columnPath.DataPropertyName = "Path";
            this._columnPath.HeaderText = "Path";
            this._columnPath.Name = "_columnPath";
            this._columnPath.ReadOnly = true;
            // 
            // _ContextMenuStrip
            // 
            this._ContextMenuStrip.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuitemOpenContainingFolder});
            this._ContextMenuStrip.Name = "_ContextMenuStrip";
            this._ContextMenuStrip.Size = new System.Drawing.Size(219, 26);
            // 
            // _menuitemOpenContainingFolder
            // 
            this._menuitemOpenContainingFolder.Enabled = false;
            this._menuitemOpenContainingFolder.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._menuitemOpenContainingFolder.Name = "_menuitemOpenContainingFolder";
            this._menuitemOpenContainingFolder.Size = new System.Drawing.Size(218, 22);
            this._menuitemOpenContainingFolder.Text = "&Open Containing Folder";
            // 
            // MainView
            // 
            this.AcceptButton = this._buttonSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._buttonExit;
            this.ClientSize = new System.Drawing.Size(784, 444);
            this.Controls.Add(this._SplitContainer);
            this.Controls.Add(this._StatusStrip);
            this.Controls.Add(this._ToolStrip);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainView";
            this.Text = "Karaokidex 2";
            this._ToolStrip.ResumeLayout(false);
            this._ToolStrip.PerformLayout();
            this._StatusStrip.ResumeLayout(false);
            this._StatusStrip.PerformLayout();
            this._SplitContainer.Panel1.ResumeLayout(false);
            this._SplitContainer.Panel2.ResumeLayout(false);
            this._SplitContainer.ResumeLayout(false);
            this._groupboxCriteria.ResumeLayout(false);
            this._groupboxCriteria.PerformLayout();
            this._ButtonContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._gridResults)).EndInit();
            this._ContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip _ToolStrip;
        private System.Windows.Forms.ToolStripButton _buttonOpenDatabase;
        private System.Windows.Forms.ToolStripButton _buttonCreateDatabase;
        private System.Windows.Forms.StatusStrip _StatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel _labelDatabaseLocation;
        private System.Windows.Forms.OpenFileDialog _OpenFileDialog;
        private System.Windows.Forms.SplitContainer _SplitContainer;
        private System.Windows.Forms.GroupBox _groupboxCriteria;
        private System.Windows.Forms.TextBox _textboxCriteria;
        private System.Windows.Forms.Label _labelCriteria;
        private System.Windows.Forms.FlowLayoutPanel _ButtonContainer;
        private System.Windows.Forms.Button _buttonSearch;
        private System.Windows.Forms.DataGridView _gridResults;
        private System.Windows.Forms.ToolStripStatusLabel _labelTrackCount;
        private System.Windows.Forms.Button _buttonExit;
        private System.Windows.Forms.ContextMenuStrip _ContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem _menuitemOpenContainingFolder;
        private System.Windows.Forms.DataGridViewTextBoxColumn _columnID;
        private System.Windows.Forms.DataGridViewImageColumn _columnImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn _columnTrack;
        private System.Windows.Forms.DataGridViewTextBoxColumn _columnPath;
        private System.Windows.Forms.ToolStripStatusLabel _labelResults;
    }
}