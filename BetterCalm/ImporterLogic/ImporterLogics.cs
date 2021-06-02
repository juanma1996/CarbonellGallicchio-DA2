using AutoMapper;
using ImporterInterface;
using ImporterInterface.Models;
using ImporterLogicInterface;
using Microsoft.Extensions.Configuration;
using Model.In;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using AdapterInterface;
using ImporterLogic.Mapper;

namespace ImporterLogic
{
    public class ImporterLogics : IImporterLogic
    {
        private readonly IConfiguration configuration;
        private readonly IMapper mapper;
        private readonly IAudioContentLogicAdapter audioContentLogicAdapter;
        private readonly IVideoContentLogicAdapter videoContentLogicAdapter;

        public ImporterLogics(IConfiguration configuration, IModelMapper mapper, IAudioContentLogicAdapter audioContentLogicAdapter,
            IVideoContentLogicAdapter videoContentLogicAdapter)
        {
            this.configuration = configuration;
            this.mapper = mapper.Configure();
            this.audioContentLogicAdapter = audioContentLogicAdapter;
            this.videoContentLogicAdapter = videoContentLogicAdapter;
        }

        private static IEnumerable<Type> GetTypesInAssembly<Interface>(Assembly assembly)
        {
            List<Type> types = new List<Type>();
            foreach (var type in assembly.GetTypes())
            {
                if (typeof(Interface).IsAssignableFrom(type))
                    types.Add(type);
            }
            return types;
        }
        private FileInfo[] GetFiles()
        {
            string path = configuration["ImportersFolder:Path"];
            DirectoryInfo directory = new DirectoryInfo(path);
            FileInfo[] files = directory.GetFiles("*.dll");
            return files;
        }
        private IEnumerable<Type> GetImplementations(string assemblyFullname)
        {
            Assembly myAssembly = Assembly.LoadFile(assemblyFullname);
            IEnumerable<Type> implementations = GetTypesInAssembly<IContentImporter>(myAssembly);
            return implementations;
        }
        public void ImportWithKnownInterface(ImportModel importModel)
        {
            FileInfo[] files = GetFiles();
            bool foundImporter = false;
            for (int i = 0; i < files.Length && !foundImporter; i++)
            {
                IEnumerable<Type> implementations = GetImplementations(files[i].FullName);
                if (implementations != null && implementations.Count() != default)
                {
                    IContentImporter contentImporter = (IContentImporter)Activator.CreateInstance(implementations.FirstOrDefault());
                    if (contentImporter != null && contentImporter.GetId().Equals(importModel.ImporterType))
                    {
                        foundImporter = true;
                        ContentImporterModel contentImporterModel = contentImporter.ImportContent(importModel.FilePath);
                        switch (contentImporterModel.PlayableContentType)
                        {
                            case ImporterInterface.Enums.PlayableContentType.AudioContent:
                                AudioContentModel audioContentModel = mapper.Map<AudioContentModel>(contentImporterModel);
                                audioContentLogicAdapter.Add(audioContentModel);
                                break;
                            case ImporterInterface.Enums.PlayableContentType.VideoContent:
                                VideoContentModel videoContentModel = mapper.Map<VideoContentModel>(contentImporterModel);
                                videoContentLogicAdapter.Add(videoContentModel);
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }
        public List<string> GetAll()
        {
            List<string> importers = new List<string>();
            FileInfo[] files = GetFiles();
            for (int i = 0; i < files.Length; i++)
            {
                IEnumerable<Type> implementations = GetImplementations(files[i].FullName);
                if (implementations != null && implementations.Count() != default)
                {
                    IContentImporter contentImporter = (IContentImporter)Activator.CreateInstance(implementations.FirstOrDefault());
                    if (contentImporter != null)
                    {
                        string importerId = contentImporter.GetId();
                        importers.Add(importerId);
                    }
                }
            }
            return importers;
        }
    }
}
