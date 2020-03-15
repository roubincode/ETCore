using System;
using System.IO;
using UnityEngine;

namespace ETModel
{
    public static class ConfigHelper 
    {
        public  delegate string GT(string key);
        public  delegate string GG();

        public static GT gText;
        public static GG gGlobal;

        public static void SetHelper(GT a,GG b){
            gText = a;
			gGlobal = b;
        }
        
#if SERVER
        public static string GetText(string key)
		{
			string path = $"../Config/{key}.txt";
			try
			{
				string configStr = File.ReadAllText(path);
				return configStr;
			}
			catch (Exception e)
			{
				throw new Exception($"load config file fail, path: {path} {e}");
			}
		}
        public static T ToObject<T>(string str)
		{
			return MongoHelper.FromJson<T>(str);
		}
#else
        public static string GetText(string key)
        {
            return gText(key);
        }
        
        public static string GetGlobal()
        {
            return gGlobal();
        }
        public static T ToObject<T>(string str)
        {
            return JsonHelper.FromJson<T>(str);
        }
#endif
        
    }
}