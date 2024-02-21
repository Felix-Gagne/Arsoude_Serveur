using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Arsoude_Backend.Data;
using Arsoude_Backend.Models;
using Arsoude_Backend.Exceptions;
using Arsoude_Backend.Services;
using Arsoude_Backend.Models.DTOs;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;

namespace Arsoude_Backend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly CommentService _commentService;
        private readonly UserManager<IdentityUser> _userManager;

        public CommentsController(ApplicationDbContext context, CommentService service, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _commentService = service;
            _userManager = userManager;
        }

        [HttpGet("{TrailId}")]
        public async Task<ActionResult> GetTrailComments(int TrailId)
        {
            try
            {

                List<Comments> comments = await _commentService.GetComments(TrailId);
                return Ok(comments);

            }
            catch (Exception ex)
            {

                if (ex.GetType() == typeof(TrailNotFoundException))
                {

                    return NotFound();

                }
            }



            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> PostComment(CommentDTO comment)
        {
            IdentityUser? user = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
            if (user == null)
            {
                return Unauthorized(new { Message = "Comment : Please Login" });
            }

            try
            {
                await _commentService.PostComment(comment, user);

                return Ok();
            }
            catch (Exception ex)
            {
                if (ex.GetType() == typeof(NullReferenceException))
                {

                    return NotFound(new { Message = "Comment : No comment found" });



                }
                return BadRequest(new { Message = "Comment : une erreur innatendu est survenu" });




            }
        }
    }
}
