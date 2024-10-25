using UnityEngine;

namespace CodeBase.Configs
{
    [CreateAssetMenu(fileName = "EnemyConfig", menuName = "Configs/Enemy")]
    public class EnemyConfig : ScriptableObject
    {
        public int Damage;
        public float MovementSpeed;
        public float StopDistance;
        public int HealthPoints;
        public GameObject Prefab;
    }
}
