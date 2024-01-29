using Arsoude_Backend.Models;
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
            // On encrypte le mot de passe
            user.PasswordHash = hasher2.HashPassword(user, "Passw0rd!");
            builder.Entity<IdentityUser>().HasData(user);
        }

        public DbSet<User> Users { get; set; } = default!;
        public DbSet<Trail> Trails { get; set; } = default!; 
        public DbSet<Coordinates> Coordinates { get; set; } = default!;
    }
}