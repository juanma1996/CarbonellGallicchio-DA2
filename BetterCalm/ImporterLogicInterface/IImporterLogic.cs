using System;
using System.Collections.Generic;
using System.Reflection;

namespace ImporterLogicInterface
{
    public interface IImporterLogic
    {
        void InstantiateObjectWithKnownInterface(string filePath);
    }
}
