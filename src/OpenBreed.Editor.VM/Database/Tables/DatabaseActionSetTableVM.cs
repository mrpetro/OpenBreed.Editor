﻿using OpenBreed.Common;
using OpenBreed.Common.Actions;
using OpenBreed.Editor.VM.Database.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBreed.Editor.VM.Database.Tables
{
    public class DatabaseActionSetTableVM : DbTableVM
    {
        #region Private Fields

        private IRepository<IActionSetEntry> _repository;

        #endregion Private Fields

        #region Public Constructors

        public DatabaseActionSetTableVM()
        {
        }

        #endregion Public Constructors

        #region Public Properties

        public override string Name { get { return "Action sets"; } }

        #endregion Public Properties

        #region Public Methods

        public override void Load(IRepository repository)
        {
            _repository = repository as IRepository<IActionSetEntry> ?? throw new InvalidOperationException($"Expected {nameof(IRepository<IActionSetEntry>)}");
        }

        #endregion Public Methods
    }
}