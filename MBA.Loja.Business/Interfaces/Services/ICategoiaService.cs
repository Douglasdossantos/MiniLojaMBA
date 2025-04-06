using MBA.Loja.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBA.Loja.Business.Interfaces.Services
{
    public interface ICategoiaService : IDisposable
    {
        Task Adicionar(Categoria categoria);
        Task Atualizar(Categoria categoria);
        Task Remover(Guid id);
    }
}
