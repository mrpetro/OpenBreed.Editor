﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OpenBreed.Editor.Cfg;
using OpenBreed.Editor.VM;

namespace OpenBreed.Editor.UI.WinForms.Forms
{
    public partial class OptionsForm : Form
    {
        private SettingsMan m_Settings;

        public OptionsForm(SettingsMan settings)
        {
            if (settings == null)
                throw new ArgumentNullException("settings");

            InitializeComponent();

            m_Settings = settings;

            OptionsABTA.UpdateCtrlWithCfg(m_Settings.Cfg.Options.ABTA);
            OptionsABHC.UpdateCtrlWithCfg(m_Settings.Cfg.Options.ABHC);
            OptionsABSE.UpdateCtrlWithCfg(m_Settings.Cfg.Options.ABSE);
        }

        public void UpdateSettings()
        {
            OptionsABTA.UpdateCfgWithCtrl(m_Settings.Cfg.Options.ABTA);
            OptionsABHC.UpdateCfgWithCtrl(m_Settings.Cfg.Options.ABHC);
            OptionsABSE.UpdateCfgWithCtrl(m_Settings.Cfg.Options.ABSE);

            m_Settings.Store();
        }
    }
}
