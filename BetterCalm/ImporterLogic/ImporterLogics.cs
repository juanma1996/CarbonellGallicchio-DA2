using ImporterInterface;
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

        public void InstantiateObjectWithKnownInterface()
        {
            var dllFile = new FileInfo(@"C:\Users\jgallicchio\Documents\CarbonellGallicchio\BetterCalm\JsonContentImporter\bin\Debug\netcoreapp3.1\JsonContentImporter.dll");
            Assembly myAssembly = Assembly.LoadFile(dllFile.FullName);
            IEnumerable<Type> implementations = GetTypesInAssembly<IContentImporter>(myAssembly);
            IContentImporter contentImporter = (IContentImporter)Activator.CreateInstance(implementations.First());
            contentImporter.ImportContent(@"C:\Users\juan.gallicchio\Desktop\ejemplo.json");
        }

        public IEnumerable<Type> GetTypesInAssembly<Interface>(Assembly assembly)
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
