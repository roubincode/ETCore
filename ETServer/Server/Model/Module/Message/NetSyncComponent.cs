namespace ETModel
{
    public enum SyncType
	{
		State,
		Frame,
	}

	[ObjectSystem]
	public class NetSyncComponentAwakeSystem : AwakeSystem<NetSyncComponent, SyncType>
	{
		public override void Awake(NetSyncComponent self, SyncType syncType)
		{
			self.Awake(syncType);
		}
	}
    
    public class NetSyncComponent : Component
	{
		public SyncType type {get;set;}

        public void Awake(SyncType syncType)
		{
            this.type = syncType;

#if SERVER
			if(this.type == SyncType.Frame){
				// frameSync 帧同步组件
				Game.Scene.AddComponent<ServerFrameComponent>();
			}else if(this.type == SyncType.State){
				// stateSync 状态同步寻路组件
				Game.Scene.AddComponent<PathfindingComponent>();
			}
#else
			if(this.type == SyncType.Frame){
				// frameSync 帧同步组件
				Game.Scene.AddComponent<ClientFrameComponent>();
			}
#endif
			
        }

	}
}