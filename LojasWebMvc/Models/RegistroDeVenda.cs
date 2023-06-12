using LojasWebMvc.Models.Enums;
using Microsoft.OData.Edm;

namespace LojasWebMvc.Models
{
    public class RegistroDeVenda
    {
        public int Id { get; set; }
        public DateTime Data { get; set;}
        public Double Quantia { get; set; }
        public VendasStatus Status { get; set; }
        public Vendedor Vendedor { get; set; }
        public RegistroDeVenda() 
        {
        }

        public RegistroDeVenda(int id, DateTime data, double quantia, VendasStatus status, Vendedor vendedor)
        {
            Id = id;
            Data = data;
            Quantia = quantia;
            Status = status;
            Vendedor = vendedor;
        }
    }
}
