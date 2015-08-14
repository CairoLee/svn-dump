using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content.Pipeline;

namespace XNATerrainPipeline {

	internal static class AssemblyHelper {
		private readonly static string[] mAssemblySplitter;
		private readonly static string mWindowsPublicKeyTokens;
		private readonly static string mXboxPublicKeyTokens;


		static AssemblyHelper() {
			mWindowsPublicKeyTokens = "0c21691816f8c6d0";
			mXboxPublicKeyTokens = "121fbd51268a0405";
			mAssemblySplitter = new[]{
				","
			};
		}


		internal static string GetAssemblyPublicKey(TargetPlatform targetPlatform) {
			string str = "PublicKeyToken=";
			TargetPlatform targetPlatform1 = targetPlatform;
			if (targetPlatform1 == TargetPlatform.Windows) {
				str = string.Concat(str, AssemblyHelper.mWindowsPublicKeyTokens);
			} else if (targetPlatform1 == TargetPlatform.Xbox360) {
				str = string.Concat(str, AssemblyHelper.mXboxPublicKeyTokens);
			} else {
				throw new ArgumentException("targetPlatform");
			}
			return str;
		}

		internal static string GetRuntimeReader(Type type, TargetPlatform targetPlatform) {
			string fullName = type.FullName;
			string str = type.Assembly.FullName;
			string[] strArrays = str.Split(AssemblyHelper.mAssemblySplitter, StringSplitOptions.None);
			string[] assemblyPublicKey = new string[9];
			assemblyPublicKey[0] = fullName;
			assemblyPublicKey[1] = ", ";
			assemblyPublicKey[2] = strArrays[0];
			assemblyPublicKey[3] = ", ";
			assemblyPublicKey[4] = strArrays[1];
			assemblyPublicKey[5] = ", ";
			assemblyPublicKey[6] = strArrays[2];
			assemblyPublicKey[7] = ", ";
			assemblyPublicKey[8] = AssemblyHelper.GetAssemblyPublicKey(targetPlatform);
			return string.Concat(assemblyPublicKey);
		}
	}
}