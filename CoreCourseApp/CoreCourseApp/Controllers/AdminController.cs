using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreCourseApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreCourseApp.Controllers
{
    public class AdminController : Controller
    {
        private UserManager<ApplicationUser> userManeger;
        private IPasswordValidator<ApplicationUser> passwordValidator;
        private IPasswordHasher<ApplicationUser> passwordHasher;
        public AdminController(UserManager<ApplicationUser> _userManager, IPasswordValidator<ApplicationUser> _passwordValidator, IPasswordHasher<ApplicationUser> _passwordHasher)
        {
            userManeger = _userManager;
            passwordValidator = _passwordValidator;
            passwordHasher = _passwordHasher;
        }
        public IActionResult Index()
        {
            return View(userManeger.Users);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = model.UserName;
                user.Email = model.Email;
                var result = await userManeger.CreateAsync(user, model.Password);
                if (result.Succeeded)// başarılı ise
                {
                    return RedirectToAction("Index");

                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);// boş geçtik aklımızda tutuyoruz ilerdeki bir konu için

                    }
                }
            }

            return View(model);
        }

        [HttpPost]  
        public async Task<IActionResult> Delete(string id)
        {
            var user = await userManeger.FindByIdAsync(id);

            if (user!=null)
            {
                var result = await userManeger.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("",item.Description);
                    }
                }
            }

            else
            {
                ModelState.AddModelError("", "User not found");
            }

            return View("Index", userManeger.Users);
        }

        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            var user = await userManeger.FindByIdAsync(id);
            if (user!=null)
            {
                return View(user);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(string id, string Password, string Email)
        {
            var user = await userManeger.FindByIdAsync(id);
            if (user!=null)
            {
                user.Email = Email;
                IdentityResult validPass = null;
                if (!string.IsNullOrEmpty(Password))
                {
                    validPass = await passwordValidator.ValidateAsync(userManeger, user, Password);
                    if (validPass.Succeeded)
                    {
                        user.PasswordHash = passwordHasher.HashPassword(user, Password);
                    }
                    else
                    {
                        foreach (var item in validPass.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }
                    }
                }//EnFirstIf

                if (validPass.Succeeded)
                {
                    var result = await userManeger.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }
                    }
                }
            }//EndOutIf
            else
            {
                ModelState.AddModelError("", "User not found");
            }
            return View("Index");
        }
    }
}