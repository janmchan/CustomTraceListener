using System;
using System.Xml;

namespace FilteredTraceListener
{
    public class PiiObfuscator
    {
        public const string ObfuscateValue = "<!-- removed -->";
        public static object Obfuscate(object data)
        {
            try
            {
                XmlDocument xml = new XmlDocument();
                xml.LoadXml(data.ToString());
                var nsMgr = new XmlNamespaceManager(xml.NameTable);
                var listOfPii = PiiFinder.GetPiiFields(); //Replace this with fields you want to obfuscate.
                foreach (var pii in listOfPii)
                {
                    var xpath = $@"//*[local-name()='{pii}']";
                    var node = xml.SelectSingleNode(xpath, nsMgr);
                    if (node != null)
                        node.InnerXml = ObfuscateValue;
                }
                return xml.CreateNavigator();

            }
            catch (Exception ex)
            {
                InternalWrite(ex.ToString());
                return data;
            }

        }
        
        private static void InternalWrite(string message)
        {
            var fileName = "loggerException.txt";
            using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(fileName, true))
            {
                file.WriteLine(message);
            }
        }
    }
}
