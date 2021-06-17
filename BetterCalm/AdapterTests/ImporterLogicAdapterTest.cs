using Adapter;
using ImporterLogicInterface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.In;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdapterTests
{
    [TestClass]
    public class ImporterLogicAdapterTest
    {
        [TestMethod]
        public void TestAddImportingOk()
        {
            ImportModel importModel = new ImportModel()
            {
                FilePath = "somePath",
                ImporterType = "json"
            };
            Mock<IImporterLogic> mock = new Mock<IImporterLogic>(MockBehavior.Strict);
            mock.Setup(m => m.ImportWithKnownInterface(It.IsAny<ImportModel>()));
            ImporterLogicAdapter importerLogicAdapter = new ImporterLogicAdapter(mock.Object);

            importerLogicAdapter.ImportWithKnownInterface(importModel);

            mock.VerifyAll();
        }

        [TestMethod]
        public void TestGetImportersOk()
        {
            List<string> importersToReturn = new List<string>()
            {
                "Json", "Xml"
            };
            Mock<IImporterLogic> mock = new Mock<IImporterLogic>(MockBehavior.Strict);
            mock.Setup(m => m.GetAll()).Returns(importersToReturn);
            ImporterLogicAdapter importerLogicAdapter = new ImporterLogicAdapter(mock.Object);

            List<string> importers =  importerLogicAdapter.GetAll();

            mock.VerifyAll();
            Assert.AreEqual(importersToReturn.Count, importers.Count);
            Assert.AreEqual(importersToReturn.First(), importers.First());
            Assert.AreEqual(importersToReturn.Last(), importers.Last());
        }
    }
}
