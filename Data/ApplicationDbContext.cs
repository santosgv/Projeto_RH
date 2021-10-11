using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Projeto_RH.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

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

        public DbSet<Projeto_RH.Entidades.Permissoes> Permissoes { get; set; }
    }
}
