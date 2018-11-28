﻿using OpenBreed.Common.Maps;
using OpenBreed.Editor.VM.Base;
using OpenBreed.Editor.VM.Maps.Helpers;
using OpenBreed.Editor.VM.Props;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using OpenBreed.Editor.VM.Maps.Layers;

namespace OpenBreed.Editor.VM.Maps
{
    public delegate void CurrentMapBodyChangedEventHandler(object sender, CurrentMapBodyChangedEventArgs e);


    public class CurrentMapBodyChangedEventArgs : EventArgs
    {

        #region Public Constructors

        public CurrentMapBodyChangedEventArgs(MapBodyModel mapBody)
        {
            MapBody = mapBody;
        }

        #endregion Public Constructors

        #region Public Properties

        public MapBodyModel MapBody { get; set; }

        #endregion Public Properties

    }

    public class MapBodyVM : BaseViewModel
    {

        #region Public Fields

        public BindingList<MapBodyBaseLayerVM> Layers;

        #endregion Public Fields

        #region Private Fields

        private Size _size;

        #endregion Private Fields

        #region Public Constructors

        public MapBodyVM(MapVM map)
        {
            Map = map;

            Layers = new BindingList<MapBodyBaseLayerVM>();

            //TilesInserter = new TilesInserter(this, Map.Project.Root.TileSets.CurrentItem.Selector);
            //PropertyInserter = new PropertyInserter(this, Map.Root.PropSets.Selector);

        }

        #endregion Public Constructors

        #region Public Events

        public event CurrentMapBodyChangedEventHandler CurrentMapBodyChanged;


        #endregion Public Events

        #region Public Properties

        public MapVM Map { get; private set; }
        public float MaxCoordX { get; private set; }
        public float MaxCoordY { get; private set; }
        //public PropertyInserter PropertyInserter { get; private set; }
        public Size Size
        {
            get { return _size; }
            set { SetProperty(ref _size, value); }
        }

        //public TilesInserter TilesInserter { get; private set; }

        #endregion Public Properties

        #region Public Methods

        public int GetMapIndexX(float xCoord)
        {
            int xIndex = (int)(xCoord / Map.TileSize);

            if (xIndex < 0)
                xIndex = 0;
            else if (xIndex > Size.Width - 1)
                xIndex = Size.Width - 1;

            return xIndex;
        }

        public int GetMapIndexY(float yCoord)
        {
            int yIndex = (int)(yCoord / Map.TileSize);

            if (yIndex < 0)
                yIndex = 0;
            else if (yIndex > Size.Height - 1)
                yIndex = Size.Height - 1;

            return yIndex;
        }

        //public MapCellModel GetCell(int x, int y)
        //{
        //    return CurrentMapBody.Cells[x, y];
        //}


        public void Resize(int newSizeX, int newSizeY)
        {
            //m_CurrentMapBody.Resize(newSizeX, newSizeY);
        }

        public void ResizeOld(int newSizeX, int newSizeY)
        {
            //var mapResizeOperation = new MapResizeOperation(Size.Width, Size.Height, newSizeX, newSizeY);
            //Map.Commands.ExecuteCommand(new CmdResize(this, mapResizeOperation));
        }


        public void SetTileGfx(int x, int y, int gfxId)
        {
            //CurrentMapBody.SetTileGfx(x, y, gfxId);

            Map.IsModifiedInternal = true;
        }

        public void SetTileProperty(int x, int y, int propertyId)
        {
            //CurrentMapBody.SetTileProperty(x, y, propertyId);

            Map.IsModifiedInternal = true;
        }

        #endregion Public Methods

        #region Internal Methods

        internal void ConnectEvents()
        {
        }

        internal Point GetIndexCoords(Point point)
        {
            return new Point(point.X / Map.TileSize, point.Y / Map.TileSize);
        }

        internal void Load(MapModel map)
        {
            var body = map.Body;
            Size = body.Size;

            Layers.RaiseListChangedEvents = false;
            Layers.Clear();
            foreach (var layer in body.Layers)
                AppendLayer(layer);
            Layers.RaiseListChangedEvents = true;
            Layers.ResetBindings();

            MaxCoordX = Size.Width * Map.TileSize;
            MaxCoordY = Size.Height * Map.TileSize;
        }

        #endregion Internal Methods

        #region Protected Methods

        protected virtual void OnCurrentMapBodyChanged(CurrentMapBodyChangedEventArgs e)
        {
            if (CurrentMapBodyChanged != null) CurrentMapBodyChanged(this, e);
        }


        #endregion Protected Methods

        #region Private Methods

        private void AppendLayer(IMapBodyLayerModel layer)
        {
            MapBodyBaseLayerVM newLayerVM = null;

            if (layer.Name == "GFX")
                newLayerVM = new MapBodyGfxLayerVM(this);
            else if (layer.Name == "PROP")
                newLayerVM = new MapBodyPropertyLayerVM(this);

            newLayerVM.Restore(layer);
            Layers.Add(newLayerVM);
        }

        #endregion Private Methods

    }
}