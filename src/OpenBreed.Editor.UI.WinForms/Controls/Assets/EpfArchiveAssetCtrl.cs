﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenBreed.Editor.VM.Assets;

namespace OpenBreed.Editor.UI.WinForms.Controls.Assets
{
    public partial class EpfArchiveAssetCtrl : UserControl
    {
        #region Private Fields

        private EPFArchiveFileAssetVM _vm;

        #endregion Private Fields

        #region Public Constructors

        public EpfArchiveAssetCtrl()
        {
            InitializeComponent();
        }

        #endregion Public Constructors

        #region Public Methods

        public void Initialize(EPFArchiveFileAssetVM vm)
        {
            _vm = vm;

            tbxEpfArchivePath.DataBindings.Add(nameof(tbxEpfArchivePath.Text), _vm, nameof(_vm.ArchivePath), false, DataSourceUpdateMode.OnPropertyChanged);
            cbxEntryName.DataBindings.Add(nameof(cbxEntryName.Text), _vm, nameof(_vm.EntryName), false, DataSourceUpdateMode.OnPropertyChanged);
        }

        #endregion Public Methods
    }
}