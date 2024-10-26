using CodeBase.Configs;
using UnityEngine;
using UnityEngine.Events;

namespace CodeBase.Gacha.Claw
{
    public class ClawCollector : MonoBehaviour
    {
        [SerializeField] private ClawMovement m_clawMovement;
        [SerializeField] private float m_distance = 1f;

        public event UnityAction<WeaponConfig> EventOnClawPicked;

        private void Update()
        {
            Debug.DrawRay(transform.position, -transform.up * m_distance, Color.red);

            CheckForPickup();
        }

        private void CheckForPickup()
        {
            Ray rayChecker = new Ray(transform.position, -transform.up * m_distance);

            if (Physics.Raycast(rayChecker, out RaycastHit hit, m_distance))
            {
                if (hit.collider != null)
                {
                    GachaPickup pickup = hit.collider.GetComponent<GachaPickup>();

                    if (pickup != null)
                    {
                        pickup.GetItem(out WeaponConfig config);

                        m_clawMovement.enabled = false;

                        EventOnClawPicked?.Invoke(config);

                        enabled = false;
                    }
                }
            }
        }
    }
}
