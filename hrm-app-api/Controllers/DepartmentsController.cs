using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using hrm_app_api.Models;

namespace hrm_app_api.Controllers
{
    public class DepartmentsController : ApiController
    {
        private hrmappDbContext db = new hrmappDbContext();

        // GET: api/Departments
        public IQueryable<DEPARTMENT> GetDEPARTMENT()
        {
            return db.DEPARTMENT;
        }

        // GET: api/Departments/5
        [ResponseType(typeof(DEPARTMENT))]
        public IHttpActionResult GetDEPARTMENT(int id)
        {
            DEPARTMENT dEPARTMENT = db.DEPARTMENT.Find(id);
            if (dEPARTMENT == null)
            {
                return NotFound();
            }

            return Ok(dEPARTMENT);
        }

        // PUT: api/Departments/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDEPARTMENT(int id, DEPARTMENT dEPARTMENT)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dEPARTMENT.DEPT_ID)
            {
                return BadRequest();
            }

            db.Entry(dEPARTMENT).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DEPARTMENTExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Departments
        [ResponseType(typeof(DEPARTMENT))]
        public IHttpActionResult PostDEPARTMENT(DEPARTMENT dEPARTMENT)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DEPARTMENT.Add(dEPARTMENT);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dEPARTMENT.DEPT_ID }, dEPARTMENT);
        }

        // DELETE: api/Departments/5
        [ResponseType(typeof(DEPARTMENT))]
        public IHttpActionResult DeleteDEPARTMENT(int id)
        {
            DEPARTMENT dEPARTMENT = db.DEPARTMENT.Find(id);
            if (dEPARTMENT == null)
            {
                return NotFound();
            }

            db.DEPARTMENT.Remove(dEPARTMENT);
            db.SaveChanges();

            return Ok(dEPARTMENT);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DEPARTMENTExists(int id)
        {
            return db.DEPARTMENT.Count(e => e.DEPT_ID == id) > 0;
        }
    }
}