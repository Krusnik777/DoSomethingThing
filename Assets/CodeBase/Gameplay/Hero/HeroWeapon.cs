using CodeBase.Configs;
using CodeBase.Gameplay.Hero;
using UnityEngine;

namespace CodeBase.Hero
{
    public class HeroWeapon : MonoBehaviour
    {
        [SerializeField] private Transform m_weaponPoint;
        [SerializeField] private HeroAttack m_heroAttack;
        [SerializeField] private AttackRadiusController m_attackRadiusController;

        private void Start()
        {
            SetupWeapon(null);
        }

        public void SetupWeapon(WeaponConfig config)
        {
            if (config == null)
            {
                m_attackRadiusController.Init(m_heroAttack);
            }
            else
            {
                var weapon = Instantiate(config.Prefab, m_weaponPoint);

                weapon.InstallConfig(config);
                m_attackRadiusController.Init(weapon);

                m_heroAttack.enabled = false;
            }
        }
    }
}
