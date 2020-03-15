using System;
using System.IO;
using UnityEngine;

namespace ETModel
{
    public static class ClientConfigHelper 
    {
        public static void SetConfigHelper(){
            ConfigHelper.SetHelper(GetText,GetGlobal);
        }
        public static string GetText(string key)
        {
            try
            {
                GameObject config = (GameObject)Game.Scene.GetComponent<ResourcesComponent>().GetAsset("config.unity3d", "Config");
                string configStr = config.Get<TextAsset>(key).text;
                return configStr;
            }
            catch (Exception e)
            {
                throw new Exception($"load config file fail, key: {key}", e);
            }
        }
        
        public static string GetGlobal()
        {
            try
            {
                GameObject config = (GameObject)ResourcesHelper.Load("KV");
                string configStr = config.Get<TextAsset>("GlobalProto").text;
                return configStr;
            }
            catch (Exception e)
            {
                throw new Exception($"load global config file fail", e);
            }
        }
        
    }
}