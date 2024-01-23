using Arsoude_Backend.Data;
using Arsoude_Backend.Models.DTOs;
using Microsoft.AspNetCore.Identity;
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

            var user = new IdentityUser
            {
                UserName = register.Username,
            };

            var result = await _userManager.CreateAsync(user, register.Password);


            //Créer le profil utilisateur ici
            //if (result.Succeeded)
            //{
            //    Player player = new Player
            //    {
            //        IdentityUserId = user.Id,
            //        Name = register.Email,
            //        OwnedCards = cardList,
            //        IdentityUser = user,
            //        Money = 500
            //    };

            //    _context.Players.Add(player);
            //    _context.SaveChanges();
            //}

            return result;
        }

        //Modèle à utiliser quand on aura le modèle User
        //public async Task<Player> LoginUserAsync(LoginDTO login, ApplicationDbContext context)
        //{
        //    Player player = await context.Players.FirstOrDefaultAsync(player => player.Name == login.UserName);
        //    return player;
        //}


        public async Task SignOutUserAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
