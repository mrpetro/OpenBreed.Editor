﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenBreed.Editor.VM.Maps;
using OpenBreed.Common.Maps.Builders;
using System.IO;
using OpenBreed.Common.Maps.Readers.MAP;
using OpenBreed.Common.Maps.Writers.MAP;
using OpenBreed.Editor.VM.Sources;
using OpenBreed.Common.Maps;

namespace OpenBreed.Editor.VM.Sources.Formats
{
    public class ABTAMAPFormat : ISourceFormat
    {
        public ABTAMAPFormat()
        {
        }

        public object Load(BaseSource source)
        {
            //Remember to set source stream to begining
            source.Stream.Seek(0, SeekOrigin.Begin);

            var mapBuilder = MapBuilder.NewMapModel();
            MAPReader mapReader = new MAPReader(mapBuilder);
            return mapReader.Read(source.Stream);
        }

        public void Save(BaseSource source, object model)
        {
            if (source.Stream == null)
                throw new InvalidOperationException("Source stream not opened.");

            //Remember to clear the stream before writing
            source.Stream.SetLength(0);

            MAPWriter mapWriter = new MAPWriter(source.Stream);
            mapWriter.Write((MapModel)model);
        }
    }
}