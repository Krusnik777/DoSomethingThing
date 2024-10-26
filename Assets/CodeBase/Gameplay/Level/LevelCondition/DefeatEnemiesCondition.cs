using UnityEngine;
using UnityEngine.Events;

namespace CodeBase.Gameplay.Level
{
    public class DefeatEnemiesCondition : MonoBehaviour, ILevelCondition
    {
        [SerializeField] private int m_targetKills;

        public event UnityAction OnCompleted;

        private GameplayController gameplayController;

        private bool completed;
        public bool Completed => completed;

        public int TargetValue => m_targetKills;

        public void Init(GameplayController gameplayController)
        {
            this.gameplayController = gameplayController;

            gameplayController.KillsCounter.EventOnKillsUpdated += OnKillsUpdated;

            completed = false;
        }

        private void OnKillsUpdated(int currentKills)
        {
            if (currentKills >= m_targetKills)
            {
                gameplayController.KillsCounter.EventOnKillsUpdated -= OnKillsUpdated;

                completed = true;

                OnCompleted?.Invoke();
            }
        }
    }
}
