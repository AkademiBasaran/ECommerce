using ECommerce.Data;
using ECommerce.Data.Static;
using ECommerce.Models;
using ECommerce.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace ECommerce.Controllers;

public class AccountsController : Controller
{
    readonly UserManager<ApplicationUser> _userManager;
    readonly SignInManager<ApplicationUser> _signInManager;
    readonly AppDbContext _context;

    public AccountsController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, AppDbContext context)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _context = context;
    }

    public IActionResult Login() => View(new LoginVM());

    [HttpPost]
    public async Task<IActionResult> Login(LoginVM login)
    {
        if (!ModelState.IsValid) return View(login);

        var user = await _userManager.FindByEmailAsync(login.EmailAddress);

        if (user is not null)
        {
            var passwordCheck = await _userManager.CheckPasswordAsync(user, login.Password);

            if (passwordCheck)
            {
                var result = await _signInManager.PasswordSignInAsync(user, login.Password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Movies");
                }
            }

            TempData["Error"] = "Hatalı şifre";
            return View(login);
        }

        TempData["Error"] = "Hatalı giriş";
        return View(login);

    }


    public IActionResult Register() => View(new RegisterVM());

    [HttpPost]
    public async Task<IActionResult> Register(RegisterVM register)
    {
        if (!ModelState.IsValid) return View(register);
     
        var user = await _userManager.FindByEmailAsync(register.EmailAddress);

        if (user is not null)
        {
            TempData["Error"] = "Bu email adresi kullanılmaktadır.";
            return View(register);
        }

        var newUser = new ApplicationUser() 
        {
            Email = register.EmailAddress,
            FullName = register.FullName,
            UserName = register.EmailAddress,
            EmailConfirmed = true
        };

        var response = await _userManager.CreateAsync(newUser,register.Password);

        if (response.Succeeded)
            await _userManager.AddToRoleAsync(newUser, UserRoles.User);


        return View("RegisterCompleted");


    }

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index","Movies");
    }

}
