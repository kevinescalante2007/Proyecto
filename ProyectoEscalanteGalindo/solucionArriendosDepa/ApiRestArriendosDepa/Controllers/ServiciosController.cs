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
using ApiRestArriendosDepa.Models;
using ApiRestArriendosDepa.Models.misModelosPersonalizados;

namespace ApiRestArriendosDepa.Controllers
{
    public class ServiciosController : ApiController
    {
        private DBArrendatarioEntities db = new DBArrendatarioEntities();

        // GET: api/Servicios
        public IQueryable<Servicios> GetServicios()
        {
            return db.Servicios;
        }

        // GET: api/Servicios/5
        [ResponseType(typeof(Servicios))]
        public IHttpActionResult GetServicios(int id)
        {
            Servicios servicios = db.Servicios.SingleOrDefault( ser => ser.Id_apartamento_per ==  id);
            if (servicios == null)
            {
                return NotFound();
            }
            ServiciosDT serviciosDT = new ServiciosDT(servicios);

            return Ok(serviciosDT
                
                );
        }

        // PUT: api/Servicios/5
        [ResponseType(typeof(bool))]
        public IHttpActionResult PutServicios(int id, Servicios servicios)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != servicios.Id_apartamento_per)
            {
                return BadRequest();
            }

            db.Entry(servicios).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
                return Ok(true);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiciosExists(id))
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

        // POST: api/Servicios
        [ResponseType(typeof(Servicios))]
        public IHttpActionResult PostServicios(Servicios servicios)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Servicios.Add(servicios);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = servicios.Id_servicio }, servicios);
        }

        // DELETE: api/Servicios/5
        [ResponseType(typeof(Servicios))]
        public IHttpActionResult DeleteServicios(int id)
        {
            Servicios servicios = db.Servicios.FirstOrDefault(i => i.Id_apartamento_per == id);
            if (servicios == null)
            {
                return NotFound();
            }

            db.Servicios.Remove(servicios);
            db.SaveChanges();

            return Ok(servicios);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ServiciosExists(int id)
        {
            return db.Servicios.Count(e => e.Id_servicio == id) > 0;
        }
    }
}