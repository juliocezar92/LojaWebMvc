using LojasWebMvc.Models;

namespace LojasWebMvc.Services
{
    public class VendedorService
    {
        private readonly LojasWebMvcContext _context;

        public VendedorService(LojasWebMvcContext context)
        {
            _context = context;
        }

        public List<Vendedor> FindAll() 
        {
            return _context.Vendedor.ToList();
        }

        public void Insert(Vendedor obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

    }
}
