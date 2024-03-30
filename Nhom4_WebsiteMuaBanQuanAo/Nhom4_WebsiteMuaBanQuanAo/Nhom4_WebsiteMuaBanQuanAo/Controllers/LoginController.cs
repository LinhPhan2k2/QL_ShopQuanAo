using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nhom4_WebsiteMuaBanQuanAo.Models;

namespace Nhom4_WebsiteMuaBanQuanAo.Controllers
{
    public class LoginController : Controller
    {
        User user;
        public ActionResult Index()
        {
            if (Session[UserSession.ISLOGIN] != null && (bool)Session[UserSession.ISLOGIN])
            {
                if ((int)Session[UserSession.PERMISSION] == 1)
                    return RedirectToAction("Index", "QuanLy");
                if ((int)Session[UserSession.PERMISSION] == 2)
                    return RedirectToAction("Index", "Home");
                if ((int)Session[UserSession.PERMISSION] == 3)
                    return RedirectToAction("Index", "students");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Index(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.IsValid(model))
                {
                    user = new User();
                    if (user.IsAdmin())
                        return RedirectToAction("Index", "QuanLy");
                    if (user.IsTeacher())
                        return RedirectToAction("Index", "Home");
                    if (user.IsStudent())
                        return RedirectToAction("Index", "students");
                }
                else
                    ViewBag.error = "Username or password incorrect";
            }
            else
                ViewBag.error = "Error, Please! try again";
            return View();
        }
	}
}