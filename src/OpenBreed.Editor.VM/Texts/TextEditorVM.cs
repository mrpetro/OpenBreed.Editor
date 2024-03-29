﻿using OpenBreed.Common;
using OpenBreed.Common.Data;
using OpenBreed.Common.Interface.Data;
using OpenBreed.Database.Interface;
using OpenBreed.Database.Interface.Items.Texts;
using System;

namespace OpenBreed.Editor.VM.Texts
{
    public class TextEditorVM : ParentEntryEditor<IDbText>
    {
        #region Public Constructors

        public TextEditorVM(DbEntrySubEditorFactory subEditorFactory, IWorkspaceMan workspaceMan, IDialogProvider dialogProvider) : base(subEditorFactory, workspaceMan, dialogProvider, "Text Editor")
        {
        }

        #endregion Public Constructors
    }
}