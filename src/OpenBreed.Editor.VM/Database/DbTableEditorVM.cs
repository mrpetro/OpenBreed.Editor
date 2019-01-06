﻿using OpenBreed.Editor.VM.Base;
using OpenBreed.Editor.VM.Database.Items;
using OpenBreed.Editor.VM.Database.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBreed.Editor.VM.Database
{
    public class DbTableEditorVM : BaseViewModel
    {
        #region Internal Constructors

        internal DbTableEditorVM()
        {

            Items = new BindingList<DbEntryVM>();
            Items.ListChanged += (s, a) => OnPropertyChanged(nameof(Items));
        }

        #endregion Internal Constructors

        #region Public Properties

        public BindingList<DbEntryVM> Items { get; private set; }

        #endregion Public Properties


    }
}