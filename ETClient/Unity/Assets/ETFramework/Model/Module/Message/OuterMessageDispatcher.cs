﻿namespace ETModel
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
			 
			// 如果是帧同步消息,交给ClientFrameComponent处理
			// FrameMessage frameMessage = message as FrameMessage;
			// if (frameMessage != null)
			// {
			// 	Game.Scene.GetComponent<ClientFrameComponent>().Add(session, frameMessage);
			// 	return;
			// }
			 
			// 普通消息或者是Rpc请求消息
			MessageInfo messageInfo = new MessageInfo(opcode, message);
			Game.Scene.GetComponent<MessageDispatcherComponent>().Handle(session, messageInfo);
			await ETTask.CompletedTask;
		}
	}
}
