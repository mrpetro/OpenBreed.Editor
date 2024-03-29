﻿using OpenBreed.Common;
using OpenBreed.Common.Data;
using OpenBreed.Database.Interface.Items.Actions;
using OpenBreed.Editor.VM.Base;
using OpenBreed.Model.Actions;
using System.ComponentModel;
using System.Drawing;

namespace OpenBreed.Editor.VM.Actions
{
    public class ActionSetEmbeddedEditorVM : BaseViewModel, IEntryEditor<IDbActionSet>
    {
        #region Private Fields

        private const int PROP_SIZE = 32;
        private readonly ActionSetsDataProvider actionSetsDataProvider;

        #endregion Private Fields

        #region Public Constructors

        public ActionSetEmbeddedEditorVM(ActionSetsDataProvider actionSetsDataProvider)
        {
            Items = new BindingList<ActionVM>();
            Items.ListChanged += (s, a) => OnPropertyChanged(nameof(Items));
            this.actionSetsDataProvider = actionSetsDataProvider;
        }

        #endregion Public Constructors

        #region Public Properties

        public BindingList<ActionVM> Items { get; }

        public int SelectedIndex { get; private set; }

        #endregion Public Properties

        #region Public Methods

        public void DrawProperty(Graphics gfx, int id, float x, float y, int tileSize)
        {
            if (id >= Items.Count)
                return;

            var propertyData = Items[id];

            if (!propertyData.IsVisible)
                return;

            var image = propertyData.Icon;

            var opqPen = new Pen(Color.FromArgb(128, 255, 255, 255), 10);
            var otranspen = new Pen(Color.FromArgb(128, 255, 255, 255), 10);
            var ototTransPen = new Pen(Color.FromArgb(40, 0, 255, 0), 10);

            //ColorMatrix cm = new ColorMatrix();
            //cm.Matrix33 = 0.55f;
            //ImageAttributes ia = new ImageAttributes();
            //ia.SetColorMatrix(cm);
            //gfx.DrawImage(image, new Rectangle((int)x, (int)y, image.Width, image.Height), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, ia);

            gfx.DrawImage(image, x, y, tileSize, tileSize);
        }

        private ActionSetModel model;

        public virtual void UpdateVM(IDbActionSet entry)
        {
            model = actionSetsDataProvider.GetActionSet(entry.Id);

            Items.UpdateAfter(() =>
            {
                Items.Clear();

                foreach (var item in model.Items)
                    Items.Add(new ActionVM(item));
            });

            SelectedIndex = 0;
        }

        public virtual void UpdateEntry(IDbActionSet entry)
        {
            entry.Actions.Clear();

            foreach (var item in model.Items)
            {
                var newAction = entry.NewItem();
                ActionSetsDataHelper.ToEntry(item, newAction);
                entry.Actions.Add(newAction);
            }
        }

        #endregion Public Methods
    }
}