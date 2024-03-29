﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenBreed.Editor.VM;
using OpenBreed.Editor.VM.Maps;

namespace OpenBreed.Editor.UI.WinForms.Controls.Maps
{
    public partial class MapEditorCtrl : EntryEditorInnerCtrl
    {
        private MapEditorVM _vm;

        public MapEditorCtrl()
        {
            InitializeComponent();
        }

        public override void Initialize(EntryEditorVM vm)
        {
            _vm = vm as MapEditorVM ?? throw new InvalidOperationException(nameof(vm));

            MapView.Initialize(_vm.MapView);

            TilesTool.Initialize(_vm.TilesTool);
            ActionsTool.Initialize(_vm.ActionsTool);
            PalettesTool.Initialize(_vm.PalettesTool);

            ToolTabs.DataBindings.Add(nameof(ToolTabs.SelectedIndex), _vm.Tools, nameof(_vm.Tools.CurrentToolIndex), false, DataSourceUpdateMode.OnPropertyChanged);
            CursorPosInfoLbl.DataBindings.Add(nameof(CursorPosInfoLbl.Text), _vm.MapView.Cursor, nameof(_vm.MapView.Cursor.Info), false, DataSourceUpdateMode.OnPropertyChanged);
        }
    }
}
