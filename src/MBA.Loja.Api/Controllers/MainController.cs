using MBA.Loja.Business.Interfaces;
using MBA.Loja.Business.Notificacoes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Net;

namespace MBA.Loja.Api.Controllers
{
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        private readonly INotificador _notificador;

        protected MainController(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected bool OperacaoValida()
        {
            return !_notificador.TemNotificacao();
        }
        protected ActionResult CustomResponse( HttpStatusCode statusCode = HttpStatusCode.OK, object resultado = null)
        {
            if (OperacaoValida())
            {
                return new ObjectResult(resultado) 
                {
                    StatusCode = Convert.ToInt32(statusCode),
                };
            }

            return BadRequest(new 
            {
               errors = _notificador.ObterNotificacoes().Select( a  => a.Mensagen)               
            });
        }
        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!ModelState.IsValid) { }
            return CustomResponse();
        }

        protected void NotificarErroModelInvalida(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany( w => w.Errors );
            foreach ( var erro in erros )
            {
                var erroMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                NotificarErro( erroMsg );   
            }
        }

        protected void NotificarErro(string mensagem)
        {
            _notificador.Handle(new Notificacao(mensagem));
        }
    }
}
