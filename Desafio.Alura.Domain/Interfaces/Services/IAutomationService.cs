using Desafio.Alura.Domain.Entities;

namespace Desafio.Alura.Domain.Interfaces.Services
{
    public interface IAutomationService
    {
        Task RunAutomation();
        Task<List<Curso>> GetAll();
    }
}
