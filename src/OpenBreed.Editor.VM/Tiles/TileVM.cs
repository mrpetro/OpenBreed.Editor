﻿using System;
using System.Drawing;
using OpenBreed.Model.Tiles;

namespace OpenBreed.Editor.VM.Tiles
{
    public class TileVM
    {

        #region Public Constructors

        public TileVM(int index, Rectangle rectangle)
        {
            Index = index;
            Rectangle = rectangle;
        }

        #endregion Public Constructors

        #region Public Properties

        public int Index { get; private set; }
        public Rectangle Rectangle { get; private set; }

        internal static TileVM Create(TileModel tile)
        {
            throw new NotImplementedException();
        }

        #endregion Public Properties

    }
}