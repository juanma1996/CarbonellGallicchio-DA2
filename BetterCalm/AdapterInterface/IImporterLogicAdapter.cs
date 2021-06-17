using Model.In;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdapterInterface
{
    public interface IImporterLogicAdapter
    {
        void ImportWithKnownInterface(ImportModel importModel);
        List<string> GetAll();
    }
}
