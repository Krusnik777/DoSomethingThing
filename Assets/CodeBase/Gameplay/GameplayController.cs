using CodeBase.Data;
using CodeBase.Gameplay.Hero;
using CodeBase.Gameplay.Level;
using UnityEngine;

namespace CodeBase.Gameplay
{
    public class GameplayController : MonoBehaviour
    {
        [SerializeField] private HeroHealth m_heroHealth;
        [SerializeField] private SpawnController m_spawnController;
        [SerializeField] private TimeCounter m_timerCounter;
        public TimeCounter TimeCounter => m_timerCounter;

        private KillsCounter killsCounter;
        public KillsCounter KillsCounter => killsCounter;

        private ILevelCondition[] levelConditions;

        // TEMP
        private void Start()
        {
            Init(new PlayerProgress());
        }
        // TEMP END

        public void Init(PlayerProgress progress)
        {
            killsCounter = new KillsCounter();

            m_timerCounter.enabled = true;

            m_heroHealth.SetHealthPoints(progress.HealthPoints);

            if (progress.EquippedWeapon != null)
            {
                //equip weapon
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

        private void OnSpawnDead()
        {
            killsCounter.UpdateKills();
        }

        private void OnHeroDeath()
        {
            m_heroHealth.EventOnDie -= OnHeroDeath;

            // GAME OVER
            Debug.Log("GAME OVER");

            m_spawnController.enabled = false;
        }

        private void OnConditionCompleted()
        {
            for (int i = 0; i < levelConditions.Length; i++)
            {
                if (!levelConditions[i].Completed) return;
            }

            // Level END
            Debug.Log("Level Completed");

            m_spawnController.enabled = false;
        }
    }
}
