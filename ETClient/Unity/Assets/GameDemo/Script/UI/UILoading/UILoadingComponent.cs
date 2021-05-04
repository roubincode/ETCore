using UnityEngine;
using UnityEngine.UI;
using ETModel;
namespace Demo
{
	[ObjectSystem]
	public class UILoadingComponentAwakeSystem : AwakeSystem<UILoadingComponent>
	{
		public override void Awake(UILoadingComponent self)
		{
			self.process = self.GetParent<UI>().GameObject.Get<GameObject>("Text").GetComponent<Text>();
		}
	}

	[ObjectSystem]
	public class UILoadingComponentUpdateSystem :UpdateSystem<UILoadingComponent>
	{
		public override void Update(UILoadingComponent self)
		{
			self.Async();
		}
		
	}

	public class UILoadingComponent : ETModel.Component
	{
		public Text process;
		public void Async()
		{
				SceneChangeComponent sceneChange = Game.Scene.GetComponent<SceneChangeComponent>();
				if (sceneChange == null) return;
				process.text = $"{sceneChange.Process}%";
			
		}
	}
}
