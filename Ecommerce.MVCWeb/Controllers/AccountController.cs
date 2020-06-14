using Ecommerce.Core.Models;
using Ecommerce.MVCWeb.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Ecommerce.MVCWeb.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private SignInManager<AppUser> _signManager;
        private UserManager<AppUser> _userManager;

        public AccountController(ILogger<HomeController> logger, SignInManager<AppUser> signManager, UserManager<AppUser> userManager) {
            _logger = logger;
            _signManager = signManager;
            _userManager = userManager;
        }

        public IActionResult Login(string returnUrl = "") {
            var model = new LoginViewModel {
                ReturnUrl = returnUrl
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model) {
            if (ModelState.IsValid) {
                var user = await _userManager.FindByEmailAsync(model.Email);

                if (user != null) {

                    await _signManager.SignOutAsync();

                    var result = await _signManager.PasswordSignInAsync(user,
                                           model.Password, isPersistent: false, lockoutOnFailure: true);
                    if (result.Succeeded) {

                        if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl)) {
                            return Redirect(model.ReturnUrl);
                        }
                        else {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                }
            }
            ModelState.AddModelError("", "Lütfen giriş bilgilerinizi kontrol edin.");
            return View(model);
        }

        public async Task<IActionResult> Logout() {
            await _signManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}
