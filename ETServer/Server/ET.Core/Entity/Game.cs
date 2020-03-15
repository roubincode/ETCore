#if !Server
using UnityEngine;
#endif
namespace ETModel
{
	public static class Game
	{
		private static EventSystem eventSystem;

		public static EventSystem EventSystem
		{
			get
			{
				return eventSystem ?? (eventSystem = new EventSystem());
			}
		}
		
		private static Scene scene;

		public static Scene Scene
		{
			get
			{
				if (scene != null)
				{
					return scene;
				}
				#if Server
				scene = new Scene();
				#else
				scene = new Scene() { Name = "ClientM" };
				#endif
				
				return scene;
			}
		}

		private static ObjectPool objectPool;

		public static ObjectPool ObjectPool
		{
			get
			{
				if (objectPool != null)
				{
					return objectPool;
				}
				#if Server
				objectPool = new ObjectPool();
				#else
				objectPool = new ObjectPool() { Name = "ClientM" };
				#endif
				
				return objectPool;
			}
		}
#if Server
		private static Hotfix hotfix;

		public static Hotfix Hotfix
		{
			get
			{
				return hotfix ?? (hotfix = new Hotfix());
			}
		}
#endif

		public static void Close()
		{
			scene?.Dispose();
			scene = null;
			
			objectPool?.Dispose();
			objectPool = null;
			
			#if Server
			hotfix = null;
			#endif
			
			eventSystem = null;
		}
	}
}