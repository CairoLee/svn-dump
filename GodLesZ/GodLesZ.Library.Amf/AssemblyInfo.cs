
using System.Reflection;

//
// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
//
#if (NET_1_1)
[assembly: AssemblyTitle("GodLesZ.Library.Amf for .NET Framework 1.1")]
#elif (NET_2_0)
[assembly: AssemblyTitle("GodLesZ.Library.Amf for .NET Framework 2.0")]
#elif (NET_3_5)
[assembly: AssemblyTitle("GodLesZ.Library.Amf for .NET Framework 3.5")]
#elif (NET_4_0)
[assembly: AssemblyTitle("GodLesZ.Library.Amf")]
#elif (MONO)
[assembly: AssemblyTitle("GodLesZ.Library.Amf for MONO 2.0")]
#else
[assembly: AssemblyTitle("GodLesZ.Library.Amf")]
#endif

#if DEBUG
[assembly: AssemblyDescription("GodLesZ.Library.Amf [Debug build]")]
#else
[assembly: AssemblyDescription("GodLesZ.Library.Amf [Retail]")]
#endif

#if DEBUG
[assembly: AssemblyConfiguration("Debug")]
#else
[assembly: AssemblyConfiguration("Retail")]
#endif
[assembly: AssemblyCompany("GodLesZ")]
[assembly: AssemblyProduct("GodLesZ.Library.Amf")]
[assembly: AssemblyCopyright("Copyright © 2012 GodLesZ")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
// Configure log4net using the .log4net file
[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config", Watch = true)]
// The config file will be watched for changes.
[assembly: System.Security.AllowPartiallyTrustedCallers()]
[assembly: System.CLSCompliant(true)]

#if (NET_4_0)
[assembly: System.Security.SecurityRules(System.Security.SecurityRuleSet.Level1)]
#endif
//
// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Revision and Build Numbers 
// by using the '*' as shown below:

[assembly: AssemblyVersion("1.0.0.0")]