using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LojasWebMvc.Models;

namespace LojasWebMvc.Data
{
    public class LojasWebMvcContext : DbContext
    {
        public LojasWebMvcContext (DbContextOptions<LojasWebMvcContext> options)
            : base(options)
        {
        }

        public DbSet<LojasWebMvc.Models.Departamento> Departamento { get; set; } = default!;
    }
}
