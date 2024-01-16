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
    public class ApartamentosController : ApiController
    {
        private DBArrendatarioEntities db = new DBArrendatarioEntities();

        //COMENTADO

        // GET: api/Apartamentos
        //public IQueryable<Apartamentos> GetApartamentos()
        //{
        //    return db.Apartamentos;
        //}


        //Agreado para la vista
        public IHttpActionResult GetApartamentos()
        {
            var resultados = db.Database.SqlQuery<modeloVista>("SELECT * FROM listaApartamentos").ToList();

            if (resultados == null || resultados.Count == 0)
            {
                return NotFound();
            }

            return Ok(resultados);
        }


        //Get:api/Apartamentos/5
        [ResponseType(typeof(Apartamentos))]
        public IHttpActionResult GetApar(int id)
        {

            Apartamentos apartamento = db.Apartamentos.SingleOrDefault(car => car.Id_apartamento == id);
            if (apartamento == null)
            {
                return NotFound();
            }

            AparatamentosDT apartamentoDt = new AparatamentosDT(apartamento);
            return Ok(apartamentoDt);
        }


        // PUT: api/Apartamentos/5
        [ResponseType(typeof(bool))]
        public IHttpActionResult PutApartamentos(int id, Apartamentos apartamentos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != apartamentos.Id_apartamento)
            {
                return BadRequest();
            }

            db.Entry(apartamentos).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
                return Ok(true);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApartamentosExists(id))
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

        // POST: api/Apartamentos
        [ResponseType(typeof(Apartamentos))]
        public IHttpActionResult PostApartamentos(Apartamentos apartamentos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Apartamentos.Add(apartamentos);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = apartamentos.Id_apartamento }, apartamentos);
        }

        // DELETE: api/Apartamentos/5
        [ResponseType(typeof(Apartamentos))]
        public IHttpActionResult DeleteApartamentos(int id)
        {
            Apartamentos apartamentos = db.Apartamentos.Find(id);
            if (apartamentos == null)
            {
                return NotFound();
            }

            db.Apartamentos.Remove(apartamentos);
            db.SaveChanges();

            return Ok(apartamentos);
        }


        //traer
        [HttpGet]
        [Route("api/Apartamentos/ByUserId/{idUsuarioPer}")]
        [ResponseType(typeof(IEnumerable<Apartamentos>))]
        public IHttpActionResult GetApartamentosByUserId(int idUsuarioPer)
        {
            var apartamentos = db.Apartamentos
                .Where(a => a.Id_usuario_per == idUsuarioPer)
                .Select(a => new
                {
                    a.Id_apartamento,
                    a.Nombre_apart,
                    a.Precio_apart,
                    a.Id_usuario_per,
                    a.Longitud,
                    a.Latitud,
                    a.Estado_apart
                })
                .ToList();

            if (apartamentos == null || apartamentos.Count == 0)
            {
                return NotFound();
            }

            return Ok(apartamentos);
        }



        //
        // PUT: api/Apartamentos/UpdateEstado/5
        [HttpPut]
        [Route("api/Apartamentos/UpdateEstado/{id}")]
        [ResponseType(typeof(bool))]
        public IHttpActionResult PutActualizarEstadoApartamento(int id, [FromBody] bool nuevoEstado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Apartamentos apartamento = db.Apartamentos.Find(id);
            if (apartamento == null)
            {
                return NotFound();
            }

            

            apartamento.Estado_apart = nuevoEstado;

           

            try
            {
                db.SaveChanges();

                if (nuevoEstado == true)
                {
                return Ok(true);

                }
                else
                {
                    return Ok(false);
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApartamentosExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ApartamentosExists(int id)
        {
            return db.Apartamentos.Count(e => e.Id_apartamento == id) > 0;
        }
    }
}