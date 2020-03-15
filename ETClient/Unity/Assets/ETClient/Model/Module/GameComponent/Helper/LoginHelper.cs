using System;
using ETModel;

namespace ETModel
{
    public static class LoginHelper
    {
        public static async ETVoid OnLoginAsync(string account)
        {
            try
            {
                //  ===> 登录session
                Session session = Game.Scene.GetComponent<NetOuterComponent>().Create(GlobalConfigComponent.Instance.GlobalProto.Address);
                R2C_Login r2CLogin = (R2C_Login) await session.Call(new C2R_Login() { Account = account, Password = "111111" });
               
                // ===> 网关session
                Session gateSession = Game.Scene.GetComponent<NetOuterComponent>().Create(r2CLogin.Address);
                Game.Scene.AddComponent<SessionComponent>().Session = gateSession;
				
                
                G2C_LoginGate g2CLoginGate = (G2C_LoginGate)await SessionComponent.Instance.Session.Call(new C2G_LoginGate() { Key = r2CLogin.Key });

                Log.Info("登陆gate成功!");

                // 创建Player
                Player player = ComponentFactory.CreateWithId<Player>(g2CLoginGate.PlayerId);
                PlayerComponent playerComponent = Game.Scene.GetComponent<PlayerComponent>();
                playerComponent.MyPlayer = player;

                Game.EventSystem.Run(EventIdType.LoginFinish);

                // 测试消息有成员是class类型
                //G2C_PlayerInfo g2CPlayerInfo = (G2C_PlayerInfo) await SessionComponent.Instance.Session.Call(new C2G_PlayerInfo());
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        } 
    }
}