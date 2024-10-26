using CodeBase.Gameplay.Hero;
using UnityEngine;

namespace CodeBase.Configs
{
    [CreateAssetMenu(fileName = "WeaponConfig", menuName = "Configs/Weapon")]
    public class WeaponConfig : ScriptableObject
    {
        public string Name;
        //public float Radius;
        //public float Cooldown;
        //public int Damage;
        public MeleeWeaponAttack Prefab;
    }
}
