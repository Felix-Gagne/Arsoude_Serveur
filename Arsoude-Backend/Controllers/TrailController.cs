using Arsoude_Backend.Data;
using Arsoude_Backend.Models;
using Arsoude_Backend.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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

            var bb = User.Claims.ToList();

            var aaa = User.FindFirstValue(ClaimTypes.NameIdentifier);

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

        // GET api/<TrailController>/5
        [HttpGet()]
        public string Get(int id)
        {
            return "balba";
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

            if (user != null)
            {
                return await _trailService.CreateTrail(trail);
            }

            else
            {
                return NotFound("Create Trail: No user found");
            }
        }

        //// DELETE: api/Trails/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteTrail(int id)
        //{
        //    User? user = await userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));

        //    if (user != null)
        //    {

        //        if(TrailExists(id))
        //        {
        //            await _trailsService.DeleteTrail(id);
        //        }
        //        return Ok("Deleted");
        //    }
        //    else
        //    {
        //        return Unauthorized("Delete Trail: No user found");
        //    }
        //}

        private bool TrailExists(int id)
        {
            return (_context.Trails?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
