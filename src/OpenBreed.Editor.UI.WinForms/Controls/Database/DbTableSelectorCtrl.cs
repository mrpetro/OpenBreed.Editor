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
    public partial class DbTableSelectorCtrl : UserControl
    {
        private DbTableSelectorVM _vm;

        public DbTableSelectorCtrl()
        {
            InitializeComponent();

            cbxTables.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        internal void Initialize(DbTableSelectorVM vm)
        {
            _vm = vm;

            cbxTables.DataBindings.Clear();
            cbxTables.DataSource = _vm.Items;
            cbxTables.DisplayMember = "Name";
            cbxTables.DataBindings.Add(nameof(cbxTables.SelectedIndex), _vm, nameof(_vm.CurrentIndex), false, DataSourceUpdateMode.OnPropertyChanged);
        }
    }
}