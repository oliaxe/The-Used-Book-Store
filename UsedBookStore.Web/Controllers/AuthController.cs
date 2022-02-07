using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UsedBookStore.Web.Models;
using UsedBookStore.Web.Models.ViewModels;

namespace UsedBookStore.Web.Controllers
{
    public class AuthController : Controller
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        #region Sign Up
        public IActionResult SignUp()
        {
            if (_signInManager.IsSignedIn(User))
                return RedirectToAction("Index", "Home");
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> SignUp(SignUpViewModel signUpViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new AppUser()
                {
                    UserName = signUpViewModel.Email,
                    Email = signUpViewModel.Email,
                    FirstName = signUpViewModel.FirstName,
                    LastName = signUpViewModel.LastName,
                    StreetName = signUpViewModel.StreetName,
                    PostalCode = signUpViewModel.PostalCode,
                    City = signUpViewModel.City
                };

                var result = await _userManager.CreateAsync(user, signUpViewModel.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                foreach (var error in result.Errors)
                    ModelState.AddModelError(string.Empty, error.Description);
            }
            return View();

        }
        #endregion

        #region SignIn 
        public IActionResult SignIn(string returnUrl = null)
        {
            if (_signInManager.IsSignedIn(User))
                return RedirectToAction("Index", "Home");

            var signInViewModel = new SignInViewModel();
            if (returnUrl == null)
                signInViewModel.ReturnUrl = "/";
            else
                signInViewModel.ReturnUrl = returnUrl;

            return View(signInViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInViewModel signInViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(signInViewModel.Email, signInViewModel.Password, isPersistent: false, false);
                if (result.Succeeded)
                {
                    if (signInViewModel.ReturnUrl == null || signInViewModel.ReturnUrl == "/")
                        return RedirectToAction("Index", "Home");
                    else
                        return LocalRedirect(signInViewModel.ReturnUrl);
                }
            }
            ModelState.AddModelError(string.Empty, "Invalid email or password");
            return View();
        }
        #endregion

        #region SignOut
        public async Task<IActionResult> SignOut()
        {
            if (_signInManager.IsSignedIn(User))
                await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        #endregion
    }
}
