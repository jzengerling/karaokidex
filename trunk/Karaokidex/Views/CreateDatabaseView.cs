using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Karaokidex.Views
{
    public partial class CreateDatabaseView : Form
    {
        #region Properties
        public TextBox textboxSourceDirectory
        {
            get { return this._textboxSourceDirectory; }
        }

        public Button buttonSourceDirectory
        {
            get { return this._buttonSourceDirectory; }
        }

        public FolderBrowserDialog FolderBrowserDialog
        {
            get { return this._FolderBrowserDialog; }
        }

        public TextBox textboxTargetFile
        {
            get { return this._textboxTargetFile; }
        }

        public Button buttonTargetFile
        {
            get { return this._buttonTargetFile; }
        }

        public SaveFileDialog SaveFileDialog
        {
            get { return this._SaveFileDialog; }
        }

        public Label labelProgressCaption
        {
            get { return this._labelProgressCaption; }
        }

        public Button buttonOK
        {
            get { return this._buttonOK; }
        }

        public Button buttonCancel
        {
            get { return this._buttonCancel; }
        }
        #endregion

        #region Methods
        public CreateDatabaseView()
        {
            InitializeComponent();
        }

        #region Private Helpers
        public void EnableView()
        {
            this._textboxSourceDirectory.Enabled =
                this._buttonSourceDirectory.Enabled =
                this._textboxTargetFile.Enabled =
                this._buttonTargetFile.Enabled =
                this._buttonOK.Enabled =
                this._buttonCancel.Enabled =
                    true;
        }

        public void DisableView()
        {
            this._textboxSourceDirectory.Enabled =
                this._buttonSourceDirectory.Enabled =
                this._textboxTargetFile.Enabled =
                this._buttonTargetFile.Enabled =
                this._buttonOK.Enabled =
                this._buttonCancel.Enabled =
                    false;
        }
        #endregion
        #endregion
    }
}
