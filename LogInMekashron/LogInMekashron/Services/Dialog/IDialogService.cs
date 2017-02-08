using System; using System.Threading.Tasks; using System.Xml.Linq;
using Xamarin.Forms;  namespace LogInMekashron.Dialog {     interface IDialogService
    {         void ShowMessage(XDocument soap);     } } 
