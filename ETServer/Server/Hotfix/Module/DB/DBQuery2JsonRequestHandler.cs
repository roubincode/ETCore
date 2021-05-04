using System;
using System.Collections.Generic;
using ETModel;

namespace ETHotfix
{
	[MessageHandler(AppType.DB)]
	public class DBQuery2JsonRequestHandler : AMRpcHandler<DBQuery2JsonRequest, DBQuery2JsonResponse>
	{
		protected override async ETTask Run(Session session, DBQuery2JsonRequest request, DBQuery2JsonResponse response,Action reply)
		{
			try
			{
				DBCacheComponent dbCacheComponent = Game.Scene.GetComponent<DBCacheComponent>();
				List<Component> components = await dbCacheComponent.Get2Json(request.CollectionName, request.Json);
				response.Components = components;

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