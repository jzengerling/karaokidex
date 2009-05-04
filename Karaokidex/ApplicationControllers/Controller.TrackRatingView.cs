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
            string theTrackChecksum,
            TrackRating theTrackRating)
        {
            // Instantiate an instance
            TrackRatingView theView = new TrackRatingView();

            theView.buttonOK.Click +=
                new EventHandler(TrackRatingView_buttonOK_Click);

            theView.TrackChecksum = theTrackChecksum;

            switch (theTrackRating)
            {
                case TrackRating.OneStar:
                    theView.radio1Star.Checked = true;
                    break;
                case TrackRating.TwoStar:
                    theView.radio2Star.Checked = true;
                    break;
                case TrackRating.ThreeStar:
                    theView.radio3Star.Checked = true;
                    break;
                case TrackRating.FourStar:
                    theView.radio4star.Checked = true;
                    break;
                case TrackRating.FiveStar:
                    theView.radio5star.Checked = true;
                    break;
                default:
                    theView.radioUnrated.Checked = true;
                    break;
            }
            
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

            if (theParentView.radio1Star.Checked)
            {
                DatabaseLayer.UpdateTrackRating(
                    theParentView.TrackChecksum, 1);
            }
            else if (theParentView.radio2Star.Checked)
            {
                DatabaseLayer.UpdateTrackRating(
                    theParentView.TrackChecksum, 2);
            }
            else if (theParentView.radio3Star.Checked)
            {
                DatabaseLayer.UpdateTrackRating(
                    theParentView.TrackChecksum, 3);
            }
            else if (theParentView.radio4star.Checked)
            {
                DatabaseLayer.UpdateTrackRating(
                    theParentView.TrackChecksum, 4);
            }
            else if (theParentView.radio5star.Checked)
            {
                DatabaseLayer.UpdateTrackRating(
                    theParentView.TrackChecksum, 5);
            }
            else if (theParentView.radioUnrated.Checked)
            {
                DatabaseLayer.UpdateTrackRating(
                    theParentView.TrackChecksum, 0);
            }

            this.MainView_buttonSearch_Click(
                this._MainView.buttonSearch,
                new EventArgs());

            theParentView.Close();
        }
        #endregion
        #endregion
    }
}
