using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using personal_website.Server.Areas.Identity.Data;
using personal_website.Server.Data;
using personal_website.Server.DTO;
using personal_website.Server.Models;

namespace personal_website.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<PersonalUser> _userManager;
        private readonly SignInManager<PersonalUser> _signInManager;
        private readonly ILogger<AuthController> _logger;

        public AuthController(
            UserManager<PersonalUser> userManager,
            SignInManager<PersonalUser> signInManager,
            ILogger<AuthController> logger
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        // POST: api/Auth/register
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto Regmodel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = new PersonalUser
            {
                UserName = Regmodel.Email,
                Email = Regmodel.Email,
                DisplayName = Regmodel.DisplayName,
                Location = Regmodel.Location,
                Website = Regmodel.Website,
                GithubUsername = Regmodel.GithubUsername,
                Timezone = Regmodel.TimeZone,
                JoinedAt = DateTime.UtcNow
            };

            var result = await _userManager.CreateAsync(user, Regmodel.Password);

            if (result.Succeeded)
            {
                _logger.LogInformation("User have created a new account with a password");

                await _signInManager.SignInAsync(user, isPersistent: false);

                return Ok(MapToUserDto(user));
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return BadRequest(ModelState);
        }

        // POST: api/Auth/login
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto Loginmodel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _signInManager.PasswordSignInAsync(
                Loginmodel.Email,
                Loginmodel.Password,
                Loginmodel.StaySignedIn,
                lockoutOnFailure: false);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByEmailAsync(Loginmodel.Email);

                _logger.LogInformation("User have logged in.");

                return Ok(MapToUserDto(user));
            }

            if (result.RequiresTwoFactor)
            {
                return BadRequest(new { message = "Error: Two factor authentication is required."});
            }

            if (result.IsLockedOut)
            {
                _logger.LogWarning("Warning: User account have been locked out");
                return BadRequest(new { message = "User account locked out"});
            }

            return BadRequest(new { message = "Invalid login attempt. Please try again." });
        }

        // POST: api/Auth/logout
        [AllowAnonymous]
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            _logger.LogInformation("Logout have hit");
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User have logged out.");
            return Ok(new { message = "User have logged out successfully" });
        }

        // GET: api/Auth/current
        [AllowAnonymous]
        [HttpGet("current")]
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null) 
                return Unauthorized();

            return Ok(MapToUserDto(user));
        }

        private static UserDto MapToUserDto(PersonalUser user)
        {
            return new UserDto
            {
                Id = user.Id,
                Email = user.Email,
                DisplayName = user.DisplayName,
                Location = user.Location,
                Website = user.Website,
                GithubUsername = user.GithubUsername,
                Timezone = user.Timezone,
                JoinedAt = DateTime.UtcNow
            };
        }
    }
}
