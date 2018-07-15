using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DBHTec.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FormPage : ContentPage
	{
		public FormPage ()
		{
			InitializeComponent ();
            BindingContext = new ViewModels.FormViewModel();
		}
	}
}