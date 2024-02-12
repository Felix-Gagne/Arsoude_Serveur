using Arsoude_Backend.Data;
using Arsoude_Backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Arsoude_Backend.Services
{
    public class AdminService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;


        public AdminService(UserManager<IdentityUser> userManager, ApplicationDbContext context)
        {

            _context = context;
            _userManager = userManager;


        }


        public async Task<Trail> setStatus(bool status, int Trailid) {
            Trail? trail = await _context.Trails.FindAsync(Trailid);

            if (trail == null)
            {
                throw new NullReferenceException();
            }
            
            trail.IsApproved = status;

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

           List<Trail> trails = await _context.Trails.Where(t => t.isPublic == true && t.IsApproved == false).ToListAsync();

            return trails;



        } 



    }
}
