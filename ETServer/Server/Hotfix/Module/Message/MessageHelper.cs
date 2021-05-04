using ETModel;

namespace ETHotfix
{
	public static class MessageHelper
	{
		public static void Broadcast(IActorMessage message)
		{
			Unit[] units = Game.Scene.GetComponent<UnitComponent>().GetAll();
			ActorMessageSenderComponent actorLocationSenderComponent = Game.Scene.GetComponent<ActorMessageSenderComponent>();
			foreach (Unit unit in units)
			{
				ActorMessageSender actorMessageSender = actorLocationSenderComponent.Get(unit.player.GActorId);
				actorMessageSender.Send(message);
			}
		}
	}
}
