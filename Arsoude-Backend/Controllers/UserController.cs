using Arsoude_Backend.Data;
using Arsoude_Backend.Models;
using Arsoude_Backend.Models.DTOs;
using Arsoude_Backend.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

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
        private readonly IConfiguration _config;

        public UserController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, ApplicationDbContext context, UserService userService, IConfiguration config)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            _context = context;
            _userService = userService;
            _config = config;
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterDTO register)
        {
            User emailCheck = await _context.TrailUsers.Where(x => x.IdentityUser.Email == register.Email).FirstOrDefaultAsync();
            User usernameCheck = await _context.TrailUsers.Where(x => x.IdentityUser.UserName == register.Username).FirstOrDefaultAsync();

            if (emailCheck != null || usernameCheck != null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "Le courriel ou le nom d'utilisateur existe déjà." });
            }

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
            // Try to sign in with username
            IdentityUser? user = await UserManager.FindByNameAsync(login.Username);

            if (user != null && await UserManager.CheckPasswordAsync(user, login.Password))
            {
                // If sign in with username fails, try with email 

                //var token = await GenerateToken(user);
                //LoginResponse token1 = new LoginResponse
                //{
                //    Token = token
                //};
                IList<string> roles = await UserManager.GetRolesAsync(user);
                List<Claim> authClaim = new List<Claim>();
                foreach (string role in roles)
                {

                    authClaim.Add(new Claim(ClaimTypes.Role, role));
                }
                authClaim.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
                SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Cette Phrase est tellement longue quelle va empecher les hackers de passer"));
                JwtSecurityToken token = new JwtSecurityToken(
                    issuer: "https://localhost:7127",
                    claims: authClaim,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature));





                return Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                        validTo = token.ValidTo,
                        Message = "Connection Réussie :)"
                    });
                

                
            }
            return BadRequest(new { Message = "Le mot de passe ou le nom d'utilisateur ne correspond pas." });
        }

        [HttpPut]
        public async Task<ActionResult> AddAditionnalInfo(InfoRegDTO dto)
        {
            try
            {
                User user = await _context.TrailUsers.Where(x => x.IdentityUser.UserName == dto.Username).FirstOrDefaultAsync();

                if (user != null)
                {
                    user.HouseNo = dto.HouseNo;
                    user.Street = dto.Street;
                    user.City = dto.City;
                    user.State = dto.State;
                    user.YearOfBirth = dto.YearOfBirth;
                    user.MonthOfBirth = dto.MonthOfBirth;

                    _context.SaveChangesAsync();

                    return Ok(new { Message = "User info updated" });
                }
                else
                {
                    return NotFound(new { Message = "User not found" });
                }
            }
            catch(Exception ex)
            {
                return StatusCode(500, $"An error occured: {ex.Message}");
            }
        }


        [HttpGet]
        public async Task<ActionResult> Logout()
        {
            await SignInManager.SignOutAsync();
            return Ok(new { Message = "Utilisateur déconnecté" });
        }

        ////Génère le token JWT pour l'authentification
        //private string GenerateToken(User user)
        //{
        //    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        //    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        //    var claims = new[]
        //    {
        //        new Claim(ClaimTypes.NameIdentifier,user.IdentityUser.UserName),
        //        new Claim(ClaimTypes.Role, user.Role)
        //    };
        //    var token = new JwtSecurityToken(_config["Jwt:Issuer"],
        //        _config["Jwt:Audience"],
        //        claims,
        //        expires: DateTime.Now.AddMinutes(15),
        //        signingCredentials: credentials);


        //    return new JwtSecurityTokenHandler().WriteToken(token);

        //}

        private async Task<string> GenerateToken(IdentityUser user)
        {
            IList<string> roles = await UserManager.GetRolesAsync(user);
            List<Claim> authClaim = new List<Claim>();
            foreach (string role in roles)
            {

                authClaim.Add(new Claim(ClaimTypes.Role, role));
            }
            authClaim.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Cette Phrase est tellement longue quelle va empêcher les hackers de passer"));
            JwtSecurityToken token = new JwtSecurityToken(
                issuer: "http://localhost:5050",
                audience: "http://localhost:4200",
                claims: authClaim,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature));

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        public static string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            var randomString = new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
            return randomString;
        }

        // GET: api/<UserController>
        [HttpGet]
        public async HelloWorld GetWord()
        {
            await _context.Database.MigrateAsync();


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
