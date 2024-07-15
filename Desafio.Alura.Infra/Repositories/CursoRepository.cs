using Desafio.Alura.Domain.Entities;
using Desafio.Alura.Domain.Interfaces.Respositories;
using Desafio.Alura.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Desafio.Alura.Infra.Repositories
{
    public class CursoRepository(AppDbContext context) : ICursoRepository
    {
        private AppDbContext _context { get; set; } = context;
        public async Task<Curso> GravarCurso(Curso curso)
        {
            await _context.AddAsync(curso);
            await _context.SaveChangesAsync();

            return curso;
        }

        public async Task<List<Curso>> GetAll()
        {
            return await _context.Curso
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
