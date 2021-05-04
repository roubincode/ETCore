using System;
using ETModel;

namespace ETHotfix
{
	[MessageHandler(AppType.DB)]
	public class DBQueryRequestHandler : AMRpcHandler<DBQueryRequest, DBQueryResponse>
	{
		protected override async ETTask Run(Session session, DBQueryRequest request,DBQueryResponse response ,Action reply)
		{
			try
			{
				DBCacheComponent dbCacheComponent = Game.Scene.GetComponent<DBCacheComponent>();
				ComponentWithId component = await dbCacheComponent.Get(request.CollectionName, request.Id);

				response.Component = component;

				if (request.NeedCache && component != null)
				{
					dbCacheComponent.AddToCache(component, request.CollectionName);
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