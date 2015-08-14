using System.Reflection;
using System.Runtime.CompilerServices;

#if (!SSCLI)
//
// GodLesZ.Library.Logging makes use of static methods which cannot be made com visible
//
[assembly: System.Runtime.InteropServices.ComVisible(false)]
#endif

//
// GodLesZ.Library.Logging is CLS compliant
//
[assembly: System.CLSCompliant(true)]

#if (!NETCF)
//
// If GodLesZ.Library.Logging is strongly named it still allows partially trusted callers
//
[assembly: System.Security.AllowPartiallyTrustedCallers]
#endif

//
// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
//

#if (CLI_1_0)
[assembly: AssemblyTitle("Apache GodLesZ.Library.Logging for CLI 1.0 Compatible Frameworks")]
#elif (NET_1_0)
[assembly: AssemblyTitle("Apache GodLesZ.Library.Logging for .NET Framework 1.0")]
#elif (NET_1_1)
[assembly: AssemblyTitle("Apache GodLesZ.Library.Logging for .NET Framework 1.1")]
#elif (NET_4_0)
#if CLIENT_PROFILE
[assembly: AssemblyTitle("Apache GodLesZ.Library.Logging for .NET Framework 4.0 Client Profile")]
#else
[assembly: AssemblyTitle("Apache GodLesZ.Library.Logging for .NET Framework 4.0")]
#endif // Client Profile
#elif (NET_2_0)
#if CLIENT_PROFILE
[assembly: AssemblyTitle("Apache GodLesZ.Library.Logging for .NET Framework 3.5 Client Profile")]
#else
[assembly: AssemblyTitle("Apache GodLesZ.Library.Logging for .NET Framework 2.0")]
#endif // Client Profile
#elif (NETCF_1_0)
[assembly: AssemblyTitle("Apache GodLesZ.Library.Logging for .NET Compact Framework 1.0")]
#elif (NETCF_2_0)
[assembly: AssemblyTitle("Apache GodLesZ.Library.Logging for .NET Compact Framework 2.0")]
#elif (MONO_1_0)
[assembly: AssemblyTitle("Apache GodLesZ.Library.Logging for Mono 1.0")]
#elif (MONO_2_0)
[assembly: AssemblyTitle("Apache GodLesZ.Library.Logging for Mono 2.0")]
#elif (SSCLI_1_0)
[assembly: AssemblyTitle("Apache GodLesZ.Library.Logging for Shared Source CLI 1.0")]
#elif (CLI_1_0)
[assembly: AssemblyTitle("Apache GodLesZ.Library.Logging for CLI Compatible Frameworks")]
#elif (NET)
[assembly: AssemblyTitle("Apache GodLesZ.Library.Logging for .NET Framework")]
#elif (NETCF)
[assembly: AssemblyTitle("Apache GodLesZ.Library.Logging for .NET Compact Framework")]
#elif (MONO)
[assembly: AssemblyTitle("Apache GodLesZ.Library.Logging for Mono")]
#elif (SSCLI)
[assembly: AssemblyTitle("Apache GodLesZ.Library.Logging for Shared Source CLI")]
#else
[assembly: AssemblyTitle("Apache GodLesZ.Library.Logging")]
#endif

#if DEBUG
[assembly: AssemblyConfiguration("Debug")]
#else
[assembly: AssemblyConfiguration("Retail")]
#endif

[assembly: AssemblyProduct("GodLesZ.Library.Logging")]
[assembly: AssemblyDefaultAlias("GodLesZ.Library.Logging")]
[assembly: AssemblyCulture("")]		
		
//
// In order to sign your assembly you must specify a key to use. Refer to the 
// Microsoft .NET Framework documentation for more information on assembly signing.
//
// Use the attributes below to control which key is used for signing. 
//
// Notes: 
//   (*) If no key is specified, the assembly is not signed.
//   (*) KeyName refers to a key that has been installed in the Crypto Service
//       Provider (CSP) on your machine. KeyFile refers to a file which contains
//       a key.
//   (*) If the KeyFile and the KeyName values are both specified, the 
//       following processing occurs:
//       (1) If the KeyName can be found in the CSP, that key is used.
//       (2) If the KeyName does not exist and the KeyFile does exist, the key 
//           in the KeyFile is installed into the CSP and used.
//   (*) In order to create a KeyFile, you can use the sn.exe (Strong Name) utility.
//       When specifying the KeyFile, the location of the KeyFile should be
//       relative to the project output directory which is
//       %Project Directory%\obj\<configuration>. For example, if your KeyFile is
//       located in the project directory, you would specify the AssemblyKeyFile 
//       attribute as [assembly: AssemblyKeyFile("..\\..\\mykey.snk")]
//   (*) Delay Signing is an advanced option - see the Microsoft .NET Framework
//       documentation for more information on this.
//
#if STRONG && (CLI_1_0 || NET_1_0 || NET_1_1 || NETCF_1_0 || SSCLI)
[assembly: AssemblyDelaySign(false)]
[assembly: AssemblyKeyFile(@"..\..\..\GodLesZ.Library.Logging.snk")]
#endif
// We do not use a CSP key for strong naming
// [assembly: AssemblyKeyName("")]

