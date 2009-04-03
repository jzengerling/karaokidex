using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Karaokidex.Views
{
    public partial class MainView : Form
    {
        #region Properties
        public ToolStripButton buttonCreateDatabase
        {
            get { return this._buttonCreateDatabase; }
        }

        public ToolStripButton buttonOpenDatabase
        {
            get { return this._buttonOpenDatabase; }
        }

        public Button buttonSearch
        {
            get { return this._buttonSearch; }
        }

        public Button buttonExit
        {
            get { return this._buttonExit; }
        }

        public TextBox textboxCriteria
        {
            get { return this._textboxCriteria; }
        }

        public DataGridView gridResults
        {
            get { return this._gridResults; }
        }

        public ToolStripMenuItem menuitemOpenContainingFolder
        {
            get { return this._menuitemOpenContainingFolder; }
        }

        public OpenFileDialog OpenFileDialog
        {
            get { return this._OpenFileDialog; }
        }

        public ToolStripLabel labelDatabaseLocation
        {
            get { return this._labelDatabaseLocation; }
        }

        public ToolStripLabel labelTrackCount
        {
            get { return this._labelTrackCount; }
        }

        public ToolStripLabel labelResults
        {
            get { return this._labelResults; }
        }
        #endregion

        public MainView()
        {
            InitializeComponent();
        }
    }
}
