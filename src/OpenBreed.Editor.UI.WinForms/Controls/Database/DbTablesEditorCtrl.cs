﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenBreed.Editor.VM.Database;

namespace OpenBreed.Editor.UI.WinForms.Controls.Database
{
    public partial class DbTablesEditorCtrl : UserControl
    {
        #region Private Fields

        private DbTablesEditorVM _vm;

        #endregion Private Fields

        #region Public Constructors

        public DbTablesEditorCtrl()
        {
            InitializeComponent();
        }

        #endregion Public Constructors

        #region Public Methods

        public void Initialize(DbTablesEditorVM vm)
        {
            _vm = vm;

            TableSelector.Initialize(_vm.DbTableSelector);
            TableEditor.Initialize(_vm.DbTableEditor);
        }

        #endregion Public Methods
    }
}
