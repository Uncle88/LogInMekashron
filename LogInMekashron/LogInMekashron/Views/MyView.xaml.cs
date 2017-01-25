using System;
using System.Collections.Generic;
using Xamarin.Forms.Xaml;
using Xamarin.Forms;
using LogInMekashron.ViewModels;
using LogInMekashron.Services;

namespace LogInMekashron.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyView : ContentPage
    {
        public MyView()
        {
            InitializeComponent();
            BindingContext = new LogInViewModel();
        }
    }
}
