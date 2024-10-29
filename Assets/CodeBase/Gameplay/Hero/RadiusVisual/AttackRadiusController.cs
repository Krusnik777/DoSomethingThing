using UnityEngine;

namespace CodeBase.Gameplay.Hero
{
    public class AttackRadiusController : MonoBehaviour
    {
        [SerializeField] private AttackRadiusVisual m_attackRadiusVisual;
        [SerializeField] private AttackRadiusColors m_attackRadiusColors;

        private IAttack attacker;

        public void Init(IAttack attack)
        {
            attacker = attack;

            m_attackRadiusVisual.SetRadius(attacker.Radius);

            attacker.EventOnCooldownStart += OnCooldownStart;
        }

        private void OnDestroy()
        {
            attacker.EventOnCooldownStart -= OnCooldownStart;
        }

        private void OnCooldownStart()
        {
            m_attackRadiusColors.ChangeColorToCooldown(attacker.Cooldown);
        }
    }
}
