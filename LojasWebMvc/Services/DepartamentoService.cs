using LojasWebMvc.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace LojasWebMvc.Services
{

    public class DepartamentoService
    {
        private readonly LojasWebMvcContext _context;

        public DepartamentoService(LojasWebMvcContext context)
        {
            _context = context;
        }

        public async Task <List<Departamento>> FindAllAsync()
        {
            return await _context.Departamento.OrderBy(x => x.Name).ToListAsync();
        }
    }
}
