using LojasWebMvc.Models;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace LojasWebMvc.Services
{
    public class RegistroDeVendasService
    {
        private readonly LojasWebMvcContext _context;

        public RegistroDeVendasService(LojasWebMvcContext context)
        {
            _context = context;
        }

        public async Task<List<RegistroDeVenda>> FindByDateAsync(DateTime? minDate, DateTime? maxDate) 
        {
            var result = from obj in _context.RegistroDeVendas select obj;
            if (minDate.HasValue)
            {
                result = result.Where(x => x.Data >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Data <= maxDate.Value);
            }
            return await result
                .Include(x => x.Vendedor)
                .Include(x => x.Vendedor.Departamento)
                .OrderByDescending(x => x.Data)
                .ToListAsync();
        }
        public async Task<List<IGrouping<Departamento, RegistroDeVenda>>> FindByDateAgroupingAsync(DateTime? minDate, DateTime? maxDate) 
        {
            var result = from obj in _context.RegistroDeVendas select obj;
            if (minDate.HasValue)
            {
                result = result.Where(x => x.Data >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Data <= maxDate.Value);
            }
            var vendas = await result
        .Include(x => x.Vendedor)
        .Include(x => x.Vendedor.Departamento)
        .OrderByDescending(x => x.Data)
        .ToListAsync();

            var vendasAgrupadas = vendas.GroupBy(x => x.Vendedor.Departamento).ToList();

            return vendasAgrupadas;
        }
    }
}
