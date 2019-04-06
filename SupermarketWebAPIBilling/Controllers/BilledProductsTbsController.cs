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
    public class BilledProductsTbsController : ApiController
    {
        private supermarketDBEntities2 db = new supermarketDBEntities2();

        // GET: api/BilledProductsTbs
        public IQueryable<BilledProductsTb> GetBilledProductsTbs()
        {
            return db.BilledProductsTbs;
        }

        // GET: api/BilledProductsTbs/5
        [ResponseType(typeof(BilledProductsTb))]
        public IHttpActionResult GetBilledProductsTb(int id)
        {
            BilledProductsTb billedProductsTb = db.BilledProductsTbs.Find(id);
            if (billedProductsTb == null)
            {
                return NotFound();
            }

            return Ok(billedProductsTb);
        }

        // PUT: api/BilledProductsTbs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBilledProductsTb(int id, BilledProductsTb billedProductsTb)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != billedProductsTb.Id)
            {
                return BadRequest();
            }

            db.Entry(billedProductsTb).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BilledProductsTbExists(id))
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

        // POST: api/BilledProductsTbs
        [ResponseType(typeof(BilledProductsTb))]
        public IHttpActionResult PostBilledProductsTb(BilledProductsTb billedProductsTb)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BilledProductsTbs.Add(billedProductsTb);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = billedProductsTb.Id }, billedProductsTb);
        }

        // DELETE: api/BilledProductsTbs/5
        [ResponseType(typeof(BilledProductsTb))]
        public IHttpActionResult DeleteBilledProductsTb(int id)
        {
            BilledProductsTb billedProductsTb = db.BilledProductsTbs.Find(id);
            if (billedProductsTb == null)
            {
                return NotFound();
            }

            db.BilledProductsTbs.Remove(billedProductsTb);
            db.SaveChanges();

            return Ok(billedProductsTb);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BilledProductsTbExists(int id)
        {
            return db.BilledProductsTbs.Count(e => e.Id == id) > 0;
        }
    }
}