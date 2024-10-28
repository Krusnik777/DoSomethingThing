using CodeBase.Configs;
using CodeBase.Gameplay.Hero;
using UnityEngine;

namespace CodeBase.Hero
{
    public class HeroWeapon : MonoBehaviour
    {
        [SerializeField] private Transform m_weaponPoint;
        [SerializeField] private HeroAttack m_heroAttack;

        public void GetWeapon(WeaponConfig config)
        {
            var weapon = Instantiate(config.Prefab, m_weaponPoint);

            weapon.InstallConfig(config);

            m_heroAttack.enabled = false;
        }
    }
}
