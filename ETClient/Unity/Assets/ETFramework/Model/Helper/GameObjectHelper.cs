using System;
using UnityEngine;
namespace ETModel
{
	public static class GameObjectHelper
	{
		public static T Get<T>(this GameObject gameObject, string key) where T : class
		{
			try
			{
				return gameObject.GetComponent<ReferenceCollector>().Get<T>(key);
			}
			catch (Exception e)
			{
				throw new Exception($"获取{gameObject.name}的ReferenceCollector key失败, key: {key}", e);
			}
		}

		public static UnityEngine.Object[] GetAll<T>(this GameObject gameObject) where T : class
		{
			UnityEngine.Object[] gos = gameObject.GetComponent<ReferenceCollector>().GetAll<T>();
			// Debug.Log(gos.Length);
			return gos;
		}
	}
}