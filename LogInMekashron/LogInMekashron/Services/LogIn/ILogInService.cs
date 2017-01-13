using System;

using Xamarin.Forms;

namespace LogInMekashron.LogIn
{
    public class ILogInService : ContentPage
    {
        public ILogInService()
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

