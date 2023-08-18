using System.Windows.Forms;

namespace Organizador_de_Arquivos
{
    public class WebBrowserHelper
    {
        public static WebBrowser CreateWebBrowser()
        {
            WebBrowser webBrowser = new WebBrowser();
            webBrowser.ScriptErrorsSuppressed = true; // Para suprimir erros de script
            return webBrowser;
        }
    }
}
