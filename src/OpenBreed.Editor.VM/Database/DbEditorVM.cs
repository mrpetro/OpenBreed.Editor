﻿using OpenBreed.Common;
using OpenBreed.Common.XmlDatabase;
using OpenBreed.Editor.VM.Base;
using OpenBreed.Editor.VM.Database.Items;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBreed.Editor.VM.Database
{
    public class DbEditorVM : BaseViewModel
    {

        public DbTablesEditorVM DbTablesEditor { get; }

        #region Private Fields

        private DatabaseVM _currentDb;
        private ProjectState _state;

        #endregion Private Fields

        #region Public Constructors

        public DbEditorVM(EditorVM root)
        {
            Root = root;

            DbTablesEditor = new DbTablesEditorVM();
        }

        #endregion Public Constructors

        #region Public Properties

        public DatabaseVM CurrentDb
        {
            get { return _currentDb; }
            set { SetProperty(ref _currentDb, value); }
        }

        public string FilePath { get; private set; }
        public bool IsModified { get; internal set; }
        public string Name { get; set; }
        public EditorVM Root { get; private set; }

        public ProjectState State
        {
            get { return _state; }
            set { SetProperty(ref _state, value); }
        }

        #endregion Public Properties

        #region Internal Properties

        #endregion Internal Properties

        #region Public Methods

        public DatabaseVM OpenXmlDatabase(string xmlFilePath)
        {
            var xmlDatabase = new XmlDatabase(xmlFilePath, DatabaseMode.Read);
            Root.UnitOfWork = new XmlUnitOfWork(xmlDatabase);
            Root.DataProvider = new DataProvider(Root.UnitOfWork);

            return new DatabaseVM(this.Root, Root.UnitOfWork);
        }

        public void SaveDatabase(string filePath)
        {
            throw new NotImplementedException();
        }

        public bool TryCloseDatabase()
        {
            return DbEditorVMHelper.TryCloseDatabase(this);
        }



        public void TryOpenDatabase()
        {
            DbEditorVMHelper.TryOpenDatabase(this);
        }

        #endregion Public Methods

        //internal DbEntryVM CreateItem(IEntry entry)
        //{
        //    if (entry is IImageEntry)
        //        return new DbImageEntryVM(this, Root.ImageEditor);
        //    else if (entry is ISoundEntry)
        //        return new DbSoundEntryVM(this, Root.SoundEditor);
        //    else if (entry is ILevelEntry)
        //        return new DbLevelEntryVM(this, null);
        //    else if (entry is ISourceEntry)
        //        return new DbSourceEntryVM(this, null);
        //    else if (entry is IPropSetEntry)
        //        return new DbPropSetEntryVM(this, Root.PropSetEditor);
        //    else if (entry is ITileSetEntry)
        //        return new DbTileSetEntryVM(this, Root.TileSetEditor);
        //    else if (entry is ISpriteSetEntry)
        //        return new DbSpriteSetEntryVM(this, null);
        //    else if (entry is IPaletteEntry)
        //        return new DbPaletteEntryVM(this, Root.PaletteEditor);
        //    else
        //        throw new NotImplementedException(entry.ToString());
        //}

        //internal DatabaseTableVM CreateTable(IRepository repository)
        //{
        //    if (repository is IRepository<IImageEntry>)
        //        return new DatabaseImageTableVM(this);
        //    if (repository is IRepository<ISoundEntry>)
        //        return new DatabaseSoundTableVM(this);
        //    else if (repository is IRepository<ILevelEntry>)
        //        return new DatabaseLevelTableVM(this);
        //    else if (repository is IRepository<IPropSetEntry>)
        //        return new DatabasePropertySetTableVM(this);
        //    else if (repository is IRepository<ISourceEntry>)
        //        return new DatabaseSourceTableVM(this);
        //    else if (repository is IRepository<ITileSetEntry>)
        //        return new DatabaseTileSetTableVM(this);
        //    else if (repository is IRepository<ISpriteSetEntry>)
        //        return new DatabaseSpriteSetTableVM(this);
        //    else if (repository is IRepository<IPaletteEntry>)
        //        return new DatabasePaletteTableVM(this);
        //    else
        //        throw new NotImplementedException(repository.ToString());
        //}

        //internal IEnumerable<DatabaseTableVM> GetTables()
        //{
        //    foreach (var repository in UnitOfWork.Repositories)
        //    {
        //        var tableVM = CreateTable(repository);
        //        tableVM.Load(repository);
        //        yield return tableVM;
        //    }
        //}

        #region Internal Methods

        internal void Save()
        {
            throw new NotImplementedException();
        }

        #endregion Internal Methods

    }
}