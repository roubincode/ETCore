using System;


namespace ET
{
    public static class LoginHelper
    {
        public static async ETVoid OnLoginAsync()
        {
            try
            {
                UILoginComponent login = Game.Scene.GetComponent<UIComponent>().Get(UIType.UILogin).GetComponent<UILoginComponent>();
                
                // 创建一个ETHotfix层的Session, ETHotfix的Session会通过ETModel层的Session发送消息
                Session realmSession = Game.Scene.GetComponent<NetOuterComponent>().Create(GlobalConfigComponent.Instance.GlobalProto.Address);
                R2C_Login r2CLogin = (R2C_Login) await realmSession.Call(new C2R_Login() { Account = "abc", Password = "111111" });
                realmSession.Dispose();
                Log.Info("正在登录中...");

                //判断Realm服务器返回结果
                if (r2CLogin.Error == ErrorCode.ERR_AccountOrPasswordError)
                {
                    Log.Info("登录失败,账号或密码错误");
                    login.account.text = "";
                    login.password.text = "";
                    return;
                }


                // 创建一个ETModel层的Session,并且保存到ETModel.SessionComponent中
                Session gateSession = Game.Scene.GetComponent<NetOuterComponent>().Create(r2CLogin.Address);
                Game.Scene.AddComponent<SessionComponent>().Session = gateSession;
                SessionComponent.Instance.Session = gateSession;
				
                G2C_LoginGate g2CLoginGate = (G2C_LoginGate)await gateSession.Call(
                    new C2G_LoginGate() { Key = r2CLogin.Key, GateId = r2CLogin.GateId});

                //判断登陆Gate服务器返回结果
                if (g2CLoginGate.Error == ErrorCode.ERR_ConnectGateKeyError)
                {
                    Log.Info("连接网关服务器超时");
                    login.account.text = "";
                    login.password.text = "";
                    gateSession.Dispose();
                    return;
                }
                //判断通过则登陆Gate成功
                Log.Info("登陆gate成功!");

                // 创建Player
                Player player = EntityFactory.CreateWithId<Player>(Game.Scene, g2CLoginGate.PlayerId);
                PlayerComponent playerComponent = Game.Scene.GetComponent<PlayerComponent>();
                playerComponent.MyPlayer = player;

                Game.EventSystem.Run(EventIdType.LoginFinish);

                // 测试消息有成员是class类型
                G2C_PlayerInfo g2CPlayerInfo = (G2C_PlayerInfo) await SessionComponent.Instance.Session.Call(new C2G_PlayerInfo());
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        } 
    }
}