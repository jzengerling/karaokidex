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

        public ToolStripButton buttonRefreshDatabase
        {
            get { return this._buttonRefreshDatabase; }
        }

        public ToolStripButton buttonKaraFun
        {
            get { return this._buttonKaraFun; }
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

        public Label labelSelectedTrackPath
        {
            get { return this._labelSelectedTrackPath; }
        }

        public Button buttonOpenContainingFolder
        {
            get { return this._buttonOpenContainingFolder; }
        }

        public ToolStripMenuItem menuitemEnqueueInKaraFun
        {
            get { return this._menuitemEnqueueInKaraFun; }
        }

        public ToolStripMenuItem menuitemPlayInKaraFun
        {
            get { return this._menuitemPlayInKaraFun; }
        }

        public ToolStripMenuItem menuitemEditTrackRating
        {
            get { return this._menuitemEditTrackRating; }
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

            DataGridViewCellStyle theBigFontStyle = new DataGridViewCellStyle();
            theBigFontStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            theBigFontStyle.BackColor = SystemColors.Window;
            theBigFontStyle.Font = new Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            theBigFontStyle.ForeColor = SystemColors.ControlText;
            theBigFontStyle.SelectionBackColor = SystemColors.Highlight;
            theBigFontStyle.SelectionForeColor = SystemColors.HighlightText;
            theBigFontStyle.WrapMode = DataGridViewTriState.False;
            
            this._gridResults.ColumnHeadersDefaultCellStyle = 
                this._gridResults.DefaultCellStyle = 
                    theBigFontStyle;
        }
    }
}
