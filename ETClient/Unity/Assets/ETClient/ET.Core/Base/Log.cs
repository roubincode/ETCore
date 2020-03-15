using System;

namespace ETModel
{
	public static class Log
	{
#if SERVER
		private static readonly ILog globalLog = new NLogAdapter();

		public static void Trace(string message)
		{
			globalLog.Trace(message);
		}

		public static void Warning(string message)
		{
			globalLog.Warning(message);
		}

		public static void Info(string message)
		{
			globalLog.Info(message);
		}

		public static void Debug(string message)
		{
			globalLog.Debug(message);
		}

		public static void Error(Exception e)
		{
			globalLog.Error(e.ToString());
		}

		public static void Error(string message)
		{
			globalLog.Error(message);
		}

        public static void Fatal(Exception e)
        {
            globalLog.Fatal(e.ToString());
        }

        public static void Fatal(string message)
        {
            globalLog.Fatal(message);
        }

		public static void Msg(object message)
		{
			globalLog.Debug(MongoHelper.ToJson(message));
		}
#else
		public static void Trace(string msg)
		{
			UnityEngine.Debug.Log(msg);
		}
		
		public static void Debug(string msg)
		{
			UnityEngine.Debug.Log(msg);
		}
		
		public static void Info(string msg)
		{
			UnityEngine.Debug.Log(msg);
		}

		public static void Warning(string msg)
		{
			UnityEngine.Debug.LogWarning(msg);
		}

		public static void Error(string msg)
		{
			UnityEngine.Debug.LogError(msg);
		}
		
		public static void Error(Exception e)
		{
			UnityEngine.Debug.LogException(e);
		}

		public static void Fatal(string msg)
		{
			UnityEngine.Debug.LogAssertion(msg);
		}

		public static void Trace(string message, params object[] args)
		{
			UnityEngine.Debug.LogFormat(message, args);
		}

		public static void Warning(string message, params object[] args)
		{
			UnityEngine.Debug.LogWarningFormat(message, args);
		}

		public static void Info(string message, params object[] args)
		{
			UnityEngine.Debug.LogFormat(message, args);
		}

		public static void Debug(string message, params object[] args)
		{
			UnityEngine.Debug.LogFormat(message, args);
		}

		public static void Error(string message, params object[] args)
		{
			UnityEngine.Debug.LogErrorFormat(message, args);
		}

		public static void Fatal(string message, params object[] args)
		{
			UnityEngine.Debug.LogAssertionFormat(message, args);
		}

		public static void Msg(object msg)
		{
			Debug(Dumper.DumpAsString(msg));
		}
#endif
    }
}
