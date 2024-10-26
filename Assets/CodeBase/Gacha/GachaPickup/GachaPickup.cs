using CodeBase.Configs;
using UnityEngine;
using UnityEngine.Events;

namespace CodeBase.Gacha
{
    public class GachaPickup : MonoBehaviour
    {
        [SerializeField] private WeaponConfig m_weaponConfig;

        public void GetItem(out WeaponConfig config)
        {
            config = m_weaponConfig;

            Destroy(gameObject);
        }
    }
}
