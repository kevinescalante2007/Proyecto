using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Hosting;
using System.Web.Http;
using System.Web.Http.Description;
using ApiRestArriendosDepa.Models;
using ApiRestArriendosDepa.Models.misModelosPersonalizados;

namespace ApiRestArriendosDepa.Controllers
{
    public class ImagenesController : ApiController
    {
        private DBArrendatarioEntities db = new DBArrendatarioEntities();

        // GET: api/Imagenes
        public IQueryable<Imagenes> GetImagenes()
        {
            return db.Imagenes;
        }

        // GET: api/Imagenes/5
        [ResponseType(typeof(Imagenes))]
        public IHttpActionResult GetImagenes(int id)
        {
            Imagenes imagenes = db.Imagenes.Find(id);
            if (imagenes == null)
            {
                return NotFound();
            }

            return Ok(imagenes);
        }

        // PUT: api/Imagenes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutImagenes(int id, Imagenes imagenes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != imagenes.id_foto)
            {
                return BadRequest();
            }

            db.Entry(imagenes).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImagenesExists(id))
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

        // POST: api/Imagenes
        [ResponseType(typeof(Imagenes))]
        public IHttpActionResult PostImagenes(Imagenes imagenes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Imagenes.Add(imagenes);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = imagenes.id_foto }, imagenes);
        }

        // POST: api/Imagenes
        // POST: api/Imagenes

        // ...
        //[HttpPost]
        //[Route("api/Imagenes/Subir")]
        //[ResponseType(typeof(void))]
        //public async Task<IHttpActionResult> PostImagenes()
        //{
        //    if (!Request.Content.IsMimeMultipartContent())
        //    {
        //        return StatusCode(HttpStatusCode.UnsupportedMediaType);
        //    }

        //    // Crear una instancia de MultipartFormDataStreamProvider
        //    var provider = new MultipartFormDataStreamProvider("ruta_absoluta_o_relativa_de_guardado_de_archivos");

        //    try
        //    {
        //        // Leer el contenido multipart de la solicitud
        //        await Request.Content.ReadAsMultipartAsync(provider);

        //        // Obtener el id_apartamentos_per del formulario
        //        var idApartamentosPer = provider.FormData["id_apartamentos_per"];

        //        // Crear una instancia de Imagenes y asignar el id_apartamentos_per
        //        var imagenes = new Imagenes
        //        {
        //            id_apartamentos_per = Convert.ToInt32(idApartamentosPer)

        //        };

        //        // Procesar cada archivo adjunto y asignarlos a las propiedades correspondientes
        //        for (int i = 0; i < provider.FileData.Count; i++)
        //        {
        //            var fileData = provider.FileData[i];
        //            var propertyName = $"foto{i + 1}";

        //            if (fileData != null)
        //            {
        //                using (var stream = new FileStream(fileData.LocalFileName, FileMode.Open, FileAccess.Read))
        //                using (var reader = new BinaryReader(stream))
        //                {
        //                    // Leer los bytes del archivo
        //                    var fileBytes = reader.ReadBytes((int)stream.Length);

        //                    // Asignar los bytes al campo correspondiente en Imagenes
        //                    typeof(Imagenes).GetProperty(propertyName)?.SetValue(imagenes, fileBytes);
        //                }
        //            }
        //        }

        //        // Agregar las imágenes a la base de datos u otro procesamiento necesario
        //        db.Imagenes.Add(imagenes);
        //        db.SaveChanges();

        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Error al procesar la solicitud: {ex.Message}");
        //        Console.WriteLine($"StackTrace: {ex.StackTrace}");
        //        return InternalServerError(ex);
        //    }
        //}

        //[HttpPost]
        //[Route("api/Imagenes/Subir")]
        //[ResponseType(typeof(void))]
        //public async Task<IHttpActionResult> PostImagenes()
        //{
        //    if (!Request.Content.IsMimeMultipartContent())
        //    {
        //        return StatusCode(HttpStatusCode.UnsupportedMediaType);
        //    }

        //    // Ruta absoluta para guardar los archivos
        //    string rutaAbsoluta = @"E:\ImagenesArriendosf";

        //    // Verificar si el directorio existe y, si no, crearlo
        //    if (!Directory.Exists(rutaAbsoluta))
        //    {
        //        Directory.CreateDirectory(rutaAbsoluta);
        //    }

        //    // Crear una instancia de MultipartFormDataStreamProvider usando la ruta absoluta
        //    var provider = new MultipartFormDataStreamProvider(rutaAbsoluta);

        //    try
        //    {
        //        // Leer el contenido multipart de la solicitud
        //        await Request.Content.ReadAsMultipartAsync(provider);

        //        // Obtener el id_apartamentos_per del formulario
        //        var idApartamentosPer = provider.FormData["id_apartamentos_per"];

        //        // Crear una instancia de Imagenes y asignar el id_apartamentos_per
        //        var imagenes = new Imagenes
        //        {
        //            id_apartamentos_per = Convert.ToInt32(idApartamentosPer)
        //        };

        //        // Procesar cada archivo adjunto y asignarlos a las propiedades correspondientes
        //        for (int i = 0; i < provider.FileData.Count; i++)
        //        {
        //            var fileData = provider.FileData[i];
        //            var propertyName = $"foto{i + 1}";

        //            if (fileData != null)
        //            {
        //                using (var stream = new FileStream(fileData.LocalFileName, FileMode.Open, FileAccess.Read))
        //                using (var reader = new BinaryReader(stream))
        //                {
        //                    // Leer los bytes del archivo
        //                    var fileBytes = reader.ReadBytes((int)stream.Length);

        //                    // Asignar los bytes al campo correspondiente en Imagenes
        //                    typeof(Imagenes).GetProperty(propertyName)?.SetValue(imagenes, fileBytes);
        //                }
        //            }
        //        }

        //        // Agregar las imágenes a la base de datos u otro procesamiento necesario
        //        db.Imagenes.Add(imagenes);
        //        db.SaveChanges();

        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Error al procesar la solicitud: {ex.Message}");
        //        Console.WriteLine($"StackTrace: {ex.StackTrace}");
        //        return InternalServerError(ex);
        //    }
        //}

        [HttpPost]
        [Route("api/Imagenes/Subir")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PostImagenes()
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                return StatusCode(HttpStatusCode.UnsupportedMediaType);
            }

            // Ruta relativa al directorio de la aplicación
            string rutaRelativa = "ImagenesArriendosf";

            // Obtener la ruta física al directorio de la aplicación
            string rutaFisica = HostingEnvironment.MapPath($"~/{rutaRelativa}");

            // Verificar si el directorio existe y, si no, crearlo
            if (!Directory.Exists(rutaFisica))
            {
                Directory.CreateDirectory(rutaFisica);
            }

            // Crear una instancia de MultipartFormDataStreamProvider usando la ruta relativa
            var provider = new MultipartFormDataStreamProvider(rutaFisica);

            try
            {
                // Leer el contenido multipart de la solicitud
                await Request.Content.ReadAsMultipartAsync(provider);

                // Obtener el id_apartamentos_per del formulario
                var idApartamentosPer = provider.FormData["id_apartamentos_per"];

                // Crear una instancia de Imagenes y asignar el id_apartamentos_per
                var imagenes = new Imagenes
                {
                    id_apartamentos_per = Convert.ToInt32(idApartamentosPer)
                };

                // Procesar cada archivo adjunto y asignarlos a las propiedades correspondientes
                for (int i = 0; i < provider.FileData.Count; i++)
                {
                    var fileData = provider.FileData[i];
                    var propertyName = $"foto{i + 1}";

                    if (fileData != null)
                    {
                        using (var stream = new FileStream(fileData.LocalFileName, FileMode.Open, FileAccess.Read))
                        using (var reader = new BinaryReader(stream))
                        {
                            // Leer los bytes del archivo
                            var fileBytes = reader.ReadBytes((int)stream.Length);

                            // Asignar los bytes al campo correspondiente en Imagenes
                            typeof(Imagenes).GetProperty(propertyName)?.SetValue(imagenes, fileBytes);
                        }
                    }
                }

                // Agregar las imágenes a la base de datos u otro procesamiento necesario
                db.Imagenes.Add(imagenes);
                db.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al procesar la solicitud: {ex.Message}");
                Console.WriteLine($"StackTrace: {ex.StackTrace}");
                return InternalServerError(ex);
            }
        }



        //actualizar
        //[HttpPut]
        //[Route("api/Imagenes/Actualizar/{idApartamentosPer}")]
        //[ResponseType(typeof(void))]
        //public async Task<IHttpActionResult> PutImagenes(int idApartamentosPer)
        //{
        //    if (!Request.Content.IsMimeMultipartContent())
        //    {
        //        return StatusCode(HttpStatusCode.UnsupportedMediaType);
        //    }

        //    // Ruta relativa al directorio de la aplicación
        //    string rutaRelativa = "ImagenesArriendosf";

        //    // Obtener la ruta física al directorio de la aplicación
        //    string rutaFisica = HostingEnvironment.MapPath($"~/{rutaRelativa}");

        //    // Verificar si el directorio existe y, si no, crearlo
        //    if (!Directory.Exists(rutaFisica))
        //    {
        //        Directory.CreateDirectory(rutaFisica);
        //    }

        //    // Crear una instancia de MultipartFormDataStreamProvider usando la ruta relativa
        //    var provider = new MultipartFormDataStreamProvider(rutaFisica);

        //    try
        //    {
        //        // Leer el contenido multipart de la solicitud
        //        await Request.Content.ReadAsMultipartAsync(provider);

        //        // Obtener la instancia existente de Imagenes por id_apartamentos_per
        //        var imagenes = db.Imagenes.FirstOrDefault(i => i.id_apartamentos_per == idApartamentosPer);

        //        if (imagenes == null)
        //        {
        //            return NotFound(); // Otra respuesta HTTP 404 o manejo de error según tus necesidades
        //        }

        //        // Procesar cada archivo adjunto y asignarlos a las propiedades correspondientes
        //        for (int i = 0; i < provider.FileData.Count; i++)
        //        {
        //            var fileData = provider.FileData[i];
        //            var propertyName = $"foto{i + 1}";

        //            if (fileData != null)
        //            {
        //                using (var stream = new FileStream(fileData.LocalFileName, FileMode.Open, FileAccess.Read))
        //                using (var reader = new BinaryReader(stream))
        //                {
        //                    // Leer los bytes del archivo
        //                    var fileBytes = reader.ReadBytes((int)stream.Length);

        //                    // Asignar los bytes al campo correspondiente en Imagenes
        //                    typeof(Imagenes).GetProperty(propertyName)?.SetValue(imagenes, fileBytes);
        //                }
        //            }
        //        }

        //        // Actualizar las imágenes en la base de datos u otro procesamiento necesario
        //        db.SaveChanges();

        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Error al procesar la solicitud: {ex.Message}");
        //        Console.WriteLine($"StackTrace: {ex.StackTrace}");
        //        return InternalServerError(ex);
        //    }
        //}




        [HttpPut]
        [Route("api/Imagenes/Actualizar/{idApartamentosPer}")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutImagenes(int idApartamentosPer)
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                return StatusCode(HttpStatusCode.UnsupportedMediaType);
            }

            // Ruta relativa al directorio de la aplicación
            string rutaRelativa = "ImagenesArriendosf";

            // Obtener la ruta física al directorio de la aplicación
            string rutaFisica = HostingEnvironment.MapPath($"~/{rutaRelativa}");

            // Verificar si el directorio existe y, si no, crearlo
            if (!Directory.Exists(rutaFisica))
            {
                Directory.CreateDirectory(rutaFisica);
            }

            // Crear una instancia de MultipartFormDataStreamProvider usando la ruta relativa
            var provider = new MultipartFormDataStreamProvider(rutaFisica);

            try
            {
                // Leer el contenido multipart de la solicitud
                await Request.Content.ReadAsMultipartAsync(provider);

                // Obtener la instancia existente de Imagenes por id_apartamentos_per
                var imagenes = db.Imagenes.FirstOrDefault(i => i.id_apartamentos_per == idApartamentosPer);

                if (imagenes == null)
                {
                    return NotFound(); // Otra respuesta HTTP 404 o manejo de error según tus necesidades
                }

                switch (provider.FileData.Count)
                {
                    case 1:
                        imagenes.foto2 = null;
                        imagenes.foto3 = null;
                        imagenes.foto4 = null;
                        imagenes.foto5 = null;
                        imagenes.foto6 = null;
                        break;
                    case 2:
                        imagenes.foto3 = null;
                        imagenes.foto4 = null;
                        imagenes.foto5 = null;
                        imagenes.foto6 = null;
                        break;
                    case 3:
                        imagenes.foto4 = null;
                        imagenes.foto5 = null;
                        imagenes.foto6 = null;
                        break;
                    case 4:
                        imagenes.foto5 = null;
                        imagenes.foto6 = null;
                        break;
                    case 5:
                        imagenes.foto6 = null; 
                        break;
                    default:
                        
                        break;
                }

                // Procesar cada archivo adjunto y asignarlos a las propiedades correspondientes
                for (int i = 0; i < provider.FileData.Count; i++)
                {

                    if (provider.FileData[i] != null)
                    {
                        var fileData = provider.FileData[i];


                        var propertyName = $"foto{i + 1}";

                       
                        
                            using (var stream = new FileStream(fileData.LocalFileName, FileMode.Open, FileAccess.Read))
                            using (var reader = new BinaryReader(stream))
                            {
                                // Leer los bytes del archivo
                                var fileBytes = reader.ReadBytes((int)stream.Length);

                                // Asignar los bytes al campo correspondiente en ImagenesDT

                                typeof(Imagenes).GetProperty(propertyName)?.SetValue(imagenes, fileBytes ?? null);
                            }
                        }
                    
                }

                // Actualizar las imágenes en la base de datos u otro procesamiento necesario
                db.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al procesar la solicitud: {ex.Message}");
                Console.WriteLine($"StackTrace: {ex.StackTrace}");
                return InternalServerError(ex);
            }
        }



        // DELETE: api/Imagenes/5
        [ResponseType(typeof(Imagenes))]
        public IHttpActionResult DeleteImagenes(int id)
        {
            Imagenes imagenes = db.Imagenes.FirstOrDefault(i => i.id_apartamentos_per == id);
            if (imagenes == null)
            {
                return NotFound();
            }

            db.Imagenes.Remove(imagenes);
            db.SaveChanges();

            return Ok(imagenes);
        }




        [HttpGet]
        [Route("api/Imagenes/GetFoto1ByUserId/{userId}")]
        [ResponseType(typeof(List<byte[]>))]
        public IHttpActionResult GetFoto1ByUserId(int userId)
        {
            // Buscar los Id_apartamento asociados al usuario
            var idApartamentos = db.Apartamentos
                .Where(a => a.Id_usuario_per == userId)
                .Select(a => a.Id_apartamento)
                .ToList();

            // Buscar las fotos1 correspondientes a los Id_apartamento
            var fotos1 = db.Imagenes
                .Where(i => idApartamentos.Contains(i.id_apartamentos_per.Value))
                .Select(i => i.foto1)
                .ToList();

            return Ok(fotos1);
        }

        [HttpGet]
        [Route("api/Imagenes/GetTodasFotosPorApartamento/{apartamento_per}")]
        [ResponseType(typeof(List<byte[]>))]
        public IHttpActionResult GetTodasFotosPorApartamento(int apartamento_per)
        {

            // Buscar las fotos1 correspondientes a los Id_apartamento
            var fotos = db.Imagenes
                .Where(i => i.id_apartamentos_per == apartamento_per )
                .Select(i => new { i.foto1, i.foto2, i.foto3, i.foto4, i.foto5, i.foto6})
                .ToList();

            return Ok(fotos);
        }


        //metodo de traer Fotso par busqueda
        [HttpGet]
        [Route("api/Imagenes/GetTodasFotosPorApartamentoss/{apartamento_per}")]
        [ResponseType(typeof(List<byte[]>))]
        public IHttpActionResult GetTodasFotosPorApartamentoss(int apartamento_per)
        {

            // Buscar las fotos1 correspondientes a los Id_apartamento
            var fotos = db.Imagenes
                .Where(i => i.id_apartamentos_per == apartamento_per)
                .Select(i => new { i.foto1, i.foto2, i.foto3, i.foto4, i.foto5, i.foto6 })
                .ToList();

            // Convertir cada byte array a su representación Base64
            var fotosBase64 = fotos.Select(foto => new
            {
                Foto1 = foto.foto1 != null ? Convert.ToBase64String(foto.foto1) : null,
                Foto2 = foto.foto2 != null ? Convert.ToBase64String(foto.foto2) : null,
                Foto3 = foto.foto3 != null ? Convert.ToBase64String(foto.foto3) : null,
                Foto4 = foto.foto4 != null ? Convert.ToBase64String(foto.foto4) : null,
                Foto5 = foto.foto5 != null ? Convert.ToBase64String(foto.foto5) : null,
                Foto6 = foto.foto6 != null ? Convert.ToBase64String(foto.foto6) : null
            }).ToList();

            return Ok(fotosBase64);
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ImagenesExists(int id)
        {
            return db.Imagenes.Count(e => e.id_foto == id) > 0;
        }
    }
}