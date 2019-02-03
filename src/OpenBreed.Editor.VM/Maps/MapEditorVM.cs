﻿using OpenBreed.Editor.VM.Base;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenBreed.Editor.VM.Tiles;
using OpenBreed.Editor.VM.Sprites;
using OpenBreed.Common;
using OpenBreed.Common.Maps;
using System.ComponentModel;

namespace OpenBreed.Editor.VM.Maps
{
    public class MapEditorVM : EntryEditorBaseVM<IMapEntry, LevelVM>
    {
        #region Public Constructors

        public MapEditorVM(IRepository repository) : base(repository)
        {
            MapView = new MapEditorViewVM(this);
            //TileSetSelector = new LevelTileSetSelectorVM(this);
            //TileSelector = new LevelTileSelectorVM(this);
            PropSelector = new MapEditorPropsToolVM(this);
            PaletteSelector = new MapEditorPalettesToolVM(this);

            PropertyChanged += LevelEditorVM_PropertyChanged;

            PaletteSelector.PropertyChanged += PaletteSelector_PropertyChanged;
        }

        private void PaletteSelector_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(PaletteSelector.CurrentItem):
                    foreach (var tileSet in Editable.TileSets)
                        tileSet.Palette = PaletteSelector.CurrentItem;
                    break;
                default:
                    break;
            }
        }

        private void LevelEditorVM_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(Editable):
                    MapView.CurrentMapBody = Editable.Body;
                    PaletteSelector.CurrentItem = Editable.Palettes.FirstOrDefault();
                    break;
                default:
                    break;
            }
        }

        #endregion Public Constructors

        #region Public Properties

        public MapEditorViewVM MapView { get; }

        public override string EditorName { get { return "Level Editor"; } }
        public MapEditorPalettesToolVM PaletteSelector { get; }
        public MapEditorPropsToolVM PropSelector { get; }
        //public LevelTileSelectorVM TileSelector { get; }

        #endregion Public Properties

        #region Internal Methods

        internal void Connect()
        {
            PropSelector.Connect();
        }

        #endregion Internal Methods

        //public void Load(string name)
        //{
        //    CurrentLevel = Root.CreateLevel();
        //    //CurrentLevel.Load(name);

        //    TileSelector.CurrentItem = CurrentLevel.TileSets.FirstOrDefault();
        //    PropSelector.CurrentItem = CurrentLevel.PropSet;
        //    SpriteSetViewer.CurrentItem = CurrentLevel.SpriteSets.FirstOrDefault();
        //    PaletteSelector.CurrentItem = CurrentLevel.Palettes.FirstOrDefault();
        //}

        #region Protected Methods

        protected override void UpdateEntry(LevelVM source, IMapEntry target)
        {
            base.UpdateEntry(source, target);
        }

        protected override void UpdateVM(IMapEntry source, LevelVM target)
        {
            var model = DataProvider.GetLevel(source.Id);

            //foreach (var spriteSet in model.SpriteSets)
            //    target.AddSpriteSet(spriteSet);

            foreach (var tileSet in model.TileSets)
                target.AddTileSet(tileSet);

            if (model.PropSet != null)
                target.Body.SetPropSet(model.PropSet);

            target.Properties.Load(model.Map);
            target.Body.Load(model.Map);

            //PaletteSelector.PropertyChanged += PaletteSelector_PropertyChanged;

            target.Restore(model.Palettes);

            base.UpdateVM(source, target);
        }

        #endregion Protected Methods

        //private void PaletteSelector_PropertyChanged(object sender, PropertyChangedEventArgs e)
        //{
        //    var paletteSelector = sender as LevelPaletteSelectorVM;

        //    switch (e.PropertyName)
        //    {
        //        case nameof(paletteSelector.CurrentItem):
        //            Root.PaletteEditor.Editable = paletteSelector.CurrentItem;
        //            Root.PaletteEditor.CurrentColorIndex = 0;

        //            foreach (var tileSet in TileSets)
        //                tileSet.Palette = paletteSelector.CurrentItem;

        //            break;
        //        default:
        //            break;
        //    }
        //}

    }
}