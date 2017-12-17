using System;
namespace LogInMekashron
{
    public class Constants
    {
        public const string PopUpMessageTitle = "Message";
        public const string ButtonComplete = "OK";

        public const string Url = "http://isapi.mekashron.com/StartAJob/General.dll/soap/ILogin";
        public const string mediaType = "application/xml";

        public const string nameContentValidation = "Content-Type";
        public const string valueContentValidation = "text/xml;charset=utf-8";

        public const string nameContentValidation2 = "SOAPAction";
        public const string valueContentValidation2 = "urn:General.Intf-IGeneral";
    }
}
