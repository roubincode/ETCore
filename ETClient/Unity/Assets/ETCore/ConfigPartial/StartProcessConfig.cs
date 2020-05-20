#if SERVER
using System.ComponentModel;
namespace ET
{
	public partial class StartProcessConfigCategory
	{
		public override void EndInit()
		{
		}
	}
	
	public partial class StartProcessConfig: ISupportInitialize
	{
		public string InnerAddress;
		public string OuterAddress;

		public void BeginInit()
		{
		}

		public void EndInit()
		{
			this.InnerAddress = $"{this.InnerIP}:{this.InnerPort}";
			this.OuterAddress = $"{this.OuterIP}:{this.OuterPort}";
		}
	}
}
#endif