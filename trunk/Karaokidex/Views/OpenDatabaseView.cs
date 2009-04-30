﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Karaokidex.Views
{
    public partial class OpenDatabaseView : Form
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

        public TextBox textboxDatabaseFile
        {
            get { return this._textboxDatabaseFile; }
        }

        public Button buttonDatabaseFile
        {
            get { return this._buttonDatabaseFile; }
        }

        public OpenFileDialog OpenFileDialog
        {
            get { return this._OpenFileDialog; }
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
        public OpenDatabaseView()
        {
            InitializeComponent();
        }

        #region Private Helpers
        public void EnableView()
        {
            this._textboxSourceDirectory.Enabled =
                this._buttonSourceDirectory.Enabled =
                this._textboxDatabaseFile.Enabled =
                this._buttonDatabaseFile.Enabled =
                this._buttonOK.Enabled =
                this._buttonCancel.Enabled =
                    true;
        }

        public void DisableView()
        {
            this._textboxSourceDirectory.Enabled =
                this._buttonSourceDirectory.Enabled =
                this._textboxDatabaseFile.Enabled =
                this._buttonDatabaseFile.Enabled =
                this._buttonOK.Enabled =
                this._buttonCancel.Enabled =
                    false;
        }
        #endregion
        #endregion
    }
}
