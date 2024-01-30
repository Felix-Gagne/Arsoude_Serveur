using Arsoude_Backend.Controllers;
using Arsoude_Backend.Data;
using Arsoude_Backend.Models;
using Arsoude_Backend.Models.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace Arsoude_Backend.Services
{
    public class TrailsService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ApplicationDbContext _context;

        public TrailsService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        
        public async Task<Trail> CreateTrail(Trail trail)
        {

            if(trail == null)
            {
                throw new Exception("Create Trail: the trail is null");
            }

            if (_context.Trails == null)
            {
                throw new Exception("Create Trail: Entity set 'ApplicationDbContext.Trails'  is null.");
            }

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
            if(id == null)
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
                throw new Exception("Get Trail: Id in paramater is null.");

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
    }
}
