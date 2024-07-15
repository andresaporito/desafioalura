using Desafio.Alura.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Desafio.Alura.Infra.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Curso> Curso { get; set; }
    }
}
