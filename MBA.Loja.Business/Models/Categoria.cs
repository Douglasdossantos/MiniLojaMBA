﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBA.Loja.Business.Models
{
    public class Categoria : Entity
    {
        public string Nome { get;  set; }
        public bool Ativo { get;  set; }

        public List<Produto> Produtos { get; set; } = new();
    }
}
