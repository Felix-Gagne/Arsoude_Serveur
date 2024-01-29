using Arsoude_Backend.Data;
using Arsoude_Backend.Models;
using Arsoude_Backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Arsoude_Backend.Controllers
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected UserService usersService;
        private readonly ApplicationDbContext _context;

        public BaseController(UserService usersService, ApplicationDbContext context)
        {
            this.usersService = usersService;
            _context = context;
        }

        private User? user = null;

        public User currentUser
        {
            get
            {
                if(user == null)
                {
                    user = _context.Users.FirstOrDefault(x => x.IdentityUserId == UserId);
                }
                return user;
            }
        }

        public string UserId
        {
            get
            {
                return User.FindFirstValue(ClaimTypes.NameIdentifier)!; ;
            }
        }
    }
}
