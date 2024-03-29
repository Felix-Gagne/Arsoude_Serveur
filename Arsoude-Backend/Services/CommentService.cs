﻿using Arsoude_Backend.Data;
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
        private readonly LevelService _levelService;



        public CommentService(ApplicationDbContext context, LevelService levelService)
        {
            _context = context;
            _levelService = levelService;
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
            IdentityUser username = await _context.Users.Where(x => x.Id == user.Id).FirstOrDefaultAsync();
            Trail trail = await _context.Trails.FindAsync(comment.Trailid);

            Hike hike = await _context.Hikes.Where(x => x.UserId == commentowner.Id && x.TrailId == trail.Id).FirstOrDefaultAsync();

            if (trail == null)
            {
                throw new NullReferenceException();
            }
            if(hike == null)
            {
                Comments newCom = new Comments
                {
                    Id = 0,
                    userHasCompleted = false,
                    Date = DateTime.Now.ToString("MM-dd-yyyy"),
                    User = commentowner,
                    Text = comment.Text,
                    Trail = trail,
                    Username = username.UserName
                };
                await _context.AddAsync(newCom);

                commentowner.Level.Experience += 15;
                _levelService.CheckForLevelUp(commentowner.Id);

                await _context.SaveChangesAsync();
            }
            else
            {
                Comments newCom = new Comments
                {
                    Id = 0,
                    userHasCompleted = hike.IsCompleted,
                    Date = DateTime.Now.ToString("MM-dd-yyyy"),
                    User = commentowner,
                    Text = comment.Text,
                    Trail = trail
                };
                await _context.AddAsync(newCom);

                commentowner.Level.Experience += 15;
                _levelService.CheckForLevelUp(commentowner.Id);

                await _context.SaveChangesAsync();
            }
        } 

    }
}
