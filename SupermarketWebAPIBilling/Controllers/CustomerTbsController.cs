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
    public class CustomerTbsController : ApiController
    {
        private supermarketDBEntities2 db = new supermarketDBEntities2();

        // GET: api/CustomerTbs
        public IQueryable<CustomerTb> GetCustomerTbs()
        {
            return db.CustomerTbs;
        }

        // GET: api/CustomerTbs/5
        [ResponseType(typeof(CustomerTb))]
        public IHttpActionResult GetCustomerTb(string id)
        {
            CustomerTb customerTb = db.CustomerTbs.Find(id);
            if (customerTb == null)
            {
                return NotFound();
            }

            return Ok(customerTb);
        }

        // PUT: api/CustomerTbs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCustomerTb(string id, CustomerTb customerTb)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customerTb.CustomerId)
            {
                return BadRequest();
            }

            db.Entry(customerTb).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerTbExists(id))
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

        // POST: api/CustomerTbs
        [ResponseType(typeof(CustomerTb))]
        public IHttpActionResult PostCustomerTb(CustomerTb customerTb)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CustomerTbs.Add(customerTb);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CustomerTbExists(customerTb.CustomerId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = customerTb.CustomerId }, customerTb);
        }

        // DELETE: api/CustomerTbs/5
        [ResponseType(typeof(CustomerTb))]
        public IHttpActionResult DeleteCustomerTb(string id)
        {
            CustomerTb customerTb = db.CustomerTbs.Find(id);
            if (customerTb == null)
            {
                return NotFound();
            }

            db.CustomerTbs.Remove(customerTb);
            db.SaveChanges();

            return Ok(customerTb);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CustomerTbExists(string id)
        {
            return db.CustomerTbs.Count(e => e.CustomerId == id) > 0;
        }
    }
}