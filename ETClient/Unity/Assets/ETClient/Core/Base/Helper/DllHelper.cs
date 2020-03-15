using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace ETModel
{
	public static class DllHelper
	{
		public static Assembly GetHotfixAssembly()
		{
			byte[] dllBytes = File.ReadAllBytes("./ETServer.Hotfix.dll");
			byte[] pdbBytes = File.ReadAllBytes("./ETServer.Hotfix.pdb");
			Assembly assembly = Assembly.Load(dllBytes, pdbBytes);
			return assembly;
		}
	}
}
