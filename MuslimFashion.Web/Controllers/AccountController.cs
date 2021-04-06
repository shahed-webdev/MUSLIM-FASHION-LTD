using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MuslimFashion.BusinessLogic;
using MuslimFashion.BusinessLogic.Registration;
using MuslimFashion.Data;
using MuslimFashion.ViewModel;
using System.Threading.Tasks;

namespace MuslimFashion.Web.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ICustomerCore _customer;
        private readonly IRegistrationCore _registration;
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, ICustomerCore customer, IRegistrationCore registration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _customer = customer;
            _registration = registration;
        }

        //GET: Login
        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;

            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "home");

            return View();
        }


        //POST: Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid) return View(model);

            var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);

            if (result.Succeeded)
            {
                var type = _registration.UserTypeByUserName(model.UserName);

                return type switch
                {
                    UserType.Admin => LocalRedirect(returnUrl ??= Url.Content($"/Dashboard/Index")),
                    UserType.SubAdmin => LocalRedirect(returnUrl ??= Url.Content($"/Dashboard/Index")),
                    UserType.Customer => LocalRedirect(returnUrl ??= Url.Content($"/Customer/Dashboard")),
                    _ => LocalRedirect(returnUrl ??= Url.Content($"/Account/Login"))
                };
            }

            if (result.RequiresTwoFactor) return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, model.RememberMe });

            if (result.IsLockedOut)
                return RedirectToPage("./Lockout");


            ModelState.AddModelError(string.Empty, "Incorrect username or password");
            return View(model);
        }

        //GET: SignUp
        [AllowAnonymous]
        public IActionResult SignUp(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;

            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "home");

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(CustomerAddWithRegistrationModel withRegistrationModel, string returnUrl)
        {
            if (!ModelState.IsValid) return View(withRegistrationModel);

            var response = await _customer.AddWithRegistrationAsync(withRegistrationModel);

            if (response.IsSuccess)
            {
                await _signInManager.SignInAsync(response.Data, false);
                return LocalRedirect(returnUrl ??= Url.Content($"/Customer/Dashboard"));
            }

            ModelState.AddModelError(response.FieldName, response.Message);

            return View(withRegistrationModel);
        }

        // GET: ChangePassword
        public ActionResult ChangePassword()
        {
            return View();
        }

        // POST: ChangePassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var user = await _userManager.GetUserAsync(User);
            if (user == null) return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");

            var changePasswordResult = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
            if (!changePasswordResult.Succeeded)
            {
                foreach (var error in changePasswordResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                return View(model);
            }

            await _signInManager.RefreshSignInAsync(user);

            return RedirectToAction("Index", "Dashboard");
        }

        //POST: logout
        [HttpPost]
        public async Task<IActionResult> Logout(string returnUrl = null)
        {
            await _signInManager.SignOutAsync();

            if (returnUrl != null) return LocalRedirect(returnUrl);

            return RedirectToAction("Index", "Home");
        }
    }
}
