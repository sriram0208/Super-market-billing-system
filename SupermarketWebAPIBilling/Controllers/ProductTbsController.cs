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
    public class ProductTbsController : ApiController
    {
        private supermarketDBEntities2 db = new supermarketDBEntities2();

        // GET: api/ProductTbs
        public IQueryable<ProductTb> GetProductTbs()
        {
            return db.ProductTbs;
        }

        // GET: api/ProductTbs/5
        [ResponseType(typeof(ProductTb))]
        public ProductTb GetProductTb(int id)
        {
            ProductTb productTb = db.ProductTbs.Find(id);
            if (productTb == null)
            {
                return null;
                //return false;
                //return NotFound();
            }
            return productTb;
            //return true;
            //  return Ok(productTb);
        }

        // PUT: api/ProductTbs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProductTb(int id, ProductTb productTb)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != productTb.ProductId)
            {
                return BadRequest();
            }

            db.Entry(productTb).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductTbExists(id))
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

        [ResponseType(typeof(ProductTb))]
        public bool PostProductTb(int id)
        {
            if (!ModelState.IsValid)
            {
                return false;
                //return BadRequest(ModelState);
            }
            if(true)
            {
                return true;
            }
           // return false;
        }

        // POST: api/ProductTbs
        [ResponseType(typeof(ProductTb))]
        public IHttpActionResult PostProductTb(ProductTb productTb)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ProductTbs.Add(productTb);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ProductTbExists(productTb.ProductId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = productTb.ProductId }, productTb);
        }

        // DELETE: api/ProductTbs/5
        [ResponseType(typeof(ProductTb))]
        public IHttpActionResult DeleteProductTb(int id)
        {
            ProductTb productTb = db.ProductTbs.Find(id);
            if (productTb == null)
            {
                return NotFound();
            }

            db.ProductTbs.Remove(productTb);
            db.SaveChanges();

            return Ok(productTb);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductTbExists(int id)
        {
            return db.ProductTbs.Count(e => e.ProductId == id) > 0;
        }
    }
}