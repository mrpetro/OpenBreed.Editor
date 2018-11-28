﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace OpenBreed.Editor.VM.Database.Sources
{
    [Serializable]
    public class SourceDef
    {
        [XmlAttribute]
        public string Name { get; set; }
 
        [XmlAttribute]
        public string Type { get; set; }
    }
}