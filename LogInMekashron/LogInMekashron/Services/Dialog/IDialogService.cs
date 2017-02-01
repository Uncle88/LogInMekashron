using System;

using Xamarin.Forms;

namespace LogInMekashron.Dialog
{
    public class IDialogService : ContentPage
    {
        public IDialogService()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

