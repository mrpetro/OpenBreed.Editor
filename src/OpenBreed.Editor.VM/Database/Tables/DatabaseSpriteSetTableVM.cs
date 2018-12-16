﻿using OpenBreed.Common.Database;
using OpenBreed.Common.Database.Tables.Props;
using OpenBreed.Common.Database.Tables.Sprites;
using OpenBreed.Common.Database.Tables.Tiles;
using OpenBreed.Editor.VM.Database.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBreed.Editor.VM.Database.Tables
{
    public class DatabaseSpriteSetTableVM : DatabaseTableVM
    {
        #region Private Fields

        private DatabaseSpriteSetTableDef _model;

        #endregion Private Fields

        #region Public Constructors

        public DatabaseSpriteSetTableVM(DatabaseVM owner) : base(owner)
        {
        }

        #endregion Public Constructors

        #region Public Properties

        public override string Name { get { return "Sprite sets"; } }

        #endregion Public Properties

        #region Public Methods

        public override IEnumerable<DatabaseItemVM> GetItems()
        {
            foreach (var itemDef in _model.Items)
            {
                var itemVM = Owner.CreateItem(itemDef);
                itemVM.Load(itemDef);
                yield return itemVM;
            }
        }

        public override void Load(DatabaseItemDef itemDef)
        {
            _model = itemDef as DatabaseSpriteSetTableDef ?? throw new InvalidOperationException($"Expected {nameof(DatabaseSpriteSetTableDef)}");

            base.Load(itemDef);
        }

        #endregion Public Methods
    }
}
