using ETModel;
using Vector3 = UnityEngine.Vector3;

namespace ETModel
{
	[MessageHandler]
	public class M2C_CreateUnitsHandler : AMHandler<M2C_CreateUnits>
	{
		protected override async ETTask Run(ETModel.Session session, M2C_CreateUnits message)
		{	
			UnitComponent unitComponent = ETModel.Game.Scene.GetComponent<UnitComponent>();
			
			foreach (UnitInfo unitInfo in message.Units)
			{
				if (unitComponent.Get(unitInfo.UnitId) != null)
				{
					continue;
				}
				Unit unit = UnitFactory.Create(unitInfo.UnitId);
				unit.Position = new Vector3(unitInfo.X, unitInfo.Y, unitInfo.Z);

				SyncType type = Game.Scene.GetComponent<NetSyncComponent>().type;
				if(type == SyncType.Frame){
					if (PlayerComponent.Instance.MyPlayer.UnitId == unit.Id)
					{
						Game.Scene.GetComponent<CameraComponent>().Unit = unit;
					}
				}

			}

			await ETTask.CompletedTask;
		}
	}
}
