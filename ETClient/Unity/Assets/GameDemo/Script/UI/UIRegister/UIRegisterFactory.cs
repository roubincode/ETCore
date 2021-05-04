using System;
using UnityEngine;
using ETModel;
namespace Demo
{
    [UIFactory(UIType.UIRegister)]
    public class UIRegistFactory:IUIFactory
    {
        public UI Create(Scene scene, string type, GameObject parent)
        {
	        try
	        {
                UI ui = UIResources.Get(type);

				ui.AddComponent<UIRegisterComponent>();
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
            Game.Scene.GetComponent<ResourcesComponent>().UnloadBundle($"{type}.unity3d");
        }
    }
}