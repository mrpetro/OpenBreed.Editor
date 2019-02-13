﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenBreed.Editor.VM.Maps;
using OpenBreed.Editor.VM.Common;
using OpenBreed.Editor.UI.WinForms.Forms.Common;

namespace OpenBreed.Editor.UI.WinForms.Controls.Maps
{
    public partial class MapEditorActionsManCtrl : UserControl
    {
        #region Private Fields

        private MapEditorActionsManVM _vm;

        #endregion Private Fields

        #region Public Constructors

        public MapEditorActionsManCtrl()
        {
            InitializeComponent();
        }

        #endregion Public Constructors

        #region Public Methods

        public void Initialize(MapEditorActionsManVM vm)
        {
            _vm = vm;

            tbxActionSetId.DataBindings.Add(nameof(tbxActionSetId.Text), _vm, nameof(_vm.ActionSetId), false, DataSourceUpdateMode.OnPropertyChanged);
            btnActionSetSelect.Click += (s,a) => _vm.SelectActionSetId();
            _vm.OpenRefIdSelectorAction = OnOpenRefIdSelector;
        }

        private void OnOpenRefIdSelector(RefSelectorVM vm)
        {
            using (var form = new RefIdSelectorForm())
            {
                form.StartPosition = FormStartPosition.CenterScreen;
                form.Initialize(vm);
                if (form.ShowDialog() == DialogResult.OK)
                    vm.Accept();
            }
        }

        #endregion Public Methods
    }
}