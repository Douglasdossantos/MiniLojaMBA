using MBA.Loja.Business.Interfaces;

namespace MBA.Loja.Business.Notificacoes
{
    public class Notificador : INotificador
    {
        private readonly List<Notificacao> _notificacoes;

        public Notificador(List<Notificacao> notificacoes)
        {
            _notificacoes = new List<Notificacao>();
        }

        public void Handle(Notificacao notificacao)
        {
            _notificacoes.Add(notificacao);
        }

        public List<Notificacao> ObterNotificacoes()
        {
            return _notificacoes;
        }

        public bool TemNotificacao()
        {
            return _notificacoes.Any(); 
        }
    }
}
