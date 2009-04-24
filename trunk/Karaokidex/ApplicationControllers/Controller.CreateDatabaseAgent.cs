using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Karaokidex.ApplicationControllers
{
    public partial class Controller
    {
        #region Event Handlers
        private void CreateDatabaseAgent_Inserting(
            object sender, 
            EventArgs e)
        {
            CreateDatabaseAgent theAgent =
                sender as CreateDatabaseAgent;

            this.OnCreateDatabaseAgentInserting(
                theAgent.CurrentFileInfo);
        }

        private void CreateDatabaseAgent_Completed(
            object sender,
            EventArgs e)
        {
            this.OnCreateDatabaseAgentCompleted();
        }
        #endregion
    }
}
