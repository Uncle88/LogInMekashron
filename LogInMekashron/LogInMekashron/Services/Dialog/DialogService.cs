using Xamarin.Forms;


namespace LogInMekashron.Dialog
{
    public class DialogService : IDialogService
    {
        public void ShowMessage(string Message)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                await Application.Current.MainPage.DisplayAlert("Message", Message.ToUpper(), "OK");
            });
        }
    }
}