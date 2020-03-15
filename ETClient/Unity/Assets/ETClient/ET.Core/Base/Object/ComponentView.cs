#if !SERVER
using UnityEngine;

namespace ETModel
{
    public class ComponentView: MonoBehaviour
    {
        public object Component { get; set; }
    }
}
#endif