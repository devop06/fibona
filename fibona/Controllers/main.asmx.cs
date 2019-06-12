using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Web;
using System.Web.Services;
using System.Xml;

namespace fibona.Controllers
{
    /// <summary>
    /// Summary description for main
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class main : System.Web.Services.WebService
    {

        [WebMethod]
        public string XmlToJson(string xml)
        {
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.LoadXml(xml);
            }
            catch(XmlException exception)
            {
                throw new Exception(exception.Message);
            }
            return JsonConvert.SerializeXmlNode(doc);
        }

        [WebMethod]
        public int Fibonacci(int n)
        {
            if (n < 1 || n > 100)
                throw new Exception("-1, exception");
            int a = 0, b = 1;
            for (int i = 0; i < n; i++)
            {
                int c = a;
                a = b;
                b = c + b;
            }
            return a;
        }
    }
}
