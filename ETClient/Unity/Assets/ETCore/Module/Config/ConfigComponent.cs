using System;
using System.Collections.Generic;

namespace ET
{
    /// <summary>
    /// Config组件会扫描所有的有ConfigAttribute标签的配置,加载进来
    /// </summary>
    public class ConfigComponent: Entity
    {
        public static ConfigComponent Instance;
		
        public Dictionary<Type, ACategory> AllConfig = new Dictionary<Type, ACategory>();
    }
#if !SERVER
	[ObjectSystem]
    public class ConfigAwakeSystem : AwakeSystem<ConfigComponent>
    {
        public override void Awake(ConfigComponent self)
        {
	        ConfigComponent.Instance = self;
            self.Awake();
        }
    }

    [ObjectSystem]
    public class ConfigLoadSystem : LoadSystem<ConfigComponent>
    {
        public override void Load(ConfigComponent self)
        {
            self.Load();
        }
    }
    
    [ObjectSystem]
    public class ConfigDestroySystem : DestroySystem<ConfigComponent>
    {
	    public override void Destroy(ConfigComponent self)
	    {
		    ConfigComponent.Instance = null;
	    }
    }
    
    public static class ConfigComponentSystem
	{
		public static void Awake(this ConfigComponent self)
		{
			self.Load();
		}

		public static IConfig Get(this ConfigComponent self,Type type,int id){
			if (!self.AllConfig.TryGetValue(type, out ACategory configCategory))
			{
				throw new Exception($"ConfigComponent not found key: {type.FullName}");
			}
			return configCategory.TryGet(id);
		}

		public static void Load(this ConfigComponent self)
		{
			self.AllConfig.Clear();
			HashSet<Type> types = Game.EventSystem.GetTypes(typeof(ConfigAttribute));

			foreach (Type type in types)
			{
				object obj = Activator.CreateInstance(type);

				ACategory iCategory = obj as ACategory;
				if (iCategory == null)
				{
					throw new Exception($"class: {type.Name} not inherit from ACategory");
				}
				iCategory.BeginInit();
				iCategory.EndInit();

				self.AllConfig[iCategory.ConfigType] = iCategory;
			}
		}

		
	}
#endif
}