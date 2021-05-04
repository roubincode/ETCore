using System;
using ETModel;

namespace ETHotfix
{
	[MessageHandler(AppType.DB)]
	public class DBSaveRequestHandler : AMRpcHandler<DBSaveRequest, DBSaveResponse>
	{
		protected override async ETTask Run(Session session, DBSaveRequest request, DBSaveResponse response,Action reply)
		{
			try
			{
				DBCacheComponent dbCacheComponent = Game.Scene.GetComponent<DBCacheComponent>();
				if (string.IsNullOrEmpty(request.CollectionName))
				{
					request.CollectionName = request.Component.GetType().Name;
				}

				if (request.NeedCache)
				{
					dbCacheComponent.AddToCache(request.Component, request.CollectionName);
				}
				await dbCacheComponent.Add(request.Component, request.CollectionName);
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