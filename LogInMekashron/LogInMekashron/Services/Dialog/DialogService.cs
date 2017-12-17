using Xamarin.Forms;
namespace LogInMekashron.Dialog
{
    public class DialogService : IDialogService
    {
        public void ShowMessage(string message)
        {
            DependencyService.Get<IDialogService>().ShowMessage(message);
        }
    }
}
