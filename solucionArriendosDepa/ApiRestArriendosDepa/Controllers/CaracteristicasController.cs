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
    public class CaracteristicasController : ApiController
    {
        private DBArrendatarioEntities db = new DBArrendatarioEntities();

        // GET: api/Caracteristicas
        public IQueryable<Caracteristicas> GetCaracteristicas()
        {
            return db.Caracteristicas;
        }

        // GET: api/Caracteristicas/5
        [ResponseType(typeof(Caracteristicas))]
        public IHttpActionResult GetCaracteristicas(int id)
        {
            
            Caracteristicas caracteristicas = db.Caracteristicas.SingleOrDefault( car => car.Id_apartamento_per == id );
            if (caracteristicas == null)
            {
                return NotFound();
            }
            CaracteristicasDT caracteristicasDTO = new CaracteristicasDT(caracteristicas);

            return Ok(caracteristicasDTO);
        }

        // PUT: api/Caracteristicas/5
        [ResponseType(typeof(bool))]
        public IHttpActionResult PutCaracteristicas(int id, Caracteristicas caracteristicas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != caracteristicas.Id_apartamento_per)
            {
                return BadRequest();
            }

            caracteristicas.Bano_Compartido = false;

            db.Entry(caracteristicas).State = EntityState.Modified;

            try
            {
               
                db.SaveChanges();

                return Ok(true);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CaracteristicasExists(id))
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

        // POST: api/Caracteristicas
        [ResponseType(typeof(Caracteristicas))]
        public IHttpActionResult PostCaracteristicas(Caracteristicas caracteristicas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Caracteristicas.Add(caracteristicas);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = caracteristicas.Id_caracteristicas }, caracteristicas);
        }

        // DELETE: api/Caracteristicas/5
        [ResponseType(typeof(Caracteristicas))]
        public IHttpActionResult DeleteCaracteristicas(int id)
        {
            Caracteristicas caracteristicas = db.Caracteristicas.FirstOrDefault(i => i.Id_apartamento_per == id);
            if (caracteristicas == null)
            {
                return NotFound();
            }

            db.Caracteristicas.Remove(caracteristicas);
            db.SaveChanges();

            return Ok(caracteristicas);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CaracteristicasExists(int id)
        {
            return db.Caracteristicas.Count(e => e.Id_caracteristicas == id) > 0;
        }
    }
}