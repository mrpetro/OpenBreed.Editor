﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenBreed.Editor.Cfg.Options.ABHC;
using OpenBreed.Editor.Cfg.Options.ABSE;
using OpenBreed.Editor.Cfg.Options.ABTA;

namespace OpenABEdCfg.Options
{
    [Serializable]
    public class OptionsCfg
    {
        public ABTACfg ABTA { get; set; }
        public ABHCCfg ABHC { get; set; }
        public ABSECfg ABSE { get; set; }
    }
}
