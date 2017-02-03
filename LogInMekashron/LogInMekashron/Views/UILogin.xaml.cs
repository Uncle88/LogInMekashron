using System;
using System.Collections.Generic;
using Xamarin.Forms.Xaml;
using Xamarin.Forms;
using LogInMekashron.ViewModels;
using LogInMekashron.Services;

namespace LogInMekashron.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UILogin : ContentPage
    {
        public UILogin()
        {
            InitializeComponent();
            BindingContext = new LogInViewModel();
        }

        //async void OnAlertSimpleClicked(object sender, EventArgs e)
        //{
        //    await DisplayAlert("Message","message" , "OK");
        //}
    }
}
