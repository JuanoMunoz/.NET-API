using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PRACTICE.Dto_s.Account;
using PRACTICE.Interfaces;
using PRACTICE.Models;

namespace PRACTICE.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IAccountService _accountService;
        private readonly SignInManager<AppUser> _signInManager;
        public AccountController(UserManager<AppUser> userManager, IAccountService accountService, SignInManager<AppUser> signInManager) {
            _userManager = userManager;
            _accountService = accountService;
            _signInManager = signInManager;
        }

        [HttpPost("login")]
        public async Task<IActionResult> login(LoginDto login)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = await _userManager.Users.FirstOrDefaultAsync(u=>u.UserName == login.UserName.ToLower());
            if(user == null)
            {
                return Unauthorized("No la hiciste rey");
            }
            var result = await _signInManager.CheckPasswordSignInAsync(user, login.Password, false);
            if (!result.Succeeded)
            {
                return Unauthorized("Contraseña y/o usuario incorrecto");
            }
            return Ok(new NewUser
            {
                Username = login.UserName,
                Token = _accountService.CreateJwtToken(user)
            }) ;
        }
        [HttpPost("register")]
        public async Task<IActionResult> register(RegisterDTO registerDTO) {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var appUser = new AppUser
                {
                    UserName = registerDTO.Username,
                    Email = registerDTO.Email,
                };
                var createdUser = await _userManager.CreateAsync(appUser,registerDTO.Password);
                if (!createdUser.Succeeded)
                {
                    return StatusCode(500, createdUser.Errors);
                }
                var rolesResult = await _userManager.AddToRoleAsync(appUser, "User");
                if (!createdUser.Succeeded)
                {
                    await _userManager.DeleteAsync(appUser);
                    return StatusCode(500, rolesResult.Errors);
                }

                return StatusCode(201, new NewUser
                {
                    Username = registerDTO.Username,
                    Email = registerDTO.Email,
                    Token = _accountService.CreateJwtToken(appUser)
                }) ;

            }catch(Exception ex)
            {
                return StatusCode(500,ex.Message);
            }
        }
    }
}
