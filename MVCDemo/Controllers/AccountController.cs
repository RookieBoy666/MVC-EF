using MVCDemo.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Controllers
{
    public class AccountController : Controller
    {
        private AccountContext db = new AccountContext();
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            ViewBag.LoginState = "登录前";
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection fc)
        {
            string name = fc["exampleInputname"];
            string password = fc["exampleInputPassword1"];
            var user = db.SysUsers.Where(b=>b.UserName == name & b.Password == password);
          
            if(user.Count()>0)
            {
                 ViewBag.LoginState = name + "  +"+password + "登录后";
            }
            else
            {
                ViewBag.LoginState = "用户不存在...";
            }
            return View();
        }
        public ActionResult Register()
        {
            ViewBag.register = "注册前。。。";
            return View();
        }

        [HttpPost]
        public ActionResult Register(FormCollection fc)
        {
           
            string name = fc["name"];
            string age = fc["age"];
            ViewBag.register = name + "+" + age;
            return View();
        }

    }
}