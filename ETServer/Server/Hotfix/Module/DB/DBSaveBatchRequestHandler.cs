using System;
using ETModel;

namespace ETHotfix
{
	[MessageHandler(AppType.DB)]
	public class DBSaveBatchRequestHandler : AMRpcHandler<DBSaveBatchRequest, DBSaveBatchResponse>
	{
		protected override async ETTask Run(Session session, DBSaveBatchRequest request, DBSaveBatchResponse response,Action reply)
		{
			try
			{
				DBCacheComponent dbCacheComponent = Game.Scene.GetComponent<DBCacheComponent>();

				if (string.IsNullOrEmpty(request.CollectionName))
				{
					request.CollectionName = request.Components[0].GetType().Name;
				}

				if (request.NeedCache)
				{
					foreach (ComponentWithId component in request.Components)
					{
						dbCacheComponent.AddToCache(component, request.CollectionName);
					}
				}

				await dbCacheComponent.AddBatch(request.Components, request.CollectionName);

				reply();
				await ETTask.CompletedTask;
			}
			catch (Exception e)
			{
				ReplyError(response, e, reply);
			}
		}
	}
}
