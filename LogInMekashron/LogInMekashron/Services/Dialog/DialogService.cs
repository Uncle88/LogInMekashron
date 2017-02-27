using Xamarin.Forms;
namespace LogInMekashron.Dialog
{
    public class DialogService : IDialogService
    {
        public void ShowMessage(string message)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                await Application.Current.MainPage.DisplayAlert("Message", message.ToUpper(), "OK");
            });
        }
    }
}