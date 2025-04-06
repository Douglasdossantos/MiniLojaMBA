using MBA.Loja.Business.Interfaces;
using MBA.Loja.Business.Interfaces.Services;
using MBA.Loja.Business.Models;
using MBA.Loja.Business.Models.Validations;
using System;

namespace MBA.Loja.Business.Services
{
    public class CategoriaService : BaseService, ICategoiaService
    {
        private readonly ICategoiaService _categoiaService;

        public CategoriaService(ICategoiaService categoiaService, INotificador notificador) : base(notificador) 
        {
            _categoiaService = categoiaService;
        }
        public async Task Adicionar(Categoria categoria)
        {
            if (!ExecutarValidacao(new CategoriaValidation(), categoria))
            {
                return;
            }
            await _categoiaService.Adicionar(categoria);    
        }
        public async Task Atualizar(Categoria categoria)
        {
            if (!ExecutarValidacao(new CategoriaValidation(), categoria))
            {
                return;
            }
            await _categoiaService.Atualizar(categoria);
        }
        public async Task Remover(Guid id)
        {
            await _categoiaService.Remover(id);
        }
        public void Dispose()
        {
            _categoiaService?.Dispose();    
        }
    }
}
