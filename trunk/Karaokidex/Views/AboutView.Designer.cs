namespace Karaokidex.Views
{
    partial class AboutView
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
            this._ButtonContainer = new System.Windows.Forms.FlowLayoutPanel();
            this._buttonClose = new System.Windows.Forms.Button();
            this._groupboxKaraokeDatabase = new System.Windows.Forms.GroupBox();
            this._textKaraokeDatabaseTrackCount = new System.Windows.Forms.Label();
            this._textKaraokeDatabasePath = new System.Windows.Forms.Label();
            this._labelKaraokeDatabaseTrackCount = new System.Windows.Forms.Label();
            this._labelKaraokeDatabasePath = new System.Windows.Forms.Label();
            this._groupboxMusicDatabase = new System.Windows.Forms.GroupBox();
            this._textMusicDatabaseTrackCount = new System.Windows.Forms.Label();
            this._textMusicDatabasePath = new System.Windows.Forms.Label();
            this._labelMusicDatabaseTrackCount = new System.Windows.Forms.Label();
            this._labelMusicDatabasePath = new System.Windows.Forms.Label();
            this._labelVersion = new System.Windows.Forms.Label();
            this._textVersion = new System.Windows.Forms.Label();
            this._ButtonContainer.SuspendLayout();
            this._groupboxKaraokeDatabase.SuspendLayout();
            this._groupboxMusicDatabase.SuspendLayout();
            this.SuspendLayout();
            // 
            // _ButtonContainer
            // 
            this._ButtonContainer.BackColor = System.Drawing.SystemColors.Control;
            this._ButtonContainer.Controls.Add(this._buttonClose);
            this._ButtonContainer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._ButtonContainer.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this._ButtonContainer.Location = new System.Drawing.Point(0, 219);
            this._ButtonContainer.Name = "_ButtonContainer";
            this._ButtonContainer.Size = new System.Drawing.Size(474, 32);
            this._ButtonContainer.TabIndex = 3;
            // 
            // _buttonClose
            // 
            this._buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._buttonClose.Image = global::Karaokidex.Properties.Resources.cross;
            this._buttonClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._buttonClose.Location = new System.Drawing.Point(396, 3);
            this._buttonClose.Name = "_buttonClose";
            this._buttonClose.Size = new System.Drawing.Size(75, 27);
            this._buttonClose.TabIndex = 1;
            this._buttonClose.Text = "&Close";
            this._buttonClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._buttonClose.UseVisualStyleBackColor = true;
            // 
            // _groupboxKaraokeDatabase
            // 
            this._groupboxKaraokeDatabase.Controls.Add(this._textKaraokeDatabaseTrackCount);
            this._groupboxKaraokeDatabase.Controls.Add(this._textKaraokeDatabasePath);
            this._groupboxKaraokeDatabase.Controls.Add(this._labelKaraokeDatabaseTrackCount);
            this._groupboxKaraokeDatabase.Controls.Add(this._labelKaraokeDatabasePath);
            this._groupboxKaraokeDatabase.Location = new System.Drawing.Point(12, 39);
            this._groupboxKaraokeDatabase.Name = "_groupboxKaraokeDatabase";
            this._groupboxKaraokeDatabase.Padding = new System.Windows.Forms.Padding(8);
            this._groupboxKaraokeDatabase.Size = new System.Drawing.Size(450, 84);
            this._groupboxKaraokeDatabase.TabIndex = 4;
            this._groupboxKaraokeDatabase.TabStop = false;
            this._groupboxKaraokeDatabase.Text = "Karaoke Database";
            // 
            // _textKaraokeDatabaseTrackCount
            // 
            this._textKaraokeDatabaseTrackCount.AutoEllipsis = true;
            this._textKaraokeDatabaseTrackCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._textKaraokeDatabaseTrackCount.Location = new System.Drawing.Point(55, 52);
            this._textKaraokeDatabaseTrackCount.Margin = new System.Windows.Forms.Padding(3);
            this._textKaraokeDatabaseTrackCount.Name = "_textKaraokeDatabaseTrackCount";
            this._textKaraokeDatabaseTrackCount.Size = new System.Drawing.Size(100, 21);
            this._textKaraokeDatabaseTrackCount.TabIndex = 3;
            this._textKaraokeDatabaseTrackCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _textKaraokeDatabasePath
            // 
            this._textKaraokeDatabasePath.AutoEllipsis = true;
            this._textKaraokeDatabasePath.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._textKaraokeDatabasePath.Location = new System.Drawing.Point(55, 25);
            this._textKaraokeDatabasePath.Margin = new System.Windows.Forms.Padding(3);
            this._textKaraokeDatabasePath.Name = "_textKaraokeDatabasePath";
            this._textKaraokeDatabasePath.Size = new System.Drawing.Size(384, 21);
            this._textKaraokeDatabasePath.TabIndex = 2;
            this._textKaraokeDatabasePath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _labelKaraokeDatabaseTrackCount
            // 
            this._labelKaraokeDatabaseTrackCount.AutoSize = true;
            this._labelKaraokeDatabaseTrackCount.Location = new System.Drawing.Point(11, 56);
            this._labelKaraokeDatabaseTrackCount.Name = "_labelKaraokeDatabaseTrackCount";
            this._labelKaraokeDatabaseTrackCount.Size = new System.Drawing.Size(38, 13);
            this._labelKaraokeDatabaseTrackCount.TabIndex = 1;
            this._labelKaraokeDatabaseTrackCount.Text = "Tracks";
            // 
            // _labelKaraokeDatabasePath
            // 
            this._labelKaraokeDatabasePath.AutoSize = true;
            this._labelKaraokeDatabasePath.Location = new System.Drawing.Point(11, 29);
            this._labelKaraokeDatabasePath.Name = "_labelKaraokeDatabasePath";
            this._labelKaraokeDatabasePath.Size = new System.Drawing.Size(29, 13);
            this._labelKaraokeDatabasePath.TabIndex = 0;
            this._labelKaraokeDatabasePath.Text = "Path";
            // 
            // _groupboxMusicDatabase
            // 
            this._groupboxMusicDatabase.Controls.Add(this._textMusicDatabaseTrackCount);
            this._groupboxMusicDatabase.Controls.Add(this._textMusicDatabasePath);
            this._groupboxMusicDatabase.Controls.Add(this._labelMusicDatabaseTrackCount);
            this._groupboxMusicDatabase.Controls.Add(this._labelMusicDatabasePath);
            this._groupboxMusicDatabase.Location = new System.Drawing.Point(12, 129);
            this._groupboxMusicDatabase.Name = "_groupboxMusicDatabase";
            this._groupboxMusicDatabase.Padding = new System.Windows.Forms.Padding(8);
            this._groupboxMusicDatabase.Size = new System.Drawing.Size(450, 84);
            this._groupboxMusicDatabase.TabIndex = 5;
            this._groupboxMusicDatabase.TabStop = false;
            this._groupboxMusicDatabase.Text = "Music Database";
            // 
            // _textMusicDatabaseTrackCount
            // 
            this._textMusicDatabaseTrackCount.AutoEllipsis = true;
            this._textMusicDatabaseTrackCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._textMusicDatabaseTrackCount.Location = new System.Drawing.Point(55, 52);
            this._textMusicDatabaseTrackCount.Margin = new System.Windows.Forms.Padding(3);
            this._textMusicDatabaseTrackCount.Name = "_textMusicDatabaseTrackCount";
            this._textMusicDatabaseTrackCount.Size = new System.Drawing.Size(100, 21);
            this._textMusicDatabaseTrackCount.TabIndex = 3;
            this._textMusicDatabaseTrackCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _textMusicDatabasePath
            // 
            this._textMusicDatabasePath.AutoEllipsis = true;
            this._textMusicDatabasePath.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._textMusicDatabasePath.Location = new System.Drawing.Point(55, 25);
            this._textMusicDatabasePath.Margin = new System.Windows.Forms.Padding(3);
            this._textMusicDatabasePath.Name = "_textMusicDatabasePath";
            this._textMusicDatabasePath.Size = new System.Drawing.Size(384, 21);
            this._textMusicDatabasePath.TabIndex = 2;
            this._textMusicDatabasePath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _labelMusicDatabaseTrackCount
            // 
            this._labelMusicDatabaseTrackCount.AutoSize = true;
            this._labelMusicDatabaseTrackCount.Location = new System.Drawing.Point(11, 56);
            this._labelMusicDatabaseTrackCount.Name = "_labelMusicDatabaseTrackCount";
            this._labelMusicDatabaseTrackCount.Size = new System.Drawing.Size(38, 13);
            this._labelMusicDatabaseTrackCount.TabIndex = 1;
            this._labelMusicDatabaseTrackCount.Text = "Tracks";
            // 
            // _labelMusicDatabasePath
            // 
            this._labelMusicDatabasePath.AutoSize = true;
            this._labelMusicDatabasePath.Location = new System.Drawing.Point(11, 29);
            this._labelMusicDatabasePath.Name = "_labelMusicDatabasePath";
            this._labelMusicDatabasePath.Size = new System.Drawing.Size(29, 13);
            this._labelMusicDatabasePath.TabIndex = 0;
            this._labelMusicDatabasePath.Text = "Path";
            // 
            // _labelVersion
            // 
            this._labelVersion.AutoSize = true;
            this._labelVersion.Location = new System.Drawing.Point(9, 16);
            this._labelVersion.Name = "_labelVersion";
            this._labelVersion.Size = new System.Drawing.Size(42, 13);
            this._labelVersion.TabIndex = 4;
            this._labelVersion.Text = "Version";
            // 
            // _textVersion
            // 
            this._textVersion.AutoEllipsis = true;
            this._textVersion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._textVersion.Location = new System.Drawing.Point(67, 12);
            this._textVersion.Margin = new System.Windows.Forms.Padding(3);
            this._textVersion.Name = "_textVersion";
            this._textVersion.Size = new System.Drawing.Size(100, 21);
            this._textVersion.TabIndex = 4;
            this._textVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AboutView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this._buttonClose;
            this.ClientSize = new System.Drawing.Size(474, 251);
            this.Controls.Add(this._textVersion);
            this.Controls.Add(this._labelVersion);
            this.Controls.Add(this._groupboxMusicDatabase);
            this.Controls.Add(this._groupboxKaraokeDatabase);
            this.Controls.Add(this._ButtonContainer);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AboutView";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About";
            this._ButtonContainer.ResumeLayout(false);
            this._groupboxKaraokeDatabase.ResumeLayout(false);
            this._groupboxKaraokeDatabase.PerformLayout();
            this._groupboxMusicDatabase.ResumeLayout(false);
            this._groupboxMusicDatabase.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel _ButtonContainer;
        private System.Windows.Forms.Button _buttonClose;
        private System.Windows.Forms.GroupBox _groupboxKaraokeDatabase;
        private System.Windows.Forms.Label _labelKaraokeDatabaseTrackCount;
        private System.Windows.Forms.Label _labelKaraokeDatabasePath;
        private System.Windows.Forms.Label _textKaraokeDatabaseTrackCount;
        private System.Windows.Forms.Label _textKaraokeDatabasePath;
        private System.Windows.Forms.GroupBox _groupboxMusicDatabase;
        private System.Windows.Forms.Label _textMusicDatabaseTrackCount;
        private System.Windows.Forms.Label _textMusicDatabasePath;
        private System.Windows.Forms.Label _labelMusicDatabaseTrackCount;
        private System.Windows.Forms.Label _labelMusicDatabasePath;
        private System.Windows.Forms.Label _labelVersion;
        private System.Windows.Forms.Label _textVersion;
    }
}