﻿using OpenBreed.Common.Data;
using OpenBreed.Common.Interface.Data;
using OpenBreed.Database.Interface;
using OpenBreed.Editor.VM.Base;
using System;

namespace OpenBreed.Editor.VM.Common
{
    public class EntryRefIdEditorVM : BaseViewModel
    {
        #region Private Fields

        private readonly IWorkspaceMan workspaceMan;
        private readonly Type entryType;
        private string refId;

        #endregion Private Fields

        #region Public Constructors

        public EntryRefIdEditorVM(IWorkspaceMan workspaceMan, Type entryType)
        {
            this.workspaceMan = workspaceMan;
            this.entryType = entryType;
        }

        #endregion Public Constructors

        #region Public Properties

        public Action<string> RefIdSelected { get; set; }
        public Action<EntryRefIdSelectorVM> OpenRefIdSelectorAction { get; set; }

        public string RefId
        {
            get { return refId; }
            set { base.SetProperty(ref refId, value); }
        }

        #endregion Public Properties

        #region Public Methods

        public void SelectEntryId()
        {
            var refSelector = new EntryRefIdSelectorVM(workspaceMan, entryType);
            refSelector.CurrentEntryId = RefId;
            OpenRefIdSelectorAction?.Invoke(refSelector);

            if (refSelector.SelectedEntryId == null)
                return;

            RefId = refSelector.SelectedEntryId;
            RefIdSelected?.Invoke(RefId);
        }

        #endregion Public Methods
    }
}