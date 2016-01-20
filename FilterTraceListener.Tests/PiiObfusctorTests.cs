using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FilteredTraceListener;
using System.Xml;
using System.Xml.XPath;

namespace FilterTraceListener.Tests
{
    [TestClass]
    public class PiiObfusctorTests
    {
        [TestMethod]
        public void Obfuscate_RemovesPiiFileds()
        {
            var result = PiiObfuscator.Obfuscate(sampleXml);
            XmlDocument xml = new XmlDocument();
            var nav = result as XPathNavigator;
            xml.LoadXml(nav.OuterXml);
            var nsMgr = new XmlNamespaceManager(xml.NameTable);
            var xpath = $@"//*[local-name()='SubjectLocality']";
            var node = xml.SelectSingleNode(xpath, nsMgr);
            Assert.AreEqual(PiiObfuscator.ObfuscateValue, node.InnerXml);
        }

        private const string sampleXml = @"<MessageLogTraceRecord Time='2016-01-20T11:19:08.2031258+13:00' Source='TransportSend' Type='System.ServiceModel.Dispatcher.OperationFormatter+OperationFormatterMessage' xmlns='http://schemas.microsoft.com/2004/06/ServiceModel/Management/MessageTrace'>
		<Addressing>
			<Action>http://tempuri.org/IService1/GetDataUsingDataContractResponse</Action>
		</Addressing>
		<s:Envelope xmlns:s='http://schemas.xmlsoap.org/soap/envelope/'>
			<s:Header>
				<ActivityId CorrelationId='8967e920-b617-42f7-b277-deb524c8a6e9' xmlns='http://schemas.microsoft.com/2004/09/ServiceModel/Diagnostics'>3fc9ca53-bcac-430a-93d0-3a7e1cb01bbc</ActivityId>
			</s:Header>
			<s:Body>
				<GetDataUsingDataContractResponse xmlns='http://tempuri.org/'>
					<GetDataUsingDataContractResult xmlns:a='http://schemas.datacontract.org/2004/07/WcfDemo' xmlns:i='http://www.w3.org/2001/XMLSchema-instance'>
						<a:BoolValue>true</a:BoolValue>
						<a:SubjectLocality>SensitiveInformation</a:SubjectLocality>
					</GetDataUsingDataContractResult>
				</GetDataUsingDataContractResponse>
			</s:Body>
		</s:Envelope>
	</MessageLogTraceRecord>";
    }
}
