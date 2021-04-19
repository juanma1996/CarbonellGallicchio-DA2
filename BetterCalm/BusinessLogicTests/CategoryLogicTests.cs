﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Domain;
using DataAccessInterface;
using Moq;
using System;
using BusinessLogic.Mapper;
using Model.Out;
using System.Linq;

namespace BusinessLogic.Tests
{
    [TestClass()]
    public class CategoryLogicTests
    {
        [TestMethod]
        public void TestGetAllCategories()
        {
            List<Playlist> playlists = new List<Playlist>()
            {
                new Playlist()
                {
                    Id = 1
                }
            };
            List<Category> categoryToReturn = new List<Category>()
            {
                new Category
                {
                    Id = 1,
                    Playlists = playlists
                }
            };
            Mock<IRepository<Category>> mock = new Mock<IRepository<Category>>(MockBehavior.Strict);
            mock.Setup(m => m.GetAll()).Returns(categoryToReturn);
            ModelMapper mapper = new ModelMapper();
            Validation validate = new Validation();
            CategoryLogic categoryLogic = new CategoryLogic(mock.Object, mapper, validate);

            List<CategoryBasicInfoModel> result = categoryLogic.GetAll();

            mock.VerifyAll();
            Assert.AreEqual(categoryToReturn.Count, result.Count);
        }

        [TestMethod]
        public void TestGetPlaylistByCategoryOk()
        {
            List<Playlist> playlists = new List<Playlist>()
            {
                new Playlist()
                {
                    Id = 1,
                },
                new Playlist()
                {
                    Id = 2,
                },
            };
            Category categoryToReturn = new Category()
            {
                Id = 1,
                Playlists = playlists
            };
            Mock<IRepository<Category>> mock = new Mock<IRepository<Category>>(MockBehavior.Strict);
            mock.Setup(m => m.GetById(1)).Returns(categoryToReturn);
            ModelMapper mapper = new ModelMapper();
            Validation validate = new Validation();
            CategoryLogic categoryLogic = new CategoryLogic(mock.Object, mapper, validate);
            
            List<PlaylistBasicInfoModel> result = categoryLogic.GetPlaylistsBy(1);

            mock.VerifyAll();
            Assert.AreEqual(result.Count, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestGetPlaylistByCategoryNotExistentId()
        {
            List<Playlist> playlists = new List<Playlist>();
            Category categoryToReturn = new Category()
            {
                Id = 1,
                Playlists = playlists
            };
            var id = 2;
            Mock<IRepository<Category>> mock = new Mock<IRepository<Category>>(MockBehavior.Strict);
            mock.Setup(m => m.GetById(id)).Returns((Category)null);
            ModelMapper mapper = new ModelMapper();
            Validation validate = new Validation();
            CategoryLogic categoryLogic = new CategoryLogic(mock.Object, mapper, validate);

            var result = categoryLogic.GetPlaylistsBy(2);

            mock.VerifyAll();
        }
    }
}