﻿using OpenBreed.Database.Interface.Items.Palettes;
using OpenBreed.Editor.VM.Base;
using OpenBreed.Editor.VM.Maps;
using OpenBreed.Model.Palettes;
using System.ComponentModel;
using System.Drawing;

namespace OpenBreed.Editor.VM.Palettes
{
    public class PaletteEditorExVM : BaseViewModel, IEntryEditor<IPaletteEntry>
    {
        #region Private Fields

        private Color _currentColor = Color.Empty;
        private int _currentColorIndex = -1;

        #endregion Private Fields

        #region Public Constructors

        public PaletteEditorExVM(ParentEntryEditor<IPaletteEntry> parent)
        {
            Parent = parent;

            Colors = new BindingList<Color>();
            Initialize();

            Colors.ListChanged += (s, a) => OnPropertyChanged(nameof(Colors));
        }

        #endregion Public Constructors

        #region Public Properties

        public ParentEntryEditor<IPaletteEntry> Parent { get; }
        public BindingList<Color> Colors { get; }

        public Color CurrentColor
        {
            get { return CurrentColorIndex == -1 ? Color.Empty : Colors[CurrentColorIndex]; }

            set
            {
                if (Colors[CurrentColorIndex] == value)
                    return;

                Colors[CurrentColorIndex] = value;
                OnPropertyChanged(nameof(CurrentColor));
            }
        }

        public int CurrentColorIndex
        {
            get { return _currentColorIndex; }
            set { SetProperty(ref _currentColorIndex, value); }
        }

        public MapEditorPalettesToolVM Palettes { get; private set; }

        #endregion Public Properties

        #region Public Methods

        public virtual void UpdateVM(IPaletteEntry entry)
        {
        }

        public virtual void UpdateEntry(IPaletteEntry target)
        {
            var model = Parent.DataProvider.Palettes.GetPalette(target.Id);

            for (int i = 0; i < model.Length; i++)
                model.Data[i] = Colors[i];
        }

        #endregion Public Methods

        #region Protected Methods

        protected void UpdateVMColors(PaletteModel model)
        {
            Colors.UpdateAfter(() =>
            {
                for (int i = 0; i < model.Data.Length; i++)
                    Colors[i] = model.Data[i];
            });

            CurrentColorIndex = 0;
        }

        #endregion Protected Methods

        #region Private Methods

        private void Initialize()
        {
            Colors.UpdateAfter(() =>
            {
                for (int i = 0; i < 256; i++)
                    Colors.Add(Color.FromArgb(255, i, i, i));
            });

            CurrentColorIndex = 0;
        }

        #endregion Private Methods
    }
}