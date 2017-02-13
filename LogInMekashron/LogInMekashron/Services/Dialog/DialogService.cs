using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using LogInMekashron.Services;
using System.Xml.Linq;
using System.Linq;


namespace LogInMekashron.Dialog
{
    public class DialogService : IDialogService
    {
        //DialogFilter _dialogFilter;

        public DialogService() { }

        public void ShowMessage(XDocument doc)
        {
            // _dialogFilter.LinqFilter(doc);
        }
    }
}