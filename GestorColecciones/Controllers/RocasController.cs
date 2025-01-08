using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using GestorColecciones.DAL;
using GestorColecciones.Models;

namespace GestorColecciones.Controllers
{
    public class RocasController : ApiController
    {
        private GestorColeccion bd = new GestorColeccion();

        [HttpGet]
        public IEnumerable<Roca> ObtenerRocas()
        {
            return bd.Rocas.ToList();
        }

        [HttpGet]
        public IHttpActionResult ObtenerRoca(int id)
        {
            var roca = bd.Rocas.Find(id);
            if (roca == null)
                return NotFound();
            return Ok(roca);
        }

        [HttpPost]
        public IHttpActionResult CrearRoca(Roca roca)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            bd.Rocas.Add(roca);
            bd.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = roca.ID },
           roca);
        }

        [HttpPut]
        public IHttpActionResult ActualizarRoca(int id, Roca roca)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (id != roca.ID)
                return BadRequest();
            bd.Entry(roca).State = EntityState.Modified;
            bd.SaveChanges();
            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpDelete]
        public IHttpActionResult BorrarRoca(int id)
        {
            var roca = bd.Rocas.Find(id);
            if (roca == null)
                return NotFound();
            bd.Rocas.Remove(roca);
            bd.SaveChanges();
            return Ok(roca);
        }

    }
}
