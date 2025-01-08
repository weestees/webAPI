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
    public class FosilesController : ApiController
    {
        private GestorColeccion bd = new GestorColeccion();

        [HttpGet]
        public IEnumerable<Fosil> ObtenerFosiles()
        {
            return bd.Fosiles.ToList();
        }

        [HttpGet]
        public IHttpActionResult ObtenerFosil(int id)
        {
            var fosil = bd.Fosiles.Find(id);
            if (fosil == null)
                return NotFound();
            return Ok(fosil);
        }

        [HttpPost]
        public IHttpActionResult CrearFosil(Fosil fosil)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            bd.Fosiles.Add(fosil);
            bd.SaveChanges();
            return CreatedAtRoute("DefaultApi", new
            {
                id = fosil.ID
            }, fosil);
        }

        [HttpPut]
        public IHttpActionResult ActualizarFosil(int id, Fosil fosil)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (id != fosil.ID)
                return BadRequest();
            bd.Entry(fosil).State = EntityState.Modified;
            bd.SaveChanges();
            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpDelete]
        public IHttpActionResult BorrarFosil(int id)
        {
            var fosil = bd.Fosiles.Find(id);
            if (fosil == null)
                return NotFound();
            bd.Fosiles.Remove(fosil);
            bd.SaveChanges();
            return Ok(fosil);
        }

    }
}
