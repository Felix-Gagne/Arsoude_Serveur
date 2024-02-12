using Arsoude_Backend.Data;
using Arsoude_Backend.Models;
using Arsoude_Backend.Models.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop.Infrastructure;
using System.Diagnostics;

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

            if (user == null)
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

        public async Task<Trail> GetTrail(int id, IdentityUser user)
        {
            if (id == null)
            {
                throw new ArgumentNullException("Get Trail: Id in paramater is null.");

            }
            if (_context.Trails == null)
            {
                throw new Exception("Get Trail: Entity set 'ApplicationDbContext.Trails'  is null.");
            }



            User? owner = _context.TrailUsers.Where(u => u.IdentityUserId == user.Id).FirstOrDefault();

            var trail = await _context.Trails.FindAsync(id);


            if (trail == null)
            {
                throw new Exception("Get Trail: the trail is null");
            }

            if (trail.OwnerId != owner.Id) {
                throw new UnauthorizedAccessException();
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


        public async Task<Trail> AddCoordinates(IdentityUser user, List<Coordinates> coords, int trailId)
        {
            User? owner = await _context.TrailUsers.Where(u => u.IdentityUserId == user.Id).FirstOrDefaultAsync();

            Trail trail = await _context.Trails.Where(t => t.Id == trailId).FirstOrDefaultAsync();

            if (trail.OwnerId == owner.Id)
            {
                foreach (Coordinates coord in coords)
                {
                    trail.Coordinates.Add(coord);
                }

                await _context.SaveChangesAsync();
            }

            return trail;
        }


        public async Task<ActionResult<List<Coordinates>>> GetTrailCoordinates(IdentityUser user, int trailId)
        {
            User? owner = await _context.TrailUsers.Where(u => u.IdentityUserId == user.Id).FirstOrDefaultAsync();

            Trail trail = await _context.Trails.Where(t => t.Id == trailId).FirstOrDefaultAsync();

            if (trail.Coordinates != null)
            {
                List<Coordinates> coords = trail.Coordinates;
                return coords;
            }
            else
            {
                return new List<Coordinates>();
            }
        }


        public async Task<ActionResult<List<Trail>>> GetFilteredTrails(FilterDTO dto)
        {
            try
            {
                IQueryable<Trail> query = _context.Trails;

                if (!string.IsNullOrEmpty(dto.Keyword))
                {
                    query = query.Where(x => x.Name.ToLower().Contains(dto.Keyword.ToLower()) || x.Description.ToLower().Contains(dto.Keyword.ToLower()) || 
                    x.Location.ToLower().Contains(dto.Keyword.ToLower()));
                }

                if(dto.Type != null)
                {
                    query = query.Where(x => x.Type == dto.Type);
                }

                List<Trail> trails = await query.ToListAsync();

                if (dto.Coordinates != null && dto.Distance.HasValue)
                {
                    double userLatitude = dto.Coordinates.Latitude;
                    double userLongitude = dto.Coordinates.Longitude;

                    trails = trails.Where(x => CalculateDistance(userLatitude, userLongitude,
                        x.StartingCoordinates.Latitude, x.StartingCoordinates.Longitude) <= dto.Distance.Value).ToList();
                }

                return trails;
            }
            catch(Exception ex)
            {
                throw new Exception("Internal Server Error");
            }
        }

        public async Task controlTrailFavorite(IdentityUser user, int trailId)
        {
            User currentUser = await _context.TrailUsers.Where(x => x.IdentityUserId == user.Id).FirstOrDefaultAsync();

            Trail selectedTrail = await _context.Trails.Where(x => x.Id == trailId).FirstOrDefaultAsync();

            if(currentUser != null)
            {
                if (!currentUser.FavouriteTrails.Contains(selectedTrail))
                {
                    currentUser.FavouriteTrails.Add(selectedTrail);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    currentUser.FavouriteTrails.Remove(selectedTrail);
                    await _context.SaveChangesAsync();
                }
            }
            else
            {
                throw new Exception("Add To Favourites : No user found.");
            }
        }

        private double CalculateDistance(double lat1, double lon1, double lat2, double lon2)
        {
            const double earthRadius = 6371;

            double dLat = ConvertToRadians(lat2 - lat1);
            double dLon = ConvertToRadians(lon2 - lon1);

            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                Math.Cos(ConvertToRadians(lat1)) * Math.Cos(ConvertToRadians(lat2)) *
                Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            return earthRadius * c;
        }

        private double ConvertToRadians(double degree)
        {
            return degree * Math.PI / 180;
        }
    }
}
