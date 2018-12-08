﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenBreed.Common.Database;
using OpenBreed.Common.Database.Items.Levels;

namespace OpenBreed.Editor.VM.Database.Items
{
    public class DatabaseLevelItemVM : DatabaseItemVM
    {
        public DatabaseLevelItemVM(DatabaseVM owner) : base(owner)
        {
        }

        public override void Load(DatabaseItemDef itemDef)
        {
            var levelDef = itemDef as LevelDef ?? throw new InvalidOperationException($"Expected {nameof(LevelDef)}");

            base.Load(itemDef);     
        }
    }
}
