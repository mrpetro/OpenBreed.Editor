﻿using OpenBreed.Common;
using OpenBreed.Model.Maps;
using OpenBreed.Model.Maps.Blocks;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBreed.Editor.VM.Maps.Layers
{
    public class MapLayerGfxVM : MapLayerBaseVM
    {
        #region Private Fields

        private TileRef[] _cells;

        #endregion Private Fields

        #region Internal Constructors

        internal MapLayerGfxVM(MapLayoutVM layout) : base(layout)
        {
            _cells = new TileRef[layout.Size.Width * layout.Size.Height];
        }

        #endregion Internal Constructors

        #region Public Methods

        /// <summary>
        /// Get Layer cell using single index
        /// </summary>
        /// <param name="index">Index of cell from list</param>
        /// <returns>Tile reference object</returns>
        public TileRef GetCell(int index)
        {
            return _cells[index];
        }

        public TileRef GetCell(int x, int y)
        {
            return _cells[y * Layout.Size.Width + x];
        }

        public void Restore(MapBodyBlock bodyBlock)
        {
            _cells = new TileRef[bodyBlock.Cells.Length];

            for (int i = 0; i < _cells.Length; i++)
                _cells[i] = new TileRef(0, bodyBlock.Cells[i].GfxId);
        }

        public void Store(MapBodyBlock bodyBlock)
        {
            for (int i = 0; i < _cells.Length; i++)
                bodyBlock.Cells[i].GfxId = _cells[i].TileId;
        }

        public void SetCell(int x, int y, TileRef value)
        {
            if (_cells[y * Layout.Size.Width + x] == value)
                return;

            _cells[y * Layout.Size.Width + x] = value;
            Layout.Parent.IsModified = true;
        }

        #endregion Public Methods
    }
}
