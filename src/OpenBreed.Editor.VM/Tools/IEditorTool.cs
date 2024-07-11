﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenBreed.Editor.VM.Tools
{
    public interface IEditorTool
    {
        string Name { get; }

        void Activate();
        void Deactivate();
    }
}
