using Xamarin.Forms;
namespace LogInMekashron.Dialog
{
    public class DialogService : IDialogService
    {
        public void ShowMessage(string message)
        {
            DependencyService.Get<IDialogService>().ShowMessage(message);

            //Device.BeginInvokeOnMainThread(async () =>
            //{
            //    await Application.Current.MainPage.DisplayAlert(Constants.PopUpMessageTitle, message.ToUpper(), Constants.ButtonComplete);
            //});
        }
    }
}
