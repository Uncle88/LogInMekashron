using System;
using System.Linq;
using System.Xml.Linq;
using LogInMekashron.Model;
using Newtonsoft.Json;

namespace LogInMekashron.Helpers
{
    public static class DialogFilter
    {
        public static string LinqFilter(XDocument doc)
        {
            //1string Message = (from article in doc.Descendants("return")
            //select new
            //{
            //    message = article.Element("ResultMessage").SetValue();
            //}).ToString();
            //2doc.Descendants("return").FirstOrDefault().Value;
            string Message = doc.Root.Value;
            return Message;
        }
    }
}

