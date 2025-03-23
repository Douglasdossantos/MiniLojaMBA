using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBA.Loja.Business.Models
{
    public class Produto : Entity
    {
        public string Nome { get; private set; } 
        public string Descricao { get; private set; } 
        public decimal Preco { get; private set; }
        public int Estoque { get; private set; }
        public int CategoriaId { get; private set; }
        public Categoria Categoria { get; private set; }
        public bool Ativo { get; private set; }

        public int VendedorId { get; private set; }
        public Vendedor Vendedor { get; private set; }

        public bool AdicionarProduto( string nome, string descricao, decimal preco, int estoque)
        {

        }

    }
}
