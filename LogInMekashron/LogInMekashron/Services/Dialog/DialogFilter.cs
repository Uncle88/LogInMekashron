using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using LogInMekashron.Services;
using System.Xml.Linq;
using System.Linq;



namespace LogInMekashron.Dialog
{
    public class DialogFilter
    {
        public DialogFilter() { }

        public string LinqFilter(XDocument soap)
        {
            string Message = (from article in soap.Descendants("article")
                              select new
                              {
                                  message = article.Descendants("ResultMessage").SingleOrDefault()
                              }).ToString();//_dialogService.DisplayAlert("Message", Message, "OK");//
            return Message;
        }
    }
}

