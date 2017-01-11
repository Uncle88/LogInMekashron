using System;
using System.Collections.Generic;
using Xamarin.Forms.Xaml;
using Xamarin.Forms;

namespace LogInMekashron.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyUI : ContentPage
    {
        public MyUI()
        {
            InitializeComponent();
            //BindingContext = new MyUI();
        }
    }
}
