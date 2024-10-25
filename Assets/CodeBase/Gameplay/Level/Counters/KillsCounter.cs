using UnityEngine.Events;

namespace CodeBase.Gameplay.Level
{
    public class KillsCounter : ICounter
    {
        public event UnityAction<int> EventOnKillsUpdated;

        private int currentKills;
        public int CountedValue => currentKills;

        public KillsCounter()
        {
            currentKills = 0;
        }

        public void UpdateKills()
        {
            currentKills++;

            EventOnKillsUpdated?.Invoke(currentKills);
        }
    }
}
