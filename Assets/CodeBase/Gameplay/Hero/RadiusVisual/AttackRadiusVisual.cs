using UnityEngine;

namespace CodeBase.Gameplay.Hero
{
    public class AttackRadiusVisual : MonoBehaviour
    {
        [SerializeField] private LineRenderer m_lineRenderer;
        [SerializeField] private int m_subdivisions = 10;
        [SerializeField] private float m_radius = 2f;

        public void SetRadius(float radius) => m_radius = radius;

        private void Update()
        {
            float angleStep = 2f * Mathf.PI / m_subdivisions;

            m_lineRenderer.positionCount = m_subdivisions;

            for (int i = 0; i < m_subdivisions; i++)
            {
                float xPos = m_radius * Mathf.Cos(angleStep * i);
                float zPos = m_radius * Mathf.Sin(angleStep * i);

                Vector3 pointInCircle = new Vector3(xPos, 0f, zPos);

                m_lineRenderer.SetPosition(i, pointInCircle);
            }
        }
    }
}
