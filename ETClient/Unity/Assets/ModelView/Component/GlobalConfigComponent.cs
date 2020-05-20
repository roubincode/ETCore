using UnityEngine;
namespace ET
{
	[ObjectSystem]
    public class GlobalConfigComponentAwakeSystem : AwakeSystem<GlobalConfigComponent>
    {
        public override void Awake(GlobalConfigComponent self)
        {
            self.Awake();
            
        }
    }
	
	public class GlobalConfigComponent : Entity
	{
		public static GlobalConfigComponent Instance;
		public GlobalProto GlobalProto;

        public void Awake()
		{
			Instance = this;
			GameObject config = (GameObject)ResourcesHelper.Load("KV");
            string configStr = config.Get<TextAsset>("GlobalProto").text;
            this.GlobalProto = JsonHelper.FromJson<GlobalProto>(configStr);
		}
	}
}