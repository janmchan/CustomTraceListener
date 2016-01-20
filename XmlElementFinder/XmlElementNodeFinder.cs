using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XmlElementFinder
{
    /// <summary>
    /// This project is just to test if Xpath queries I used are working.
    /// </summary>
    public class XmlElementNodeFinder
    {
        public XmlDocument XmlDoc { get; set; }
        public XmlElementNodeFinder(XmlDocument xmlDoc)
        {
            this.XmlDoc = xmlDoc;
        }

        public XmlNode Find(string xpath, XmlNamespaceManager mgr)
        {
            return XmlDoc.SelectSingleNode(xpath, mgr);
        }
        public XmlNode Find(string xpath)
        {
            return XmlDoc.SelectSingleNode(xpath);
        }
    }
}
