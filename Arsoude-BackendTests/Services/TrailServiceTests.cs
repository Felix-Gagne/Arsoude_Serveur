using Microsoft.VisualStudio.TestTools.UnitTesting;
using Arsoude_Backend.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Arsoude_Backend.Controllers;
using Arsoude_Backend.Models;
using Microsoft.AspNetCore.Identity;
using Arsoude_Backend.Models.Enums;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Mvc;
using Arsoude_Backend.Models.Interfaces;

namespace Arsoude_Backend.Services.Tests
{
    [TestClass()]
    public class TrailServiceTests
    {
        [TestMethod()]
        public void CreateTrail()
        {
            List<Coordinates> coordinates = new List<Coordinates>
            {
                new Coordinates
                {
                    Id = 1,
                    X = 45.559602,
                    Y = -73.580236

                },
                new Coordinates
                {
                    Id = 2,
                    X = 45.671822,
                    Y = -73.526654

                }
            };

            Trail trail = new Trail
            {
                Id = 1,
                Name = "TestTrail",
                Description = "UNE MECHANT GROS TRAJET",
                Location = "Bar chez Diane",
                Type = TrailType.Pied,


                StartingCoordinatesId = 1,
                EndingCoordinatesId = 1,
                OwnerId = 1
            };

            Mock<ITrailService> serviceMock  = new Mock<ITrailService>();
            Mock<TrailController> controller = new Mock<TrailController>(serviceMock.Object) { CallBase = true };

            serviceMock.Setup(s => s.CreateTrail(It.IsAny<Trail>(), It.IsAny<IdentityUser>())).ReturnsAsync(trail);

            var actionResult = controller.Object.CreateTrail(trail);

            var result = actionResult.Result as OkObjectResult;

            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void CreateTrailTrailNull()
        {
            List<Coordinates> coordinates = new List<Coordinates>();

            Mock<TrailService> serviceMock = new Mock<TrailService>();
            Mock<TrailController> controller = new Mock<TrailController>(serviceMock.Object) { CallBase = true };

            serviceMock.Setup(s => s.CreateTrail(It.IsAny<Trail>(), It.IsAny<IdentityUser>())).ThrowsAsync(new Exception());

            var actionResult = controller.Object.CreateTrail(null);

            var result = actionResult.Result as NotFoundResult;

            Assert.IsNotNull(result);
        }
    }
}