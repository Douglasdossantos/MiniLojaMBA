using MBA.Loja.Api.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MBA.Loja.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : MainController
    {
        public CategoriaController(){}

        [HttpGet]
        public async Task<IEnumerable<CategoriaViewModel>> ObterTodos()
        {
            return Ok();
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<CategoriaViewModel>> ObterPorId( Guid id)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<CategoriaViewModel>> Adicionar(Guid id)
        {
            return Ok();
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<CategoriaViewModel>> Atualizar(Guid id)
        {
            return Ok();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<CategoriaViewModel>> Remover(Guid id)
        {
            return Ok();
        }

    }
}
