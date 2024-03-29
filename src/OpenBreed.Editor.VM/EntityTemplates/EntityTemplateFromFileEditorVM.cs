﻿using OpenBreed.Common;
using OpenBreed.Common.Data;
using OpenBreed.Common.Interface.Data;
using OpenBreed.Database.Interface.Items;
using OpenBreed.Database.Interface.Items.EntityTemplates;
using OpenBreed.Editor.VM.Base;
using OpenBreed.Model.Texts;

namespace OpenBreed.Editor.VM.EntityTemplates
{
    public class EntityTemplateFromFileEditorVM : BaseViewModel, IEntryEditor<IDbEntityTemplate>, IEntryEditor<IDbEntityTemplateFromFile>
    {
        #region Private Fields

        private bool _editEnabled;

        private string dataRef;

        private string entityTemplate;
        private readonly EntityTemplatesDataProvider entityTemplatesDataProvider;
        private readonly IModelsProvider dataProvider;

        #endregion Private Fields

        #region Public Constructors

        public EntityTemplateFromFileEditorVM(EntityTemplatesDataProvider entityTemplatesDataProvider, IModelsProvider dataProvider)
        {
            this.entityTemplatesDataProvider = entityTemplatesDataProvider;
            this.dataProvider = dataProvider;
        }

        #endregion Public Constructors

        #region Public Properties

        public bool EditEnabled
        {
            get { return _editEnabled; }
            set { SetProperty(ref _editEnabled, value); }
        }

        public string DataRef
        {
            get { return dataRef; }
            set { SetProperty(ref dataRef, value); }
        }

        public string EntityTemplate
        {
            get { return entityTemplate; }
            set { SetProperty(ref entityTemplate, value); }
        }

        #endregion Public Properties

        #region Public Methods

        public void UpdateVM(IDbEntityTemplate entry) => UpdateVM((IDbEntityTemplateFromFile)entry);

        public void UpdateEntry(IDbEntityTemplate entry) => UpdateEntry((IDbEntityTemplateFromFile)entry);

        public void UpdateEntry(IDbEntityTemplateFromFile entry)
        {
            var model = dataProvider.GetModel<TextModel>(DataRef);
            model.Text = EntityTemplate;
            entry.DataRef = DataRef;
        }

        public void UpdateVM(IDbEntityTemplateFromFile entry)
        {
            var model = entityTemplatesDataProvider.GetEntityTemplate(entry.Id);

            if (model != null)
                EntityTemplate = model.EntityTemplate;

            DataRef = entry.DataRef;
        }

        #endregion Public Methods

        #region Internal Methods

        #endregion Internal Methods

        #region Private Methods

        protected override void OnPropertyChanged(string name)
        {
            switch (name)
            {
                case nameof(DataRef):
                    EditEnabled = ValidateSettings();
                    break;

                default:
                    break;
            }

            base.OnPropertyChanged(name);
        }

        private bool ValidateSettings()
        {
            if (string.IsNullOrWhiteSpace(DataRef))
                return false;

            return true;
        }

        #endregion Private Methods
    }
}