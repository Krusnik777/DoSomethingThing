using UnityEngine;

namespace CodeBase.Configs
{
    [CreateAssetMenu(fileName = "WeaponConfig", menuName = "Configs/Weapon")]
    public class WeaponConfig : ScriptableObject
    {
        public float Radius;
        public float Cooldown;
        public int Damage;
        public GameObject Prefab;
    }
}
