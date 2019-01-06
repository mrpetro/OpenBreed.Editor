﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using OpenBreed.Editor.VM.Images;
using OpenBreed.Editor.VM;
using OpenBreed.Editor.UI.WinForms.Controls.Images;

namespace OpenBreed.Editor.UI.WinForms.Views
{
    public partial class ImageEditorView : DockContent
    {
        #region Private Fields

        private EntryEditorVM _vm;

        #endregion Private Fields

        #region Public Constructors

        public ImageEditorView()
        {
            InitializeComponent();

            EntryEditor.InnerCtrl = new ImageEditorCtrl();
        }

        #endregion Public Constructors

        #region Public Methods

        public void Initialize(EntryEditorVM vm)
        {
            _vm = vm ?? throw new ArgumentNullException(nameof(vm));
            _vm.PropertyChanged += _vm_PropertyChanged;

            EntryEditor.Initialize(_vm);
            OnEditableNameChanged();
        }

        #endregion Public Methods

        #region Private Methods

        private void _vm_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(_vm.EditableName):
                    OnEditableNameChanged();
                    break;
                default:
                    break;
            }
        }

        private void OnEditableNameChanged()
        {
            if (_vm.EditableName == null)
                Text = $"{_vm.EditorName} - no entry to edit";
            else
                Text = $"{_vm.EditorName} - {_vm.EditableName}";
        }

        #endregion Private Methods
    }
}