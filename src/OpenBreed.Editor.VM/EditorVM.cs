﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using OpenBreed.Editor.VM.Palettes;
using OpenBreed.Editor.VM.Levels;
using OpenBreed.Editor.VM.Tiles;
using System.Drawing;
using OpenBreed.Common.Maps.Readers.MAP;
using OpenBreed.Common.Maps.Builders;
using OpenBreed.Editor.VM.Database;
using OpenBreed.Editor.VM.Props;
using OpenBreed.Editor.VM.Sprites;
using OpenBreed.Editor.VM.Levels.Tools;
using OpenBreed.Common.Palettes;
using System.Diagnostics;
using OpenBreed.Common;
using OpenBreed.Common.Logging;
using OpenBreed.Editor.Cfg;
using System.ComponentModel;
using OpenBreed.Editor.VM.Base;
using OpenBreed.Editor.VM.Images;
using OpenBreed.Common.Formats;
using OpenBreed.Common.Sources;
using OpenBreed.Common.Database.Items.Props;
using OpenBreed.Common.Database.Items.Levels;
using OpenBreed.Common.Database.Items.Tiles;
using OpenBreed.Common.Database.Items.Sprites;
using OpenBreed.Common.Database.Items.Palettes;

namespace OpenBreed.Editor.VM
{
    public enum EditorState
    {
        Active,
        Exiting,
        Exited
    }

    public class EditorVM : BaseViewModel, IDisposable
    {

        #region Private Fields

        private DatabaseVM _database;
        private EditorState _state;

        #endregion Private Fields

        #region Public Constructors

        public EditorVM(IDialogProvider dialogProvider)
        {
            DialogProvider = dialogProvider;

            Settings = new SettingsMan();
            ToolsMan = new ToolsMan();

            TileSetEditor = new TileSetEditorVM(this);
            PropSetEditor = new PropSetEditorVM(this);
            DatabaseViewer = new DatabaseViewerVM(this);
            SpriteViewer = new SpriteViewerVM(this);
            ImageViewer = new ImageViewerVM(this);
            LevelEditor = new LevelEditorVM(this);
            FormatMan = new DataFormatMan();
            SourcesRepository.ExpandVariables = Settings.ExpandVariables;

            FormatMan.RegisterFormat("ABSE_MAP", new ABSEMAPFormat());
            FormatMan.RegisterFormat("ABHC_MAP", new ABHCMAPFormat());
            FormatMan.RegisterFormat("ABTA_MAP", new ABTAMAPFormat());
            FormatMan.RegisterFormat("ABTABLK", new ABTABLKFormat());
            FormatMan.RegisterFormat("ABTASPR", new ABTASPRFormat());
            FormatMan.RegisterFormat("ACBM_TILE_SET", new ACBMTileSetFormat());
            FormatMan.RegisterFormat("ACBM_IMAGE", new ACBMImageFormat());
            FormatMan.RegisterFormat("PALETTE", new PaletteFormat());
        }

        #endregion Public Constructors

        #region Public Properties

        public DatabaseVM Database
        {
            get { return _database; }
            set { SetProperty(ref _database, value); }
        }

        public DatabaseViewerVM DatabaseViewer { get; }
        public IDialogProvider DialogProvider { get; }
        public DataFormatMan FormatMan { get; }
        public ImageViewerVM ImageViewer { get; }
        public LevelEditorVM LevelEditor { get; }
        public PropSetEditorVM PropSetEditor { get; }
        public SettingsMan Settings { get; private set; }
        //public SourceMan SourceMan { get; }
        public SpriteViewerVM SpriteViewer { get; }
        public EditorState State
        {
            get { return _state; }
            set { SetProperty(ref _state, value); }
        }

        public TileSetEditorVM TileSetEditor { get; }
        public ToolsMan ToolsMan { get; }
        public IUnitOfWork UnitOfWork { get; internal set; }

        #endregion Public Properties

        #region Public Methods

        public LevelVM CreateLevel()
        {
            return new LevelVM(this);
        }

        public PaletteVM CreatePalette()
        {
            return new PaletteVM(this);
        }

        public PropSetVM CreatePropSet()
        {
            return new PropSetVM(this);
        }

        public SpriteSetVM CreateSpriteSet()
        {
            return new SpriteSetVM(this);
        }

        public TileSetVM CreateTileSet()
        {
            return new TileSetVM(this);
        }

        public void Dispose()
        {
            Settings.Store();
        }

        public DatabaseVM OpenXmlDatabase(string xmlFilePath)
        {
            var xmlDatabase = new XmlDatabase(xmlFilePath, DatabaseMode.Read);
            UnitOfWork = new XmlUnitOfWork(xmlDatabase);

            return new DatabaseVM(this, UnitOfWork);
        }
        public void Run()
        {
            try
            {
                Initialize();
                DialogProvider.ShowEditorView(this);
            }
            catch (Exception ex)
            {
                DialogProvider.ShowMessage("Critical exception: " + ex, "Open Breed Editor critial exception");
            }
        }

        public void SaveDatabase(string filePath)
        {
            throw new NotImplementedException();
        }

        public bool TryCloseDatabase()
        {
            return EditorVMHelper.TryCloseDatabase(this);
        }

        public bool TryExit()
        {
            return EditorVMHelper.TryExit(this);
        }

        public void TryOpenDatabase()
        {
            EditorVMHelper.TryOpenDatabase(this);
        }

        public void TryRunABTAGame()
        {
            Tools.TryAction(RunABTAGame);
        }

        #endregion Public Methods

        #region Internal Methods

        internal bool TrySaveDatabase()
        {
            return EditorVMHelper.TrySaveDatabase(this);
        }

        #endregion Internal Methods

        #region Private Methods

        private void Initialize()
        {
            PropSetEditor.Connect();
            DatabaseViewer.Connect();
            LevelEditor.Connect();
            SpriteViewer.Connect();

            Settings.Restore();
        }
        private void RunABTAGame()
        {
            Process proc = new Process();
            proc.StartInfo.FileName = Settings.Cfg.Options.ABTA.GameRunFilePath;
            proc.StartInfo.Arguments = Settings.Cfg.Options.ABTA.GameRunFileArgs;
            proc.StartInfo.WorkingDirectory = Settings.Cfg.Options.ABTA.GameFolderPath;
            proc.Start();
        }

        #endregion Private Methods

    }
}
