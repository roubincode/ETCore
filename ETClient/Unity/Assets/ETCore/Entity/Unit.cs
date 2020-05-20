#if SERVER
using UnityEngine;
namespace ET
{
	public enum UnitType
	{
		Hero,
		Npc
	}

	[ObjectSystem]
	public class UnitAwakeSystem : AwakeSystem<Unit, UnitType>
	{
		public override void Awake(Unit self, UnitType a)
		{
			self.Awake(a);
		}
	}

	public sealed class Unit: Entity
	{
		public UnitType UnitType { get; private set; }
		
		public Vector3 Position { get; set; }
		
		public void Awake(UnitType unitType)
		{
			this.UnitType = unitType;
		}

		public override void Dispose()
		{
			if (this.IsDisposed)
			{
				return;
			}

			base.Dispose();
		}
	}
}
#else
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;
namespace ET
{
	[ObjectSystem]
	public class UnitAwakeSystem : AwakeSystem<Unit, GameObject>
	{
		public override void Awake(Unit self, GameObject gameObject)
		{
			self.Awake(gameObject);
		}
	}

	public sealed class Unit: Entity
	{
		public int ConfigId;
		public GameObject GameUnit { get; set; }

		public void Awake(GameObject gameObject)
		{
			this.GameUnit = gameObject;
			this.GameUnit.AddComponent<ComponentView>().Component = this;
			GameUnit.transform.SetParent(this.ViewGO.transform, false);
		}

		public UnitConfig Config
		{
			get
			{
				return UnitConfigCategory.Instance.Get(this.ConfigId);
			}
		}
		
		private Vector3 position;
		
		public Vector3 Position
		{
			get
			{
				return this.ViewGO.transform.position;
			}
			set
			{
				this.ViewGO.transform.position = value;
			}
		}

		private Quaternion rotation;

		public Quaternion Rotation
		{
			get
			{
				return this.ViewGO.transform.rotation;
			}
			set
			{
				this.ViewGO.transform.rotation = value;
			}
		}
	}
}
#endif