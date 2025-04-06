using MBA.Loja.Business.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBA.Loja.Business.Models
{
    public class Vendedor : Entity
    {
        public string Nome { get;  set; }
        public string Email { get;  set; }
        public string Telefone { get;  set; }
        public string Documento { get;  set; } 
        public DateTime DataCadastro { get;  set; } = DateTime.UtcNow;
        public bool Ativo { get;  set; } = false;
        public EnumDocumento TipoDocumento { get; set; }

        public IEnumerable<Produto> Produtos { get; set; }



    }
}
