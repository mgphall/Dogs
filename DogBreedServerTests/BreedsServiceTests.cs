namespace DogBreedServerTests
{
    using System;
    using System.Linq;
    using Contracts;
    using DogBreedServer.Controllers;
    using Entities.Models;
    using LoggerService;
    using Microsoft.AspNetCore.Mvc;
    using NUnit.Framework;
    using System.Collections.Generic;
   
    [TestFixture]
    public class BreedsServiceTests
    {
        BreedsController _controller;
        IRepositoryWrapper _service;
        ILoggerManager logger;

        [SetUp]
        public void Init()
        {
            logger = new LoggerManager();
            _service = new TestRepositoryWrapper();
            _controller = new BreedsController(logger, _service);
        }

        [Test]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            var expectedResult = 5;

            // Act
            var okResult = _controller.GetAllBreeds();

            var okObject = okResult as OkObjectResult;
            // Assert

            var breedsList = (IEnumerable<Breeds>)okObject.Value;

            Assert.IsInstanceOf<OkObjectResult>(okResult);
            Assert.AreEqual(expectedResult, breedsList.Count());
        }


        [Test]
        public void Get_WhenCalled_ReturnsSingle()
        {
            var expectedResult = "Rottie";

            // Act
            var okResult = _controller.GetBreedById(new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c202"));

            var okObject = okResult as OkObjectResult;
            // Assert

            var breedsList = (Breeds)okObject.Value;

            Assert.IsInstanceOf<OkObjectResult>(okResult);
            Assert.AreEqual(expectedResult, breedsList.Breed);
        }

        [Test]
        public void Get_WhenCalled_ReturnsAllItems1()
        {
            var res = new Breeds
            {
                Breed = "NewBreed",
                GroupId = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd91234"),
                Id = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd94321")
            };

            // Act
                var okResult = _controller.CreateBreed(res);
     
            // Assert
            Assert.IsInstanceOf<CreatedAtRouteResult>(okResult);
        }

        [Test]
        public void Get_WhenCalled_ReturnsDeleteBreed()
        {
            var deleteId = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200");

            // Act
            var okResult = _controller.DeleteBreed(deleteId);

            // Assert
            Assert.IsInstanceOf<NoContentResult>(okResult);
        }

        [Test]
        public void Get_WhenCalled_ReturnsDeleteBreed1()
        {
            var invailedID = new Guid("ab1bd817-98cd-4cf3-a80a-53ea0cd91234");

            // Act
            var okResult = _controller.DeleteBreed(invailedID);

            // Assert
            Assert.IsInstanceOf<NotFoundResult>(okResult);
        }

        [Test]
        public void Get_WhenCalled_ReturnsDeleteBreed11()
        {
            var deleteId = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200");

            var res = new Breeds
            {
                Breed = "NewBreed",
                GroupId = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd91234"),
                Id = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd94321")
            };
            // Act
            var okResult = _controller.UpdateBreed(deleteId, res);

            // Assert
            Assert.IsInstanceOf<NoContentResult>(okResult);
        }

        [Test]
        public void Get_WhenCalled_ReturnsUpdatedBreed1()
        {
            var invailedID = new Guid("ab1bd817-98cd-4cf3-a80a-53ea0cd91234");

            // Act
            var okResult = _controller.UpdateBreed(invailedID, new Breeds());

            // Assert
            Assert.IsInstanceOf<NotFoundResult>(okResult);
        }


        [Test]
        public void Get_WhenCalled_GetBreedByGroupId()
        {
            var invailedID = new Guid("ab1bd817-98cd-4cf3-a80a-53ea0cd91234");

            // Act
            var okResult = _controller.GetBreedByGroupId(invailedID);

            // Assert
            Assert.IsInstanceOf<NotFoundResult>(okResult);
        }


        [Test]
        public void Get_WhenCalledinvailedID_GetBreedByGroupId()
        {
            var invailedID = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200");

            // Act
            var okResult = _controller.GetBreedByGroupId(invailedID);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(okResult);
        }


        [Test]
        public void Get_WhenCalled_InvailedReturnsError()
        {
            var res = new Breeds
            {
                Breed =  string.Empty,
                GroupId =  new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd91234"),
                Id = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd94321")
            };

            // Act
            var okResult = _controller.CreateBreed(res);

            // Assert
            Assert.IsInstanceOf<BadRequestObjectResult>(okResult);
        }
    }
}
