using CodeBase.Configs;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

namespace CodeBase.Gameplay.Enemy
{
    public class EnemyFollowHero : MonoBehaviour, IEnemyConfigInstaller
    {
        [SerializeField] private float m_movementSpeed; // Serialize is for debug or hand input
        [SerializeField] private float m_stopDistance; // Serialize is for debug or hand input
        [SerializeField] private NavMeshAgent m_agent;
        [SerializeField] private GameObject m_followTarget; // Serialize is for debug or hand input

        public event UnityAction EventOnReached;

        private bool reached = false;

        public void InstallConfig(EnemyConfig config)
        {
            m_movementSpeed = config.MovementSpeed;
            m_stopDistance = config.StopDistance;
        }

        public void SetFollowTarget(GameObject gameObject) => m_followTarget = gameObject;

        private void Start()
        {
            m_agent.speed = m_movementSpeed;
            m_agent.stoppingDistance = m_stopDistance;
            m_agent.Warp(transform.position);
        }

        private void Update()
        {
            if (m_followTarget == null || reached) return;

            if (Vector3.Distance(m_agent.transform.position, m_followTarget.transform.position) <= m_stopDistance)
            {
                EventOnReached?.Invoke();

                reached = true;

                return;
            }

            m_agent.destination = m_followTarget.transform.position;
        }
    }
}