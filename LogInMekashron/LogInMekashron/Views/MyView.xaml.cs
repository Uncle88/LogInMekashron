using System;
using System.Collections.Generic;
using Xamarin.Forms.Xaml;
using Xamarin.Forms;

namespace LogInMekashron.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyView : ContentPage
    {
        public MyView()
        {
            InitializeComponent();
            //BindingContext = new MyUI();
        }
    }
}
