using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HelloWorld.Models
{
    public class Contexto : DbContext
    {

        public DbSet<Carro> Carros { get; set; }

        public Contexto(DbContextOptions<Contexto> opcoes) : base(opcoes) { }
    }
}
