using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace CodeBase.Gameplay.Level
{
    public class TimeCondition : MonoBehaviour, ILevelCondition
    {
        [SerializeField] private float m_targetTime;
        [SerializeField] private float[] m_infiniteModeTimes;

        public event UnityAction OnCompleted;

        private TimeCounter timeCounter;

        public float RemainingTime => m_targetTime - timeCounter.CountedValue;
        public bool Completed => RemainingTime <= 0;

        public int TargetValue => (int) (m_targetTime);

        public void Init(GameplayController gameplayController)
        {
            timeCounter = gameplayController.TimeCounter;

            StartCoroutine(UpdateTimeRoutine());
        }

        private void Start()
        {
            if (GlobalController.Instance == null) return;

            if (GlobalController.GameMode != GameMode.Infinite) return;

            int randomTimeId = Random.Range(0, m_infiniteModeTimes.Length);

            m_targetTime = m_infiniteModeTimes[randomTimeId];
        }

        private IEnumerator UpdateTimeRoutine()
        {
            while (RemainingTime > 0)
            {
                yield return null;
            }

            OnCompleted?.Invoke();
        }
    }
}
