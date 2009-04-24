using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Karaokidex.Views
{
    public partial class CreateDatabaseAgentView : Form
    {
        #region Members
        private DirectoryInfo _SourceDirectoryInfo;
        private FileInfo _TargetFileInfo;
        #endregion

        #region Properties
        public DirectoryInfo SourceDirectoryInfo
        {
            get { return this._SourceDirectoryInfo; }
            set { this._SourceDirectoryInfo = value; }
        }

        public FileInfo TargetFileInfo
        {
            get { return this._TargetFileInfo; }
            set { this._TargetFileInfo = value; }
        }

        public Label labelCurrentDirectory
        {
            get { return this._labelCurrentDirectory; }
        }

        public Label labelCurrentFile
        {
            get { return this._labelCurrentFile; }
        }
        #endregion

        #region Methods
        public CreateDatabaseAgentView(
            DirectoryInfo theSourceDirectoryInfo,
            FileInfo theTargetFileInfo)
        {
            InitializeComponent();

            this._SourceDirectoryInfo = theSourceDirectoryInfo;
            this._TargetFileInfo = theTargetFileInfo;
        }
        #endregion
    }
}
