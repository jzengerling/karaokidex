namespace Karaokidex.Views
{
    partial class CreateDatabaseAgentView
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
            this._groupboxCurrentFile = new System.Windows.Forms.GroupBox();
            this._labelCurrentFile = new System.Windows.Forms.Label();
            this._groupboxCurrentDirectory = new System.Windows.Forms.GroupBox();
            this._labelCurrentDirectory = new System.Windows.Forms.Label();
            this._groupboxCurrentFile.SuspendLayout();
            this._groupboxCurrentDirectory.SuspendLayout();
            this.SuspendLayout();
            // 
            // _groupboxCurrentFile
            // 
            this._groupboxCurrentFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._groupboxCurrentFile.Controls.Add(this._labelCurrentFile);
            this._groupboxCurrentFile.Location = new System.Drawing.Point(12, 76);
            this._groupboxCurrentFile.Margin = new System.Windows.Forms.Padding(3, 3, 3, 8);
            this._groupboxCurrentFile.Name = "_groupboxCurrentFile";
            this._groupboxCurrentFile.Size = new System.Drawing.Size(450, 53);
            this._groupboxCurrentFile.TabIndex = 6;
            this._groupboxCurrentFile.TabStop = false;
            this._groupboxCurrentFile.Text = "Current File";
            // 
            // _labelCurrentFile
            // 
            this._labelCurrentFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this._labelCurrentFile.Location = new System.Drawing.Point(3, 17);
            this._labelCurrentFile.Name = "_labelCurrentFile";
            this._labelCurrentFile.Size = new System.Drawing.Size(444, 33);
            this._labelCurrentFile.TabIndex = 1;
            this._labelCurrentFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._labelCurrentFile.UseMnemonic = false;
            // 
            // _groupboxCurrentDirectory
            // 
            this._groupboxCurrentDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._groupboxCurrentDirectory.Controls.Add(this._labelCurrentDirectory);
            this._groupboxCurrentDirectory.Location = new System.Drawing.Point(12, 12);
            this._groupboxCurrentDirectory.Margin = new System.Windows.Forms.Padding(3, 3, 3, 8);
            this._groupboxCurrentDirectory.Name = "_groupboxCurrentDirectory";
            this._groupboxCurrentDirectory.Size = new System.Drawing.Size(450, 53);
            this._groupboxCurrentDirectory.TabIndex = 5;
            this._groupboxCurrentDirectory.TabStop = false;
            this._groupboxCurrentDirectory.Text = "Current Directory";
            // 
            // _labelCurrentDirectory
            // 
            this._labelCurrentDirectory.Dock = System.Windows.Forms.DockStyle.Fill;
            this._labelCurrentDirectory.Location = new System.Drawing.Point(3, 17);
            this._labelCurrentDirectory.Name = "_labelCurrentDirectory";
            this._labelCurrentDirectory.Size = new System.Drawing.Size(444, 33);
            this._labelCurrentDirectory.TabIndex = 0;
            this._labelCurrentDirectory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._labelCurrentDirectory.UseMnemonic = false;
            // 
            // CreateDatabaseAgentView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(474, 146);
            this.ControlBox = false;
            this.Controls.Add(this._groupboxCurrentFile);
            this.Controls.Add(this._groupboxCurrentDirectory);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateDatabaseAgentView";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this._groupboxCurrentFile.ResumeLayout(false);
            this._groupboxCurrentDirectory.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox _groupboxCurrentFile;
        private System.Windows.Forms.GroupBox _groupboxCurrentDirectory;
        private System.Windows.Forms.Label _labelCurrentFile;
        private System.Windows.Forms.Label _labelCurrentDirectory;
    }
}