using DBHTec.Models;
using DBHTec.Servicos;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DBHTec.ViewModels
{
    public class FormViewModel : BaseViewModel
    {
        #region Propriedades

        private bool isBusy;

        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                if (SetProperty(ref isBusy, value))
                {
                    ServicoCommand.ChangeCanExecute();
                    PoliticaCommand.ChangeCanExecute();
                }
            }
        }

        private double? idade;

        public double? Idade
        {
            get { return idade; }
            set { SetProperty(ref idade, value); }
        }

        private double? bmi;

        public double? BMI
        {
            get { return bmi; }
            set { SetProperty(ref bmi, value); }
        }

        private double? gravidez;

        public double? Gravidez
        {
            get { return gravidez; }
            set { SetProperty(ref gravidez, value); }
        }

        private double? diabPedigree;

        public double? DiabPedigree
        {
            get { return diabPedigree; }
            set { SetProperty(ref diabPedigree, value); }
        }

        private double? tricips;

        public double? Triceps
        {
            get { return tricips; }
            set {SetProperty(ref tricips , value); }
        }

        private double? plasmaG;

        public double? PlasmaG
        {
            get { return plasmaG; }
            set {SetProperty(ref plasmaG , value); }
        }

        private double? insulinaSerica;

        public double? InsulinaSerica
        {
            get { return insulinaSerica; }
            set {SetProperty(ref insulinaSerica , value); }
        }

        private double? pressaoSangue;

        public double? PressaoSangue
        {
            get { return pressaoSangue; }
            set {SetProperty(ref pressaoSangue , value); }
        }


        #endregion

        Input1 Input1;
        public Command ServicoCommand  { get; }
        public Command PoliticaCommand { get; }
        public FormViewModel()
        {
            PoliticaCommand = new Command(async () => await ExecutePoliticaCommand(), () => !IsBusy);
            ServicoCommand  = new Command(async () => await ExecuteServicoCommand(), () => !IsBusy);
        }

        async Task ExecutePoliticaCommand()
        {
            if (!IsBusy)
            {
                try
                {
                    IsBusy = true;
                    await PushAsync<PoliticaViewModel>();
                }
                catch (Exception ex)
                {

                    await DisplayAlert("Erro", $"Erro:{ex.Message}", "Ok");
                }
                finally
                {
                    IsBusy = false;
                }
            }
            return;
        }

        void CriarInput()
        {

            Popular();
            Input1 = new Input1
            {
                BMI                        = string.Format(culture,"{0:N3}",this.BMI),
                DiabetesPedigree           = string.Format(culture,"{0:N3}",this.DiabPedigree),
                EspessuraTriceps           = string.Format(culture,"{0:N0}",this.Triceps),
                GlicosePlasma              = string.Format(culture,"{0:N0}",this.PlasmaG),
                Gravidez                   = string.Format(culture,"{0:N0}",this.Gravidez),
                Idade                      = string.Format(culture,"{0:N0}",this.Idade),
                IdPaciente                 = "1882185",
                InsulinaSerica             = string.Format(culture,"{0:N0}",this.InsulinaSerica),
                PressaoSanguineaDiastolica = string.Format(culture,"{0:N0}",this.PressaoSangue)
            };
        }

        private void Popular()
        {
            BMI            = 27.36983156;
            DiabPedigree   = 1.350472047;
            Triceps        = 20.8;
            PlasmaG        = 104;
            Gravidez       = 9;
            Idade          = 43;
            InsulinaSerica = 24;
            PressaoSangue  = 51;
            VerificarNulo();
        }

        async Task ExecuteServicoCommand()
        {
            if (!IsBusy)
            {
                try
                {
                    IsBusy = true;
                    CriarInput();
                    var resposta = await MLService.Current.AcessarML(new Diabete
                    {
                        Inputs = new Inputs
                        {
                            Input1 = new Input1[] { Input1 }

                        }
                    });

                    await PushAsync<RespostaViewModel>(resposta);
                    LimparCampos();

                }
                catch (Exception ex)
                {
                    await DisplayAlert("Erro", $"Erro:{ex.Message}", "Ok");
                }
                finally
                {
                    IsBusy = false;
                }
            }
            return;
        }

        private void LimparCampos()
        {
            BMI            = null;
            DiabPedigree   = null;
            Triceps        = null;
            PlasmaG        = null;
            Gravidez       = null;
            Idade          = null;
            InsulinaSerica = null;
            PressaoSangue  = null;
        }

        private void VerificarNulo()
        {
            var t = GetType();

            foreach (var item in t.GetProperties())
            {
                
                if (item.GetValue(this, null) == null)
                    item.SetValue(this, 0.0, null);
            }
        }
    }
}