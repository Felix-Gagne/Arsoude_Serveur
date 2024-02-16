using Arsoude_Backend.Data;
using Arsoude_Backend.Exceptions;
using Arsoude_Backend.Models;
using Arsoude_Backend.Models.DTOs;

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

        public async Task PostComment(CommentDTO comment) { 
            
           
            
        
        
        
        } 

    }
}
