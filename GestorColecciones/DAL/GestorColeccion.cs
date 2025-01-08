using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using GestorColecciones.Models;


namespace GestorColecciones.DAL
{
    public class GestorColeccion : DbContext
    {
        public DbSet<Roca> Rocas { get; set; }
        public DbSet<Fosil> Fosiles { get; set; }
    }
}