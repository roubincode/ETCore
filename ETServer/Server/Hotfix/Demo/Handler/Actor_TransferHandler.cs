using System;
using System.Net;


namespace ET
{
	[ActorMessageHandler]
	public class Actor_TransferHandler : AMActorRpcHandler<Unit, Actor_TransferRequest, Actor_TransferResponse>
	{
		protected override async ETTask Run(Unit unit, Actor_TransferRequest request, Actor_TransferResponse response, Action reply)
		{
			//..
			reply();

			await ETTask.CompletedTask;
		}
	}
}