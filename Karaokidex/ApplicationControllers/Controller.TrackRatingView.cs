using System;
using System.Windows.Forms;
using System.IO;
using Karaokidex.Views;
using System.Drawing;
using System.Threading;
using Karaokidex.Enumerators;

namespace Karaokidex.ApplicationControllers
{
    public partial class Controller
    {
        #region Methods
        private void TrackRatingView_Show(
            string theTrackChecksum)
        {
            // Instantiate an instance
            TrackRatingView theView = new TrackRatingView();

            theView.buttonOK.Click +=
                new EventHandler(TrackRatingView_buttonOK_Click);

            // Show the form
            theView.ShowDialog(this._MainView);
        }

        #region Event Handlers
        private void TrackRatingView_buttonOK_Click(
            object sender, 
            EventArgs e)
        {
            Button theOKButton =
                sender as Button;
            TrackRatingView theParentView =
                theOKButton.FindForm() as TrackRatingView;
        }
        #endregion
        #endregion
    }
}
