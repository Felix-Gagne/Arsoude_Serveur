using Arsoude_Backend.Data;
using Arsoude_Backend.Models;
using Arsoude_Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace Arsoude_Backend.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        readonly UserManager<IdentityUser> UserManager;
        private ApplicationDbContext _context;
        private readonly IConfiguration _config;
        private readonly AdminService _adminService;

        public AdminController(UserManager<IdentityUser> userManager, ApplicationDbContext context, IConfiguration config, AdminService adminService)
        {
            UserManager = userManager;
            _context = context;
            _config = config;
            _adminService = adminService;
        }



        //Fonction pour approver une trail
        [HttpPut("{id}")]
        public async Task<IActionResult> EvaluateTrail(bool isApproved, int id) {
            IdentityUser? user = await UserManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));

            if (user != null)
            {
                try
                {
                    Trail trail = await _adminService.setStatus(isApproved, id);

                    return Ok(new { Message = "Status Modifier!", trail = trail });
                }
                catch (Exception e) {
                    if (e.GetType() == typeof(NullReferenceException)) {
                        // si la trail est null renvoyer une erreur
                        return BadRequest(new { Message = "Admin : Trail was not found" });
                    
                    }
                    //Erreur inatendu, probablement un probleme de database (Update-database)
                    return BadRequest(new {Message = "Admin : Une erreur c'est produite" });
                    
                    }
            }

            else { 
            //si le user est null renvoyer une erreur
            return Unauthorized(new { Message =" Admin :No user Found" });
            }

            
        
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrail(int id)
        {
            IdentityUser? user = await UserManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));

            if (user != null)
            {
                try
                {
                    Trail trail = await _adminService.DeleteTrail(id);

                    return Ok(new { Message = "Randonné Supprimé!", trail = trail });
                }
                catch (Exception e)
                {
                    if (e.GetType() == typeof(NullReferenceException))
                    {
                        // si la trail est null renvoyer une erreur
                        return BadRequest(new { Message = "Admin : La randonnée n'a pas été trouvée" });

                    }
                    //Erreur inatendu, probablement un probleme de database (Update-database)
                    return BadRequest(new { Message = "Admin : Une erreur c'est produite" });

                }
            }

            else
            {
                //si le user est null renvoyer une erreur
                return Unauthorized(new { Message = " Admin :No user Found" });
            }



        }




        [HttpGet]
        public async Task<IActionResult> GetToBeApproved()
        {
            IdentityUser? user = await UserManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
            if (user != null)
            {


                List<Trail> result = await _adminService.GetList();

                return Ok(result);

                
            }



            else
            {
                //si le user est null renvoyer une erreur
                return Unauthorized(new { Message = " Admin :No user Found" });
            }




            }









        }
}
