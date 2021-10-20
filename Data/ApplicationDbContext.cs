using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Projeto_RH.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using Projeto_RH.Models;
using Microsoft.AspNetCore.Identity;

namespace Projeto_RH.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Rh> RH { get; set; }

        public DbSet<Projeto_RH.Models.TipoUsuario> TipoUsuario { get; set; }

        public DbSet<Projeto_RH.Models.AcessoTipoUsuario> AcessoTipoUsuario { get; set; }

        public DbSet<Projeto_RH.Models.PerfilUsuario> PerfilUsuario { get; set; }
        public DbSet<IdentityUser> Usuario{ get;  set; }
    }
}
