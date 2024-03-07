using Arsoude_Backend.Data;
using Arsoude_Backend.Exceptions;
using Arsoude_Backend.Models.Enums;
using Arsoude_Backend.Models;
using Arsoude_Backend.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arsoude_BackendTests.Services
{
    [TestClass()]
    public class FavoriteTrailTest
    {

        DbContextOptions<ApplicationDbContext> options;

        private readonly LevelService _levelService;

        private User user;
        private Trail trailInTheFavorite;
        private Trail trailtIWantInTheFavorite;

        public FavoriteTrailTest()
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
                Id = 1,
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
                Id = 2,
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
        public async Task addTrailToFavorite()
        {
            using ApplicationDbContext db = new ApplicationDbContext(options);

            TrailService trailService = new TrailService(db, _levelService);

            User currentUser = await db.TrailUsers.Where(x => x.IdentityUserId == user.IdentityUserId).FirstOrDefaultAsync();
            Trail trail = await db.Trails.Where(x => x.Id == trailtIWantInTheFavorite.Id).FirstOrDefaultAsync();

            //Nombre de trail dans les favoris avant l'ajout d'une nouvelle
            Assert.AreEqual(currentUser.FavouriteTrails.Count(), 1);

            await trailService.AddTrailToFavorite(currentUser, trail.Id);

            User currentUserAfterAdd = await db.TrailUsers.Where(x => x.IdentityUserId == user.IdentityUserId).FirstOrDefaultAsync();

            //Nombre de trail aprés l'ajout d'une trail au favoris
            Assert.AreEqual(currentUserAfterAdd.FavouriteTrails.Count(), 2);
        }

        [TestMethod()]
        public async Task removeTrailFromFavorite()
        {
            using ApplicationDbContext db = new ApplicationDbContext(options);

            TrailService trailService = new TrailService(db, _levelService);

            User currentUser = await db.TrailUsers.Where(x => x.IdentityUserId == user.IdentityUserId).FirstOrDefaultAsync();
            Trail trail = await db.Trails.Where(x => x.Id == trailInTheFavorite.Id).FirstOrDefaultAsync();

            //Nombre de trail dans les favoris avant que l'on remove une trail au favoris
            Assert.AreEqual(currentUser.FavouriteTrails.Count(), 1);

            await trailService.RemoveTrailFromFavorite(currentUser, trail.Id);

            User currentUserAfterAdd = await db.TrailUsers.Where(x => x.IdentityUserId == user.IdentityUserId).FirstOrDefaultAsync();

            //Nombre de trail aprés avoir remove une trail des favoris
            Assert.AreEqual(currentUserAfterAdd.FavouriteTrails.Count(), 0);
        }

        [ExpectedException(typeof(UserNotFoundException))]
        [TestMethod()]
        public async Task FavoriteNoUserFail()
        {
            using ApplicationDbContext db = new ApplicationDbContext(options);

            TrailService trailService = new TrailService(db, _levelService);

            

            await trailService.AddTrailToFavorite(null, trailtIWantInTheFavorite.Id);
        }

        [ExpectedException(typeof(TrailNotFoundException))]
        [TestMethod()]
        public async Task FavoriteNoTrailFail()
        {
            using ApplicationDbContext db = new ApplicationDbContext(options);

            TrailService trailService = new TrailService(db, _levelService);

            

            await trailService.AddTrailToFavorite(user, 40);
        }

    }
}
