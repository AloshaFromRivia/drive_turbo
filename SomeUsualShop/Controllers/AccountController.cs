using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SomeUsualShop.Models;
using SomeUsualShop.Models.ViewModels;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace SomeUsualShop.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private UserManager<DriveTurboUser> _userManager;
        private SignInManager<DriveTurboUser> _signInManager;

        public AccountController(UserManager<DriveTurboUser> userManager, SignInManager<DriveTurboUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginModel()
            {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("Password,Login,ReturnUrl")]LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                DriveTurboUser user = await _userManager.FindByNameAsync(loginModel.Login);
                if (user != null)
                {
                    await _signInManager.SignOutAsync();
                    if ((await _signInManager.PasswordSignInAsync(user, loginModel.Password, false, false)).Succeeded)
                    {
                        return Redirect(loginModel?.ReturnUrl ?? "/Home/");
                    }
                }
            }
            ModelState.AddModelError("","Неверный пароль/логин");
            return View(loginModel);
        }

        [AllowAnonymous]
        public IActionResult Registration(string returnUrl)
        {
            return View(new RegistrationModel()
            {
                ReturnUrl = returnUrl
            });
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registration([Bind("Name,Password,Email,ReturnUrl")]RegistrationModel registrationModel)
        {
            IdentityResult result=null;
            DriveTurboUser user = new DriveTurboUser()
            {
                UserName = registrationModel.Name,
                Email = registrationModel.Email
            };
            if (ModelState.IsValid)
            {
                result = await _userManager.CreateAsync(user, registrationModel.Password);
                await _userManager.AddToRoleAsync(user,"User");
                if (result.Succeeded)
                {
                    await _signInManager.SignOutAsync();
                    SignInResult signInResult = await _signInManager.PasswordSignInAsync(user, registrationModel.Password, false, false);
                    if (signInResult.Succeeded) {
                        return Redirect(registrationModel.ReturnUrl ?? "/Home");
                    }
                }
            }
            AddErrorsFromResult(result);
            return View(registrationModel);
        }

        public async Task<RedirectResult> Logout(string returnUrl = "/")
        {
            await _signInManager.SignOutAsync();
            return Redirect(returnUrl);
        }

        private void AddErrorsFromResult(IdentityResult result) {
            foreach (IdentityError error in result.Errors) {
                ModelState.AddModelError("", error.Description);
            }
        }
    }
}