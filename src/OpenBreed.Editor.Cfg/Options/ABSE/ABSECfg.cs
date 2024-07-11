﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenBreed.Editor.Cfg.Options.ABSE
{
    [Serializable]
    public class ABSECfg
    {
        public string GameFolderPath { get; set; }
        public string GameRunFilePath { get; set; }
        public string GameRunFileArgs { get; set; }
    }
}
