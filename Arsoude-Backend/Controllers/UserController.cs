using Arsoude_Backend.Data;
using Arsoude_Backend.Models.DTOs;
using Arsoude_Backend.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Arsoude_Backend.Controllers
{
    public class HelloWorld
    {
        public string Text { get; set; } = "hello world";
    }

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly UserManager<IdentityUser> UserManager;
        readonly SignInManager<IdentityUser> SignInManager;
        private ApplicationDbContext _context;
        private readonly UserService _userService;

        public UserController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, ApplicationDbContext context, UserService userService)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            _context = context;
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterDTO register)
        {
            var result = await _userService.RegisterUserAsync(register);

            if (result.Succeeded)
            {
                return Ok(new { Message = "Utilisateur inscrit" });
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "La création de l'utilisateur a échoué." });
            }
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginDTO login)
        {
            var result = await SignInManager.PasswordSignInAsync(login.Username, login.Password, true, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                //Modèle à suivre quand le modèle user est créé
                //var player = await _accountService.LoginUserAsync(login, _context);
                //PlayerDTO playerDTO = new PlayerDTO(player);


                //if (player != null && playerDTO != null)
                //{
                //    return Ok(playerDTO);
                //}

                return Ok("Utilisateur connecté");
            }
            else
                return null;

            //À retourner quand le user est pas trouvé
            //return NotFound(new { Error = "L'utilisateur est introuvable ou le mot de passe de concorde pas" });
        }


        public async Task<ActionResult> Logout()
        {
            await SignInManager.SignOutAsync();
            return Ok(new { Message = "Utilisateur déconnecté" });
        }


        // GET: api/<UserController>
        [HttpGet]
        public HelloWorld GetWord()
        {
            return new HelloWorld();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }


    }
}
