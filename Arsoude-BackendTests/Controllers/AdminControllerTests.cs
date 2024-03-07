using Microsoft.VisualStudio.TestTools.UnitTesting;
using Arsoude_Backend.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arsoude_Backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Arsoude_Backend.Data;
using Arsoude_Backend.Services;
using Moq;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;

namespace Arsoude_Backend.Controllers.Tests
{
    [TestClass()]
    public class AdminControllerTests
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly AdminService adminService;
        private readonly IConfiguration _config;
        public AdminControllerTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                       .UseInMemoryDatabase(databaseName: "AdminTest")
                       .Options;
            _dbContext = new ApplicationDbContext(options);
            adminService = new AdminService(_dbContext, null);
            var config = new Mock<IConfiguration>();
            _config = config.Object;

        }


        [TestInitialize]
        public void Init()
        {
            IdentityUser admin = new IdentityUser
            {
                Id = "11111111-1111-1111-1111-111111111111",
                UserName = "admin@admin.com",
                Email = "admin@admin.com",
                // La comparaison d'identity se fait avec les versions normalis�s
                NormalizedEmail = "ADMIN@ADMIN.COM",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                EmailConfirmed = true
            };
            _dbContext.Users.Add(admin);
            var coordinates = new Coordinates() { Id = 500, Latitude = 1, Longitude = 1 };
            var coordinates2 = new Coordinates() { Id = 501, Latitude = 1, Longitude = 1 };
            _dbContext.Coordinates.Add(coordinates);
            _dbContext.Coordinates.Add(coordinates2);
            var trail1 = new Trail()
            {
                Id = 1,
                isPublic = true,
                EndingCoordinates = coordinates,
                StartingCoordinates = coordinates,
                Description = "Test",
                Location = "location",
                Name = "test",
                Type = 0
            };
            var trail2 = new Trail()
            {
                Id = 2,
                isPublic = true,
                EndingCoordinates = coordinates,
                StartingCoordinates = coordinates,
                Description = "Test",
                Location = "location",
                Name = "test",
                Type = 0
            };
            var trail3 = new Trail()
            {
                Id = 3,
                isPublic = false,
                IsApproved = true,
                EndingCoordinates = coordinates,
                StartingCoordinates = coordinates,
                Description = "Test",
                Location = "location",
                Name = "test",
                Type = 0
            };
            _dbContext.Trails.AddRange(new List<Trail> { trail1, trail2, trail3 });

            var trail = new Trail()
            {
                Id = 400,
                OwnerId = 2,
                Description = "Test",
                EndingCoordinates = coordinates,
                StartingCoordinates = coordinates,
                EndingCoordinatesId = 500,
                StartingCoordinatesId = 501,
                Location = "location",
                Name = "test",
                Type = 0
            };
            _dbContext.Trails.Add(trail);
            _dbContext.SaveChanges();
        }

        [TestCleanup]
        public void Dispose()
        {
            
            _dbContext.Trails.RemoveRange(_dbContext.Trails);
            _dbContext.Users.RemoveRange(_dbContext.Users);
            _dbContext.Coordinates.RemoveRange(_dbContext.Coordinates);
            _dbContext.SaveChanges();
        }

        [TestMethod()]
        public async Task EvaluateTrailTest()
        {
            // Arrange
            var controller = new AdminController(_dbContext, _config, adminService);
            int trailId = 1;
            bool isApproved = true;

            // Act
            IActionResult result = await controller.EvaluateTrail(isApproved, trailId);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;

            Assert.IsNotNull(okResult);
        }

        [TestMethod()]
        public async Task EvaluateTrail_InvalidTrailId()
        {
            // Arrange
            var controller = new AdminController(_dbContext, _config, adminService);
            int invalidTrailId = 999; // Id qui ne conrespond a auncune randonnée
            bool isApproved = true;

            // Act
            IActionResult result = await controller.EvaluateTrail(isApproved, invalidTrailId);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
            var badRequestResult = result as BadRequestObjectResult;
            Assert.IsNotNull(badRequestResult);
        }

        [TestMethod()]
        public async Task DeleteTrail_TrailNotFound_Test()
        {
            // Arrange
            var controller = new AdminController(_dbContext, _config, adminService);
            int nonExistentTrailId = 999; // Id qui ne conrespond a auncune randonnée

            // Act
            IActionResult result = await controller.DeleteTrail(nonExistentTrailId);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
           
        }

        [TestMethod()]
        public async Task DeleteTrail_ValidTrailId_Test()
        {
            // Arrange
            var controller = new AdminController(_dbContext, _config, adminService);
            int validTrailId = 1;

            // Act
            IActionResult result = await controller.DeleteTrail(validTrailId);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            //Vérifier si la randonnée a bien été deleted
            Assert.AreEqual(3, _dbContext.Trails.Count());
           

        }
        [TestMethod()]
        public async Task GetToBeApproved_Valid_Test()
        {
            // Arrange
            var controller = new AdminController(_dbContext, _config, adminService);

            // Act
            IActionResult result = await controller.GetToBeApproved();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult.Value);
            Assert.IsInstanceOfType(okResult.Value, typeof(List<Trail>)); // vérifie qu'il y a bien une liste
            var trails = okResult.Value as List<Trail>;
            Assert.IsTrue(trails.Count > 0);
            // vérifie que tout les trails dans la liste sont publique et n'ont pas de statue approuvé/refuser
            Assert.IsTrue(trails.All(t => t.IsApproved == null && t.isPublic == true)); 
        }


    }
}