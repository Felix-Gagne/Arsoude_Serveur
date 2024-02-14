using Arsoude_Backend.Data;
using Arsoude_Backend.Exceptions;
using Arsoude_Backend.Models;
using Arsoude_Backend.Models.DTOs;
using Arsoude_Backend.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Arsoude_Backend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TrailController : ControllerBase
    {
        readonly UserManager<IdentityUser> UserManager;
        private ApplicationDbContext _context;
        private readonly UserService _userService;
        private readonly TrailService _trailService;
        
        private readonly IConfiguration _config;
        public TrailController(UserManager<IdentityUser> userManager,  ApplicationDbContext context, UserService userService, IConfiguration config, TrailService trailService)
        {
            UserManager = userManager;
            _context = context;
            _userService = userService;
            _config = config;
            _trailService = trailService;
        }
        // GET: api/<TrailController>
        [HttpGet]
        public async Task<ActionResult> GetUserTrails()
        {

            IdentityUser? user = await UserManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));


            if (user != null)
            {
                try
                {
                    List<Trail> result = new List<Trail>();
                    result = await _trailService.GetUserTrailsAsync(user);


                    return Ok(result);
                }

                catch (Exception ex) {
                    if (ex.GetType() == typeof(UnauthorizedAccessException))
                    {
                        return BadRequest(new { Message = "Identity exist but no user is attached to it" });
                    
                    }
                    return BadRequest(ex);


                }
                
            }
            else
            {


                return Unauthorized( new {Message = "Veuillez vous connectez" });
            }
          
        }

        [HttpGet]
        public async Task<ActionResult<List<Trail>>> GetAllTrails()
        {
            return await _context.Trails.Where(x => x.IsApproved == true && x.isPublic == true).ToListAsync();
        }

        // GET api/<TrailController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                Trail trail = await _trailService.GetTrail(id);
                return Ok(trail);
            }

            catch (Exception e)
            {
                if (e.GetType() == typeof(UnauthorizedAccessException))
                {
                    return BadRequest(new { Message = "Get: Cette Randonnée ne vous appartient pas" });

                }
                else
                {
                    return BadRequest(e);
                }

            }

        }

        // PUT: api/Trails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrail(int id, Trail trail)
        {
            if (id != trail.Id)
            {
                return BadRequest();
            }

            _context.Entry(trail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Trails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
         [HttpPost]
        public async Task<ActionResult<Trail>> CreateTrail(Trail trail)
        {
            IdentityUser? user = await UserManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));

            try
            {
                await _trailService.CreateTrail(trail, user);
                return Ok();
            }
            catch (UserNotFoundException)
            {
                return NotFound(new { Message = "User not found" });
            }
            catch (TrailNotFoundException)
            {
                return NotFound(new { Message = "Trail not found" });
            }
        }

        [HttpPost("{trailId}")]
        public async Task<ActionResult<Trail>> AddCoordinates(List<Coordinates> coords, int trailId)
        {
            IdentityUser user = await UserManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
            if(user != null)
            {
                return await _trailService.AddCoordinates(user, coords, trailId);
            }
            else
            {
                return NotFound("Add Coordinates: No user found");
            }
        }
        
        [HttpGet("{trailId}")]
        public async Task<ActionResult<List<Coordinates>>> GetTrailCoordinates(int trailId)
        {
            IdentityUser user = await UserManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));

            if (user != null)
            {
                return await _trailService.GetTrailCoordinates(user, trailId);
            }
            else
            {
                return NotFound("Get Trail Coordinates: No user found");
            }
        }
        
         // DELETE: api/Trails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrail(int id)
        {
            IdentityUser? user = await UserManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));

            if (user != null)
            {

                if (TrailExists(id))
                {
                    await _trailService.DeleteTrail(id);
                }
                return Ok("Deleted");
            }
            else
            {
                return Unauthorized("Delete Trail: No user found");
            }
        }

        [HttpPost]
        public async Task<ActionResult<List<Trail>>> GetFilteredTrails(FilterDTO dto)
        {
            return await _trailService.GetFilteredTrails(dto);
        }

        [HttpPost("{trailId}")]
        public async Task<ActionResult> ManageTrailFavorite(int trailId, bool buttonState)
        {
            IdentityUser user = await UserManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));

            User currentUser = await _context.TrailUsers.Where(x => x.IdentityUserId == user.Id).FirstOrDefaultAsync();

            try
            {
                if (buttonState == false)
                {
                    await _trailService.AddTrailToFavorite(currentUser, trailId);
                    return Ok();
                }
                await _trailService.RemoveTrailFromFavorite(currentUser, trailId);
                return Ok();
            }
            catch (UserNotFoundException userNotFound)
            {
                return NotFound(userNotFound.Message);
            }
            catch (TrailNotFoundException trailNotFoundException)
            {
                return NotFound(trailNotFoundException.Message);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }

        private bool TrailExists(int id)
        {
            return (_context.Trails?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        [HttpGet("{trailId}/{status}")]
        public async Task<ActionResult> SetTrailStatus(int trailId, bool status)
        {
            IdentityUser user = await UserManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier)); 
            User? owner = await _context.TrailUsers.Where(u => u.IdentityUserId == user.Id).FirstOrDefaultAsync();

            try 
            {
                await _trailService.SwitchVisiblityStatus(owner, trailId, status);
                return Ok(); 
            }

            catch (UserNotFoundException) 
            {
                return NotFound(new { Message = "User not found" });
            }
            catch (TrailNotFoundException)
            {
                return NotFound(new { Message = "The selected trail does not exist" });
            }
            catch (NotOwnerExcpetion) 
            {
                return Unauthorized(new { Message = "You cannot change the visibility of a trail you don't own" }); 
            }
        }
    }
    
}
