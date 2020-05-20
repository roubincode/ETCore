using UnityEngine;

namespace ET
{
    public static class UnitFactory
    {
        public static Unit Create(Entity domain, UnitInfo unitInfo)
        {
	        ResourcesComponent resourcesComponent = Game.Scene.GetComponent<ResourcesComponent>();
            GameObject bundleGameObject = (GameObject)resourcesComponent.GetAsset("Unit.unity3d", "Unit");
            GameObject prefab = bundleGameObject.Get<GameObject>("Skeleton");
	        
            GameObject go = UnityEngine.Object.Instantiate(prefab);
            Unit unit = EntityFactory.CreateWithId<Unit, GameObject>(domain,unitInfo.UnitId, go);
            unit.Position = new Vector3(unitInfo.X, unitInfo.Y, unitInfo.Z);
	        
			unit.AddComponent<MoveComponent>();
	        unit.AddComponent<TurnComponent>();
	        unit.AddComponent<UnitPathComponent>();
            unit.AddComponent<AnimatorComponent>();
	       
	        UnitComponent unitComponent = Game.Scene.GetComponent<UnitComponent>();
            unitComponent.Add(unit);
            return unit;
        }
    }
}