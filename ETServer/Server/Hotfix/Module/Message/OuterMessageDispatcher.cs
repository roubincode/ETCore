using ETModel;
using Google.Protobuf;
namespace ETHotfix
{
	public class OuterMessageDispatcher: IMessageDispatcher
	{
		public bool Dispatch(Session session, ushort opcode, object message)
		{
			DispatchAsync(session, opcode, message).Coroutine();
			return true;
		}
		
		public async ETVoid DispatchAsync(Session session, ushort opcode, object message)
		{
			// 根据消息接口判断是不是Actor消息，不同的接口做不同的处理
			switch (message)
			{
				case IFrameMessage iFrameMessage: // 如果是帧消息，构造成OneFrameMessage发给对应的unit
				{
					// ...
					return;
				}
				case IActorLocationRequest actorLocationRequest: // gate session收到actor rpc消息，先向actor 发送rpc请求，再将请求结果返回客户端
				{
					long unitId = session.GetComponent<SessionUserComponent>().User.UnitId;
					ActorLocationSender actorLocationSender = Game.Scene.GetComponent<ActorLocationSenderComponent>().Get(unitId);

					int rpcId = actorLocationRequest.RpcId; // 这里要保存客户端的rpcId
					long instanceId = session.InstanceId;
					IResponse response = await actorLocationSender.Call(actorLocationRequest);
					response.RpcId = rpcId;

					// session可能已经断开了，所以这里需要判断
					if (session.InstanceId == instanceId)
					{
						session.Reply(response);
					}
					
					break;
				}
				case IActorLocationMessage actorLocationMessage:
				{
					long unitId = session.GetComponent<SessionUserComponent>().User.UnitId;
					ActorLocationSender actorLocationSender = Game.Scene.GetComponent<ActorLocationSenderComponent>().Get(unitId);
					actorLocationSender.Send(actorLocationMessage);
					break;
				}
				case IActorRequest iActorRequest: 
				{
					long actorId = session.GetComponent<SessionUserComponent>().User.ActorId;
					ActorMessageSender actorMessageSender = Game.Scene.GetComponent<ActorMessageSenderComponent>().Get(actorId);

					int rpcId = iActorRequest.RpcId; // 这里要保存客户端的rpcId
					IResponse response = await actorMessageSender.Call(iActorRequest);
					response.RpcId = rpcId;

					session.Reply(response);
					return;
				}
				case IActorMessage iActorMessage: 
				{
					long actorId = session.GetComponent<SessionUserComponent>().User.ActorId;
					ActorMessageSender actorMessageSender = Game.Scene.GetComponent<ActorMessageSenderComponent>().Get(actorId);
					actorMessageSender.Send(iActorMessage);
					return;
				}
				default:
				{
					// 非Actor消息
					Game.Scene.GetComponent<MessageDispatcherComponent>().Handle(session, new MessageInfo(opcode, message));
					break;
				}
			}
		}
	}
}
