using Xamarin.Forms;

namespace DBHTec.ViewModels
{
    public class PoliticaViewModel : BaseViewModel
    {
        public HtmlWebViewSource Conteudo { get; }

        public PoliticaViewModel()
        {
            Conteudo = new HtmlWebViewSource
            {
                Html = @"<h2>Política de privacidade para <a href='http://github.com/pictos'>DiabetesApp</a></h2><p>Todas as suas informações pessoais recolhidas, serão usadas para o ajudar a tornar o uso de nosso aplicativo o mais produtivo e agradável possível.</p><p>A garantia da confidencialidade dos dados pessoais dos utilizadores do nosso aplicativo é importante para o DiabetesApp.</p><p>Todas as informações pessoais relativas a membros, assinantes, clientes ou visitantes que usem o DiabetesApp serão tratadas em concordância com a Lei da Proteção de Dados Pessoais de 26 de outubro de 1998 (Lei n.º 67/98).</p><p>A informação pessoal recolhida pode incluir qualquer grupo de dados utilizados para a predição de diabes.</p><p>O uso do DiabetesApp pressupõe a aceitação deste Acordo de privacidade. A equipa do DiabetesApp reserva-se ao direito de alterar este acordo sem aviso prévio. Deste modo, recomendamos que consulte a nossa política de privacidade com regularidade de forma a estar sempre atualizado.</p><h2>Ligações a serviços de terceiros</h2><p>O DiabetesApp possui ligações para outros serviços , os quais, a nosso ver, podem conter informações / ferramentas úteis para os nossos visitantes. A nossa política de privacidade não é aplicada a serviços de terceiros, sendo assim o usuário deverá ler a politica de privacidade do mesmo.</p><p>Não nos responsabilizamos pela política de privacidade ou conteúdo presente nesses mesmos serviços.</p>"

            };
        }
    }
}
