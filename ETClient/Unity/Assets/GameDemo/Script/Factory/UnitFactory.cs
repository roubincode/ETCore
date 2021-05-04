using UnityEngine;
using ETModel;
namespace Demo
{
    public static class UnitFactory
    {
        public static Unit Create(long id, string type = "Skeleton")
        {
            GameObject prefab = UnitResources.Get($"{type}");
	        GameObject go = UnityEngine.Object.Instantiate(prefab);
	        Unit unit = ComponentFactory.CreateWithId<Unit, GameObject>(id, go);
	        //unit.AddComponent<FrameMoveComponent>();
            
			UnitComponent unitComponent = Game.Scene.GetComponent<UnitComponent>();
            unitComponent.Add(unit);
            return unit;
        }

        public static Unit Create(long id, GameObject go)
        {
	        Unit unit = ComponentFactory.CreateWithId<Unit, GameObject>(id, go);
            //unit.AddComponent<CharacterMoveComponent>();
			UnitComponent unitComponent = Game.Scene.GetComponent<UnitComponent>();
            unitComponent.Add(unit);
            return unit;
        }


        public static void Remove(Unit unit){
	        //unit.RemoveComponent<FrameMoveComponent>();
            UnitComponent unitComponent = Game.Scene.GetComponent<UnitComponent>();
            unitComponent.Remove(unit.Id);
            unit.Dispose();
        }
    }
}