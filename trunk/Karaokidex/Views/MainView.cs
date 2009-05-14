using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Karaokidex.Views
{
    public partial class MainView : Form
    {
        #region Constants
        private const int SNAP_OFFSET = 30;
        private const int WM_WINDOWPOSCHANGING = 70;
        #endregion

        #region Structs
        [StructLayout(LayoutKind.Sequential)]
        public struct WINDOWPOS
        {
            public IntPtr hwnd;
            public IntPtr hwndInsertAfter;
            public int x;
            public int y;
            public int cx;
            public int cy;
            public int flags;
        }
        #endregion

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

        public ToolStripButton buttonListInvalidTracks
        {
            get { return this._buttonListInvalidTracks; }
        }

        public ToolStripButton buttonKaraFun
        {
            get { return this._buttonKaraFun; }
        }

        public ToolStripButton buttonOpenKaraokeRequestSheet
        {
            get { return this._buttonOpenKaraokeRequestSheet; }
        }

        public ToolStripButton buttonExit
        {
            get { return this._buttonExit; }
        }

        public Button buttonSearch
        {
            get { return this._buttonSearch; }
        }

        public Button buttonClear
        {
            get { return this._buttonClear; }
        }

        public TextBox textboxCriteria
        {
            get { return this._textboxCriteria; }
        }

        public CheckBox checkboxShowOnlyRatedTracks
        {
            get { return this._checkboxShowOnlyRatedTracks; }
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

        public ToolStripMenuItem menuitemMarkTrackAsInvalid
        {
            get { return this._menuitemMarkTrackAsInvalid; }
        }

        public ToolStripLabel labelVersion
        {
            get { return this._labelVersion; }
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

        #region Snap To Border Functionality
        protected override void WndProc(
            ref Message theMessage)
        {
            switch (theMessage.Msg)
            {
                case WM_WINDOWPOSCHANGING:
                    SnapToDesktopBorder (this, theMessage.LParam, 0);
                break;
            }

            base.WndProc (ref theMessage);
        }

        public void SnapToDesktopBorder(
            Form theClientForm, 
            IntPtr LParam, 
            int theWidthAdjustment)
        {
            if (theClientForm == null)
            {
                throw new ArgumentNullException();
            }

            // Snap client to the top, left, bottom or right desktop border
            // as the form is moved near that border.
            try
            {
                // Marshal the LPARAM value which is a WINDOWPOS struct
                WINDOWPOS theNewPosition = new WINDOWPOS();
                
                theNewPosition = (WINDOWPOS)Marshal.PtrToStructure(
                    LParam, theNewPosition.GetType());

                if (theNewPosition.y.Equals(0) || theNewPosition.x.Equals(0))
                {
                    return;
                }

                // Adjust the client size for borders and caption bar
                Rectangle theClientRectangle =
                    theClientForm.RectangleToScreen(theClientForm.ClientRectangle);
                
                theClientRectangle.Width += 
                    SystemInformation.FrameBorderSize.Width - theWidthAdjustment;
                theClientRectangle.Height += 
                    SystemInformation.FrameBorderSize.Height + SystemInformation.CaptionHeight;

                // Now get the screen working area (without taskbar)
                Rectangle theWorkingRectangle = 
                    Screen.FromControl(theClientForm).WorkingArea;

                // Left border
                if (theNewPosition.x >= theWorkingRectangle.X - SNAP_OFFSET &&
                    theNewPosition.x <= theWorkingRectangle.X + SNAP_OFFSET)
                {
                    theNewPosition.x = theWorkingRectangle.X;
                }

                // Get screen bounds and taskbar height (when taskbar is horizontal)
                Rectangle theScreenRectangle = 
                    Screen.FromControl(theClientForm).Bounds;
                int theTaskBarHeight = 
                    theScreenRectangle.Height = theWorkingRectangle.Height;

                // Top border (check if taskbar is on top or bottom via WorkingRect.Y)
                if (theNewPosition.y >= -SNAP_OFFSET &&
                    (theWorkingRectangle.Y > 0 && theNewPosition.y <= (theTaskBarHeight + SNAP_OFFSET)) ||
                    (theWorkingRectangle.Y <= 0 && theNewPosition.y <= SNAP_OFFSET))
                {
                    if (theTaskBarHeight > 0)
                    {
                        theNewPosition.y = theWorkingRectangle.Y; // Horizontal Taskbar
                    }
                    else
                    {
                        theNewPosition.y = 0; // Vertical Taskbar
                    }
                }

                // Right border
                if (theNewPosition.x + theClientRectangle.Width <= theWorkingRectangle.Right + SNAP_OFFSET &&
                    theNewPosition.x + theClientRectangle.Width >= theWorkingRectangle.Right - SNAP_OFFSET)
                {
                    theNewPosition.x = 
                        theWorkingRectangle.Right - (theClientRectangle.Width + SystemInformation.FrameBorderSize.Width);
                }

                // Bottom border
                if (theNewPosition.y + theClientRectangle.Height <= theWorkingRectangle.Bottom + SNAP_OFFSET &&
                    theNewPosition.y + theClientRectangle.Height >= theWorkingRectangle.Bottom - SNAP_OFFSET)
                {
                    theNewPosition.y = 
                        theWorkingRectangle.Bottom - (theClientRectangle.Height + SystemInformation.FrameBorderSize.Height);
                }

                // Marshal it back
                Marshal.StructureToPtr(theNewPosition, LParam, true);
            }
            catch
            {
                throw;
            }
        }
        #endregion
    }
}
