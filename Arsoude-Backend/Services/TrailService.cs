using Arsoude_Backend.Data;
using Arsoude_Backend.Exceptions;
using Arsoude_Backend.Models;
using Arsoude_Backend.Models.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;

namespace Arsoude_Backend.Services
{
    public class TrailService : ControllerBase
    {
        private readonly ApplicationDbContext _context;


        public TrailService(ApplicationDbContext context)
        {

            _context = context;
        }

        public async Task<List<Trail>> GetUserTrailsAsync(IdentityUser user)
        {


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
                throw new UserNotFoundException();
            }
            if (trail == null)
            {
                throw new TrailNotFoundException();
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
                throw new ArgumentNullException("Get Trail: Id in paramater is null.");

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

                trail.StartingCoordinates = coords.First();
                trail.EndingCoordinates = coords.Last();
                trail.Distance = coords.Count() * 10 / 1000;

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
                coords = coords.Where(c => c.Latitude != trail.StartingCoordinates.Latitude && c.Latitude != trail.EndingCoordinates.Latitude).ToList();

                return coords;
            }
            else
            {
                return new List<Coordinates>();
            }
        }


        public async Task<List<Trail>> GetFilteredTrails(FilterDTO dto)
        {
            IQueryable<Trail> query = _context.Trails;

            if (!string.IsNullOrEmpty(dto.Keyword))
            {
                query = query.Where(x => x.Name.ToLower().Contains(dto.Keyword.ToLower()) || x.Description.ToLower().Contains(dto.Keyword.ToLower()) ||
                x.Location.ToLower().Contains(dto.Keyword.ToLower()));
            }

            if (dto.Type != null)
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

            if (trails.Count == 0)
            {
                throw new Exception("Pas de randonnées trouvé pour les filtres fournis");
            }

            return trails;
        }

        public async Task<bool> VerifyThatUserHaveTrailInFavorite(User currentUser, int trailId)
        {
            Trail selectedTrail = await _context.Trails.Where(x => x.Id == trailId).FirstOrDefaultAsync();

            if (currentUser != null)
            {
                if (selectedTrail != null)
                {
                    UserFavoriteTrail userFavoriteTrail = await _context.UserFavoriteTrails.Where(x => x.UserId == currentUser.Id && x.TrailId == trailId).FirstOrDefaultAsync();
                    if (userFavoriteTrail == null)
                    {
                        return false;
                    }
                    return true;
                }
                else
                {
                    throw new TrailNotFoundException();
                }

            }
            else
            {
                throw new UserNotFoundException();
            }
        }

        public async Task AddTrailToFavorite(User currentUser, int trailId)
        {
            bool trailInFavorite = await VerifyThatUserHaveTrailInFavorite(currentUser, trailId);
            if (trailInFavorite == false)
            {
                UserFavoriteTrail userFavoriteTrail = new UserFavoriteTrail { TrailId = trailId, UserId = currentUser.Id };
                currentUser.FavouriteTrails.Add(userFavoriteTrail);
                await _context.SaveChangesAsync();
            }

        }

        public async Task RemoveTrailFromFavorite(User currentUser, int trailId)
        {
            bool trailInFavorite = await VerifyThatUserHaveTrailInFavorite(currentUser, trailId);
            if (trailInFavorite)
            {
                UserFavoriteTrail userFavoriteTrail = await _context.UserFavoriteTrails.Where(x => x.UserId == currentUser.Id && x.TrailId == trailId).FirstOrDefaultAsync();
                currentUser.FavouriteTrails.Remove(userFavoriteTrail);
                await _context.SaveChangesAsync();
            }
        }

        public async Task SwitchVisiblityStatus(User owner, int trailId, bool status)
        {
            Trail? trail = await _context.Trails.Where(t => t.Id == trailId).FirstOrDefaultAsync();

            if (owner == null) 
            { 
                throw new UserNotFoundException();
            } 
            else if (trail == null) 
            { 
                throw new TrailNotFoundException();
            } 
            else if (trail.OwnerId != owner.Id) 
            { 
                throw new NotOwnerExcpetion(); 
            }

            trail.isPublic = status; 
            _context.SaveChangesAsync();
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
