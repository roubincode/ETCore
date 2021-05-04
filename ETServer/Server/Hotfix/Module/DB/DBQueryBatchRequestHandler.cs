using System;
using System.Collections.Generic;
using ETModel;

namespace ETHotfix
{
	[MessageHandler(AppType.DB)]
	public class DBQueryBatchRequestHandler : AMRpcHandler<DBQueryBatchRequest, DBQueryBatchResponse>
	{
		protected override async ETTask Run(Session session, DBQueryBatchRequest request,DBQueryBatchResponse response ,Action reply)
		{
			try
			{
				DBCacheComponent dbCacheComponent = Game.Scene.GetComponent<DBCacheComponent>();
				List<ComponentWithId> components = await dbCacheComponent.GetBatch(request.CollectionName, request.IdList);

				response.Components = components;

				if (request.NeedCache)
				{
					foreach (ComponentWithId component in components)
					{
						dbCacheComponent.AddToCache(component, request.CollectionName);
					}
				}

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