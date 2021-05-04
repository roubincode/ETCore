namespace ETModel
{
#if SERVER
	[ObjectSystem]
	public class PlayerAwakeSystem : AwakeSystem<Player, string>
	{
		public override void Awake(Player self, string a)
		{
			self.Awake(a);
		}
	}

	public static class PlayerEx 
	{
		public static string Account { get; private set; }
		public static void Awake(this Player self,string account)
		{
			Account = account;
		}
		
	}
#endif	
	public partial class Player : Entity
	{
		
		public long UnitId { get; set; }
		public long ActorID { get; set; }

		/// 玩家GateActorId,是网关User的实例id
        public long GActorId { get; set; }

        /// 玩家ClientActorId,是网关session的实例id
        public long CActorId { get; set; }

		/// 角色目标
		public Entity target { get; set; }
		public Entity nextTarget { get; set; }
        
        /// <summary>
        /// 默认为假 Session断开/离开房间时触发离线
        /// </summary>
        public bool isOffline { get; set; }
	}
}

