using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LojasWebMvc.Models;

namespace LojasWebMvc.Models
{
    public class LojasWebMvcContext : DbContext
    {
        public LojasWebMvcContext (DbContextOptions<LojasWebMvcContext> options)
            : base(options)
        {
        }

        public DbSet<Departamento> Departamento { get; set; } = default!;
        public DbSet<Vendedor> Vendedor { get; set; } = default!;
        public DbSet<RegistroDeVenda> RegistroDeVendas { get; set; } = default!;
    }
}
