using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace ETModel
{
	[ObjectSystem]
	public class DBQuery2JsonTaskAwakeSystem : AwakeSystem<DBQuery2JsonTask, string, string, TaskCompletionSource<List<Component>>>
	{
		public override void Awake(DBQuery2JsonTask self, string collectionName, string json, TaskCompletionSource<List<Component>> tcs)
		{
			self.CollectionName = collectionName;
			self.Json = json;
			self.Tcs = tcs;
		}
	}

	public sealed class DBQuery2JsonTask : DBTask
	{
		public string CollectionName { get; set; }

		public string Json { get; set; }

		public TaskCompletionSource<List<Component>> Tcs { get; set; }
		
		public override async Task Run()
		{
			DBComponent dbComponent = Game.Scene.GetComponent<DBComponent>();
			try
			{
				// 执行查询数据库任务
				FilterDefinition<Component> filterDefinition = new JsonFilterDefinition<Component>(this.Json);
				IAsyncCursor<Component> cursor = await dbComponent.Get2Collection(this.CollectionName).FindAsync(filterDefinition);
				List<Component> components = await cursor.ToListAsync();
				this.Tcs.SetResult(components);
			}
			catch (Exception e)
			{
				this.Tcs.SetException(new Exception($"查询数据库异常! {CollectionName} {this.Json}", e));
			}
		}
	}
}