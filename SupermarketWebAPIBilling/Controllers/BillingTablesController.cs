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
    public class BillingTablesController : ApiController
    {
        private supermarketDBEntities2 db = new supermarketDBEntities2();

        // GET: api/BillingTables
        public IQueryable<BillingTable> GetBillingTables()
        {
            return db.BillingTables;
        }

        // GET: api/BillingTables/5
        [ResponseType(typeof(BillingTable))]
        public IHttpActionResult GetBillingTable(int id)
        {
            BillingTable billingTable = db.BillingTables.Find(id);
            if (billingTable == null)
            {
                return NotFound();
            }

            return Ok(billingTable);
        }

        // PUT: api/BillingTables/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBillingTable(int id, BillingTable billingTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != billingTable.BillId)
            {
                return BadRequest();
            }

            db.Entry(billingTable).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BillingTableExists(id))
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

        // POST: api/BillingTables
        [ResponseType(typeof(BillingTable))]
        public IHttpActionResult PostBillingTable(BillingTable billingTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BillingTables.Add(billingTable);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = billingTable.BillId }, billingTable);
        }

        // DELETE: api/BillingTables/5
        [ResponseType(typeof(BillingTable))]
        public IHttpActionResult DeleteBillingTable(int id)
        {
            BillingTable billingTable = db.BillingTables.Find(id);
            if (billingTable == null)
            {
                return NotFound();
            }

            db.BillingTables.Remove(billingTable);
            db.SaveChanges();

            return Ok(billingTable);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BillingTableExists(int id)
        {
            return db.BillingTables.Count(e => e.BillId == id) > 0;
        }
    }
}