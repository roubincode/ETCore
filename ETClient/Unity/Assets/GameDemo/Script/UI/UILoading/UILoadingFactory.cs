using System;
using UnityEngine;
using ETModel;
namespace Demo
{
    [UIFactory(UIType.UILoading)]
    public class UILoadingFactory:IUIFactory
    {
        public UI Create(Scene scene, string type, GameObject parent)
        {
	        try
	        {
                UI ui = UIResources.GetLoading();
				ui.AddComponent<UILoadingComponent>();
				return ui;
	        }
	        catch (Exception e)
	        {
				Log.Error(e);
		        return null;
	        }
		}
		public void Remove(string type)
        {
            
        }
    }
}