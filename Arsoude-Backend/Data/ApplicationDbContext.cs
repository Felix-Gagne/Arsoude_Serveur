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
            User userAdmin = new User()
            {
                Id = 99,
                LastName = "Admin",
                FirstName = "Admin",
                AreaCode = "A1A 1A1",
                IdentityUserId = admin.Id,



            };
            builder.Entity<User>().HasData(userAdmin);
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
            builder.Entity<IdentityUserRole<string>>().HasData(
               new IdentityUserRole<string> { UserId = user.Id, RoleId = "11111111-1111-1111-1111-111111111113" }
           );

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

            Coordinates c1 = new Coordinates()
            {
                Id = 1,
                Latitude = 45.559602,
                Longitude = -73.580236

            };
            Coordinates c2 = new Coordinates()
            {
                Id = 2,
                Latitude = 45.671822,
                Longitude = -73.526654

            };
            builder.Entity<Coordinates>().HasData(c1, c2);

            //Coordinates c3 = new Coordinates()
            //{
            //    Id = 3,
            //    Latitude = 45.559602,
            //    Longitude = -73.580236

            //};
            //Coordinates c4 = new Coordinates()
            //{
            //    Id = 4,
            //    Latitude = 45.671822,
            //    Longitude = -73.526654

            //};
            //builder.Entity<Coordinates>().HasData(c3, c4);

            //Coordinates c5 = new Coordinates()
            //{
            //    Id = 5,
            //    Latitude = 45.559602,
            //    Longitude = -73.580236

            //};
            //Coordinates c6 = new Coordinates()
            //{
            //    Id = 6,
            //    Latitude = 45.671822,
            //    Longitude = -73.526654

            //};
            //builder.Entity<Coordinates>().HasData(c5, c6);

            Trail trail = new Trail
            {
                Id = 1,
                Name = "TestTrail",
                Description = "UNE MECHANT GROS TRAJET",
                Location = "Bar chez Diane",
                Type = TrailType.Pied,
                StartingCoordinatesId = 1,
                EndingCoordinatesId = 2,
                OwnerId = test.Id,
                isPublic = true,
                
            };

            builder.Entity<Trail>().HasData(trail);

            Trail trail2 = new Trail()
            {
                Id = 2,
                Name = "Sentier de la Forêt Enchantée",
                Description = "Une randonnée pittoresque à travers une forêt luxuriante où les oiseaux chantent et les rivières murmurent.",
                Location = "Parc National de la Forêt Verte",
                Type = TrailType.Pied,
                StartingCoordinatesId = 1,
                EndingCoordinatesId = 2,
                OwnerId = test.Id,
                ImageUrl = "https://www.parksconservancy.org/sites/default/files/styles/basic/public/programs/A_PRSF_111020_MCu_020-2104x1440.jpg?itok=Cp14Z3ba"
            };
            builder.Entity<Trail>().HasData(trail2);

            Trail trail3 = new Trail()
            {
                Id = 3,
                Name = "Escapade au Sommet",
                Description = "Une aventure difficile menant au sommet d'une montagne majestueuse offrant une vue imprenable sur la vallée ci-dessous.",
                Location = "Parc National des Montagnes Escarpées",
                Type = TrailType.Vélo,
                StartingCoordinatesId = 1,
                EndingCoordinatesId = 2,
                OwnerId = test.Id,
                ImageUrl = "https://cdn.kimkim.com/files/a/images/47739a6ddfef20df8e214fb3bd457adf1f27feab/original-fd1e0fff538a1dd6ebb2ab679ffbab4d.jpg"
            };
            builder.Entity<Trail>().HasData(trail3);

        }

        public DbSet<User> TrailUsers { get; set; } = default!;

        public DbSet<Trail> Trails { get; set; } = default!;

        public DbSet<UserFavoriteTrail> UserFavoriteTrails { get; set; } = default!;


        public DbSet<Coordinates> Coordinates { get; set; } = default!;   

    }
}