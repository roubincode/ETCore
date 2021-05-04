using ETModel;
namespace ETModel
{
/// <summary>
/// MMOServer外网消息
/// </summary>
	[Message(OuterOpcode.EnterMap_C2G)]
	public partial class EnterMap_C2G : IRequest {}

	[Message(OuterOpcode.EnterMap_G2C)]
	public partial class EnterMap_G2C : IResponse {}

	[Message(OuterOpcode.CreateUnits_M2C)]
	public partial class CreateUnits_M2C : IActorMessage {}

	[Message(OuterOpcode.C2M_SelectTarget)]
	public partial class C2M_SelectTarget : IActorLocationMessage {}

	[Message(OuterOpcode.M2C_SelectTarget)]
	public partial class M2C_SelectTarget : IActorMessage {}

	[Message(OuterOpcode.M2C_CreateSprites)]
	public partial class M2C_CreateSprites : IActorMessage {}

	[Message(OuterOpcode.SpriteInfo)]
	public partial class SpriteInfo {}

	[Message(OuterOpcode.C2M_Input_Move)]
	public partial class C2M_Input_Move : IActorLocationMessage {}

	[Message(OuterOpcode.M2C_Result_Move)]
	public partial class M2C_Result_Move : IActorMessage {}

	[Message(OuterOpcode.C2M_Input_UseSkill)]
	public partial class C2M_Input_UseSkill : IActorLocationMessage {}

	[Message(OuterOpcode.M2C_Result_UseSkill)]
	public partial class M2C_Result_UseSkill : IActorMessage {}

	[Message(OuterOpcode.M2C_StartSkill)]
	public partial class M2C_StartSkill : IActorMessage {}

	[Message(OuterOpcode.M2C_FinishSkill)]
	public partial class M2C_FinishSkill : IActorMessage {}

	[Message(OuterOpcode.Vector3Info)]
	public partial class Vector3Info {}

//获取大厅玩家信息请求
	[Message(OuterOpcode.GetUserInfo_InLobby_C2G)]
	public partial class GetUserInfo_InLobby_C2G : IRequest {}

	[Message(OuterOpcode.GetUserInfo_InLobby_G2C)]
	public partial class GetUserInfo_InLobby_G2C : IResponse {}

//----ET
	[Message(OuterOpcode.Actor_Test)]
	public partial class Actor_Test : IActorMessage {}

	[Message(OuterOpcode.C2M_TestRequest)]
	public partial class C2M_TestRequest : IActorLocationRequest {}

	[Message(OuterOpcode.M2C_TestResponse)]
	public partial class M2C_TestResponse : IActorLocationResponse {}

	[Message(OuterOpcode.Actor_TransferRequest)]
	public partial class Actor_TransferRequest : IActorLocationRequest {}

	[Message(OuterOpcode.Actor_TransferResponse)]
	public partial class Actor_TransferResponse : IActorLocationResponse {}

	[Message(OuterOpcode.C2G_EnterMap)]
	public partial class C2G_EnterMap : IRequest {}

	[Message(OuterOpcode.G2C_EnterMap)]
	public partial class G2C_EnterMap : IResponse {}

	[Message(OuterOpcode.UnitInfo)]
	public partial class UnitInfo {}

	[Message(OuterOpcode.M2C_CreateUnits)]
	public partial class M2C_CreateUnits : IActorMessage {}

	[Message(OuterOpcode.Frame_ClickMap)]
	public partial class Frame_ClickMap : IActorLocationMessage {}

	[Message(OuterOpcode.State_ClickMap)]
	public partial class State_ClickMap : IActorLocationMessage {}

	[Message(OuterOpcode.M2C_PathfindingResult)]
	public partial class M2C_PathfindingResult : IActorMessage {}

	[Message(OuterOpcode.C2R_Ping)]
	public partial class C2R_Ping : IRequest {}

	[Message(OuterOpcode.R2C_Ping)]
	public partial class R2C_Ping : IResponse {}

	[Message(OuterOpcode.G2C_Test)]
	public partial class G2C_Test : IMessage {}

	[Message(OuterOpcode.C2M_Reload)]
	public partial class C2M_Reload : IRequest {}

	[Message(OuterOpcode.M2C_Reload)]
	public partial class M2C_Reload : IResponse {}

}
namespace ETModel
{
	public static partial class OuterOpcode
	{
		 public const ushort EnterMap_C2G = 101;
		 public const ushort EnterMap_G2C = 102;
		 public const ushort CreateUnits_M2C = 103;
		 public const ushort C2M_SelectTarget = 104;
		 public const ushort M2C_SelectTarget = 105;
		 public const ushort M2C_CreateSprites = 106;
		 public const ushort SpriteInfo = 107;
		 public const ushort C2M_Input_Move = 108;
		 public const ushort M2C_Result_Move = 109;
		 public const ushort C2M_Input_UseSkill = 110;
		 public const ushort M2C_Result_UseSkill = 111;
		 public const ushort M2C_StartSkill = 112;
		 public const ushort M2C_FinishSkill = 113;
		 public const ushort Vector3Info = 114;
		 public const ushort GetUserInfo_InLobby_C2G = 115;
		 public const ushort GetUserInfo_InLobby_G2C = 116;
		 public const ushort Actor_Test = 117;
		 public const ushort C2M_TestRequest = 118;
		 public const ushort M2C_TestResponse = 119;
		 public const ushort Actor_TransferRequest = 120;
		 public const ushort Actor_TransferResponse = 121;
		 public const ushort C2G_EnterMap = 122;
		 public const ushort G2C_EnterMap = 123;
		 public const ushort UnitInfo = 124;
		 public const ushort M2C_CreateUnits = 125;
		 public const ushort Frame_ClickMap = 126;
		 public const ushort State_ClickMap = 127;
		 public const ushort M2C_PathfindingResult = 128;
		 public const ushort C2R_Ping = 129;
		 public const ushort R2C_Ping = 130;
		 public const ushort G2C_Test = 131;
		 public const ushort C2M_Reload = 132;
		 public const ushort M2C_Reload = 133;
	}
}
