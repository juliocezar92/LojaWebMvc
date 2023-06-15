using LojasWebMvc.Models.Enums;
using Microsoft.OData.Edm;
using System.ComponentModel.DataAnnotations;

namespace LojasWebMvc.Models
{
    public class Vendedor
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} Requerido")]
        [StringLength(80, MinimumLength = 5,ErrorMessage = "{0} deve conter pelo menos {2} letras e no maximo {1} letras.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} Requerido")]
        [EmailAddress(ErrorMessage = "entre com um email valido!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} Requerido")]
        [Display(Name = "Data Nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public  DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "{0} Requerido")]
        [Range(100.00, 50000.00, ErrorMessage = "{0} deve se entre {1} até {2}")]
        [Display (Name = "Base salário")]
        [DisplayFormat(DataFormatString = "{0:f2}")]
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
