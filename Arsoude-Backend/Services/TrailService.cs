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


        public async Task<Trail> CreateTrail(Trail trail, IdentityUser user)
        {

            if( user == null)
            {
                throw new Exception("Create Trail: the user is null");

            }
            if (trail == null)
            {
                throw new Exception("Create Trail: the trail is null");
            }

            if (_context.Trails == null)
            {
                throw new Exception("Create Trail: Entity set 'ApplicationDbContext.Trails'  is null.");
            }

            User userOfficial = _context.TrailUsers.Where(_u => _u.IdentityUserId == user.Id).FirstOrDefault();
            _context.Coordinates.Add(trail.EndingCoordinates);
            _context.Coordinates.Add(trail.StartingCoordinates);
            trail.OwnerId = userOfficial.Id;
            _context.Trails.Add(trail);
            await _context.SaveChangesAsync();

            return trail;
        }

        public async Task DeleteTrail(int id)
        {
            if (_context.Trails == null)
            {
                throw new Exception("Delete Trail: Entity set 'ApplicationDbContext.Trails'  is null.");
            }
            if (id == null)
            {
                throw new Exception("Delete Trail: Id in paramater is null.");

            }
            var trail = await _context.Trails.FindAsync(id);
            if (trail == null)
            {
                throw new Exception("Delete Trail: the trail is null");
            }

            _context.Trails.Remove(trail);
            await _context.SaveChangesAsync();
        }

        public async Task<Trail> GetTrail(int id)
        {
            if (id == null)
            {
                throw new Exception("Get Trail: Id in paramater is null.");

            }
            if (_context.Trails == null)
            {
                throw new Exception("Get Trail: Entity set 'ApplicationDbContext.Trails'  is null.");
            }
            var trail = await _context.Trails.FindAsync(id);
            if (trail == null)
            {
                throw new Exception("Get Trail: the trail is null");
            }
            return trail;
        }

        public async Task<List<Trail>> GetTrails()
        {
            if (_context.Trails != null)
            {
                return await _context.Trails.ToListAsync();
            }
            else
            {
                throw new Exception("Get Trails: Entity set 'ApplicationDbContext.Trails'  is null.");
            }
        }







    }
}
