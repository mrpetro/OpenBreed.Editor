﻿using OpenBreed.Common;
using OpenBreed.Common.Data;
using OpenBreed.Common.Formats;
using OpenBreed.Database.Interface;
using OpenBreed.Database.Interface.Items.Actions;
using OpenBreed.Database.Interface.Items.DataSources;
using OpenBreed.Database.Interface.Items.EntityTemplates;
using OpenBreed.Database.Interface.Items.Images;
using OpenBreed.Database.Interface.Items.Maps;
using OpenBreed.Database.Interface.Items.Palettes;
using OpenBreed.Database.Interface.Items.Scripts;
using OpenBreed.Database.Interface.Items.Sounds;
using OpenBreed.Database.Interface.Items.Sprites;
using OpenBreed.Database.Interface.Items.Texts;
using OpenBreed.Database.Interface.Items.Tiles;
using OpenBreed.Editor.VM;
using OpenBreed.Editor.VM.Actions;
using OpenBreed.Editor.VM.DataSources;
using OpenBreed.Editor.VM.EntityTemplates;
using OpenBreed.Editor.VM.Images;
using OpenBreed.Editor.VM.Maps;
using OpenBreed.Editor.VM.Palettes;
using OpenBreed.Editor.VM.Scripts;
using OpenBreed.Editor.VM.Sounds;
using OpenBreed.Editor.VM.Sprites;
using OpenBreed.Editor.VM.Texts;
using OpenBreed.Editor.VM.Tiles;

namespace OpenBreed.Editor.UI.WinForms.Extensions
{
    public static class ManagerCollectionExtension
    {
        #region Public Methods


        public static void SetupDbEntrySubEditors(this IManagerCollection managerCollection)
        {
            managerCollection.AddTransient<IEntryEditor<ITileSetFromBlkEntry>>(() => new TileSetFromBlkEditorVM(managerCollection.GetManager<TileSetsDataProvider>(),
                                                                                                                managerCollection.GetManager<PalettesDataProvider>()));


            managerCollection.AddTransient<IEntryEditor<IActionSetEntry>>(() => new ActionSetEmbeddedEditorVM(managerCollection.GetManager<ActionSetsDataProvider>()));


            managerCollection.AddTransient<IEntryEditor<IFileDataSourceEntry>>(() => new FileDataSourceEditorVM());

            managerCollection.AddTransient<IEntryEditor<IEPFArchiveDataSourceEntry>>(() => new EpfArchiveFileDataSourceEditorVM());


            managerCollection.AddTransient<IEntryEditor<IEntityTemplateFromFileEntry>>(() => new EntityTemplateFromFileEditorVM(managerCollection.GetManager<EntityTemplatesDataProvider>(),
                                                                                                                                managerCollection.GetManager<IDataProvider>()));


            managerCollection.AddTransient<IEntryEditor<IImageEntry>>(() => new ImageFromFileEditorVM(managerCollection.GetManager<IWorkspaceMan>(),
                                                                                                                managerCollection.GetManager<IDialogProvider>(),
                                                                                                                managerCollection.GetManager<IDataProvider>()));


            managerCollection.AddTransient<IEntryEditor<ISpriteSetFromSprEntry>>(() => new SpriteSetFromSprEditorVM(managerCollection.GetManager<SpriteSetsDataProvider>(),
                                                                                                                managerCollection.GetManager<PalettesDataProvider>(),
                                                                                                                managerCollection.GetManager<IDataProvider>()));



            managerCollection.AddTransient<IEntryEditor<ISpriteSetFromImageEntry>>(() => new SpriteSetFromImageEditorVM(managerCollection.GetManager<SpriteSetsDataProvider>(),
                                                                                                                managerCollection.GetManager<PalettesDataProvider>(),
                                                                                                                managerCollection.GetManager<IDataProvider>()));


            managerCollection.AddTransient<IEntryEditor<IPaletteFromBinaryEntry>>(() => new PaletteFromBinaryEditorVM(managerCollection.GetManager<PalettesDataProvider>(),
                                                                                                                managerCollection.GetManager<IDataProvider>()));


            managerCollection.AddTransient<IEntryEditor<IPaletteFromMapEntry>>(() => new PaletteFromMapEditorVM(managerCollection.GetManager<PalettesDataProvider>(),
                                                                                                                managerCollection.GetManager<IDataProvider>()));


            managerCollection.AddTransient<IEntryEditor<ITextEmbeddedEntry>>(() => new TextEmbeddedEditorVM(managerCollection.GetManager<TextsDataProvider>()));



            managerCollection.AddTransient<IEntryEditor<ITextFromMapEntry>>(() => new TextFromMapEditorVM(managerCollection.GetManager<TextsDataProvider>(),
                                                                                                          managerCollection.GetManager<IDataProvider>()));



            managerCollection.AddTransient<IEntryEditor<ISoundEntry>>(() => new SoundFromPcmEditorVM(managerCollection.GetManager<SoundsDataProvider>()));

            managerCollection.AddTransient<IEntryEditor<IScriptEmbeddedEntry>>(() => new ScriptEmbeddedEditorVM(managerCollection.GetManager<ScriptsDataProvider>()));


            managerCollection.AddTransient<IEntryEditor<IScriptFromFileEntry>>(() => new ScriptFromFileEditorVM(managerCollection.GetManager<IWorkspaceMan>(),
                                                                                                                managerCollection.GetManager<ScriptsDataProvider>(),
                                                                                                                managerCollection.GetManager<IDataProvider>()));



        }


        public static void SetupDbEntryEditors(this IManagerCollection managerCollection)
        {
            managerCollection.AddTransient<TileSetEditorVM>(() => new TileSetEditorVM(managerCollection, managerCollection.GetManager<IWorkspaceMan>(),
                                                                                                                managerCollection.GetManager<IDialogProvider>()));
            managerCollection.AddTransient<SpriteSetEditorVM>(() => new SpriteSetEditorVM(managerCollection, managerCollection.GetManager<IWorkspaceMan>(),
                                                                                                                managerCollection.GetManager<IDialogProvider>()));
            managerCollection.AddTransient<ActionSetEditorVM>(() => new ActionSetEditorVM(managerCollection, managerCollection.GetManager<IWorkspaceMan>(),
                                                                                                                managerCollection.GetManager<IDialogProvider>()));
            managerCollection.AddTransient<PaletteEditorVM>(() => new PaletteEditorVM(managerCollection, managerCollection.GetManager<IWorkspaceMan>(),
                                                                                                                managerCollection.GetManager<IDialogProvider>()));
            managerCollection.AddTransient<TextEditorVM>(() => new TextEditorVM(managerCollection, managerCollection.GetManager<IWorkspaceMan>(),
                                                                                                                managerCollection.GetManager<IDialogProvider>()));
            managerCollection.AddTransient<ScriptEditorVM>(() => new ScriptEditorVM(managerCollection, managerCollection.GetManager<IWorkspaceMan>(),
                                                                                                                managerCollection.GetManager<IDialogProvider>()));
            managerCollection.AddTransient<EntityTemplateEditorVM>(() => new EntityTemplateEditorVM(managerCollection, managerCollection.GetManager<IWorkspaceMan>(),
                                                                                                                managerCollection.GetManager<IDialogProvider>()));
            managerCollection.AddTransient<ImageEditorVM>(() => new ImageEditorVM(managerCollection, managerCollection.GetManager<IWorkspaceMan>(),
                                                                                                                managerCollection.GetManager<IDialogProvider>()));
            managerCollection.AddTransient<SoundEditorVM>(() => new SoundEditorVM(managerCollection, managerCollection.GetManager<IWorkspaceMan>(),
                                                                                                                managerCollection.GetManager<IDialogProvider>()));
            managerCollection.AddTransient<MapEditorVM>(() => new MapEditorVM(managerCollection.GetManager<IWorkspaceMan>(),
                                                                                                                managerCollection.GetManager<MapsDataProvider>(),
                                                                                                                managerCollection.GetManager<PalettesDataProvider>(),
                                                                                                                managerCollection.GetManager<ActionSetsDataProvider>(),
                                                                                                                managerCollection.GetManager<TileSetsDataProvider>(),
                                                                                                                managerCollection.GetManager<IDialogProvider>()));
            managerCollection.AddTransient<DataSourceEditorVM>(() => new DataSourceEditorVM(managerCollection, managerCollection.GetManager<IWorkspaceMan>(),
                                                                                                                managerCollection.GetManager<IDialogProvider>()));
        }

        public static void SetupDbEntryEditorFactory(this IManagerCollection managerCollection)
        {
            managerCollection.AddSingleton<DbEntryEditorFactory>(() =>
            {
                var entryEditorFactory = new DbEntryEditorFactory(managerCollection);
                entryEditorFactory.Register<IRepository<ITileSetEntry>, TileSetEditorVM>();
                entryEditorFactory.Register<IRepository<ISpriteSetEntry>, SpriteSetEditorVM>();
                entryEditorFactory.Register<IRepository<IActionSetEntry>, ActionSetEditorVM>();
                entryEditorFactory.Register<IRepository<IPaletteEntry>, PaletteEditorVM>();
                entryEditorFactory.Register<IRepository<ITextEntry>, TextEditorVM>();
                entryEditorFactory.Register<IRepository<IScriptEntry>, ScriptEditorVM>();
                entryEditorFactory.Register<IRepository<IEntityTemplateEntry>, EntityTemplateEditorVM>();
                entryEditorFactory.Register<IRepository<IImageEntry>, ImageEditorVM>();
                entryEditorFactory.Register<IRepository<ISoundEntry>, SoundEditorVM>();
                entryEditorFactory.Register<IRepository<IMapEntry>, MapEditorVM>();
                entryEditorFactory.Register<IRepository<IDataSourceEntry>, DataSourceEditorVM>();
                return entryEditorFactory;
            });
        }

        #endregion Public Methods
    }
}