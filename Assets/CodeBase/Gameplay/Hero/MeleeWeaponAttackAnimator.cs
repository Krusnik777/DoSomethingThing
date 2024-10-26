using UnityEngine;

namespace CodeBase.Gameplay.Hero
{
    public class MeleeWeaponAttackAnimator : MonoBehaviour
    {
        private const string _AttackTrigger = "Attack";

        [SerializeField] private Animator m_animator;

        public void Attack()
        {
            m_animator.SetTrigger(_AttackTrigger);
        }
    }
}
