﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Data;
using OpenBreed.Editor.VM.Props;
using OpenBreed.Common.Assets;
using System.ComponentModel;
using OpenBreed.Editor.VM.Base;
using OpenBreed.Common.Logging;
using OpenBreed.Common.Props;

namespace OpenBreed.Editor.VM.Props
{
    public class PropSetVM : EditableEntryVM
    {

        #region Private Fields

        private const int PROP_SIZE = 32;

        #endregion Private Fields

        #region Public Constructors

        public PropSetVM()
        {
            Items = new BindingList<PropVM>();
        }

        public PropSetVM(IPropSetEntry model)
        {
            Items = new BindingList<PropVM>();

            foreach (var property in model.Items)
            {
                var newProp = CreateProp(property);
                newProp.Load(property);
                Items.Add(newProp);
            }
        }

        #endregion Public Constructors

        #region Public Properties

        public BindingList<PropVM> Items { get; private set; }

        #endregion Public Properties

        #region Public Methods

        public PropVM CreateProp(IPropertyEntry propDef)
        {
            return new PropVM(this);
        }

        public void DrawProperty(Graphics gfx, int id, float x, float y, int tileSize)
        {
            if (id >= Items.Count)
                return;

            var propertyData = Items[id];

            if (!propertyData.Visibility)
                return;

            var image = propertyData.Presentation;

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

        #endregion Public Methods


    }
}
