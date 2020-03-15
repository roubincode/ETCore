using System;
using System.IO;
using System.Threading;
using Google.Protobuf;
using UnityEngine;
using UnityEngine.UI;
using System.Net;
using System.Net.Sockets;

namespace ETModel
{
	public class Init : MonoBehaviour
	{
        public static Init Instance;

        public InputField pname;
        public InputField password;
        public Button loginBut;
        public Button enterMap;

        GameObject uiLogin;
        GameObject uiLobby;

        private async void Start()
        {
            try
            {
                // ==> 加载程序集
                SynchronizationContext.SetSynchronizationContext(OneThreadSynchronizationContext.Instance);

				DontDestroyOnLoad(gameObject);
                ClientConfigHelper.SetConfigHelper();
                Game.EventSystem.Add(DLLType.Core, typeof(Core).Assembly);
				Game.EventSystem.Add(DLLType.Model, typeof(Init).Assembly);
                
                Game.Scene.AddComponent<GlobalConfigComponent>();
                Game.Scene.AddComponent<ResourcesComponent>();

                // ==> 网络组件
                Game.Scene.AddComponent<NetOuterComponent>();
                Game.Scene.AddComponent<PlayerComponent>();
				Game.Scene.AddComponent<UnitComponent>();
                
                Game.Scene.AddComponent<OpcodeTypeComponent>();
                Game.Scene.AddComponent<MessageDispatherComponent>();
                Game.Scene.AddComponent<ClientFrameComponent>();
               
                
                // ==> 登录UI操作
                uiLogin = GameObject.Find("UILogin");
                uiLobby = GameObject.Find("UILobby");
                uiLobby.SetActive(false);

                loginBut.onClick.AddListener(OnLogin);
                enterMap.onClick.AddListener(EnterMap);

                // 加载热更配置
				Game.Scene.GetComponent<ResourcesComponent>().LoadBundle("config.unity3d");
				Game.Scene.AddComponent<ConfigComponent>();
				Game.Scene.GetComponent<ResourcesComponent>().UnloadBundle("config.unity3d");

				UnitConfig unitConfig = (UnitConfig)Game.Scene.GetComponent<ConfigComponent>().Get(typeof(UnitConfig), 1001);
				Log.Debug($"config {JsonHelper.ToJson(unitConfig)}");

                
                //Game.Hotfix.GotoHotfix();
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }
        }

        public async void OnLogin()
        {

            // ===> 登录session
            IPEndPoint connetEndPoint = NetworkHelper.ToIPEndPoint("127.0.0.1:10002");
            Session session = Game.Scene.GetComponent<NetOuterComponent>().Create(connetEndPoint);
            string text = pname.text;

            R2C_Login r2CLogin = (R2C_Login)await session.Call(new C2R_Login() { Account = text, Password = "111111" });
            if (r2CLogin.Error != ErrorCode.ERR_Success)
            {
                Log.Error(r2CLogin.Error.ToString());
                return;
            }

            // ===> 网关session
            connetEndPoint = NetworkHelper.ToIPEndPoint(r2CLogin.Address);
            Session gateSession = Game.Scene.GetComponent<NetOuterComponent>().Create(connetEndPoint);
            Game.Scene.AddComponent<SessionComponent>().Session = gateSession;

            G2C_LoginGate g2CLoginGate = (G2C_LoginGate)await SessionComponent.Instance.Session.Call(new C2G_LoginGate() { Key = r2CLogin.Key });

            Log.Info("登陆gate成功!");

            uiLogin.SetActive(false);
            uiLobby.SetActive(true);

            // 创建Player
            Player player = ComponentFactory.CreateWithId<Player>(g2CLoginGate.PlayerId);
            PlayerComponent playerComponent = Game.Scene.GetComponent<PlayerComponent>();
            playerComponent.MyPlayer = player;


            // 测试消息有成员是class类型
            //G2C_PlayerInfo g2CPlayerInfo = (G2C_PlayerInfo)await SessionComponent.Instance.Session.Call(new C2G_PlayerInfo());
        }
        
        private async void EnterMap()
        {
            try
            {
                object o = await SessionComponent.Instance.Session.Call(new C2G_EnterMap());
                G2C_EnterMap g2CEnterMap = (G2C_EnterMap)o;
                uiLobby.SetActive(false);
                Log.Info("EnterMap...");
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }


        private void Update()
		{
			OneThreadSynchronizationContext.Instance.Update();
			//Game.Hotfix.Update?.Invoke();
			Game.EventSystem.Update();
		}

		private void LateUpdate()
		{
			//Game.Hotfix.LateUpdate?.Invoke();
			Game.EventSystem.LateUpdate();
		}

		private void OnApplicationQuit()
		{
			//Game.Hotfix.OnApplicationQuit?.Invoke();
			Game.Close();
		}

    }
}