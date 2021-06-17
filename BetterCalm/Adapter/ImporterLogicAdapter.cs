using AdapterExceptions;
using AdapterInterface;
using BusinessExceptions;
using ImporterLogicInterface;
using Model.In;
using System;
using System.Collections.Generic;
using System.IO;

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
            try
            {
                List<string> importers = importerLogic.GetAll();

                return importers;
            }
            catch (DirectoryNotFoundException)
            {
                throw new InvalidRouteForImplementationsException("Invalid route for implementations");
            }
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
            catch (TypeLoadException)
            {
                throw new InvalidRouteForFileException("Invalid route for file");
            }
            catch (DirectoryNotFoundException)
            {
                throw new InvalidRouteForImplementationsException("Invalid route for implementations");
            }
        }
    }
}
