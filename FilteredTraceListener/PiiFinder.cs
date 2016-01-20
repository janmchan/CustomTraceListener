using System;
using System.Collections.Generic;
using System.Reflection;

namespace FilteredTraceListener
{
    public class PiiFinder
    {
        private const string SMDIAGNOSTICSASSEMBLY = "SMDiagnostics, Version=4.0.4.0, Culture=neutral, PublicKeyToken=b77a5c561934e089";
        private const string DIAGNOSTICSTRINGSCLASS = "System.ServiceModel.Diagnostics.DiagnosticStrings";
        private const string PIINODESLIST = "PiiList";
        /// <summary>
        /// Default PII. In a real project you would find Pii attribute in your own contract assembly
        /// </summary>
        /// <returns></returns>
        public static List<string> GetPiiFields()
        {
            Assembly smDiagnosticsAssembly = Assembly.Load(SMDIAGNOSTICSASSEMBLY);
            Type diagnosticsStringsType = smDiagnosticsAssembly.GetType(DIAGNOSTICSTRINGSCLASS, false, true);

            FieldInfo PiiListField = diagnosticsStringsType.GetField(PIINODESLIST, BindingFlags.NonPublic | BindingFlags.Static);

            List<string> newPiiList = new List<string>((string[])PiiListField.GetValue(null));
            return newPiiList;
        }
    }
}
