using UnityEngine;

namespace ETModel
{
	[Config((int)( AppType.Gate | AppType.Map))]
	public partial class MapConfigCategory : ACategory<MapConfig>
	{
	}

	public class MapConfig: IConfig
	{
        public long Id { get; set; }
        public string Class ;
        public string Name;
        public string type;

        public int baseHealth;
        public int perHealth;

        public int mapId;

        public int taskId;

        public int battleState;
        public long pickingsId;

        public float x; 
        public float y; 
        public float z; 

        public float Rotation;

    }
}