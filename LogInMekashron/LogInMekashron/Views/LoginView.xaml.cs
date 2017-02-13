using LogInMekashron.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LogInMekashron.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class LoginView : ContentPage
    {
        public LoginView()
        {
            InitializeComponent();
            BindingContext = new LoginViewModel();
        }
    }
}
