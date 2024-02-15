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
        private ApplicationDbContext _context;
        private readonly IConfiguration _config;
        private readonly AdminService _adminService;

        public AdminController( ApplicationDbContext context, IConfiguration config, AdminService adminService)
        {
           
            _context = context;
            _config = config;
            _adminService = adminService;
        }



        //Fonction pour approver une trail
        [HttpGet("{id}/{isApproved}")]
        public async Task<IActionResult> EvaluateTrail(bool isApproved, int id)
        {



            try
            {
                Trail trail = await _adminService.SetStatus(isApproved, id);

                return Ok(new { Message = "Status Modifier!", trail = trail });
            }
            catch (Exception e)
            {
                if (e.GetType() == typeof(NullReferenceException))
                {
                    // si la trail est null renvoyer une erreur
                    return BadRequest(new { Message = "Admin : Trail was not found" });

                }
                //Erreur inatendu, probablement un probleme de database (Update-database)
                return BadRequest(new { Message = "Admin : Une erreur c'est produite" });

            }
        }








        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrail(int id)
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

           



        




        [HttpGet]
        public async Task<IActionResult> GetToBeApproved()
        {
            try
            {
                List<Trail> result = await _adminService.GetList();

                return Ok(result);
            }
            catch(Exception e) { 
            
            return BadRequest(new { Message = "Admin: Une erreur c'est produite" });
            }

        }









    }
}
