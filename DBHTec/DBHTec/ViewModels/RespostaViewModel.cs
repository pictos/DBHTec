using System.Globalization;
using DBHTec.Models;
using Xamarin.Forms;

namespace DBHTec.ViewModels
{
    public class RespostaViewModel : BaseViewModel
    {
        #region Propriedades

        private bool isBusy;

        public bool IsBusy
        {
            get { return isBusy; }
            set {SetProperty(ref isBusy , value); }
        }

        
        private string probabilidade;

        public string Probabilidade
        {
            get { return probabilidade; }
            set {SetProperty(ref probabilidade , value); }
        }

        private Color cor;

        public Color Cor
        {
            get { return cor; }
            set { SetProperty(ref cor, value); }
        }


        #endregion

        public RespostaViewModel(RespostaTest resposta)
        {
            var valor = resposta.Results.Output1[0];
            Carregar(valor);
        }

        private void Carregar(Output1 valor)
        {
            var prob      = double.Parse(valor.Probabilidade);
            probabilidade = $"Chance do paciente estar com diabetes: {string.Format(new CultureInfo("pt-BR"),"{0:N2}",prob*100)}% \n";
            if (prob > 0.60)
            {
                Cor = Color.Red;
                probabilidade += "\n O paciente está em uma situação de risco!";
            }
            else
            {
                Cor = Color.Black;
                probabilidade += "\n O paciente não está em uma situação de risco.";

            }
        }
    }
}
