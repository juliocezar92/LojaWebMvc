using LojasWebMvc.Models;
using Microsoft.EntityFrameworkCore;
using LojasWebMvc.Models.Enums;
namespace LojasWebMvc.Data
{
    public class SeedingService
    {
        private LojasWebMvcContext _context;
            public SeedingService(LojasWebMvcContext context)
        {
            _context = context;
        }
        public void Seed() 
        {
            if (_context.Departamento.Any() ||
                _context.Vendedor.Any() ||
                _context.RegistroDeVendas.Any()) 
            {
                return;// o banco de dados ja foi populado
            }

            Departamento D2 = new Departamento(2, "Computadores");
            Departamento D3 = new Departamento(3, "Eletronicos");
            Departamento D4 = new Departamento(4, "Fashion");
            Departamento D5 = new Departamento(5, "Casa");

            Vendedor v1 = new Vendedor(1,"Bob Brown", "bob@gmail.com",new DateTime(1998, 4, 21), 1000.0, D2);
            Vendedor v2 = new Vendedor(2,"Jose Silva", "jose@gmail.com", new DateTime(1995, 10, 22), 1500.0, D3);
            Vendedor v3 = new Vendedor(3, "Joaquim Barbosa", "joaqui@gmail.com", new DateTime(1992, 12, 22), 1300.0, D4);
            Vendedor v4 = new Vendedor(4, "Bob Brown", "Bob@gmail.com", new DateTime(1999, 10, 5), 1500.0, D5);

            RegistroDeVenda r1 = new RegistroDeVenda(1, new DateTime(2022, 01, 15), 11000.0, VendasStatus.Faturada, v1);
            RegistroDeVenda r2 = new RegistroDeVenda(2, new DateTime(2022, 01, 15), 1000.0, VendasStatus.Faturada, v2);
            RegistroDeVenda r3 = new RegistroDeVenda(3, new DateTime(2022, 01, 15), 1500.0, VendasStatus.Faturada, v4);
            RegistroDeVenda r4 = new RegistroDeVenda(4, new DateTime(2022, 01, 16), 100.0, VendasStatus.Faturada, v1);
            RegistroDeVenda r5 = new RegistroDeVenda(5, new DateTime(2022, 01, 16), 1200.0, VendasStatus.Faturada, v3);
            RegistroDeVenda r6 = new RegistroDeVenda(6, new DateTime(2022, 01, 16), 1100.0, VendasStatus.Faturada, v2);
            RegistroDeVenda r7 = new RegistroDeVenda(7, new DateTime(2022, 01, 17), 11000.0, VendasStatus.Faturada, v4);
            RegistroDeVenda r8 = new RegistroDeVenda(8, new DateTime(2022, 01, 17), 100.0, VendasStatus.Faturada, v2);
            RegistroDeVenda r9 = new RegistroDeVenda(9, new DateTime(2022, 01, 17), 150.0, VendasStatus.Faturada, v3);
            RegistroDeVenda r10 = new RegistroDeVenda(10, new DateTime(2022, 01, 17), 1300.0, VendasStatus.Faturada, v4);
            RegistroDeVenda r11 = new RegistroDeVenda(11, new DateTime(2022, 01, 18), 1100.0, VendasStatus.Faturada, v1);
            RegistroDeVenda r12 = new RegistroDeVenda(12, new DateTime(2022, 01, 18), 160.0, VendasStatus.Faturada, v3);
            RegistroDeVenda r13 = new RegistroDeVenda(13, new DateTime(2022, 01, 18), 1050.0, VendasStatus.Faturada, v2);
            RegistroDeVenda r14 = new RegistroDeVenda(14, new DateTime(2022, 01, 18), 1105.0, VendasStatus.Faturada, v4);
            RegistroDeVenda r15 = new RegistroDeVenda(15, new DateTime(2022, 01, 19), 1100.0, VendasStatus.Faturada, v3);
            RegistroDeVenda r16 = new RegistroDeVenda(1, new DateTime(2022, 01, 19), 150.0, VendasStatus.Faturada, v1);
            RegistroDeVenda r17 = new RegistroDeVenda(1, new DateTime(2022, 01, 19), 1200.0, VendasStatus.Faturada, v2);

            _context.Departamento.AddRange(D2, D3, D4, D5);
            _context.Vendedor.AddRange(v1, v2, v3, v4);
            _context.RegistroDeVendas.AddRange(r1, r2, r3, r4, r5, r6, r7, r8, r9, r10, r11, r12, r13, r14, r15);
            _context.SaveChanges();
        }
    }
}
