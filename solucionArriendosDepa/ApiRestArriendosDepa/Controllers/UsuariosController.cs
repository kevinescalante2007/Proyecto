using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using ApiRestArriendosDepa.Models;

namespace ApiRestArriendosDepa.Controllers
{
    public class UsuariosController : ApiController
    {
        private DBArrendatarioEntities db = new DBArrendatarioEntities();

        // GET: api/Usuarios
        public IQueryable<Usuarios> GetUsuarios()
        {
            return db.Usuarios;
        }


        //Metodo par logearme
        [ResponseType(typeof(int))]
        [Route("api/Usuarios/Login")]
        [HttpPost]
        public IHttpActionResult Login(Usuarios usuarios )
        {
            // Buscar el usuario por correo y contraseña
            Usuarios usuario = db.Usuarios.FirstOrDefault(u => u.Correo_usuario == usuarios.Correo_usuario && u.Contrasena_usuario == usuarios.Contrasena_usuario);

            if (usuario != null)
            {
                return Ok(usuario.Id_usuario);
            }
            else
            {
                return Ok(-1);
            }
        }



        // GET: api/Usuarios/5
        [ResponseType(typeof(Usuarios))]
        public IHttpActionResult GetUsuarios(int id)
        {
            Usuarios usuarios = db.Usuarios.Find(id);
            if (usuarios == null)
            {
                return NotFound();
            }

            return Ok(usuarios);
        }

        // PUT: api/Usuarios/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUsuarios(int id, Usuarios usuarios)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != usuarios.Id_usuario)
            {
                return BadRequest();
            }

            db.Entry(usuarios).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuariosExists(id))
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

        // POST: api/Usuarios
        [ResponseType(typeof(Usuarios))]
        public IHttpActionResult PostUsuarios(Usuarios usuarios)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Usuarios.Add(usuarios);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = usuarios.Id_usuario }, usuarios);
        }

        // DELETE: api/Usuarios/5
        [ResponseType(typeof(Usuarios))]
        public IHttpActionResult DeleteUsuarios(int id)
        {
            Usuarios usuarios = db.Usuarios.Find(id);
            if (usuarios == null)
            {
                return NotFound();
            }

            db.Usuarios.Remove(usuarios);
            db.SaveChanges();

            return Ok(usuarios);
        }


        //Guardar mi Imagen
        //[HttpPut]
        //[Route("api/Usuarios/{id}/Foto")]
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutUsuarioFoto(int id)
        //{
        //    // Obtener el usuario por ID
        //    Usuarios usuario = db.Usuarios.Find(id);
        //    if (usuario == null)
        //    {
        //        return NotFound();
        //    }

        //    // Verificar si hay archivos adjuntos en la solicitud
        //    if (HttpContext.Current.Request.Files.Count > 0)
        //    {
        //        // Obtener el archivo adjunto
        //        HttpPostedFile file = HttpContext.Current.Request.Files[0];

        //        // Convertir el archivo a un arreglo de bytes (byte[])
        //        byte[] fileBytes;
        //        using (BinaryReader binaryReader = new BinaryReader(file.InputStream))
        //        {
        //            fileBytes = binaryReader.ReadBytes(file.ContentLength);
        //        }

        //        // Actualizar el campo Foto_Usuario con los bytes del archivo
        //        usuario.Foto_Usuario = fileBytes;

        //        try
        //        {
        //            // Guardar los cambios en la base de datos
        //            db.SaveChanges();
        //            return StatusCode(HttpStatusCode.NoContent);
        //        }
        //        catch (Exception ex)
        //        {
        //            // Manejar cualquier error que pueda ocurrir al guardar en la base de datos
        //            return InternalServerError(ex);
        //        }
        //    }

        //    // No se proporcionó una imagen en la solicitud
        //    return BadRequest("No se proporcionó una imagen en la solicitud.");
        //}

        // PUT: api/Usuarios/{id}/Foto
        [HttpPut]
        [Route("api/Usuarios/{id}/Foto")]
        [ResponseType(typeof(string))]
        public IHttpActionResult PutUsuarioFoto(int id)
        {
            // Obtener el usuario por ID
            Usuarios usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return NotFound();
            }

            // Verificar si hay archivos adjuntos en la solicitud
            if (HttpContext.Current.Request.Files.Count > 0)
            {
                // Obtener el archivo adjunto
                HttpPostedFile file = HttpContext.Current.Request.Files[0];

                // Convertir el archivo a un arreglo de bytes (byte[])
                byte[] fileBytes;
                using (BinaryReader binaryReader = new BinaryReader(file.InputStream))
                {
                    fileBytes = binaryReader.ReadBytes(file.ContentLength);
                }

                // Actualizar el campo Foto_Usuario con los bytes del archivo
                usuario.Foto_Usuario = fileBytes;

                try
                {
                    // Guardar los cambios en la base de datos
                    db.SaveChanges();

                    // Devolver la URL de la imagen después de guardarla
                    string imageUrl = $"{Request.RequestUri.GetLeftPart(UriPartial.Authority)}/api/Usuarios/{id}/Foto";
                    return Ok(imageUrl);
                }
                catch (Exception ex)
                {
                    // Manejar cualquier error que pueda ocurrir al guardar en la base de datos
                    return InternalServerError(ex);
                }
            }

            // No se proporcionó una imagen en la solicitud
            return BadRequest("No se proporcionó una imagen en la solicitud.");
        }





        //// traer la imagen
        [HttpGet]
        [Route("api/Usuarios/{id}/Foto")]
        public IHttpActionResult ObtenerFotoUsuario(int id)
        {
            // Obtener el usuario por ID
            Usuarios usuario = db.Usuarios.Find(id);

            if (usuario == null || usuario.Foto_Usuario == null)
            {
                return NotFound(); // Usuario no encontrado o sin imagen
            }

            // Devolver la imagen como un archivo
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ByteArrayContent(usuario.Foto_Usuario)
            };

            // Establecer el tipo de contenido adecuado
            response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/jpeg");

            return ResponseMessage(response);
        }


        // actualizar la informacion del usuario nombre
        //[HttpPut]
        //[Route("api/Usuarios/Act/{id}")]
        //[ResponseType(typeof(IHttpActionResult))]
        //public IHttpActionResult PutUsuariosAct(int id, Usuarios usuarios)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != usuarios.Id_usuario)
        //    {
        //        return BadRequest();
        //    }

        //    // Obtener el usuario existente de la base de datos
        //    Usuarios usuarioExistente = db.Usuarios.Find(id);
        //    if (usuarioExistente == null)
        //    {
        //        return NotFound();
        //    }

        //    // Actualizar solo los campos deseados
        //    usuarioExistente.Nombre_usuario = usuarios.Nombre_usuario;

        //    try
        //    {
        //        db.SaveChanges();
        //        return Ok("Usuario actualizado correctamente");
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!UsuariosExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return InternalServerError(ex);
        //    }
        //}

        [HttpPut]
        [Route("api/Usuarios/Act/{id}")]
        [ResponseType(typeof(IHttpActionResult))]
        public IHttpActionResult PutUsuariosAct(int id, Usuarios usuarios)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != usuarios.Id_usuario)
            {
                return BadRequest();
            }

            // Obtener el usuario existente de la base de datos
            Usuarios usuarioExistente = db.Usuarios.Find(id);
            if (usuarioExistente == null)
            {
                return NotFound();
            }

            // Actualizar solo los campos deseados
            if (!string.IsNullOrEmpty(usuarios.Nombre_usuario))
            {
                usuarioExistente.Nombre_usuario = usuarios.Nombre_usuario;
            }

            if (!string.IsNullOrEmpty(usuarios.Correo_usuario))
            {
                usuarioExistente.Correo_usuario = usuarios.Correo_usuario;
            }

            if (!string.IsNullOrEmpty(usuarios.telefono_usuario))
            {
                usuarioExistente.telefono_usuario = usuarios.telefono_usuario;
            }

            try
            {
                db.SaveChanges();
                return Ok("Usuario actualizado correctamente");
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuariosExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
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

        private bool UsuariosExists(int id)
        {
            return db.Usuarios.Count(e => e.Id_usuario == id) > 0;
        }
    }
}