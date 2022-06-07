using hrm_app_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hrm_app_api.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            //SqlQuery("select UNIT_NAME from GS_UNIT");
            using (hrmappDbContext db = new hrmappDbContext())
            {
                var xxx = db.GS_TEST.ToList();
            }
            return View();
        }

        public void SqlQuery(string sql)
        {
            using (hrmappDbContext db = new hrmappDbContext())
            {
                try
                {
                    var xxx = db.Database.SqlQuery<GS_UNIT>(sql).ToList();
                }
                catch (Exception ex)
                {
                    
                }
            }
        }
    }
}
