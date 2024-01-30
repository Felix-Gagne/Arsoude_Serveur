using Arsoude_Backend.Data;
using Arsoude_Backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Arsoude_Backend.Services
{
    public class TrailService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;


        public TrailService(UserManager<IdentityUser> userManager, ApplicationDbContext context) { 
        
        _context = context;
            _userManager = userManager;
        
        
        }

        public async Task<List<Trail>> GetUserTrailsAsync(IdentityUser user) {


            User? owner = _context.TrailUsers.Where(u => u.IdentityUserId == user.Id).FirstOrDefault();

            if (owner != null)
            {
                List<Trail> usertrails = new List<Trail>();

                usertrails = await _context.Trails.Where(T => T.OwnerId == owner.Id).ToListAsync();
                return usertrails;
            }
            else { throw new UnauthorizedAccessException(); }
 

           
        }










    }
}
