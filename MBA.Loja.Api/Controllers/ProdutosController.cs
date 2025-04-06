using MBA.Loja.Api.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace MBA.Loja.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : MainController
    {
        public ProdutosController()
        {
        }

        [HttpGet]
        public async Task<IEnumerable<ProdutoViewModel>> ObterTodos()
        {
            return Ok();
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ProdutoViewModel>> ObterPorId(Guid id)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<ProdutoViewModel>> Adicionar(ProdutoViewModel produtoViewModel)
        {
            return Ok();
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<ProdutoViewModel>> Atualizar(Guid id, ProdutoViewModel produtoViewModel)
        {
           
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<ProdutoViewModel>> Excluir(Guid id, ProdutoViewModel produtoViewModel)
        {
            return Ok();
        }
    }
}
