using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace CodeBase.Gameplay.Level
{
    public class TimeCondition : MonoBehaviour, ILevelCondition
    {
        [SerializeField] private float m_targetTime;

        public event UnityAction OnCompleted;

        private TimeCounter timeCounter;

        public float RemainingTime => m_targetTime - timeCounter.CountedValue;
        public bool Completed => RemainingTime <= 0;

        public void Init(GameplayController gameplayController)
        {
            timeCounter = gameplayController.TimeCounter;

            StartCoroutine(UpdateTimeRoutine());
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
