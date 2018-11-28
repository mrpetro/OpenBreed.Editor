﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using OpenBreed.Common.Sprites.Builders;
using OpenBreed.Common.Sprites.Readers.SPR;

namespace OpenBreed.Editor.VM.Sources.Formats
{
    public class ABTASPRFormat : ISourceFormat
    {
        public ABTASPRFormat()
        {
        }

        public object Load(BaseSource source)
        {
            //Remember to set source stream to begining
            source.Stream.Seek(0, SeekOrigin.Begin);

            var spriteSetBuilder = SpriteSetBuilder.NewSpriteSet();
            //spriteSetBuilder.SetSource(source);
            SPRReader sprReader = new SPRReader(spriteSetBuilder);
            return sprReader.Read(source.Stream);
        }

        public void Save(BaseSource source, object model)
        {
            throw new NotImplementedException("ABTASPR Write");
        }
    }
}