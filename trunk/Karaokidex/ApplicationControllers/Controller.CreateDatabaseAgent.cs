using System;

namespace Karaokidex.ApplicationControllers
{
    public partial class Controller
    {
        #region Event Handlers
        private void CreateDatabaseAgent_Inserting(
            object sender, 
            EventArgs e)
        {
            ICreateDatabaseAgent theAgent =
                sender as ICreateDatabaseAgent;

            this.OnCreateDatabaseAgentInserting(
                theAgent.CallingView,
                theAgent.CurrentFileInfo);
        }

        private void CreateDatabaseAgent_Updating(
            object sender,
            EventArgs e)
        {
            ICreateDatabaseAgent theAgent =
                sender as ICreateDatabaseAgent;

            this.OnCreateDatabaseAgentUpdating(
                theAgent.CallingView,
                theAgent.CurrentFileInfo);
        }
        
        private void CreateDatabaseAgent_Completed(
            object sender,
            EventArgs e)
        {
            ICreateDatabaseAgent theAgent =
                sender as ICreateDatabaseAgent;

            this.OnCreateDatabaseAgentCompleted(
                theAgent.CallingView);
        }
        #endregion
    }
}
