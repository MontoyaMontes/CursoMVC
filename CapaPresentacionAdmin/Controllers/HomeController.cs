using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CapaEntidad;
using CapaNegocio;

namespace CapaPresentacionAdmin.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Users()
        {
            ViewBag.Message = "Página de Users";
            return View();
        }

        [HttpGet]
        public JsonResult ListUsers()
        {

            List<User> oList = new List<User>();

            oList = new CN_Users().GetUsers();

            return Json(new { data = oList }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public  JsonResult SaveUser(User user)
        {
            object result;
            string message;

            if (user.IdUser == 0)
            {
                result = new CN_Users().RegisterUser(user, out message);
            }
            else
            {
                result = new CN_Users().EditUser(user, out message);
            }
            return Json(new { result, message  }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult DeleteUser(int id)
        {
            bool result;
            string message;

            result = new CN_Users().DeleteUser(id, out message);
           
            return Json(new { result, message }, JsonRequestBehavior.AllowGet);
        }

    }
}