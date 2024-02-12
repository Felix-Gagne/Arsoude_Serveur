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
using Microsoft.Extensions.Options;

namespace Arsoude_Backend.Services.Tests
{
    [TestClass()]
    public class TrailServiceTests
    {

        DbContextOptions<ApplicationDbContext> options;

        private User user;
        private Trail trailInTheFavorite;
        private Trail trailtIWantInTheFavorite;

        public TrailServiceTests()
        {
            options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TrailService")
                .UseLazyLoadingProxies(true)
                .Options;
        }

        [TestInitialize]
        public void Init()
        {
            using ApplicationDbContext db = new ApplicationDbContext(options);

            Coordinates coordinates = new Coordinates() { Id = 1, Latitude = 1, Longitude = 1 };
            Coordinates coordinatesEnd = new Coordinates() { Id = 2, Latitude = 1, Longitude = 1 };
            Coordinates simpleCoordinates = new Coordinates() { Id = 3, Latitude = 1, Longitude = 1 };



            user = new User
            {
                LastName = "Simeon",
                FirstName = "Du bois",
                AreaCode = "asdasd",
                IdentityUserId = "11111111-1111-1111-1111-111111111113",
                FavouriteTrails = new List<UserFavoriteTrail>()
            };

            trailInTheFavorite = new Trail
            {
                Name = "Favorite",
                Description = "Test",
                Location = "Canada",
                Type = TrailType.Pied,
                ImageUrl = "https://media.timeout.com/images/105824352/image.jpg",
                StartingCoordinates = coordinates,
                EndingCoordinates = coordinatesEnd,
            };

            trailtIWantInTheFavorite = new Trail
            {
                Name = "Not in the favorite",
                Description = "Test",
                Location = "Canada",
                Type = TrailType.Pied,
                ImageUrl = "https://media.timeout.com/images/105824352/image.jpg",
                StartingCoordinates = coordinates,
                EndingCoordinates = coordinatesEnd,
            };

            UserFavoriteTrail userFavoriteTrail = new UserFavoriteTrail()
            {
                Id = 1,
                UserId = user.Id,
                TrailId = trailInTheFavorite.Id,
            };

            user.FavouriteTrails.Add(userFavoriteTrail);

            db.AddRange(user);
            db.AddRange(coordinates);
            db.AddRange(coordinatesEnd);
            db.AddRange(trailInTheFavorite); 
            db.AddRange(trailtIWantInTheFavorite);
            db.AddRange(userFavoriteTrail);
            db.SaveChanges();
            
        }

        [TestCleanup]
        public void Dispose()
        {
            //TODO on efface les données de tests pour remettre la BD dans son état initial
            using ApplicationDbContext db = new ApplicationDbContext(options);
            db.RemoveRange(db.TrailUsers);
            db.RemoveRange(db.Trails);
            db.RemoveRange(db.Coordinates);
            db.RemoveRange(db.UserFavoriteTrails); 
            db.SaveChanges();
        }

        [TestMethod()]
        public void SwictchVisibility_UserNotFound()
        {

        }

        [TestMethod()]
        public void SwictchVisibility_TrailNotFound()
        {

        }

        [TestMethod()]
        public void SwictchVisibility_NotOwner()
        {

        }

        [TestMethod()]
        public async Task addTrailToFavorite()
        {
            using ApplicationDbContext db = new ApplicationDbContext(options);
          
            TrailService trailService = new TrailService(db);

            User currentUser = await db.TrailUsers.Where(x => x.IdentityUserId == user.IdentityUserId).FirstOrDefaultAsync();
            Trail trail = await db.Trails.Where(x => x.Id == trailtIWantInTheFavorite.Id).FirstOrDefaultAsync();

            await trailService.ControlTrailFavorite(currentUser, trail.Id);

            User currentUserAfterAdd = await db.TrailUsers.Where(x => x.IdentityUserId == user.IdentityUserId).FirstOrDefaultAsync();

            Assert.AreEqual(currentUserAfterAdd.FavouriteTrails.Count(), 2);
        }
    }
}