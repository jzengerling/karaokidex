using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Karaokidex.Views
{
    public partial class TrackRatingView : Form
    {
        #region Properties
        public RadioButton radioUnrated
        {
            get { return this._radioUnrated; }
        }

        public RadioButton radio1Star
        {
            get { return this._radio1Star; }
        }

        public RadioButton radio2Star
        {
            get { return this._radio2Star; }
        }

        public RadioButton radio3Star
        {
            get { return this._radio3Star; }
        }

        public RadioButton radio4star
        {
            get { return this._radio4star; }
        }

        public RadioButton radio5star
        {
            get { return this._radio5star; }
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

        public TrackRatingView()
        {
            InitializeComponent();
        }
    }
}
