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
using NuGet.ContentModel;
using Arsoude_Backend.Exceptions;

namespace Arsoude_BackendTests
{
    [TestClass()]
    public class TrailCreateTests
    {
        DbContextOptions<ApplicationDbContext> options;

        public TrailCreateTests()
        {
            options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TrailService")
                .Options;
        }

        [TestCleanup]
        public void Dispose()
        {
            using ApplicationDbContext db = new ApplicationDbContext(options);
            db.Trails.RemoveRange(db.Trails);
            db.Users.RemoveRange(db.Users);
            db.Coordinates.RemoveRange(db.Coordinates);
            db.SaveChanges();
        }

        [TestMethod]
        public void CreateTrail_Ok()
        {
            IdentityUser user = new IdentityUser
            {
                Id = "11111111-1111-1111-1111-111111111112",
                UserName = "user@user.com",
                Email = "user@user.com",
                // La comparaison d'identity se fait avec les versions normalis�s
                NormalizedEmail = "USER@USER.COM",
                NormalizedUserName = "USER@USER.COM",
                EmailConfirmed = true
            };


            User userTest = new User
            {
                Id = 1,
                LastName = "Test",
                FirstName = "Test",
                AreaCode = "111 111",
                IdentityUserId = user.Id,
            };

            using ApplicationDbContext db = new ApplicationDbContext(options);
            TrailService trailService = new TrailService(db, null);

            db.AddRange(user);
            db.AddRange(userTest);
            db.SaveChanges();

            Trail t = new Trail()
            {
                Id = 2,
                Name = "Randonné Mtl",
                Description = "Une randonnée à Montréal",
                Location = "Mont-Royal",
                Type = TrailType.Pied,
                StartingCoordinates = new Coordinates
                {
                    Id = 3,
                    Latitude = 45.559602,
                    Longitude = -73.580236
                },
                EndingCoordinates = new Coordinates
                {
                    Id = 4,
                    Latitude = 45.671822,
                    Longitude = -73.526654
                },
                OwnerId = userTest.Id
            };

            trailService.CreateTrail(t, user);
            Assert.AreEqual(1, db.Trails.Count());
        }

        [TestMethod]
        [ExpectedException(typeof(UserNotFoundException))]
        public async Task CreateTrail_NullUser()
        {
            using ApplicationDbContext db = new ApplicationDbContext(options);
            TrailService trailService = new TrailService(db, null);

            Trail t = new Trail()
            {
                Id = 3,
            };


            await trailService.CreateTrail(t, null);
        }

        [TestMethod]
        [ExpectedException(typeof(TrailNotFoundException))]
        public async Task CreateTrail_NullTrail()
        {
            using ApplicationDbContext db = new ApplicationDbContext(options);
            TrailService trailService = new TrailService(db, null);

            IdentityUser user = new IdentityUser
            {
                Id = "11111111-1111-1111-1111-111111111114",
                UserName = "user@user.com",
                Email = "user@user.com",
                // La comparaison d'identity se fait avec les versions normalis�s
                NormalizedEmail = "USER@USER.COM",
                NormalizedUserName = "USER@USER.COM",
                EmailConfirmed = true
            };

            await trailService.CreateTrail(null, user);
        }

        //[TestMethod]
        //public void CreateTrail_NullContext() 
        //{
        //    IdentityUser user = new IdentityUser
        //    {
        //        Id = "11111111-1111-1111-1111-111111111115",
        //        UserName = "user@user.com",
        //        Email = "user@user.com",
        //        // La comparaison d'identity se fait avec les versions normalis�s
        //        NormalizedEmail = "USER@USER.COM",
        //        NormalizedUserName = "USER@USER.COM",
        //        EmailConfirmed = true
        //    };

        //    User userTest = new User
        //    {
        //        Id = 4,
        //        LastName = "Test",
        //        FirstName = "Test",
        //        AreaCode = "111 111",
        //        IdentityUserId = user.Id,
        //    };

        //    using ApplicationDbContext db = new ApplicationDbContext(options);
        //    TrailService trailService = new TrailService(db);

        //    Trail t = new Trail()
        //    {
        //        Id = 4,
        //        OwnerId = userTest.Id
        //    };


        //    db.Trails = null;
        //    db.SaveChanges();

        //    try
        //    {
        //        trailService.CreateTrail(t, user);
        //    }
        //    catch (Exception ex)
        //    {
        //        Assert.AreEqual("Create Trail: Entity set 'ApplicationDbContext.Trails' is null", ex.Message);
        //    }
        //}

    }
}