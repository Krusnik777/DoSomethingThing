using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace CodeBase.Gameplay.Hero
{
    public class HeroAttack : MonoBehaviour, IAttack
    {
        [SerializeField] private HeroMovement m_heroMovement;
        [SerializeField] private HeroAnimator m_animator;
        [SerializeField] private float m_cooldown;
        [SerializeField] private float m_radius;
        [SerializeField] private int m_damage;

        public float Cooldown => m_cooldown;
        public float Radius => m_radius;
        public bool ReadyToAttack => timer >= m_cooldown && targets?.Length > 0;
        public bool InCooldown => timer < m_cooldown; 

        public event UnityAction EventOnCooldownStart;

        private HealthPoints[] targets;

        private float timer;

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
            return timer >= m_cooldown && m_heroMovement.DirectionControl == Vector3.zero;
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
            EventOnCooldownStart?.Invoke();
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
