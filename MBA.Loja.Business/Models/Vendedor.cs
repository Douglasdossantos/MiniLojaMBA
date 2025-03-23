using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBA.Loja.Business.Models
{
    public class Vendedor : Entity
    {
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Telefone { get; private set; }
        public string Documento { get; private set; } 
        public DateTime DataCadastro { get; private set; } = DateTime.UtcNow;
        public bool Ativo { get; private set; } = false;



    }
}
