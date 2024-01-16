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
    public class CondicionesController : ApiController
    {
        private DBArrendatarioEntities db = new DBArrendatarioEntities();

        // GET: api/Condiciones
        public IQueryable<Condiciones> GetCondiciones()
        {
            return db.Condiciones;
        }

        // GET: api/Condiciones/5
        [ResponseType(typeof(Condiciones))]
        public IHttpActionResult GetCondiciones(int id)
        {
            Condiciones condiciones = db.Condiciones.SingleOrDefault(con => con.Id_apartamento_per == id);
            if (condiciones == null)
            {
                return NotFound();
            }

            CondicionesDT condicionesDT = new CondicionesDT(condiciones);
            return Ok(condicionesDT);
        }



        // PUT: api/Condiciones/5
        [ResponseType(typeof(bool))]
        public IHttpActionResult PutCondiciones(int id, Condiciones condiciones)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != condiciones.Id_apartamento_per)
            {
                return BadRequest();
            }

            db.Entry(condiciones).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
                return Ok(true);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CondicionesExists(id))
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

        // POST: api/Condiciones
        [ResponseType(typeof(Condiciones))]
        public IHttpActionResult PostCondiciones(Condiciones condiciones)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Condiciones.Add(condiciones);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = condiciones.Id_condicion }, condiciones);
        }

        // DELETE: api/Condiciones/5
        [ResponseType(typeof(Condiciones))]
        public IHttpActionResult DeleteCondiciones(int id)
        {
            Condiciones condiciones = db.Condiciones.FirstOrDefault(i => i.Id_apartamento_per == id); 
            if (condiciones == null)
            {
                return NotFound();
            }

            db.Condiciones.Remove(condiciones);
            db.SaveChanges();

            return Ok(condiciones);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CondicionesExists(int id)
        {
            return db.Condiciones.Count(e => e.Id_condicion == id) > 0;
        }
    }
}