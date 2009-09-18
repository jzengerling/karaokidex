using System;
using System.Windows.Forms;
using System.Globalization;
using System.IO;
using Karaokidex.Views;
using System.Diagnostics;
using System.Data;
using Karaokidex.Properties;
using System.Runtime.InteropServices;
using System.Text;
using Karaokidex.Enumerators;
using System.Drawing;
using System.Deployment.Application;

namespace Karaokidex.ApplicationControllers
{
    public partial class Controller
    {
        #region Methods
        private void AboutView_Show()
        {
            this._MainView.Cursor = Cursors.WaitCursor;

            // Instantiate an instance
            AboutView theView = new AboutView();

            if (ApplicationDeployment.IsNetworkDeployed)
            {
                ApplicationDeployment ad =
                    ApplicationDeployment.CurrentDeployment;

                theView.textVersion.Text =
                    ad.CurrentVersion.ToString();
                /*
                    String.Format(
                    CultureInfo.CurrentCulture,
                    "{0}.{1}.{2}.{3}",
                    ad.CurrentVersion.Major,
                    ad.CurrentVersion.Minor,
                    ad.CurrentVersion.Build,
                    ad.CurrentVersion.Revision);
                 */
            }
            else
            {
                theView.textVersion.Text =
                    "Not Deployed";
            }

            if (null != this._CurrentKaraokeDatabaseFileInfo)
            {
                theView.textKaraokeDatabasePath.Text =
                    this._CurrentKaraokeDatabaseFileInfo.ToString();

                theView.textKaraokeDatabaseTrackCount.Text =
                    String.Format(
                        CultureInfo.CurrentCulture,
                        "{0:N0}",
                        DatabaseLayer.GetNumberOfTracksInDatabase(
                            this._CurrentKaraokeDatabaseFileInfo));
            }

            if (null != this._CurrentMusicDatabaseFileInfo)
            {
                theView.textMusicDatabasePath.Text =
                    this._CurrentMusicDatabaseFileInfo.ToString();

                theView.textMusicDatabaseTrackCount.Text =
                    String.Format(
                        CultureInfo.CurrentCulture,
                        "{0:N0}",
                        DatabaseLayer.GetNumberOfTracksInDatabase(
                            this._CurrentMusicDatabaseFileInfo));
            }

            this._MainView.Cursor = Cursors.Default;

            theView.ShowDialog(this._MainView);
        }
        #endregion
    }
}
