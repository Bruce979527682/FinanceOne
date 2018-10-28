using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Finance.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Login()
        {
            var username = Request.Form["username"].ToString().Trim();
            var password = Request.Form["password"];
            if (!string.IsNullOrEmpty(username))
            {
                return Json(new { code = 1, src = "/home/index" });
            }            
            return Json(new { code = 0, msg = "账号或密码错误" });
        }
    }
}