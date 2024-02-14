using Arsoude_Backend.Data;
using Arsoude_Backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Arsoude_Backend.Services
{
    public class AdminService
    {
        private readonly ApplicationDbContext _context;
        


        public AdminService( ApplicationDbContext context)
        {

            _context = context;
           


        }


        public async Task<Trail> SetStatus(bool status, int Trailid) {
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

           List<Trail> trails = await _context.Trails.Where(t => t.isPublic == true && t.IsApproved == null).ToListAsync();

            return trails;



        } 



    }
}
