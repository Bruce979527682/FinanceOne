using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Finance.Models;
using Finance.Entity;
using Microsoft.EntityFrameworkCore;

namespace Finance.Controllers
{
    public class HomeController : BaseController
    {
        public FinanceContext _financeContext;
        public HomeController(FinanceContext context)
        {
            _financeContext = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public JsonResult AddRecordType()
        {
            if (!IsLogined())
            {
                return Json(new { code = -1, msg = "没有登录！" });
            }
            var user = GetUserInfoSession();
            string name = GetRequestString("Name", "");
            string remark = GetRequestString("Remark", "");
            if(name == "")
            {
                return Json(new { code = -1, msg = "添加失败！" });
            }
            var type = new RecordType
            {
                CreateDate = DateTime.Now,
                Name = name,
                Remark = remark,
                UserId = user.Id
            };
            _financeContext.RecordTypes.Add(type);
            var result = _financeContext.SaveChanges();
            if (result > 0)
            {
                return Json(new { code = 1, msg = "添加成功！" });
            }
            return Json(new { code = -1, msg = "添加失败！" });
        }

        public JsonResult AddRecord()
        {
            if (!IsLogined())
            {
                return Json(new { code = -1, msg = "没有登录！" });
            }
            var user = GetUserInfoSession();
            int category = GetRequestInt("category", 0);
            int type = GetRequestInt("type", 0);
            string name = GetRequestString("name", "");
            decimal money = GetRequestDecimal("money", 0);
            int number = GetRequestInt("number", 0);
            DateTime addTime = GetRequestDateTime("addTime", DateTime.Now);
            string remark = GetRequestString("remark", "");
            if(name == "")
            {
                return Json(new { code = -1, msg = "添加失败！" });
            }
            var record = new Record
            {
                AddTime = addTime,
                Category = category,
                Name = name,
                Remark = remark,
                UserId = user.Id,
                Money = money,
                Number = number,
                Type = type
            };
            _financeContext.Records.Add(record);
            var result = _financeContext.SaveChanges();
            if (result > 0)
            {
                return Json(new { code = 1, msg = "添加成功！" });
            }
            return Json(new { code = -1, msg = "添加失败！" });
        }

        public JsonResult GetTypeList()
        {
            if (!IsLogined())
            {
                return Json(new { code = -1, msg = "没有登录！" });
            }
            var user = GetUserInfoSession();            
            try
            {
                var list = _financeContext.RecordTypes.AsNoTracking().Where(x => x.UserId.Equals(user.Id)).ToList();
                if (list.Count > 0)
                {
                    return Json(new { code = 1, list });
                }
            }
            catch (Exception)
            {
                return Json(new { code = -4, msg = "获取数据错误！" });
            }
            
            return Json(new { code = 0, msg = "没有数据！" });
        }

        [HttpPost]
        public JsonResult GetRecordList()
        {
            if (!IsLogined())
            {
                return Json(new { code = -1, msg = "没有登录！" });
            }
            string date1 = GetRequestString("pageIndex", "");
            string date = GetRequestString("dateStr", DateTime.Now.ToString("yyyy-MM-dd"));
            try
            {
                var user = GetUserInfoSession();
                var list = _financeContext.Records.AsNoTracking().Where(x=>x.UserId==user.Id && x.AddTime.ToString("yyyy-MM-dd")== date).ToList();
                if (list.Count > 0)
                {
                    return Json(new { code = 1, list });
                }
            }
            catch (Exception e)
            {
                return Json(new { code = -4, msg = "获取数据错误！"+ e.Message });
            }
            return Json(new { code = 0, msg = "没有数据！" });            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
