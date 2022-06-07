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

           //EF_TEST();

            return View();
        }

        private void EF_TEST()
        {
            using (hrmappDbContext db = new hrmappDbContext())
            {
                List<EMPLOYEE> objList = db.EMPLOYEE.ToList();
                List<DEPARTMENT> objList2 = db.DEPARTMENT.ToList();
            }
        }


        private void SQL_TEST()
        {
            //SqlQuery("select UNIT_NAME from GS_UNIT");
        }


        public void SqlQuery(string sql)
        {
            using (hrmappDbContext db = new hrmappDbContext())
            {
                try
                {
                    var xxx = db.Database.SqlQuery<DEPARTMENT>(sql).ToList();
                }
                catch (Exception ex)
                {

                }
            }
        }
    }
}
