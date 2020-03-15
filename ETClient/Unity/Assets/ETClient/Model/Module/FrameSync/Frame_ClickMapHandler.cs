using ETModel;
using UnityEngine;

namespace ETModel
{
	[MessageHandler]
	public class Frame_ClickMapHandler : AMHandler<Frame_ClickMap>
	{
		protected override async ETTask Run(Session session, Frame_ClickMap message)
		{
			Unit unit = Game.Scene.GetComponent<UnitComponent>().Get(message.Id);
			FrameMoveComponent moveComponent = unit.GetComponent<FrameMoveComponent>();
			Vector3 dest = new Vector3(message.X / 1000f, 0, message.Z / 1000f);
			moveComponent.MoveToDest(dest, 1);
			moveComponent.Turn2D(dest - unit.Position);

			await ETTask.CompletedTask;
		}
	}
}
