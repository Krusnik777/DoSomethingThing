using UnityEngine;

namespace CodeBase.Gacha
{
    public class GachaSpawner : MonoBehaviour
    {
        [SerializeField] private CubeArea m_spawnArea;
        [SerializeField] private GachaPickup[] m_pickups;
        [SerializeField] private int m_spawnNumber;

        public void SpawnPickups()
        {
            if (m_pickups.Length == 0) return;

            for (int i = 0; i < m_spawnNumber; i++)
            {
                GachaPickup pickup = GetRandomGacha();

                Vector3 position = m_spawnArea.GetRandomInsideZone();

                Instantiate(pickup, position, Quaternion.identity);
            }
        }

        private GachaPickup GetRandomGacha()
        {
            return m_pickups[Random.Range(0, m_pickups.Length)];
        }

    }
}
