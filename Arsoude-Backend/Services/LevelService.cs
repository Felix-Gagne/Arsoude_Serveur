using Arsoude_Backend.Data;
using Arsoude_Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Arsoude_Backend.Services
{
    public class LevelService : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LevelService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async void CheckForLevelUp(int UserId)
        {
            Level lvl = await _context.Levels.Where(x => x.UserId == UserId).FirstOrDefaultAsync();

            if (lvl.Experience >= lvl.NextLevelExperience)
            {
                lvl.CurrentLevel++;
                UpdateLevel(UserId);
            }

            _context.SaveChanges();
        }

        public async void UpdateLevel(int UserId)
        {
            Level lvl = await _context.Levels.Where(x => x.UserId == UserId).FirstOrDefaultAsync();

            lvl.Experience -= lvl.NextLevelExperience;
            lvl.PreviousLevelExperience = lvl.NextLevelExperience;
            lvl.NextLevelExperience = Convert.ToInt32(lvl.NextLevelExperience * 1.5);

            _context.SaveChanges();
        }
    }
}
