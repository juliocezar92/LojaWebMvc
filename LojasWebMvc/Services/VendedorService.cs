using LojasWebMvc.Models;
using LojasWebMvc.Services.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace LojasWebMvc.Services
{
    public class VendedorService
    {
        private readonly LojasWebMvcContext _context;

        public VendedorService(LojasWebMvcContext context)
        {
            _context = context;
        }

        public async Task <List<Vendedor>> FindAllAsync() 
        {
            return await _context.Vendedor.ToListAsync();
        }

        public async Task InsertAsync(Vendedor obj)
        {
            _context.Add(obj);
            _context.SaveChangesAsync();
        }

        public async Task <Vendedor> FindByIdAsync(int id)
        {
            return await    _context.Vendedor.Include(obj => obj.Departamento).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id) 
        {
            try
            {
                var obj = await _context.Vendedor.FindAsync(id);
                _context.Vendedor.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw new IntegrityException("não podemos deletar o vendedor, porque ele possui vendas");
            }
        }

        public async Task UpdateAsync(Vendedor obj)
        {
            
            if (!await _context.Vendedor.AnyAsync(x => x.Id == obj.Id))
            {
                throw new NotFoundException("ID não encontrado");
            }
            try
            {
                _context.Update(obj);
                 await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e) 
            {
                throw new DbUpdateConcurrencyException(e.Message);
            }
        }
    }
}
