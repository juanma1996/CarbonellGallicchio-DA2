using Model.In;
using System.Collections.Generic;

namespace ImporterLogicInterface
{
    public interface IImporterLogic
    {
        void ImportWithKnownInterface(ImportModel importModel);
        List<string> GetAll();
    }
}
