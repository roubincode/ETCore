using ETModel;
namespace ETModel
{
/// <summary>
/// MMOServer热更消息
/// </summary>
//测试向服务器发送消息
	[Message(HotfixOpcode.TestMessage_C2G)]
	public partial class TestMessage_C2G : IRequest {}

//测试向服务器返回消息
	[Message(HotfixOpcode.TestMessage_G2C)]
	public partial class TestMessage_G2C : IResponse {}

//通知客户端踢下线消息
	[Message(HotfixOpcode.KickOutPlayer_R2C)]
	public partial class KickOutPlayer_R2C : IResponse {}

//客户端登陆网关请求
	[Message(HotfixOpcode.LoginGate_C2G)]
	public partial class LoginGate_C2G : IRequest {}

//客户端登陆网关返回
	[Message(HotfixOpcode.LoginGate_G2C)]
	public partial class LoginGate_G2C : IResponse {}

//客户端登陆认证请求
	[Message(HotfixOpcode.Login_C2R)]
	public partial class Login_C2R : IRequest {}

//客户端登陆认证返回
	[Message(HotfixOpcode.Login_R2C)]
	public partial class Login_R2C : IResponse {}

//退出登录
	[Message(HotfixOpcode.Logout_C2R)]
	public partial class Logout_C2R : IMessage {}

//客户端注册请求
	[Message(HotfixOpcode.Register_C2R)]
	public partial class Register_C2R : IRequest {}

//客户端注册请求回复
	[Message(HotfixOpcode.Register_R2C)]
	public partial class Register_R2C : IResponse {}

//获取用户信息
	[Message(HotfixOpcode.GetUserInfo_C2G)]
	public partial class GetUserInfo_C2G : IRequest {}

//返回用户信息
	[Message(HotfixOpcode.GetUserInfo_G2C)]
	public partial class GetUserInfo_G2C : IResponse {}

//设置用户信息
	[Message(HotfixOpcode.SetUserInfo_C2G)]
	public partial class SetUserInfo_C2G : IRequest {}

//返回设置用户信息
	[Message(HotfixOpcode.SetUserInfo_G2C)]
	public partial class SetUserInfo_G2C : IResponse {}

//返回大厅
	[Message(HotfixOpcode.C2G_ReturnLobby)]
	public partial class C2G_ReturnLobby : IMessage {}

//进入地图(广播)
	[Message(HotfixOpcode.Actor_GamerEnterMap)]
	public partial class Actor_GamerEnterMap : IActorMessage {}

	[Message(HotfixOpcode.Actor_GamerExitMap)]
	public partial class Actor_GamerExitMap : IActorMessage {}

//创建角色
	[Message(HotfixOpcode.CreateNewCharacter_C2G)]
	public partial class CreateNewCharacter_C2G : IRequest {}

	[Message(HotfixOpcode.CharacterMessage_G2C)]
	public partial class CharacterMessage_G2C : IResponse {}

// 获取角色列表
	[Message(HotfixOpcode.GetCharacters_C2G)]
	public partial class GetCharacters_C2G : IRequest {}

	[Message(HotfixOpcode.GetCharacters_G2C)]
	public partial class GetCharacters_G2C : IResponse {}

	[Message(HotfixOpcode.GetCharacter_C2G)]
	public partial class GetCharacter_C2G : IRequest {}

//装备信息
	[Message(HotfixOpcode.EquipInfo)]
	public partial class EquipInfo {}

//玩家信息
	[Message(HotfixOpcode.GamerInfo)]
	public partial class GamerInfo {}

//单个角色的简要描述
	[Message(HotfixOpcode.CharacterInfo)]
	public partial class CharacterInfo {}

//ET----
	[Message(HotfixOpcode.C2R_Login)]
	public partial class C2R_Login : IRequest {}

	[Message(HotfixOpcode.R2C_Login)]
	public partial class R2C_Login : IResponse {}

	[Message(HotfixOpcode.C2G_LoginGate)]
	public partial class C2G_LoginGate : IRequest {}

	[Message(HotfixOpcode.G2C_LoginGate)]
	public partial class G2C_LoginGate : IResponse {}

	[Message(HotfixOpcode.G2C_TestHotfixMessage)]
	public partial class G2C_TestHotfixMessage : IMessage {}

	[Message(HotfixOpcode.C2M_TestActorRequest)]
	public partial class C2M_TestActorRequest : IActorLocationRequest {}

	[Message(HotfixOpcode.M2C_TestActorResponse)]
	public partial class M2C_TestActorResponse : IActorLocationResponse {}

	[Message(HotfixOpcode.PlayerInfo)]
	public partial class PlayerInfo : IMessage {}

	[Message(HotfixOpcode.C2G_PlayerInfo)]
	public partial class C2G_PlayerInfo : IRequest {}

	[Message(HotfixOpcode.G2C_PlayerInfo)]
	public partial class G2C_PlayerInfo : IResponse {}

}
namespace ETModel
{
	public static partial class HotfixOpcode
	{
		 public const ushort TestMessage_C2G = 10001;
		 public const ushort TestMessage_G2C = 10002;
		 public const ushort KickOutPlayer_R2C = 10003;
		 public const ushort LoginGate_C2G = 10004;
		 public const ushort LoginGate_G2C = 10005;
		 public const ushort Login_C2R = 10006;
		 public const ushort Login_R2C = 10007;
		 public const ushort Logout_C2R = 10008;
		 public const ushort Register_C2R = 10009;
		 public const ushort Register_R2C = 10010;
		 public const ushort GetUserInfo_C2G = 10011;
		 public const ushort GetUserInfo_G2C = 10012;
		 public const ushort SetUserInfo_C2G = 10013;
		 public const ushort SetUserInfo_G2C = 10014;
		 public const ushort C2G_ReturnLobby = 10015;
		 public const ushort Actor_GamerEnterMap = 10016;
		 public const ushort Actor_GamerExitMap = 10017;
		 public const ushort CreateNewCharacter_C2G = 10018;
		 public const ushort CharacterMessage_G2C = 10019;
		 public const ushort GetCharacters_C2G = 10020;
		 public const ushort GetCharacters_G2C = 10021;
		 public const ushort GetCharacter_C2G = 10022;
		 public const ushort EquipInfo = 10023;
		 public const ushort GamerInfo = 10024;
		 public const ushort CharacterInfo = 10025;
		 public const ushort C2R_Login = 10026;
		 public const ushort R2C_Login = 10027;
		 public const ushort C2G_LoginGate = 10028;
		 public const ushort G2C_LoginGate = 10029;
		 public const ushort G2C_TestHotfixMessage = 10030;
		 public const ushort C2M_TestActorRequest = 10031;
		 public const ushort M2C_TestActorResponse = 10032;
		 public const ushort PlayerInfo = 10033;
		 public const ushort C2G_PlayerInfo = 10034;
		 public const ushort G2C_PlayerInfo = 10035;
	}
}
