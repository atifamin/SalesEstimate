using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using SalesEstimate.Identity;
using SalesEstimate.ViewModels;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SalesEstimate.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<AccountController> _logger; 
        public AccountController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, ILogger<AccountController> logger)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;
        }

        public IActionResult Login(string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            if (ModelState.IsValid)
            {
                try
                {
                    _logger.LogInformation("User {UserName} attempting to log in.", model.UserName);

                    var result = await _signInManager.PasswordSignInAsync(model.UserName!, model.Password!, false, false);

                    if (result.Succeeded)
                    {
                        _logger.LogInformation("User {UserName} logged in successfully.", model.UserName);
                        return RedirectToLocal(returnUrl);
                    }

                    _logger.LogWarning("Invalid login attempt for user {UserName}.", model.UserName);
                    ViewData["ErrorMessage"] = "Please check your username and password";
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An error occurred during login for user {UserName}.", model.UserName);
                    ViewData["ErrorMessage"] = "An unexpected error occurred. Please try again later.";
                }
            }

            return View(model);
        }

        public IActionResult Register(string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View(new RegisterViewModel());
        }

        public async Task CreateRolesIfNotExists(RoleManager<IdentityRole> roleManager)
        {
            string[] roleNames = { "User", "Admin" }; 
            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model, string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            if (ModelState.IsValid)
            {
                try
                {
                    // Generate username from first and last name
                    model.UserName = $"{model.FirstName}{model.LastName}";
                    _logger.LogInformation("User {UserName} attempting to register.", model.UserName);

                    // Create a new ApplicationUser instance
                    var user = new ApplicationUser
                    {
                        UserName = model.UserName,
                        Email = model.Email,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Gender = (Identity.Gender)model.Gender,
                        PhoneNumber = model.PhoneNumber,
                        StreetAddress = model.StreetAddress,
                        City = model.City,
                        State = model.State,
                        PostalCode = model.PostalCode
                    };

                    var result = await _userManager.CreateAsync(user, model.Password!);

                    if (result.Succeeded)
                    {
                        _logger.LogInformation("User {UserName} registered successfully.", model.UserName);

                        // Assign role based on the model's RoleName
                        var role = model.RoleName == "Admin" ? "Admin" : "User";
                        var roleResult = await _userManager.AddToRoleAsync(user, role);

                        if (!roleResult.Succeeded)
                        {
                            foreach (var error in roleResult.Errors)
                            {
                                _logger.LogWarning("Error adding user to role {UserName}: {ErrorDescription}", model.UserName, error.Description);
                                ModelState.AddModelError("", error.Description);
                            }
                        }

                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return RedirectToAction("Login", "Account");
                    }

                    // Handle errors during registration
                    foreach (var error in result.Errors)
                    {
                        _logger.LogWarning("Error during registration for user {UserName}: {ErrorDescription}", model.UserName, error.Description);
                        ModelState.AddModelError("", error.Description);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An error occurred during registration for user {UserName}.", model.UserName);
                    ModelState.AddModelError("", "An unexpected error occurred. Please try again later.");
                }
            }

            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> AllUsers()
        {
            try
            {
                var users = await _userManager.Users.ToListAsync();
                return View(users);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching all users.");
                return RedirectToAction("Error", "Home");
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetUserDetails(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Json(user);
        }
        [HttpPost]
        public async Task<IActionResult> EditRegisteredUser(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false });
            }

            var user = await _userManager.FindByIdAsync(registerViewModel.Id);
            if (user == null)
            {
                return Json(new { success = false });
            }

            // Update user properties
            user.UserName = registerViewModel.FirstName + registerViewModel.LastName;
            user.Email = registerViewModel.Email;
            user.PhoneNumber = registerViewModel.PhoneNumber;
            user.FirstName = registerViewModel.FirstName;
            user.LastName = registerViewModel.LastName;
            user.StreetAddress = registerViewModel.StreetAddress;
            user.City = registerViewModel.City;
            user.State = registerViewModel.State;
            user.PostalCode = registerViewModel.PostalCode;

            // Save changes
            var result = await _userManager.UpdateAsync(user);
            return Json(new { success = result.Succeeded });
        }
        public async Task<IActionResult> Logout()
        {
            try
            {
                await _signInManager.SignOutAsync();
                _logger.LogInformation("User logged out successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred during logout.");
            }

            return RedirectToAction("Login", "Account");
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(string id)
        {
            var user = _userManager.FindByIdAsync(id).Result;
            if (user != null)
            {
                var result = _userManager.DeleteAsync(user).Result;
                if (result.Succeeded)
                {
                    return Json(new { success = true });
                }
            }
            return Json(new { success = false });
        }


        private IActionResult RedirectToLocal(string? returnUrl)
        {
            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}

