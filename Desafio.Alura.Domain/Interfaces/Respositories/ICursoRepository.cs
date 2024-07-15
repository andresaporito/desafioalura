using Desafio.Alura.Domain.Entities;

namespace Desafio.Alura.Domain.Interfaces.Respositories
{
    public interface ICursoRepository
    {
        Task<Curso> GravarCurso(Curso curso);
        Task<List<Curso>> GetAll();
    }
}
