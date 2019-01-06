﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenBreed.Common;
using OpenBreed.Common.XmlDatabase;
using OpenBreed.Common.XmlDatabase.Items.Levels;
using OpenBreed.Common.Maps;

namespace OpenBreed.Editor.VM.Database.Items
{
    public class DbLevelEntryVM : DbEntryVM
    {
        #region Private Fields

        private ILevelEntry _entry;

        #endregion Private Fields

        #region Public Constructors

        public DbLevelEntryVM(DatabaseVM owner, EntryEditorVM editor) : base(owner, editor)
        {
        }

        #endregion Public Constructors

        #region Public Methods

        public override void Load(IEntry entry)
        {
            _entry = entry as ILevelEntry ?? throw new InvalidOperationException($"Expected {nameof(ILevelEntry)}");

            base.Load(entry);     
        }

        public override void Open()
        {
            Owner.Root.LevelEditor.Load(_entry.Name);
            Owner.OpenedItem = this;
        }

        #endregion Public Methods
    }
}