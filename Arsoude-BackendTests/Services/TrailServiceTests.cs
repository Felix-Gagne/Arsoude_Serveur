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
using Microsoft.EntityFrameworkCore;
using Arsoude_Backend.Data;
using Arsoude_Backend.Exceptions;

namespace Arsoude_Backend.Services.Tests
{
    [TestClass()]
    public class TrailServiceTests
    {
        [TestMethod()]
        public void SwictchVisibility_ValidData()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "SwictchVisibility_ValidData")
                .Options;

            using (var context = new ApplicationDbContext(options))
            {
                var trailService = new TrailService(context);
                var coordinates = new Coordinates() { Id = 501 ,Latitude = 1, Longitude = 1 };

                var user = new User()
                {
                    Id = 501,
                    AreaCode = "J4J5J8",
                    FirstName = "Gabriel",
                    LastName = "Gérard",
                    IdentityUserId = "1"
                };
                context.TrailUsers.Add(user);

                var trail = new Trail() { 
                    Id = 401,
                    OwnerId = 501,
                    Description = "Test", 
                    EndingCoordinates = coordinates, 
                    StartingCoordinates = coordinates, 
                    EndingCoordinatesId = 501,
                    StartingCoordinatesId = 501,
                    Location = "location", 
                    Name = "test", 
                    Type = 0,
                    isPublic = false};
                context.Trails.Add(trail);
                context.SaveChanges();

                var result = trailService.SwitchVisiblityStatus(user, trail.Id, true);

                Assert.IsNotNull(result);
                Assert.AreEqual(context.Trails.FirstOrDefault(t => t.Id == trail.Id).isPublic, true);
            }
        }

        [TestMethod()]
        public void SwictchVisibility_UserNotFound()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "SwictchVisibility_ValidData")
                .Options;

            using (var context = new ApplicationDbContext(options))
            {
                var trailService = new TrailService(context);
                var coordinates = new Coordinates() { Id = 500, Latitude = 1, Longitude = 1 };

                var trail = new Trail()
                {
                    Id = 401,
                    OwnerId = 500,
                    Description = "Test",
                    EndingCoordinates = coordinates,
                    StartingCoordinates = coordinates,
                    EndingCoordinatesId = 500,
                    StartingCoordinatesId = 500,
                    Location = "location",
                    Name = "test",
                    Type = 0,
                    isPublic = false
                };
                context.Trails.Add(trail);
                context.SaveChanges();

                Assert.ThrowsException<UserNotFoundException>(() => trailService.SwitchVisiblityStatus(null, trail.Id, true));
            }
        }

        [TestMethod()]
        public void SwictchVisibility_TrailNotFound()
        {

        }

        [TestMethod()]
        public void SwictchVisibility_NotOwner()
        {

        }
    }
}