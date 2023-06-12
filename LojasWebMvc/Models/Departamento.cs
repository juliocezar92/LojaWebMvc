namespace LojasWebMvc.Models
{
    public class Departamento
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Vendedor> Vendedores { get; set; } = new List<Vendedor>();
        public Departamento() 
        {
        }

        public Departamento(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void AddVendedor(Vendedor vendedor) 
        {
            Vendedores.Add(vendedor);
        }

        public double TotalVendedores(DateTime inicio, DateTime final) 
        {
            return Vendedores.Sum(vendedor => vendedor.TotalVendas(inicio, final));
        }
    }
}
