using LojasWebMvc.Models;

namespace LojasWebMvc.Services
{

    public class DepartamentoService
    {
        private readonly LojasWebMvcContext _context;

        public DepartamentoService(LojasWebMvcContext context)
        {
            _context = context;
        }

        public List<Departamento> FindAll()
        {
            return _context.Departamento.OrderBy(x => x.Name).ToList();
        }
    }
}
