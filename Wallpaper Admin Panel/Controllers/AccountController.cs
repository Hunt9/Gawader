using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firebase.Auth;
using Microsoft.AspNetCore.Mvc;
using Wallpaper_Admin_Panel.Models;

namespace Wallpaper_Admin_Panel.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public async Task<ActionResult> Validate(Admins admin)
        {
            var result = await AccessFirebase(admin);

            if (result)
                {

                    return Json(new { status = true, message = "Login Successfull!" });
                }
                else
                {
                    return Json(new { status = false, message = "Invalid Password!" });
                }
            
        }


        public async Task<Boolean> AccessFirebase(Admins model)
        {
            string webApiKey = "AIzaSyDIHGl8yi22i5t9a4wuOBmiue2XjTTmSB8";
            FirebaseAuthProvider authProvider = new FirebaseAuthProvider(new FirebaseConfig(webApiKey));
            try
            {
                FirebaseAuthLink auth = await authProvider.SignInWithEmailAndPasswordAsync(model.email, model.password);
            }
            catch (FirebaseAuthException)
            {
                return false;
            }
            return true;
        }
    

    }
}