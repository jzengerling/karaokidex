using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data.SQLite;
using Karaokidex.Views;

namespace Karaokidex
{
    public interface ICreateDatabaseAgent
    {
        CreateDatabaseAgentView CallingView { get; }
        DirectoryInfo CurrentDirectoryInfo { get; }
        FileInfo CurrentFileInfo { get; }

        void Start();

        event EventHandler Inserting;
        event EventHandler Updating;
        event EventHandler Completed;
    }
}
