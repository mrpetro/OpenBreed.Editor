﻿using OpenBreed.Common;
using OpenBreed.Common.Data;
using OpenBreed.Database.Interface;
using OpenBreed.Database.Interface.Items.DataSources;

namespace OpenBreed.Editor.VM.DataSources
{
    public class DataSourceEditorVM : ParentEntryEditor<IDataSourceEntry>
    {
        #region Public Constructors

        public DataSourceEditorVM(DbEntrySubEditorFactory subEditorFactory, IWorkspaceMan workspaceMan, IDialogProvider dialogProvider) : base(subEditorFactory, workspaceMan, dialogProvider, "Data Source Editor")
        {
        }

        #endregion Public Constructors
    }
}