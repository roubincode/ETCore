#if SERVER 
namespace ET
{
	[ObjectSystem]
	public class PlayerSystem : AwakeSystem<Player, string>
	{
		public override void Awake(Player self, string a)
		{
			self.Awake(a);
		}
	}

	public sealed class Player : Entity
	{
		public string Account { get; private set; }
		
		public long UnitId { get; set; }

		public void Awake(string account)
		{
			this.Account = account;
		}
	}
}
#else
namespace ET
{
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
#endif