using Arsoude_Backend.Data;
using Arsoude_Backend.Exceptions;
using Arsoude_Backend.Models;
using Arsoude_Backend.Models.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Arsoude_Backend.Services
{
    public class CommentService
    {
        private readonly ApplicationDbContext _context;



        public CommentService(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<List<Comments>> GetComments(int TrailId) {

            Trail? trail = _context.Trails.Where(t => t.Id == TrailId).FirstOrDefault();

            if (trail == null) 
            {
                throw new TrailNotFoundException();
            }
            if(trail.Comments == null)
            {
                return new List<Comments>();
            }
            return trail.Comments;
        }

        public async Task PostComment(CommentDTO comment, IdentityUser user) {
            User commentowner = await _context.TrailUsers.Where(u => u.IdentityUserId == user.Id).FirstOrDefaultAsync();
            Trail trail = await _context.Trails.FindAsync(comment.Trailid);
            if (trail == null)
            {
                throw new NullReferenceException();
            }
            Comments newCom = new Comments {
            Id= 0,
            userHasCompleted = true,
            Date = DateTime.Now,
            User = commentowner,
            Text = comment.Message,
            Trail = trail
            
            };
            await _context.AddAsync(newCom);
            await _context.SaveChangesAsync();
        } 

    }
}
