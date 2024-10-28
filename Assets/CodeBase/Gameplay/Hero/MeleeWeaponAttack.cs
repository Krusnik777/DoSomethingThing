using CodeBase.Configs;
using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Gameplay.Hero
{
    public class MeleeWeaponAttack : MonoBehaviour, IWeaponConfigInstaller
    {
        [SerializeField] private MeleeWeaponAttackAnimator m_animator;
        [SerializeField] private float m_cooldown;
        [SerializeField] private float m_radius;
        [SerializeField] private int m_damage;

        private HealthPoints[] targets;

        private float timer;

        public void InstallConfig(WeaponConfig config)
        {
            m_cooldown = config.Cooldown;
            m_radius = config.Radius;
            m_damage = config.Damage;
        }

        private void Start()
        {
            timer = m_cooldown;
        }

        private void Update()
        {
            timer += Time.deltaTime;

            if (CanAttack())
            {
                targets = FindTargets();

                if (targets.Length > 0 )
                {
                    StartAttack();
                }
            }
        }

        private bool CanAttack()
        {
            return timer >= m_cooldown;
        }

        private HealthPoints[] FindTargets()
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, m_radius);

            List<HealthPoints> result = new List<HealthPoints>();

            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].transform.root == transform.root) continue;

                HealthPoints health = colliders[i].transform.root.GetComponent<HealthPoints>();

                if (health != null) result.Add(health);
            }

            return result.ToArray();
        }

        private void StartAttack()
        {
            timer = 0;
            m_animator.Attack();
        }

        private void AnimationEventOnHit()
        {
            for (int i = 0; i < targets.Length; i++)
            {
                if (targets[i] != null) targets[i].ApplyDamage(this, m_damage);
            }
        }

        #if UNITY_EDITOR

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, m_radius);
        }

        #endif
    }
}
