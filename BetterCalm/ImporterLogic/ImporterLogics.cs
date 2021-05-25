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

namespace ImporterLogic
{
    public class ImporterLogics : IImporterLogic
    {
        private readonly IConfiguration configuration;

        public ImporterLogics(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void ImportWithKnownInterface(ImportModel importModel)
        {
            string path = configuration["ImportersFolder:Path"];
            DirectoryInfo directory = new DirectoryInfo(path);
            FileInfo[] files = directory.GetFiles("*.dll");
            bool foundImporter = false;
            for (int i = 0; i < files.Length && !foundImporter; i++)
            {
                Assembly myAssembly = Assembly.LoadFile(files[i].FullName);
                IEnumerable<Type> implementations = GetTypesInAssembly<IContentImporter>(myAssembly);
                if (implementations != null && implementations.Count() != default)
                {
                    IContentImporter contentImporter = (IContentImporter)Activator.CreateInstance(implementations.FirstOrDefault());
                    if (contentImporter != null && contentImporter.GetId().Equals(importModel.ImporterType))
                    {
                        foundImporter = true;
                        ContentImporterModel a = contentImporter.ImportContent(importModel.FilePath);
                    } 
                }
                
            }

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

        public List<string> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
