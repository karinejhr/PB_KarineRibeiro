using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IReceitaRepository
    {
        Task<IEnumerable<Receita>> GetAllAsync();
        Task<Receita> GetByIdAsync(int id);
        Task InsertAsync(Receita receita);
        Task UpdateAsync(Receita receita);
        Task DeleteAsync(Receita receita);
    }
}
