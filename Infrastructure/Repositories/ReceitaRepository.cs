using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using WebAppChefIdentity.Data;
using Domain.Interfaces.Repositories;

namespace Infrastructure.Repositories
{
    public class ReceitaRepository : IReceitaRepository
    {
        private readonly AppDbContext _context;
        public ReceitaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task DeleteAsync(Receita receita)
        {
            _context.Remove(receita);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Receita>> GetAllAsync()
        {
            return await _context.Receita.ToListAsync();
        }

        public async Task<Receita> GetByIdAsync(int id)
        {
            return await _context.Receita.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task InsertAsync(Receita receita)
        {
            _context.Add(receita);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Receita receita)
        {
            _context.Update(receita);
            await _context.SaveChangesAsync();
        }
    }
}
