using Arsoude_Backend.Data;
using Arsoude_Backend.Exceptions;
using Arsoude_Backend.Models;
using Arsoude_Backend.Models.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using System.Globalization;

namespace Arsoude_Backend.Services
{
    public class TrailService : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly LevelService _levelService;


        public TrailService(ApplicationDbContext context, LevelService levelService)
        {

            _context = context;
            _levelService = levelService;
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

            userOfficial.Level.Experience += 25;
            _levelService.CheckForLevelUp(userOfficial.Id);


            await _context.SaveChangesAsync();

            return trail;
        }

        public async Task<Hike> CreateHike(Hike hike, IdentityUser user)
        {

            if (user == null)
            {
                throw new UserNotFoundException();
            }
            if (hike == null)
            {
                throw new HikeNotFoundException();
            }

            User userOfficial = _context.TrailUsers.Where(_u => _u.IdentityUserId == user.Id).FirstOrDefault();

            hike.UserId = userOfficial.Id;

            _context.Hikes.Add(hike);
            await _context.SaveChangesAsync();

            return hike;
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

                owner.Level.Experience += 30;
                _levelService.CheckForLevelUp(owner.Id);

                await _context.SaveChangesAsync();
            }

            return trail;
        }

        public async Task SendImage(IdentityUser user, string url, int trailId)
        {
            User? owner = await _context.TrailUsers.Where(u => u.IdentityUserId == user.Id).FirstOrDefaultAsync();

            Trail trail = await _context.Trails.Where(t => t.Id == trailId).FirstOrDefaultAsync();

            if (trail.ImageList.Count == 0)
            {

                ImageTrail ogImg = new ImageTrail
                {
                    ImageUrl = trail.ImageUrl,
                    TrailId = trailId,
                };

                _context.TrailImages.Add(ogImg);

                trail.ImageList?.Add(ogImg);
            }

            if(trail.OwnerId == owner.Id)
            {
                if (trail.ImageUrl == "")
                {
                    trail.ImageUrl = url;
                    await _context.SaveChangesAsync();

                    return;
                }
            }

            ImageTrail img = new ImageTrail
            {
                ImageUrl = url,
                TrailId = trailId,
            };

            _context.TrailImages.Add(img);

            trail.ImageList?.Add(img);

            owner.Level.Experience += 30;
            _levelService.CheckForLevelUp(owner.Id);

            await _context.SaveChangesAsync();

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
                query = query.Where(x => x.Name.ToLower().Contains(dto.Keyword.ToLower()) && x.isPublic == true && x.IsApproved == true || 
                x.Description.ToLower().Contains(dto.Keyword.ToLower()) && x.isPublic == true && x.IsApproved == true || 
                x.Location.ToLower().Contains(dto.Keyword.ToLower()) && x.isPublic == true && x.IsApproved == true);
            }

            if (dto.Type != null)
            {
                query = query.Where(x => x.Type == dto.Type && x.isPublic == true && x.IsApproved == true);
            }

            List<Trail> trails = await query.ToListAsync();

            if (dto.Coordinates != null && dto.Distance.HasValue)
            {
                double userLatitude = dto.Coordinates.Latitude;
                double userLongitude = dto.Coordinates.Longitude;

                trails = trails.Where(x => CalculateDistance(userLatitude, userLongitude,
                    x.StartingCoordinates.Latitude, x.StartingCoordinates.Longitude) <= dto.Distance.Value && x.isPublic == true && x.IsApproved == true).ToList();
            }

            if (trails.Count == 0)
            {
                throw new Exception("Pas de randonn�es trouv� pour les filtres fournis");
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
                UserFavoriteTrail userFavoriteTrail = new UserFavoriteTrail { TrailId = trailId, UserId = currentUser.Id};
                currentUser.FavouriteTrails.Add(userFavoriteTrail);
                await _context.SaveChangesAsync();
            }

        }

        public async Task<List<Trail>> GetUserFavoriteTrails(User user)
        {
            List<Trail> result = new List<Trail>();

            foreach (var favoriteTrail in user.FavouriteTrails)
            {
                Trail trail = await _context.Trails.Where(x => x.Id == favoriteTrail.TrailId).FirstOrDefaultAsync();
                result.Add(trail);
            }

            return result;
        }


        public async Task<List<string>> GetTrailImages(Trail trail)
        {

            List<string> result = new List<string>();
                
            foreach(var img in trail.ImageList)
            {
                ImageTrail trailImage = await _context.TrailImages.Where(x => x.Id == img.Id).FirstOrDefaultAsync();
                result.Add(trailImage.ImageUrl);
            }
                
            return result;
        }

        public async Task RateTrail(int trailId, string rating, IdentityUser userIdentity)
        {
            Trail? trail = await _context.Trails.Where(t => t.Id == trailId).FirstOrDefaultAsync();
            User currentUser = await _context.TrailUsers.Where(x => x.IdentityUserId == userIdentity.Id).FirstOrDefaultAsync();


            if (trail != null)
            {
                if(currentUser != null)
                {
                    TrailUser trailUser = await _context.TrailRatingUser.Where(x => x.TrailId == trailId && x.UserId == currentUser.IdentityUserId).FirstOrDefaultAsync();
                    double newRating = double.Parse(rating, CultureInfo.InvariantCulture);

                    if(trailUser == null)
                    {
                        TrailUser newVote = new TrailUser()
                        {
                            TrailId = trailId,
                            UserId = currentUser.IdentityUserId,
                            VoteValue = newRating,
                        };

                        await _context.TrailRatingUser.AddAsync(newVote);
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        trailUser.VoteValue = newRating;
                    }

                    List<TrailUser> nbVotes = await _context.TrailRatingUser.ToListAsync();
                    double votesTotalValue = 0;
                    foreach(var vote in  nbVotes)
                    {
                        votesTotalValue += vote.VoteValue;
                    }
                    double voteAvearge = (votesTotalValue / nbVotes.Count);
                    trail.Rating = voteAvearge;

                    trail.TotalRatings = nbVotes.Count();
                    await _context.SaveChangesAsync();

                }
                else
                {
                    throw new UserNotFoundException();
                }
            }
            else
            {
                throw new TrailNotFoundException();
            }
            await _context.SaveChangesAsync();

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
