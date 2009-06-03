using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Karaokidex.Views
{
    public partial class AboutView : Form
    {
        #region Properties
        public Label textVersion
        {
            get { return this._textVersion; }
        }

        public Label textKaraokeDatabasePath
        {
            get { return this._textKaraokeDatabasePath; }
        }

        public Label textKaraokeDatabaseTrackCount
        {
            get { return this._textKaraokeDatabaseTrackCount; }
        }

        public Label textMusicDatabasePath
        {
            get { return this._textMusicDatabasePath; }
        }

        public Label textMusicDatabaseTrackCount
        {
            get { return this._textMusicDatabaseTrackCount; }
        }
        #endregion

        #region Methods
        public AboutView()
        {
            InitializeComponent();
        }
        #endregion
    }
}
