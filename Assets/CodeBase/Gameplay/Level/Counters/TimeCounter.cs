using UnityEngine;

namespace CodeBase.Gameplay.Level
{
    public class TimeCounter : MonoBehaviour, ICounter
    {
        private float currentTime;
        public int CountedValue => (int) currentTime;

        private void Update()
        {
            currentTime += Time.deltaTime;
        }
    }
}
