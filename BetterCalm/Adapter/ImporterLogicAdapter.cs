using AdapterExceptions;
using AdapterInterface;
using BusinessExceptions;
using ImporterLogicInterface;
using Model.In;
using System.Collections.Generic;

namespace Adapter
{
    public class ImporterLogicAdapter : IImporterLogicAdapter
    {
        private readonly IImporterLogic importerLogic;

        public ImporterLogicAdapter(IImporterLogic importerLogic)
        {
            this.importerLogic = importerLogic;
        }

        public List<string> GetAll()
        {
            List<string> importers = importerLogic.GetAll();

            return importers;
        }

        public void ImportWithKnownInterface(ImportModel importModel)
        {
            try
            {
                importerLogic.ImportWithKnownInterface(importModel);
            }
            catch (NullObjectException e)
            {
                throw new NotFoundException(e.errorMessage);
            }
        }
    }
}
