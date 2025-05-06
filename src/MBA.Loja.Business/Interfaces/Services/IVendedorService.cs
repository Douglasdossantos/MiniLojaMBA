using MBA.Loja.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBA.Loja.Business.Interfaces.Services
{
    public interface IVendedorService : IDisposable
    {
        Task AdicionarProduto(Produto produto);
        Task AtualizarProduto(Produto produto);
        Task RemoverProduto(Guid id);
        Task Adicionar(Vendedor vendedor);
        Task Atualizar(Vendedor vendedor);
        Task Remover(Guid id);
    }
}
