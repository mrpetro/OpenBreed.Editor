﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using OpenBreed.Common.Readers.BLK;
using OpenBreed.Common.Tiles.Builders;

namespace OpenBreed.Editor.VM.Sources.Formats
{
    public class ABTABLKFormat : ISourceFormat
    {
        public ABTABLKFormat()
        {
        }

        public object Load(BaseSource source)
        {
            //Remember to set source stream to begining
            source.Stream.Seek(0, SeekOrigin.Begin);

            var tileSetBuilder = TileSetBuilder.NewTileSet();
            BLKReader blkReader = new BLKReader(tileSetBuilder);
            return blkReader.Read(source.Stream);
        }

        public void Save(BaseSource source, object model)
        {
            throw new NotImplementedException("ABTABLK Write");
        }
    }
}