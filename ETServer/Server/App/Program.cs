using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using ETModel;
using NLog;

namespace App
{
	internal static class Program
	{
		private static void Main(string[] args)
		{
			// 异步方法全部会回掉到主线程
			SynchronizationContext.SetSynchronizationContext(OneThreadSynchronizationContext.Instance);
			
			try
			{			
				Game.EventSystem.Add(DLLType.Core, typeof(Game).Assembly);
				Game.EventSystem.Add(DLLType.Hotfix, DllHelper.GetHotfixAssembly());

				Options options = Game.Scene.AddComponent<OptionComponent, string[]>(args).Options;
				StartConfig startConfig = Game.Scene.AddComponent<StartConfigComponent, string, int>(options.Config, options.AppId).StartConfig;

				if (!options.AppType.Is(startConfig.AppType))
				{
					Log.Error("命令行参数apptype与配置不一致");
					return;
				}

				IdGenerater.AppId = options.AppId;

				LogManager.Configuration.Variables["appType"] = startConfig.AppType.ToString();
				LogManager.Configuration.Variables["appId"] = startConfig.AppId.ToString();
				LogManager.Configuration.Variables["appTypeFormat"] = $"{startConfig.AppType,-8}";
				LogManager.Configuration.Variables["appIdFormat"] = $"{startConfig.AppId:D3}";

				Log.Info($"server start........................ {startConfig.AppId} {startConfig.AppType}");

				Game.Scene.AddComponent<OpcodeTypeComponent>();
				Game.Scene.AddComponent<MessageDispatherComponent>();

				// 根据不同的AppType添加不同的组件
				OuterConfig outerConfig = startConfig.GetComponent<OuterConfig>();
				InnerConfig innerConfig = startConfig.GetComponent<InnerConfig>();
				ClientConfig clientConfig = startConfig.GetComponent<ClientConfig>();
				
				switch (startConfig.AppType)
				{
					case AppType.AllServer:
						Game.Scene.AddComponent<ActorMessageSenderComponent>();
						Game.Scene.AddComponent<ActorLocationSenderComponent>();

						Game.Scene.AddComponent<PlayerComponent>();
						Game.Scene.AddComponent<UnitComponent>();

						Game.Scene.AddComponent<LocationComponent>();
						Game.Scene.AddComponent<ActorMessageDispatherComponent>();

						Game.Scene.AddComponent<NetInnerComponent, string>(innerConfig.Address);
						Game.Scene.AddComponent<NetOuterComponent, string>(outerConfig.Address);

						Game.Scene.AddComponent<LocationProxyComponent>();
						Game.Scene.AddComponent<AppManagerComponent>();
						Game.Scene.AddComponent<RealmGateAddressComponent>();
						Game.Scene.AddComponent<GateSessionKeyComponent>();
						Game.Scene.AddComponent<ConfigComponent>();
						Game.Scene.AddComponent<ServerFrameComponent>();
						break;
					default:
						throw new Exception($"命令行参数没有设置正确的AppType: {startConfig.AppType}");
				}

				while (true)
				{
					try
					{
						Thread.Sleep(1);
						OneThreadSynchronizationContext.Instance.Update();
						Game.EventSystem.Update();
					}
					catch (Exception e)
					{
						Log.Error(e);
					}
				}
			}
			catch (Exception e)
			{
				Log.Error(e);
			}
		}
	}
}
