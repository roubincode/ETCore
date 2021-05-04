using System;
using System.Net;
using UnityEngine;
using UnityEngine.UI;
using ETModel;
namespace Demo
{
	[ObjectSystem]
	public class UiLoginComponentSystem : AwakeSystem<UILoginComponent>
	{
		public override void Awake(UILoginComponent self)
		{
			self.Awake();
		}
	}
	
	public class UILoginComponent: ETModel.Component
	{
		//提示文本
        public Text prompt;

        public InputField account;
        public InputField password;

        //是否正在登录中（避免登录请求还没响应时连续点击登录）
        public bool isLogining;

        public void Awake()
        {
            
            ReferenceCollector rc = this.GetParent<UI>().GameObject.GetComponent<ReferenceCollector>();

            // 初始化数据
            account = rc.Get<GameObject>("Account").GetComponent<InputField>();
            password = rc.Get<GameObject>("Password").GetComponent<InputField>();
            prompt = rc.Get<GameObject>("Prompt").GetComponent<Text>();
            this.isLogining = false;

            // 添加事件
            rc.Get<GameObject>("LoginButton").GetComponent<Button>().onClick.Add(() => LoginBtnOnClick());
            rc.Get<GameObject>("RegisterButton").GetComponent<Button>().onClick.Add(() => RegisterBtnOnClick());

            //Manager.RPG.lastUI = UIState.UILogin;
        }

        public void LoginBtnOnClick()
        {
            if (this.isLogining || this.IsDisposed)
            {
                return;
            }
            if(account.text == ""){
                prompt.text = "账号名不能为空！";
                return;
            }

            if(password.text == ""){
                prompt.text = "密码不能为空！";
                return;
            }
            this.isLogining = true;

            // 调用登录请求
            //RealmHelper.Login(this.account.text, this.password.text).Coroutine();
        }

        public void RegisterBtnOnClick()
        {
            Game.EventSystem.Run(EventIdType.GameRegister);
        }
	}
}
