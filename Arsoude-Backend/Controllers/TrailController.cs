using Arsoude_Backend.Data;
using Arsoude_Backend.Models;
using Arsoude_Backend.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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

        // POST api/<TrailController>
        [HttpPost]
        public async Task<ActionResult<Trail>> CreateTrail(Trail trail)
        {
            if (_context.Trails == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Trails'  is null.");
            }
            _context.Trails.Add(trail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrail", new { id = trail.Id }, trail);
        }

        // PUT api/<TrailController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TrailController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
