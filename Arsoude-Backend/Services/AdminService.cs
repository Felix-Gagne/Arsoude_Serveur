using Arsoude_Backend.Data;
using Arsoude_Backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Arsoude_Backend.Services
{
    public class AdminService
    {
        private readonly ApplicationDbContext _context;
        private readonly LevelService _levelService;
        


        public AdminService( ApplicationDbContext context, LevelService levelService)
        {

            _context = context;
           _levelService = levelService;


        }


        public async Task<Trail> SetStatus(bool status, int Trailid) {
            Trail? trail = await _context.Trails.FindAsync(Trailid);

            if (trail == null)
            {
                throw new NullReferenceException();
            }
            
            trail.IsApproved = status;

            User userOfficial = await _context.TrailUsers.Where(x => x.Id == trail.OwnerId).FirstOrDefaultAsync();

            if (trail.IsApproved == true)
            {
                userOfficial.Level.Experience += 25;
                _levelService.CheckForLevelUp(userOfficial.Id);
            }

            await _context.SaveChangesAsync();

            return trail;
        }

        public async Task<Trail> DeleteTrail(int Trailid)
        {
            Trail? trail = await _context.Trails.FindAsync(Trailid);
            if (trail == null)
            {
                throw new NullReferenceException();
            }

            _context.Trails.Remove(trail);

            await _context.SaveChangesAsync();

            return trail;


        }


         public async Task<List<Trail>> GetList()
        {

           List<Trail> trails = await _context.Trails.Where(t => t.isPublic == true && t.IsApproved == null).ToListAsync();

            return trails;



        } 



    }
}
