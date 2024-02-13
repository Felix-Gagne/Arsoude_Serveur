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
using Arsoude_Backend.Data;
using Microsoft.EntityFrameworkCore;
using Arsoude_Backend.Models.DTOs;

namespace Arsoude_Backend.Services.Tests
{
    [TestClass()]
    public class TrailServiceTests
    {

        DbContextOptions<ApplicationDbContext> options;

        public TrailServiceTests()
        {
            options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TrailsService")
                .Options;
        }

        [TestCleanup]
        public void Dispose()
        {
            using ApplicationDbContext db = new ApplicationDbContext(options);
            db.Trails.RemoveRange(db.Trails);
            db.SaveChanges();
        }

        [TestMethod]
        public void GetFilteredTrailsNull()
        {
            using ApplicationDbContext db = new ApplicationDbContext(options);
<<<<<<< HEAD
            TrailService service = new TrailService( db);
=======
            TrailService service = new TrailService(db);
>>>>>>> DEV

            Coordinates starting = new Coordinates
            {
                Latitude = 1.0,
                Longitude = 1.0
            };

            Coordinates ending = new Coordinates
            {
                Latitude = 1.0,
                Longitude = 1.0
            };

<<<<<<< HEAD
            Trail trail1 = new Trail
            {
                Id = 1,
                Name = "Test1",
                Description = "Ceci est le test numéro 1",
                Location = "Varennes",
                Type = TrailType.Pied,
                StartingCoordinates = starting,
                EndingCoordinates = ending
            };

            FilterDTO dto = new FilterDTO
            {
                Type = TrailType.Vélo
            };
=======
            using (var context = new ApplicationDbContext(options))
            {
                var trailService = new TrailService(null, context);
                var coordinates = new Coordinates() { Id = 500 ,Latitude = 1, Longitude = 1 };

                var user = new User()
                {    IdentityUserId = "11",
                    Id = 500,
                    AreaCode = "J4J5J8",
                    FirstName = "Gabriel",
                    LastName = "Gérard"
                };
                context.TrailUsers.Add(user);

                var trail = new Trail() { 
                    Id = 400,
                    OwnerId = 2,
                    Description = "Test", 
                    EndingCoordinates = coordinates, 
                    StartingCoordinates = coordinates, 
                    EndingCoordinatesId = 500,
                    StartingCoordinatesId = 500,
                    Location = "location", 
                    Name = "test", 
                    Type = 0 };
                context.Trails.Add(trail);
                context.SaveChanges();
>>>>>>> TEST_Admin

            try
            {
                service.GetFilteredTrails(dto);
            }
            catch(Exception ex)
            {
                Assert.AreEqual(new Exception("Pas de randonnées trouvé pour les filtres fournis"), ex.Message);
            }

        }

        [TestMethod]
        public async Task GetFilteredTrailsKeywordOK()
        {
            using ApplicationDbContext db = new ApplicationDbContext(options);
<<<<<<< HEAD
            TrailService service = new TrailService( db);
=======
            TrailService service = new TrailService(db);
>>>>>>> DEV

            Coordinates starting = new Coordinates
            {
                Latitude = 1.0,
                Longitude = 1.0
            };

            Coordinates ending = new Coordinates
            {
                Latitude = 1.0,
                Longitude = 1.0
            };

            Trail trail1 = new Trail
            {
                Id = 1,
                Name = "Test1",
                Description = "Ceci est le test numéro 1",
                Location = "Varennes",
                Type = TrailType.Pied,
                StartingCoordinates = starting,
                EndingCoordinates = ending
            };
            db.Add(trail1);

            Trail trail2 = new Trail
            {
                Id = 2,
                Name = "Test2",
                Description = "1",
                Location = "Varennes",
                Type = TrailType.Pied,
                StartingCoordinates = starting,
                EndingCoordinates = ending
            };
            db.Add(trail2);

            Trail trail3 = new Trail
            {
                Id = 3,
                Name = "Test3",
                Description = "Ceci est le test numéro 2",
                Location = "Varennes",
                Type = TrailType.Vélo,
                StartingCoordinates = starting,
                EndingCoordinates = ending
            };
            db.Add(trail3);
            db.SaveChanges();

            FilterDTO dto = new FilterDTO
            {
                Keyword = "1"
            };

            List<Trail> trails = await service.GetFilteredTrails(dto);

            Assert.AreEqual(2, trails.Count());

        }

        [TestMethod]
        public async Task GetFilteredTrailsTypeOK()
        {
            using ApplicationDbContext db = new ApplicationDbContext(options);
            TrailService service = new TrailService(db);

            Coordinates starting = new Coordinates
            {
                Latitude = 1.0,
                Longitude = 1.0
            };

            Coordinates ending = new Coordinates
            {
                Latitude = 1.0,
                Longitude = 1.0
            };

            Trail trail1 = new Trail
            {
                Id = 1,
                Name = "Test1",
                Description = "Ceci est le test numéro 1",
                Location = "Varennes",
                Type = TrailType.Pied,
                StartingCoordinates = starting,
                EndingCoordinates = ending
            };
            db.Add(trail1);

            Trail trail2 = new Trail
            {
                Id = 2,
                Name = "Test2",
                Description = "1",
                Location = "Varennes",
                Type = TrailType.Pied,
                StartingCoordinates = starting,
                EndingCoordinates = ending
            };
            db.Add(trail2);

            Trail trail3 = new Trail
            {
                Id = 3,
                Name = "Test3",
                Description = "Ceci est le test numéro 2",
                Location = "Varennes",
                Type = TrailType.Vélo,
                StartingCoordinates = starting,
                EndingCoordinates = ending
            };
            db.Add(trail3);
            db.SaveChanges();

            FilterDTO dto = new FilterDTO
            {
                Type = TrailType.Pied
            };

            List<Trail> trails = await service.GetFilteredTrails(dto);

            Assert.AreEqual(2, trails.Count());

        }

        [TestMethod]
        public async Task GetFilteredTrailsDistanceOK()
        {
            using ApplicationDbContext db = new ApplicationDbContext(options);
            TrailService service = new TrailService(db);

            Coordinates starting = new Coordinates
            {
                Latitude = 1.0,
                Longitude = 1.0
            };

            Coordinates ending = new Coordinates
            {
                Latitude = 1.0,
                Longitude = 1.0
            };

            Coordinates starting2 = new Coordinates
            {
                Latitude = 10.0,
                Longitude = 10.0
            };

            Coordinates ending2 = new Coordinates
            {
                Latitude = 10.0,
                Longitude = 10.0
            };

            Trail trail1 = new Trail
            {
                Id = 1,
                Name = "Test1",
                Description = "Ceci est le test numéro 1",
                Location = "Varennes",
                Type = TrailType.Pied,
                StartingCoordinates = starting,
                EndingCoordinates = ending
            };
            db.Add(trail1);

            Trail trail2 = new Trail
            {
                Id = 2,
                Name = "Test2",
                Description = "1",
                Location = "Varennes",
                Type = TrailType.Pied,
                StartingCoordinates = starting,
                EndingCoordinates = ending
            };
            db.Add(trail2);

            Trail trail3 = new Trail
            {
                Id = 3,
                Name = "Test3",
                Description = "Ceci est le test numéro 2",
                Location = "Varennes",
                Type = TrailType.Vélo,
                StartingCoordinates = starting2,
                EndingCoordinates = ending2
            };
            db.Add(trail3);
            db.SaveChanges();

            FilterDTO dto = new FilterDTO
            {
                Coordinates = starting,
                Type = TrailType.Pied
            };

            List<Trail> trails = await service.GetFilteredTrails(dto);

            Assert.AreEqual(2, trails.Count());

        }

        [TestMethod]
        public async Task GetFilteredTrailsOK()
        {
            using ApplicationDbContext db = new ApplicationDbContext(options);
            TrailService service = new TrailService(db);

            Coordinates starting = new Coordinates
            {
                Latitude = 1.0,
                Longitude = 1.0
            };

            Coordinates ending = new Coordinates
            {
                Latitude = 1.0,
                Longitude = 1.0
            };

            Trail trail1 = new Trail
            {
                Id = 1,
                Name = "Test1",
                Description = "Ceci est le test numéro 1",
                Location = "Varennes",
                Type = TrailType.Pied,
                StartingCoordinates = starting,
                EndingCoordinates = ending
            };
            db.Add(trail1);

            Trail trail2 = new Trail
            {
                Id = 2,
                Name = "Test2",
                Description = "1",
                Location = "Varennes",
                Type = TrailType.Pied,
                StartingCoordinates = starting,
                EndingCoordinates = ending
            };
            db.Add(trail2);

            Trail trail3 = new Trail
            {
                Id = 3,
                Name = "Test3",
                Description = "Ceci est le test numéro 2",
                Location = "Varennes",
                Type = TrailType.Vélo,
                StartingCoordinates = starting,
                EndingCoordinates = ending
            };
            db.Add(trail3);
            db.SaveChanges();

            FilterDTO dto = new FilterDTO();

            List<Trail> trails = await service.GetFilteredTrails(dto);

            Assert.AreEqual(3, trails.Count());

        }

    }
}