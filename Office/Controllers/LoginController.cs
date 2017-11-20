using Office.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic;
using BusinessObject;

namespace Office.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }




        public ActionResult LoginUser(UsersViewModel userViewModel)
        {
            UserLogic Ul = new UserLogic();
            string[] name = new string[2];
            name =Ul.GetLoginDetails(userViewModel.Email, userViewModel.Password);
            ViewBag.Message = "";
            if (name != null)
            {
                ViewBag.Message = "Login Successfull" + name[0];
                Session["LoggedUser"] = name[0];
                Session["LoggedUserId"] = name[1];

            }
            else
                ViewBag.Message = "Login unSuccessfull";

            ViewBag.x = new OtHoursViewModel();
            return  RedirectToAction("Index", "Employee",ViewBag.Message);
        }

    }
}
