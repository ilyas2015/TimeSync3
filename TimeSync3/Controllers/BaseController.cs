using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Timesheet.Data;

namespace TimeSync3.Controllers
{
    public class BaseController : Controller
    {
        protected ApplicationDbContext db = new ApplicationDbContext();

        //// GET: Base
        //public ActionResult Index()
        //{
        //    return View();
        //}
    }
}