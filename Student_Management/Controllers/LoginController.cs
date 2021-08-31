using Student_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Student_Management.Controllers
{
    public class LoginController : Controller
    {
      

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Hacker_User objchk)
        {
            if(ModelState.IsValid)
            {
                using (LEARNINGEntities db = new LEARNINGEntities())
                {
                    var obj = db.Hacker_User.Where(x => x.User_Name.Equals(objchk.User_Name) && x.Password.Equals(objchk.Password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["UserID"] = obj.User_ID.ToString();
                        Session["UserName"] = obj.User_Name.ToString();
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "UserName or Password Invalid");
                    }
                    
                }
            }
            return View(objchk);

        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Login");
        }
    }
}