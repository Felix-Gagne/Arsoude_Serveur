using Arsoude_Backend.Models;
using Arsoude_Backend.Models.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Arsoude_Backend.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().HasData(
            new IdentityRole { Id = "11111111-1111-1111-1111-111111111113", Name = "Admin", NormalizedName = "ADMIN" }
        );

            // Creation du compte admin
            PasswordHasher<IdentityUser> hasher = new PasswordHasher<IdentityUser>();
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
            // On encrypte le mot de passe
            admin.PasswordHash = hasher.HashPassword(admin, "Passw0rd!");
            builder.Entity<IdentityUser>().HasData(admin);

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { UserId = admin.Id, RoleId = "11111111-1111-1111-1111-111111111113" }
            );

            /*builder.Entity<IdentityRole>().HasData(
               new IdentityRole { Id = "2", Name = "Player", NormalizedName = "PLAYER" }
           );*/

            // Creation d'un compte utilisateur test
            PasswordHasher<IdentityUser> hasher2 = new PasswordHasher<IdentityUser>();
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

            User test = new User {
                Id = 1,
                LastName = "Test",
                FirstName = "Test",
                AreaCode = "111 111",
                IdentityUserId = user.Id,
            
            
            };

            

            // On encrypte le mot de passe
            user.PasswordHash = hasher2.HashPassword(user, "Passw0rd!");
            builder.Entity<IdentityUser>().HasData(user);
            builder.Entity<User>().HasData(test);
            


            List<Coordinates> coordinates = new List<Coordinates>();

            coordinates.Add(new Coordinates
            {
                Id = 1,
                X = 45.559602,
                Y = -73.580236

            });
            coordinates.Add(new Coordinates
            {
                Id = 2,
                X = 45.671822,
                Y = -73.526654

            });
            builder.Entity<Coordinates>().HasData(coordinates);

            Trail trail = new Trail { 
            Id = 1,
            Name = "TestTrail",
            Description = "UNE MECHANT GROS TRAJET",
            Location = "Bar chez Diane",
            Type = TrailType.Pied,
            StartingCoordinates = coordinates.First(),
            EndingCoordinates = coordinates.Last(),
            OwnerId = test.Id



            };



        }

        public DbSet<User> Users { get; set; } = default!;

        public DbSet<Trail> Trails { get; set; } = default!;
        public DbSet<Coordinates> Coordinates { get; set; } = default!;   

    }
}