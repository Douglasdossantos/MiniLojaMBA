using MBA.Loja.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBA.Loja.Business.Interfaces.Services
{
    public interface IProdutoService :IDisposable
    {
        Task Adicionr(Produto produto);
        Task Atualizar(Produto produto);
        Task Remover(Guid id);
    }
}
