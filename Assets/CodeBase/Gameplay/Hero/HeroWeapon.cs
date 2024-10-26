using CodeBase.Gameplay.Hero;
using UnityEngine;

namespace CodeBase.Hero
{
    public class HeroWeapon : MonoBehaviour
    {
        [SerializeField] private Transform m_weaponPoint;
        [SerializeField] private HeroAttack m_heroAttack;

        public void GetWeapon(MeleeWeaponAttack meleeWeaponAttack)
        {
            Instantiate(meleeWeaponAttack, m_weaponPoint);

            m_heroAttack.enabled = false;
        }
    }
}
