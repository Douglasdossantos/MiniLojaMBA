using MBA.Loja.Api.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MBA.Loja.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendedorController : MainController
    {
        public VendedorController()
        {            
        }
        public async Task<IEnumerable<VendedorController>> ObterTodos()
        {
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<VendedorController>> ObterPorId(Guid id)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<VendedorController>> Adicionar(Guid id)
        {
            return Ok();
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<VendedorController>> Atualizar(Guid id, VendedorViewModel vendedorViewModel)
        {
            return Ok();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<VendedorController>> Remover(Guid id)
        {
            return Ok();
        }
    }
}
