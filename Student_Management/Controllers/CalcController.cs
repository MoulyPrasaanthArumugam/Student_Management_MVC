using Student_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Student_Management.Controllers
{
    public class CalcController : Controller
    {
        // GET: Calc
        public ActionResult Index()
        {
            return View(new Calc());
        }

        [HttpPost]
        public ActionResult Index (Calc c, string calculate)
        {
            if(calculate=="add")
            {
                c.Total = c.Num1 + c.Num2;
            }
            else if(calculate=="sub")
            {
                c.Total = c.Num1 + c.Num2;
            }
            else if (calculate == "mul")
            {
                c.Total = c.Num1 * c.Num2;
            }
            else 
            {
                c.Total = c.Num1 / c.Num2;
            }
            return View(c);
        }
    }
}