namespace Karaokidex.Views
{
    partial class OpenDatabaseView
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
            this._buttonCancel = new System.Windows.Forms.Button();
            this._buttonOK = new System.Windows.Forms.Button();
            this._groupboxSourceDirectory = new System.Windows.Forms.GroupBox();
            this._textboxSourceDirectory = new System.Windows.Forms.TextBox();
            this._buttonSourceDirectory = new System.Windows.Forms.Button();
            this._FolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this._groupboxDatabaseFile = new System.Windows.Forms.GroupBox();
            this._textboxDatabaseFile = new System.Windows.Forms.TextBox();
            this._buttonDatabaseFile = new System.Windows.Forms.Button();
            this._OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this._ButtonContainer.SuspendLayout();
            this._groupboxSourceDirectory.SuspendLayout();
            this._groupboxDatabaseFile.SuspendLayout();
            this.SuspendLayout();
            // 
            // _ButtonContainer
            // 
            this._ButtonContainer.BackColor = System.Drawing.SystemColors.Control;
            this._ButtonContainer.Controls.Add(this._buttonCancel);
            this._ButtonContainer.Controls.Add(this._buttonOK);
            this._ButtonContainer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._ButtonContainer.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this._ButtonContainer.Location = new System.Drawing.Point(0, 140);
            this._ButtonContainer.Name = "_ButtonContainer";
            this._ButtonContainer.Size = new System.Drawing.Size(474, 32);
            this._ButtonContainer.TabIndex = 2;
            // 
            // _buttonCancel
            // 
            this._buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._buttonCancel.Image = global::Karaokidex.Properties.Resources.cross;
            this._buttonCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._buttonCancel.Location = new System.Drawing.Point(396, 3);
            this._buttonCancel.Name = "_buttonCancel";
            this._buttonCancel.Size = new System.Drawing.Size(75, 27);
            this._buttonCancel.TabIndex = 1;
            this._buttonCancel.Text = "&Cancel";
            this._buttonCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._buttonCancel.UseVisualStyleBackColor = true;
            // 
            // _buttonOK
            // 
            this._buttonOK.Enabled = false;
            this._buttonOK.Image = global::Karaokidex.Properties.Resources.tick;
            this._buttonOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._buttonOK.Location = new System.Drawing.Point(315, 3);
            this._buttonOK.Name = "_buttonOK";
            this._buttonOK.Size = new System.Drawing.Size(75, 27);
            this._buttonOK.TabIndex = 0;
            this._buttonOK.Text = "&OK";
            this._buttonOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._buttonOK.UseVisualStyleBackColor = true;
            // 
            // _groupboxSourceDirectory
            // 
            this._groupboxSourceDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._groupboxSourceDirectory.Controls.Add(this._textboxSourceDirectory);
            this._groupboxSourceDirectory.Controls.Add(this._buttonSourceDirectory);
            this._groupboxSourceDirectory.Location = new System.Drawing.Point(12, 76);
            this._groupboxSourceDirectory.Margin = new System.Windows.Forms.Padding(3, 3, 3, 8);
            this._groupboxSourceDirectory.Name = "_groupboxSourceDirectory";
            this._groupboxSourceDirectory.Size = new System.Drawing.Size(450, 53);
            this._groupboxSourceDirectory.TabIndex = 0;
            this._groupboxSourceDirectory.TabStop = false;
            this._groupboxSourceDirectory.Text = "Source Directory";
            // 
            // _textboxSourceDirectory
            // 
            this._textboxSourceDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._textboxSourceDirectory.Location = new System.Drawing.Point(6, 24);
            this._textboxSourceDirectory.Name = "_textboxSourceDirectory";
            this._textboxSourceDirectory.Size = new System.Drawing.Size(407, 21);
            this._textboxSourceDirectory.TabIndex = 0;
            // 
            // _buttonSourceDirectory
            // 
            this._buttonSourceDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._buttonSourceDirectory.Image = global::Karaokidex.Properties.Resources.folder;
            this._buttonSourceDirectory.Location = new System.Drawing.Point(416, 20);
            this._buttonSourceDirectory.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this._buttonSourceDirectory.Name = "_buttonSourceDirectory";
            this._buttonSourceDirectory.Size = new System.Drawing.Size(28, 27);
            this._buttonSourceDirectory.TabIndex = 1;
            this._buttonSourceDirectory.UseVisualStyleBackColor = true;
            // 
            // _groupboxDatabaseFile
            // 
            this._groupboxDatabaseFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._groupboxDatabaseFile.Controls.Add(this._textboxDatabaseFile);
            this._groupboxDatabaseFile.Controls.Add(this._buttonDatabaseFile);
            this._groupboxDatabaseFile.Location = new System.Drawing.Point(12, 12);
            this._groupboxDatabaseFile.Margin = new System.Windows.Forms.Padding(3, 3, 3, 8);
            this._groupboxDatabaseFile.Name = "_groupboxDatabaseFile";
            this._groupboxDatabaseFile.Size = new System.Drawing.Size(450, 53);
            this._groupboxDatabaseFile.TabIndex = 3;
            this._groupboxDatabaseFile.TabStop = false;
            this._groupboxDatabaseFile.Text = "Database File";
            // 
            // _textboxDatabaseFile
            // 
            this._textboxDatabaseFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._textboxDatabaseFile.Location = new System.Drawing.Point(6, 24);
            this._textboxDatabaseFile.Name = "_textboxDatabaseFile";
            this._textboxDatabaseFile.Size = new System.Drawing.Size(407, 21);
            this._textboxDatabaseFile.TabIndex = 0;
            // 
            // _buttonDatabaseFile
            // 
            this._buttonDatabaseFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._buttonDatabaseFile.Image = global::Karaokidex.Properties.Resources.page_white_text;
            this._buttonDatabaseFile.Location = new System.Drawing.Point(416, 20);
            this._buttonDatabaseFile.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this._buttonDatabaseFile.Name = "_buttonDatabaseFile";
            this._buttonDatabaseFile.Size = new System.Drawing.Size(28, 27);
            this._buttonDatabaseFile.TabIndex = 1;
            this._buttonDatabaseFile.UseVisualStyleBackColor = true;
            // 
            // _OpenFileDialog
            // 
            this._OpenFileDialog.DefaultExt = "kdb";
            this._OpenFileDialog.Filter = "Karakidex Databases|*.kdb";
            // 
            // OpenDatabaseView
            // 
            this.AcceptButton = this._buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this._buttonCancel;
            this.ClientSize = new System.Drawing.Size(474, 172);
            this.Controls.Add(this._groupboxDatabaseFile);
            this.Controls.Add(this._groupboxSourceDirectory);
            this.Controls.Add(this._ButtonContainer);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OpenDatabaseView";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Open Database";
            this._ButtonContainer.ResumeLayout(false);
            this._groupboxSourceDirectory.ResumeLayout(false);
            this._groupboxSourceDirectory.PerformLayout();
            this._groupboxDatabaseFile.ResumeLayout(false);
            this._groupboxDatabaseFile.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel _ButtonContainer;
        private System.Windows.Forms.Button _buttonOK;
        private System.Windows.Forms.Button _buttonCancel;
        private System.Windows.Forms.GroupBox _groupboxSourceDirectory;
        private System.Windows.Forms.TextBox _textboxSourceDirectory;
        private System.Windows.Forms.Button _buttonSourceDirectory;
        private System.Windows.Forms.FolderBrowserDialog _FolderBrowserDialog;
        private System.Windows.Forms.GroupBox _groupboxDatabaseFile;
        private System.Windows.Forms.TextBox _textboxDatabaseFile;
        private System.Windows.Forms.Button _buttonDatabaseFile;
        private System.Windows.Forms.OpenFileDialog _OpenFileDialog;
    }
}