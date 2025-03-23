using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBA.Loja.Business.Models
{
    public class Categoria : Entity
    {
        public string Nome { get; private set; }
        public bool Ativo { get; private set; }

        public List<Produto> produtos { get; set; } = new();
    }
}
