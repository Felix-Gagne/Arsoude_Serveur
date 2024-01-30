using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Arsoude_Backend.Data;
using Arsoude_Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Arsoude_Backend.Services;
using System.Diagnostics;

namespace Arsoude_Backend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TrailsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public TrailsService _trailsService;


        public TrailsController(ApplicationDbContext context,  TrailsService trailService)
        {
            _context = context;
            _trailsService = trailService;
        }

        // GET: api/Trails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Trail>>> GetTrails()
        {
            return await _trailsService.GetTrails();
        }

        //// GET: api/Trails/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Trail>> GetTrail(int id)
        //{
        //    User? user = await userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));

        //    if (user != null)
        //    {
        //        Trail trail = await _trailsService.GetTrail(id);
        //        return trail;
        //    }
        //    else
        //    {
        //        return Unauthorized("Get Trail: No user found");
        //    }
        //}

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
            //User? user = await userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));

            //if (user != null)
            //{
            //    return await _trailsService.CreateTrail(trail);
            //}
            if (true)
            {
                return await _trailsService.CreateTrail(trail);
            }
            else
            {
                return Unauthorized("Create Trail: No user found");
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
