using AutoMapper;
using MBA.Loja.Api.ViewModels;
using MBA.Loja.Business.Interfaces;
using MBA.Loja.Business.Interfaces.Repository;
using MBA.Loja.Business.Interfaces.Services;
using MBA.Loja.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MBA.Loja.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class ProdutoController : MainController
    {
        private readonly IProdutoRepository _produtoRepository; 
        private readonly IProdutoService _produtoService;   
        private readonly IMapper _mapper;

        public ProdutoController(IProdutoRepository produtoRepository, 
            IProdutoService produtoService, 
            IMapper mapper, INotificador notificador) : base (notificador)
        {
            _produtoRepository = produtoRepository;
            _produtoService = produtoService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<ProdutoViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<ProdutoViewModel>>(await _produtoRepository.ObterTodos());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ProdutoViewModel>> ObterProdutoId(Guid id)
        {
            var produtoViewmodel = await ObterProdutoId(id);
            if (produtoViewmodel == null)
            {
                NotFound();
            }

            return produtoViewmodel;

        }

        [HttpPost]
        public async Task<ActionResult<ProdutoViewModel>> Adicionar([FromBody] ProdutoViewModel produtoViewModel)
        {
            if (!ModelState.IsValid)
            {
                return CustomResponse(ModelState);
            }

            await _produtoService.Adicionar(_mapper.Map<Produto>(produtoViewModel));

            return CustomResponse(HttpStatusCode.Created, produtoViewModel);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Atualizar(Guid id, ProdutoViewModel produtoViewModel)
        {
            if (id == produtoViewModel.Id)
            {
                NotificarErro("Os Id não são iguais!");
                return CustomResponse();
            }

            if (!ModelState.IsValid)
            {
                return CustomResponse(ModelState);  
            }

            var produtoAtualizacao = await ObterProduto(id);

            produtoAtualizacao.Preco = produtoViewModel.Preco;
            produtoAtualizacao.Ativo = produtoViewModel.Ativo;

            await _produtoService.Atualizar(_mapper.Map<Produto>(produtoAtualizacao));

            return CustomResponse(HttpStatusCode.NoContent);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Excluir(Guid id)
        {
            var produto = await ObterProduto(id);
            if (produto == null)
            {
                return NotFound();
            }

            await _produtoService.Remover(id);

            return CustomResponse(HttpStatusCode.NoContent);
        }

        private async Task<ProdutoViewModel> ObterProduto(Guid id)
        {
            return _mapper.Map<ProdutoViewModel>(await _produtoRepository.ObterProdudoEVendedor(id));
        }
    }
}
