using System;

namespace sistema_fornecedor.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataPedido { get; set; } = DateTime.UtcNow;

        public double Valor { get; set; }

        public Fornecedores Fornecedor { get; set; }
    }
}