using Microsoft.VisualStudio.TestTools.UnitTesting;
using Arsoude_Backend.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arsoude_Backend.Data;
using Arsoude_Backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Arsoude_Backend.Services.Tests
{

    [TestClass()]
    public class AdminServiceTests
    {
        [TestClass()]
        public class AdminControllerTests
        {

            private readonly ApplicationDbContext _dbContext;


            public AdminControllerTests()
            {
                var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                           .UseInMemoryDatabase(databaseName: "AdminTest")
                           .Options;
                _dbContext = new ApplicationDbContext(options);


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
            public async Task setStatusValidAsync()
            {

                // Arrange
                AdminService service = new AdminService(_dbContext);
                bool newStatus = true;
                int trailId = 400;

                // Act
                Trail updatedTrail = await service.setStatus(newStatus, trailId);

                // Assert
                Assert.AreEqual(newStatus, updatedTrail.IsApproved);




            }
            [ExpectedException(typeof(NullReferenceException))]
            [TestMethod()]
            public async Task setStatus_InvalidTrailId_ReturnsNull()
            {
                // Arrange
                AdminService service = new AdminService(_dbContext);
                bool newStatus = true;
                int trailId = 999; // Invalid TrailId

                // Act
                Trail updatedTrail = await service.setStatus(newStatus, trailId);

                // Assert Exception expected
               
            }

            [TestMethod()]
            public async Task DeleteTrail_ValidTrailId_DeletesTrail()
            {
                // Arrange
                AdminService service = new AdminService(_dbContext);
                int trailId = 400;

                // Act
                Trail deletedTrail = await service.DeleteTrail(trailId);
                Trail trailInDatabase = await _dbContext.Trails.FindAsync(trailId);

                // Assert
                Assert.IsNull(trailInDatabase); //Verification que la trail a bien été supprimé
                Assert.IsNotNull(deletedTrail);  //Vérification que le service renvoit bien la trail
                Assert.AreEqual(trailId, deletedTrail.Id); //vérification que la bonne trail à été supprimé
            }

            [TestMethod()]
            [ExpectedException(typeof(NullReferenceException))]
            public async Task DeleteTrail_InvalidTrailId_ThrowsException()
            {
                // Arrange
                AdminService service = new AdminService(_dbContext);
                int trailId = 999; // Invalid TrailId

                // Act
                Trail deletedTrail = await service.DeleteTrail(trailId);

                // Assert
                // Assert Exception expected
            }

            [TestMethod()]
            public async Task GetList_ReturnsgoodTrails()
            {
                // Arrange
                AdminService service = new AdminService(_dbContext);

                // Act
                List<Trail> trails = await service.GetList();

                // Assert
                Assert.IsNotNull(trails); // la liste n'est pas null
                Assert.AreEqual(2, trails.Count); // Il y a bien 2 trail dans la liste
                Assert.IsTrue(trails.All(t => t.IsApproved == null && t.isPublic)); // tout les trails sont public et non approuvé ou refusé
            }
        }
    }
}