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
    public class EmployeesController : ApiController
    {
        private hrmappDbContext db = new hrmappDbContext();

        // GET: api/Employees
        public IQueryable<EMPLOYEE> GetEMPLOYEE()
        {
            return db.EMPLOYEE;
        }

        // GET: api/Employees/5
        [ResponseType(typeof(EMPLOYEE))]
        public IHttpActionResult GetEMPLOYEE(string id)
        {
            EMPLOYEE eMPLOYEE = db.EMPLOYEE.Find(id);
            if (eMPLOYEE == null)
            {
                return NotFound();
            }

            return Ok(eMPLOYEE);
        }

        // PUT: api/Employees/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEMPLOYEE(string id, EMPLOYEE eMPLOYEE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != eMPLOYEE.EMP_ID)
            {
                return BadRequest();
            }

            db.Entry(eMPLOYEE).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EMPLOYEEExists(id))
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

        // POST: api/Employees
        [ResponseType(typeof(EMPLOYEE))]
        public IHttpActionResult PostEMPLOYEE(EMPLOYEE eMPLOYEE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EMPLOYEE.Add(eMPLOYEE);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (EMPLOYEEExists(eMPLOYEE.EMP_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = eMPLOYEE.EMP_ID }, eMPLOYEE);
        }

        // DELETE: api/Employees/5
        [ResponseType(typeof(EMPLOYEE))]
        public IHttpActionResult DeleteEMPLOYEE(string id)
        {
            EMPLOYEE eMPLOYEE = db.EMPLOYEE.Find(id);
            if (eMPLOYEE == null)
            {
                return NotFound();
            }

            db.EMPLOYEE.Remove(eMPLOYEE);
            db.SaveChanges();

            return Ok(eMPLOYEE);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EMPLOYEEExists(string id)
        {
            return db.EMPLOYEE.Count(e => e.EMP_ID == id) > 0;
        }
    }
}