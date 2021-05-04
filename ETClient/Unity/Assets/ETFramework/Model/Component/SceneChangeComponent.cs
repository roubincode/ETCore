using UnityEngine;
using UnityEngine.SceneManagement;

namespace ETModel
{
	[ObjectSystem]
	public class SceneChangeComponentUpdateSystem: UpdateSystem<SceneChangeComponent>
	{
		public override void Update(SceneChangeComponent self)
		{
			self.Doprogress();

			// 让用户完整的看到100%的进度显示后才结束tcs
			if (self.displayProgress == 101)
			{
				self.tcs.SetResult();
			}
		}
	}

	public class SceneChangeComponent: Component
	{
		public AsyncOperation op;
		public ETTaskCompletionSource tcs;

		public int displayProgress = 0;
		int toProgress = 0;

		public void Doprogress(){
			// 90%前用op.progress
			if(op.progress < 0.90f)
			{
				toProgress = (int)op.progress * 100;
				if(displayProgress < toProgress)
				{
					++displayProgress;
				}
			// 90%-100%用帧循环自增
			}else{
				toProgress = 101;
				if(displayProgress < toProgress){
					++displayProgress;
				}
			}
			
		}
		public ETTask ChangeSceneAsync(string sceneName)
		{
			this.tcs = new ETTaskCompletionSource();
			// 加载scene 
			this.op = SceneManager.LoadSceneAsync(sceneName);

			return this.tcs.Task;
		}

		// 供进度条或进度文字调用
		public float Process
		{
			get
			{
				return this.displayProgress;
			}
		}

		public override void Dispose()
		{
			if (this.IsDisposed)
			{
				return;
			}

			if (this.Entity.IsDisposed)
			{
				return;
			}
			
			base.Dispose();
			
			this.Entity.RemoveComponent<SceneChangeComponent>();
		}
	}
}