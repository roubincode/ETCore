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
	public sealed class Player : Entity
	{
		
		public long UnitId { get; set; }

		public override void Dispose()
		{
			if (this.IsDisposed)
			{
				return;
			}

			base.Dispose();
		}
	}
}

