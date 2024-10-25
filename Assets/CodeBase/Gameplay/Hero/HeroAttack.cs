using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Gameplay.Hero
{
    public class HeroAttack : MonoBehaviour
    {
        [SerializeField] private HeroMovement m_heroMovement;
        [SerializeField] private HeroAnimator m_animator;
        [SerializeField] private float m_cooldown;
        [SerializeField] private float m_radius;
        [SerializeField] private int m_damage;

        private HealthPoints[] targets;

        private float timer;

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
            return timer >= m_cooldown && m_heroMovement.DirectionControl.magnitude < 0.05f;
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
                if (targets[i] != null) targets[i].ApplyDamage(m_damage);
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
