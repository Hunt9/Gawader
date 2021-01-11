using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Wallpaper_Admin_Panel.Controllers
{
    public class PortStaffController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

    }
}