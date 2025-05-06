using MBA.Loja.Business.Interfaces.Services;
using MBA.Loja.Business.Interfaces;
using MBA.Loja.Business.Models.Validation;
using MBA.Loja.Business.Models;
using MBA.Loja.Business.Interfaces.Repository;

namespace MBA.Loja.Business.Services
{
    public class CategoriaService : BaseService, ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaService(ICategoriaRepository categoiaRepository, INotificador notificador) : base(notificador)
        {
            _categoriaRepository = categoiaRepository;
        }
        public async Task Adicionar(Categoria categoria)
        {
            if (!ExecutarValidacao(new CategoriaValidation(), categoria))
            {
                return;
            }

            if (_categoriaRepository.Buscar(f=> f.Nome == categoria.Nome).Result.Any())
            {
                Notificar("Já existe uma categoria com esse nome informado");
                return;
            }
            await _categoriaRepository.Adicionar(categoria);
        }
        public async Task Atualizar(Categoria categoria)
        {
            if (!ExecutarValidacao(new CategoriaValidation(), categoria))
            {
                return;
            }
            await _categoriaRepository.Atualizar(categoria);
        }
        public async Task Remover(Guid id)
        {
            await _categoriaRepository.Remover(id);
        }
        public void Dispose()
        {
            _categoriaRepository?.Dispose();
        }
    }
}
