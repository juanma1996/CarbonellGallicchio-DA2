﻿using ImporterInterface;
using ImporterLogicInterface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace ImporterLogic
{
    public class ImporterLogics : IImporterLogic
    {

        public void InstantiateObjectWithKnownInterface(string filePath)
        {
            var dllFile = new FileInfo(@"C:\Users\jgallicchio\Documents\CarbonellGallicchio\BetterCalm\XmlContentImporter\bin\Debug\netcoreapp3.1\XmlContentImporter.dll");
            Assembly myAssembly = Assembly.LoadFile(dllFile.FullName);
            IEnumerable<Type> implementations = GetTypesInAssembly<IContentImporter>(myAssembly);
            IContentImporter contentImporter = (IContentImporter)Activator.CreateInstance(implementations.First());
            ContentImporterModel a = contentImporter.ImportContent(filePath);  
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
    }
}
