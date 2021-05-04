using System;
using System.Net;
using UnityEngine;
using UnityEngine.UI;
using ETModel;
namespace Demo
{
	[ObjectSystem]
	public class UIRegisterComponentSystem : AwakeSystem<UIRegisterComponent>
	{
		public override void Awake(UIRegisterComponent self)
		{
			self.Awake();
		}
	}
	
	public class UIRegisterComponent: ETModel.Component
	{
		//提示文本
        public Text prompt;

        public InputField account;
        public InputField password;
        public InputField rePassword;

        //是否正在注册中（避免登录请求还没响应时连续点击注册）
        public bool isRegistering;

        public void Awake()
        {
            
            ReferenceCollector rc = this.GetParent<UI>().GameObject.GetComponent<ReferenceCollector>();
            
            //初始化数据
            account = rc.Get<GameObject>("Account").GetComponent<InputField>();
            password = rc.Get<GameObject>("Password").GetComponent<InputField>();
            rePassword = rc.Get<GameObject>("RePassword").GetComponent<InputField>();
            prompt = rc.Get<GameObject>("Prompt").GetComponent<Text>();
            this.isRegistering = false;

            //添加事件
            rc.Get<GameObject>("CancelButton").GetComponent<Button>().onClick.Add(() => CancelBtnOnClick());
            rc.Get<GameObject>("SubmitButton").GetComponent<Button>().onClick.Add(() => SubmitBtnOnClick());

            //Manager.RPG.lastUI = UIState.UIRegister;
        }

        public void SubmitBtnOnClick()
        {
            if (this.isRegistering || this.IsDisposed)
            {
                return;
            }
            if(account.text == ""){
                prompt.text = "账号名不能为空！";
                return;
            }

            if(password.text == "" || rePassword.text == ""){
                prompt.text = "密码或确认密码不能为空！";
                return;
            }

            if (password.text != rePassword.text){
                prompt.text = "两次输入的密码不一致！";
                return;
            }
            this.isRegistering = true; 
            
            // 调用注册请求
            //RealmHelper.Register(this.account.text, this.password.text).Coroutine();
        }

        public void CancelBtnOnClick()
        {
            Game.EventSystem.Run(EventIdType.BackLogin);
        }
        
	}
}
