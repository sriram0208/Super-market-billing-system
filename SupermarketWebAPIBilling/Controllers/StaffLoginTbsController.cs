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
using SupermarketWebAPIBilling.Models;

namespace SupermarketWebAPIBilling.Controllers
{
    public class StaffLoginTbsController : ApiController
    {
        private supermarketDBEntities2 db = new supermarketDBEntities2();

        // GET: api/StaffLoginTbs
        public IQueryable<StaffLoginTb> GetStaffLoginTbs()
        {
            return db.StaffLoginTbs;
        }

        // GET: api/StaffLoginTbs/5
        [ResponseType(typeof(StaffLoginTb))]
        public IHttpActionResult GetStaffLoginTb(int id)
        {
            StaffLoginTb staffLoginTb = db.StaffLoginTbs.Find(id);
            if (staffLoginTb == null)
            {
                return NotFound();
            }

            return Ok(staffLoginTb);
        }

        // PUT: api/StaffLoginTbs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStaffLoginTb(int id, StaffLoginTb staffLoginTb)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != staffLoginTb.StaffId)
            {
                return BadRequest();
            }

            db.Entry(staffLoginTb).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StaffLoginTbExists(id))
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

        // POST: api/StaffLoginTbs
        [ResponseType(typeof(StaffLoginTb))]
        public bool PostStaffLoginTb(StaffLoginTb staffLoginTb)
        {
          
            if (!ModelState.IsValid)
            {
                return false;
               // return BadRequest(ModelState); IHttpActionResult
            }
            if (StaffLoginTbExists2(staffLoginTb))
            {
                return true;
            }
            else
            {
                return false;
            }
            //db.StaffLoginTbs.Add(staffLoginTb);
            //db.SaveChanges();
            //IHttpActionResult


           // return CreatedAtRoute("DefaultApi", new { id = staffLoginTb.StaffId }, staffLoginTb);
        }

        // DELETE: api/StaffLoginTbs/5
        [ResponseType(typeof(StaffLoginTb))]
        public IHttpActionResult DeleteStaffLoginTb(int id)
        {
            StaffLoginTb staffLoginTb = db.StaffLoginTbs.Find(id);
            if (staffLoginTb == null)
            {
                return NotFound();
            }

            db.StaffLoginTbs.Remove(staffLoginTb);
            db.SaveChanges();

            return Ok(staffLoginTb);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StaffLoginTbExists(int id)
        {
            return db.StaffLoginTbs.Count(e => e.StaffId == id) > 0;
        }
        private bool StaffLoginTbExists2(StaffLoginTb obj)
        {
            return db.StaffLoginTbs.Count(e => e.StaffId == obj.StaffId && e.Password==obj.Password) > 0;
        }
    }
}