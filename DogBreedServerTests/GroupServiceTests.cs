
using System;
using System.Collections.Generic;
using System.Linq;
using Contracts;
using Entities.Models;
using LoggerService;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace DogBreedServerTests
{
    

    public class GroupServiceTests
    {
        DogBreedServer.Controllers.GroupsController _controller;
        IRepositoryWrapper _service;
        ILoggerManager logger;

        [SetUp]
        public void Init()
        {
            logger = new LoggerManager();
            _service = new TestRepositoryWrapper();
            _controller = new DogBreedServer.Controllers.GroupsController(logger, _service); ////GroupsRepository(logger, _service);
        }


        [Test]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            var expectedResult = 5;

            // Act
            var okResult = _controller.GetAllGroups();

            var okObject = okResult as OkObjectResult;
            
            // Assert
            var result = (IEnumerable<Groups>)okObject.Value;

            Assert.IsInstanceOf<OkObjectResult>(okResult);
            Assert.AreEqual(expectedResult, result.Count());
        }

        [Test]
        public void Get_WhenCalled_ReturnsSingle()
        {
            var expectedResult = "RottieGroup";

            var id = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c202");

            // Act
            var okResult = _controller.GetGroupsById(id);

            var okObject = okResult as OkObjectResult;
            // Assert

            var result = (Groups)okObject.Value;

            Assert.IsInstanceOf<OkObjectResult>(okResult);
            Assert.AreEqual(expectedResult, result.GroupName);
        }

        [Test]
        public void Get_WhenCalledCreate_ReturnsOK()
        {
            var res = new Groups
            {
                GroupName = "NewBreed",
                GroupdId = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd91234"),
              
            };

            // Act
            var okResult = _controller.CreateGroup(res);

            // Assert
            Assert.IsInstanceOf<CreatedAtRouteResult>(okResult);
        }

        [Test]
        public void Get_WhenCalledDelete_ReturnsNoContent()
        {
            var deleteId = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c204");

            // Act
            var okResult = _controller.DeleteGroup(deleteId);

            // Assert
            Assert.IsInstanceOf<NoContentResult>(okResult);
        }


        [Test]
        public void Get_WhenCalledDelete_ReturnsNotFound()
        {
            var invailedID = new Guid("ab1bd817-98cd-4cf3-a80a-53ea0cd91234");

            // Act
            var okResult = _controller.DeleteGroup(invailedID);

            // Assert
            Assert.IsInstanceOf<NotFoundResult>(okResult);
        }

        [Test]
        public void Get_WhenCalled_ReturneUpreed11()
        {
            var updateId = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c203");

            var res = new Groups()
            {
                GroupName = "NewGroup",
                GroupdId = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd91234")
            };
            // Act
            var okResult = _controller.UpdateGroup(updateId, res);

            // Assert
            Assert.IsInstanceOf<NoContentResult>(okResult);
        }

        [Test]
        public void Get_WhenCalled_ReturnsUoBreed11()
        {
            var invailed = new Guid("ab2bd817-98cd-4cf3-a80a-53e20cd9c203");

            var res = new Groups()
            {
                GroupName = "NewGroup",
                GroupdId = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd91234")
            };
            // Act
            var okResult = _controller.UpdateGroup(invailed, res);

            // Assert
            Assert.IsInstanceOf<NotFoundResult>(okResult);
        }

        [Test]
        public void Get_WhenCalled_GetBreedByGroupId()
        {
            var invailedID = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c203");

            // Act
            var okResult = _controller.GetGroupWithDetails(invailedID);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(okResult);
        }
    }
}
