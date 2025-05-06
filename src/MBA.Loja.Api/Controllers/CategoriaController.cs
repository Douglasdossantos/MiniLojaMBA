using AutoMapper;
using MBA.Loja.Api.ViewModels;
using MBA.Loja.Business.Interfaces;
using MBA.Loja.Business.Interfaces.Repository;
using MBA.Loja.Business.Interfaces.Services;
using MBA.Loja.Business.Models;
using MBA.Loja.Data.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MBA.Loja.Api.Controllers
{
    [Route("api/[controller]")]
    //[Authorize]
    public class CategoriaController : MainController
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly ICategoriaService _categoriaService;
        private readonly IMapper _mapper;

        public CategoriaController(ICategoriaRepository categoriaRepository, 
            ICategoriaService categoriaService, IMapper mapper, INotificador notificador) : base(notificador)
        {
            _categoriaRepository = categoriaRepository;
            _categoriaService = categoriaService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CategoriaComProdutosViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<CategoriaComProdutosViewModel>>(await _categoriaRepository.ObterTodos());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<CategoriaComProdutosViewModel>> ObterPorId(Guid id)
        {
            var categoria = await ObterTodosCategoriasProdutos(id);

            if (categoria == null)
            {
                return NotFound();
            }

            return Ok(categoria);
        }

        [HttpPost]
        public async Task<ActionResult<AddCategoriaViewModel>> Adicionar(AddCategoriaViewModel categoriaViewModel)
        {
            if (!ModelState.IsValid)
            {
                return CustomResponse(ModelState);
            }
            await _categoriaRepository.Adicionar(_mapper.Map<Categoria>(categoriaViewModel));

            return CustomResponse(HttpStatusCode.Created, categoriaViewModel);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<AtualizarCategoriaViewModel>> Atualizar(Guid id, AtualizarCategoriaViewModel categoriaViewModel)
        {
            if (id != categoriaViewModel.Id)
            {
                NotificarErro("O id Informado não corresponde ao mesmo informado");
                return CustomResponse();
            }
            if (!ModelState.IsValid)
            {
                return CustomResponse(ModelState);
            }

            await _categoriaRepository.Atualizar(_mapper.Map<Categoria>(categoriaViewModel));

            return CustomResponse(HttpStatusCode.NoContent, categoriaViewModel);           
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<CategoriaComProdutosViewModel>> Excluir(Guid id)
        {
            await _categoriaService.Remover(id);
            return CustomResponse(HttpStatusCode.NoContent);
        }
        private async Task<CategoriaComProdutosViewModel> ObterTodosCategoriasProdutos(Guid IdCategoria)
        {
            return _mapper.Map<CategoriaComProdutosViewModel>(await _categoriaRepository.ObterPorId(IdCategoria)); 
        }
    }
}
