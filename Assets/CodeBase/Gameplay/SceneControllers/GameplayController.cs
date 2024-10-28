using CodeBase.Data;
using CodeBase.Gameplay.Enemy;
using CodeBase.Gameplay.Hero;
using CodeBase.Gameplay.Level;
using CodeBase.Hero;
using UnityEngine;
using UnityEngine.Events;

namespace CodeBase.Gameplay
{
    public class GameplayController : MonoBehaviour
    {
        [SerializeField] private HeroHealth m_heroHealth;
        [SerializeField] private HeroWeapon m_heroWeapon;
        [SerializeField] private SpawnController m_spawnController;
        [SerializeField] private TimeCounter m_timerCounter;

        public event UnityAction EventOnSuccess;
        public event UnityAction EventOnFailure;

        public TimeCounter TimeCounter => m_timerCounter;

        private KillsCounter killsCounter;
        public KillsCounter KillsCounter => killsCounter;

        private ILevelCondition[] levelConditions;

        public void Init(PlayerProgress progress)
        {
            killsCounter = new KillsCounter();

            m_timerCounter.enabled = true;

            m_heroHealth.SetHealthPoints(progress.HealthPoints);

            if (progress.EquippedWeapon != null)
            {
                m_heroWeapon.GetWeapon(progress.EquippedWeapon.Prefab);
            }
            else
            {
                m_heroWeapon.enabled = false;
            }

            m_spawnController.Init(m_heroHealth);
            m_spawnController.EventOnSpawnDead += OnSpawnDead;

            m_heroHealth.EventOnDie += OnHeroDeath;
            
            levelConditions = GetComponentsInChildren<ILevelCondition>();

            for (int i = 0; i < levelConditions.Length; i++)
            {
                levelConditions[i].OnCompleted += OnConditionCompleted;
                levelConditions[i].Init(this);
            }
        }

        private void OnDestroy()
        {
            m_spawnController.EventOnSpawnDead -= OnSpawnDead;
        }

        private void OnSpawnDead(object sender)
        {
            if (sender is MeleeWeaponAttack || sender is HeroAttack) killsCounter.UpdateKills();
        }

        private void OnHeroDeath(object sender)
        {
            m_heroHealth.EventOnDie -= OnHeroDeath;

            // GAME OVER
            Debug.Log("GAME OVER");

            m_spawnController.enabled = false;

            EventOnFailure?.Invoke();
        }

        private void OnConditionCompleted()
        {
            for (int i = 0; i < levelConditions.Length; i++)
            {
                if (!levelConditions[i].Completed) return;
            }

            // Level END
            Debug.Log("Level Completed");

            m_spawnController.EventOnSpawnDead -= OnSpawnDead;

            m_spawnController.enabled = false;

            m_heroHealth.GetComponent<HeroInput>().enabled = false;
            m_heroHealth.GetComponent<HeroMovement>().enabled = false;

            EnemyHealth.CleanupRemainingEnemies();

            if (GlobalController.Instance != null)
            {
                GlobalController.PlayerProgress.HealthPoints = m_heroHealth.CurrentValue;
            }

            EventOnSuccess?.Invoke();
        }
    }
}
