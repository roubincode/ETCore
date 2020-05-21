using System;
using System.Net;

using UnityEngine;
using UnityEngine.UI;

namespace ET
{
	[ObjectSystem]
	public class UILoginComponentAwakeSystem : AwakeSystem<UILoginComponent>
	{
		public override void Awake(UILoginComponent self)
		{
			ReferenceCollector rc = self.GetParent<UI>().GameObject.GetComponent<ReferenceCollector>();
			self.loginBtn = rc.Get<GameObject>("LoginBtn");
			self.loginBtn.GetComponent<Button>().onClick.Add(self.OnLogin);
			self.account = rc.Get<GameObject>("Account").GetComponent<InputField>();
			self.password = rc.Get<GameObject>("Password").GetComponent<InputField>();
		}
	}
	
	public static class UILoginComponentSystem
	{
		public static void OnLogin(this UILoginComponent self)
		{
			LoginHelper.OnLoginAsync().Coroutine();
		}
	}

	public class UILoginComponent: Entity
	{
		public InputField account;
		public InputField password;
		public GameObject loginBtn;
	}
}
