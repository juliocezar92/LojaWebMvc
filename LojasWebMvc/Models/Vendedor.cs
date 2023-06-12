using LojasWebMvc.Models.Enums;
using Microsoft.OData.Edm;

namespace LojasWebMvc.Models
{
    public class Vendedor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public  DateTime DataNascimento { get; set; }
        public double BaseSalario { get; set; }
        public Departamento Departamento { get; set; }  
        public int DepartamentoId { get; set; }
        public ICollection<RegistroDeVenda> registroDeVendas { get; set; } = new List<RegistroDeVenda>();
        
        public Vendedor() 
        {
        }

        public Vendedor(int id, string name, string email, DateTime dataNascimento, double baseSalario, Departamento departamento)
        {
            Id = id;
            Name = name;
            Email = email;
            DataNascimento = dataNascimento;
            BaseSalario = baseSalario;
            Departamento = departamento;
        }

        public void AddVenda(RegistroDeVenda sr)
        {
            registroDeVendas.Add(sr);
        }

        public void RemoveVendas(RegistroDeVenda sr)
        {
            registroDeVendas.Remove(sr);
        }

        public Double TotalVendas(DateTime inicio, DateTime final)
        {
            return registroDeVendas.Where(sr => sr.Data >= inicio && sr.Data <= final).Sum(sr => sr.Quantia);
        }
    }
}
