namespace ETModel
{
	public static partial class InnerOpcode
	{
		 public const ushort GetLoginKey_R2G = 1001;
		 public const ushort GetLoginKey_G2R = 1002;
		 public const ushort PlayerOnline_G2R = 1003;
		 public const ushort PlayerOffline_G2R = 1004;
		 public const ushort KickOutPlayer_R2G = 1005;
		 public const ushort KickOutPlayer_G2R = 1006;
		 public const ushort CreateUnit_G2M = 1007;
		 public const ushort Actor_EnterMapSucess_M2G = 1008;
		 public const ushort M2M_TrasferUnitRequest = 1009;
		 public const ushort M2M_TrasferUnitResponse = 1010;
		 public const ushort M2A_Reload = 1011;
		 public const ushort A2M_Reload = 1012;
		 public const ushort G2G_LockRequest = 1013;
		 public const ushort G2G_LockResponse = 1014;
		 public const ushort G2G_LockReleaseRequest = 1015;
		 public const ushort G2G_LockReleaseResponse = 1016;
		 public const ushort DBSaveRequest = 1017;
		 public const ushort DBSaveBatchResponse = 1018;
		 public const ushort DBSaveBatchRequest = 1019;
		 public const ushort DBSaveResponse = 1020;
		 public const ushort DBQueryRequest = 1021;
		 public const ushort DBQueryResponse = 1022;
		 public const ushort DBQueryBatchRequest = 1023;
		 public const ushort DBQueryBatchResponse = 1024;
		 public const ushort DBQueryJsonRequest = 1025;
		 public const ushort DBQueryJsonResponse = 1026;
		 public const ushort DBQuery2JsonRequest = 1027;
		 public const ushort DBQuery2JsonResponse = 1028;
		 public const ushort ObjectAddRequest = 1029;
		 public const ushort ObjectAddResponse = 1030;
		 public const ushort ObjectRemoveRequest = 1031;
		 public const ushort ObjectRemoveResponse = 1032;
		 public const ushort ObjectLockRequest = 1033;
		 public const ushort ObjectLockResponse = 1034;
		 public const ushort ObjectUnLockRequest = 1035;
		 public const ushort ObjectUnLockResponse = 1036;
		 public const ushort ObjectGetRequest = 1037;
		 public const ushort ObjectGetResponse = 1038;
		 public const ushort R2G_GetLoginKey = 1039;
		 public const ushort G2R_GetLoginKey = 1040;
		 public const ushort G2M_CreateUnit = 1041;
		 public const ushort M2G_CreateUnit = 1042;
		 public const ushort G2M_SessionDisconnect = 1043;
	}
}
