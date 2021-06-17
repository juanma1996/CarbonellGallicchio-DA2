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

        private void ThrowInvalidRouteForImplementationsException()
        {
            throw new InvalidRouteForImplementationsException("Invalid route for implementations");
        }

        private void ThrowInvalidRouteForFileException()
        {
            throw new InvalidRouteForImplementationsException("Invalid route for implementations");
        }

        public List<string> GetAll()
        {
            List<string> importers = null;
            try
            {
                importers = importerLogic.GetAll();
            }
            catch (DirectoryNotFoundException)
            {
                ThrowInvalidRouteForImplementationsException();
            }

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
            catch (TypeLoadException)
            {
                ThrowInvalidRouteForFileException();
            }
            catch (DirectoryNotFoundException)
            {
                ThrowInvalidRouteForImplementationsException();
            }
        }
    }
}
