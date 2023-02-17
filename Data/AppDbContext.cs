﻿using Microsoft.EntityFrameworkCore;
using PeliculaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeliculaAPI.Data
{
    public class AppDbContext :DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> option) : base (option)
        {

        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Peliculas> Peliculas { get; set; }

        internal Task Delete(Peliculas eliminar)
        {
            throw new NotImplementedException();
        }
    }
}
