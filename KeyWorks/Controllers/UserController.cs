using Microsoft.AspNetCore.Mvc;
using KeyWorks.Api.Data;
using KeyWorks.Api.Models;
using Microsoft.AspNetCore.Identity;
using KeyWorks.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace KeyWorks.Api.Controllers
{
    //Class controlling login and user information
    [ApiController]
    [Route("UserController")]
    public class UserController : ControllerBase
    {
        public UserManager<UserModel> userManager { get; }
        public SignInManager<UserModel> signInManager { get; }

        public UserController ( UserManager<UserModel> userManager, SignInManager<UserModel> signInManager )
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        //This method is used for login in as a registered user and is one of the 2 points of login in the system
        [HttpPost]
        [AllowAnonymous]
        [Route("/login")]
        public async Task<IActionResult> UserLoginAsync([FromBody] UserViewModel loginModel, [FromServices] AppDbContext context)
        {
            var result = await signInManager.PasswordSignInAsync(loginModel.UserName, loginModel.Password, false, false );

            if (result.Succeeded)                    
                return Ok();                
            else
                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");

            return BadRequest();
        }

        //This method is used for registering new users followed by login in with said user in case the registration was successful
        [HttpPost]
        [AllowAnonymous]
        [Route("/register-user")]
        public async Task<IActionResult> UserRegistration([FromBody] UserViewModel model, [FromServices] AppDbContext context)
        {            
            var user = new UserModel() { UserName = model.UserName };
            var result = await userManager.CreateAsync( user, model.Password);

            if (result.Succeeded)
            {
                await signInManager.SignInAsync(user, false);
                return Created("/",user);
            }

            foreach( var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }            

            return BadRequest();
        }

        //Method to change the password of current logged in user.
        [HttpPatch]
        [Route("/change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] UserViewModel model, [FromServices] AppDbContext context)
        {            
            var user = await userManager.GetUserAsync(User);
                
            if( user == null )
            {
                return RedirectToAction("login");
            }

            var result = await userManager.ChangePasswordAsync(user, model.CurrentPassword, model.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            else
            {
                await signInManager.RefreshSignInAsync(user);
                return Ok();
            }

            return BadRequest();
        }
    }
}