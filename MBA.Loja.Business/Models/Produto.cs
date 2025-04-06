using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBA.Loja.Business.Models
{
    public class Produto : Entity
    {
        public string Nome { get;  set; }
        public string Descricao { get;  set; }
        public decimal Preco { get;  set; }
        public int Estoque { get;  set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get;  set; }
        public string Imagem { get;  set; }

        public Guid CategoriaId { get;  set; }
        public Categoria Categoria { get;  set; }
        public Guid VendedorId { get;  set; }
        public Vendedor Vendedor { get;  set; }
    }
}
