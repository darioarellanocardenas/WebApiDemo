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
using WebApiAlmacenes.Models;

namespace WebApiAlmacenes.Controllers
{
    public class AlmacenesController : ApiController
    {
        private AlmacenesEntity db = new AlmacenesEntity();

        // GET: api/Almacenes
        public IQueryable<Almacenes> GetAlmacenes()
        {
            return db.Almacenes;
        }

        // GET: api/Almacenes/5
        [ResponseType(typeof(Almacenes))]
        public IHttpActionResult GetAlmacenes(int id)
        {
            Almacenes almacenes = db.Almacenes.Find(id);
            if (almacenes == null)
            {
                return NotFound();
            }

            return Ok(almacenes);
        }

        // PUT: api/Almacenes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAlmacenes(int id, Almacenes almacenes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != almacenes.iIdAlmacen)
            {
                return BadRequest();
            }

            db.Entry(almacenes).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlmacenesExists(id))
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

        // POST: api/Almacenes
        [ResponseType(typeof(Almacenes))]
        public IHttpActionResult PostAlmacenes(Almacenes almacenes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Almacenes.Add(almacenes);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = almacenes.iIdAlmacen }, almacenes);
        }

        // DELETE: api/Almacenes/5
        [ResponseType(typeof(Almacenes))]
        public IHttpActionResult DeleteAlmacenes(int id)
        {
            Almacenes almacenes = db.Almacenes.Find(id);
            if (almacenes == null)
            {
                return NotFound();
            }

            db.Almacenes.Remove(almacenes);
            db.SaveChanges();

            return Ok(almacenes);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AlmacenesExists(int id)
        {
            return db.Almacenes.Count(e => e.iIdAlmacen == id) > 0;
        }
    }
}