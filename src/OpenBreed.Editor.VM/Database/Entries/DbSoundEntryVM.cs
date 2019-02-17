﻿using OpenBreed.Common;
using OpenBreed.Common.Sounds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBreed.Editor.VM.Database.Entries
{
    public class DbSoundEntryVM : DbEntryVM
    {
        #region Private Fields

        private ISoundEntry _entry;

        #endregion Private Fields

        #region Public Constructors

        public DbSoundEntryVM()
        {
        }

        #endregion Public Constructors

        #region Public Methods

        public override void Load(IEntry entry)
        {
            _entry = entry as ISoundEntry ?? throw new InvalidOperationException($"Expected {nameof(ISoundEntry)}");

            base.Load(entry);
        }

        #endregion Public Methods
    }
}