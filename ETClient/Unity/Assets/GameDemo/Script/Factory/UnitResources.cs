using UnityEngine;
using ETModel;
namespace Demo
{
    public static class UnitResources
    {
        public static GameObject Get(string type)
        {
	        ResourcesComponent resourcesComponent = Game.Scene.GetComponent<ResourcesComponent>();
	          
            GameObject bundleGameObject = (GameObject)resourcesComponent.GetAsset("unit.unity3d", "Unit");
	        GameObject prefab = bundleGameObject.Get<GameObject>($"{type}");

            return prefab;
        }

        public static UnityEngine.Object[] GetAll(string asName)
        {
	        ResourcesComponent resourcesComponent = Game.Scene.GetComponent<ResourcesComponent>();
            GameObject bundleGameObject = (GameObject)resourcesComponent.GetAsset(asName+".unity3d", "Unit");

	        UnityEngine.Object[] prefabs = bundleGameObject.GetAll<GameObject>();
            return prefabs;
        }

        public static async ETVoid LoadUnitAsync()
        {
            // 加载Unit资源
            ResourcesComponent resourcesComponent = ETModel.Game.Scene.GetComponent<ResourcesComponent>();
            await resourcesComponent.LoadBundleAsync($"unit.unity3d");

            Game.EventSystem.Run(EventIdType.UnitLoadFinished);

            // resourcesComponent.UnloadBundle("unit.unity3d");
        }

    }
}