using System.Linq;
using System.Xml.Linq;

namespace LogInMekashron.Helpers
{
    public static class DialogFilter
    {
        public static string LinqFilter(XDocument doc)
        {
            string Message = (from article in doc.Descendants("article")
                              select new
                              {
                                  message = article.Descendants("ResultMessage").SingleOrDefault()
                              }).ToString();
            return Message;
        }
    }
}

