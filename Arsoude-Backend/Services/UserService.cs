using Arsoude_Backend.Controllers;
using Arsoude_Backend.Data;
using Arsoude_Backend.Models;
using Arsoude_Backend.Models.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace Arsoude_Backend.Services
{
    public class UserService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ApplicationDbContext _context;

        public UserService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public async Task<IdentityResult> RegisterUserAsync(RegisterDTO register)
        {
            if (register.Password != register.ConfirmPassword)
            {
                return IdentityResult.Failed(new IdentityError { Description = "Les deux mots de passe spécifiés sont différents." });
            }

            var identityUser = new IdentityUser
            {
                UserName = register.Username,
                Email = register.Email,
            };

            var result = await _userManager.CreateAsync(identityUser, register.Password);

            var user = new User
            {
                LastName = register.LastName,
                FirstName = register.FirstName,
                AreaCode = register.AreaCode,
                IdentityUserId = identityUser.Id
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return result;
        }

        //Modèle à utiliser quand on aura le modèle User
        public async Task<User> LoginUserAsync(LoginDTO login, ApplicationDbContext context)
        {
            User user = await context.Users.FirstOrDefaultAsync(p => p.IdentityUser.UserName == login.Username);
            return user;
        }


        public async Task SignOutUserAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
