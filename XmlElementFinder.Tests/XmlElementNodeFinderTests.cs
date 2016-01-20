using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml;

namespace XmlElementFinder.Tests
{
	[TestClass]
	public class XmlElementNodeFinderTests
	{
		[TestMethod]
		public void SelectElement_FindsElement()
		{
			var document = new XmlDocument();
			document.LoadXml(sampleXml);
            var xpath = @"//*[contains(local-name(),'Response') and not(contains(local-name(),'Http'))]";

            var sut = new XmlElementNodeFinder(document);
            var node = sut.Find(xpath);
            Assert.IsNotNull(node);
            Assert.AreEqual("GetDataUsingDataContractResponse", node.Name);

		}
        [TestMethod]
        public void SelectElement_UpdateElement()
        {
            var document = new XmlDocument();
            var newValue = "new value";
            document.LoadXml(sampleXml);
            var xpath = @"//*[local-name()='StringValue']";
            var sut = new XmlElementNodeFinder(document);
            var node = sut.Find(xpath);
            node.InnerText = newValue;
            Assert.IsNotNull(newValue, sut.XmlDoc.SelectSingleNode(xpath).InnerText);

        }

        private const string sampleXml = @"<MessageLogTraceRecord Time='2016-01-20T11:19:08.2031258+13:00' Source='TransportSend' Type='System.ServiceModel.Dispatcher.OperationFormatter+OperationFormatterMessage' xmlns='http://schemas.microsoft.com/2004/06/ServiceModel/Management/MessageTrace'>
		<Addressing>
			<Action>http://tempuri.org/IService1/GetDataUsingDataContractResponse</Action>
		</Addressing>
		<s:Envelope xmlns:s='http://schemas.xmlsoap.org/soap/envelope/'>
			<s:HttpRequest>
				<ActivityId CorrelationId='8967e920-b617-42f7-b277-deb524c8a6e9' xmlns='http://schemas.microsoft.com/2004/09/ServiceModel/Diagnostics'>3fc9ca53-bcac-430a-93d0-3a7e1cb01bbc</ActivityId>
			</s:HttpRequest>
			<s:Body>
				<GetDataUsingDataContractResponse xmlns='http://tempuri.org/'>
					<GetDataUsingDataContractResult xmlns:a='http://schemas.datacontract.org/2004/07/WcfDemo' xmlns:i='http://www.w3.org/2001/XMLSchema-instance'>
						<a:BoolValue>true</a:BoolValue>
						<a:StringValue>MICHAELSuffix</a:StringValue>
					</GetDataUsingDataContractResult>
				</GetDataUsingDataContractResponse>
			</s:Body>
		</s:Envelope>
	</MessageLogTraceRecord>";
    }
}
