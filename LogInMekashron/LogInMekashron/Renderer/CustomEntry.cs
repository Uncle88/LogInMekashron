using System;
using Xamarin.Forms;

namespace LogInMekashron.Renderer
{
    public class CustomEntry : Entry
    {
        //public bool IsEmpty { get; set; }
        public static readonly BindableProperty IsEmptyProperty =
            BindableProperty.Create(nameof(IsEmpty), typeof(bool), typeof(CustomEntry), false);

        public bool IsEmpty
        {
            get { return (bool)GetValue(IsEmptyProperty); }
            set { SetValue(IsEmptyProperty, value); }
        }
    }
}
