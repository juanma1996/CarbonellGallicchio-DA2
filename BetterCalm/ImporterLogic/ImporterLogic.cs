using ImporterInterface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace ImporterLogic
{
    public class ImporterLogic
    {

        private static void InstantiateObjectWithKnownInterface()
        {
            var dllFile = new FileInfo(@"Library.dll");
            Assembly myAssembly = Assembly.LoadFile(dllFile.FullName);
            IEnumerable<Type> implementations = GetTypesInAssembly<IContentImporter>(myAssembly);
            IContentImporter contentImporter = (IContentImporter)Activator.CreateInstance(implementations.First(), new object[] { "Juan", "T." });
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
