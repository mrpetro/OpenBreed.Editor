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
using OpenBreed.Editor.VM.Logging;

namespace OpenBreed.Editor.UI.WinForms.Views
{
    public partial class LoggerView : DockContent
    {
        public LoggerView()
        {
            InitializeComponent();
        }

        public void Initialize(LoggerVM vm)
        {
            LoggerCtrl.Initialize(vm);
        }
    }
}
