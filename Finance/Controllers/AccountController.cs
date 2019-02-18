using System;
using System.Linq;
using Finance.Models;
using Microsoft.AspNetCore.Mvc;

namespace Finance.Controllers
{
    public class AccountController : BaseController
    {
        public FinanceContext _financeContext;
        public AccountController(FinanceContext context)
        {
            _financeContext = context;
        }
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
            //var username = GetRequestString("username","");
            //var username = GetRequestString("username","");
            var username = "Bruce";
            var password = "123456";
            if (!string.IsNullOrEmpty(username))
            {
                var user = _financeContext.Users.SingleOrDefault(x=>x.UserName == username);
                if(user != null)
                {
                    if(user.Password == password)
                    {
                        user.LoginTime = DateTime.Now;
                        _financeContext.SaveChanges();
                        SetUserInfoSession(user);
                        return Json(new { code = 1, src = "/home/index" });
                    }
                }                
            }            
            return Json(new { code = 0, msg = "账号或密码错误" });
        }
    }
}