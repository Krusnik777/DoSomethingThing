using UnityEngine;
using UnityEngine.Events;

namespace CodeBase.Gacha.Claw
{
    public class ClawMovement : MonoBehaviour
    {
        [SerializeField] private float m_movementSpeed;
        [SerializeField] private float m_descentSpeed;
        [SerializeField] private float m_leftMovementBound = -4f;
        [SerializeField] private float m_rightMovementBound = 4f;
        [SerializeField] private float m_descentMovementBound = -2.5f;

        public event UnityAction EventOnDescentEnd;

        private Vector2 directionControl;
        public Vector2 DirectionControl => directionControl;

        private bool descending;

        public void StartDescend()
        {
            descending = true;
        }

        public void SetMoveDirection(Vector2 moveDirection)
        {
            directionControl = moveDirection;
            directionControl.Normalize();
        }

        private void Update()
        {
            if (descending)
            {
                if (transform.position.y <= m_descentMovementBound)
                {
                    descending = false;

                    EventOnDescentEnd?.Invoke();

                    enabled = false;

                    return;
                }

                transform.position += new Vector3(0, m_descentSpeed * -1 * Time.deltaTime, 0);

                return;
            }

            if (directionControl.magnitude > 0)
            {
                if (directionControl.x < 0 && transform.position.x <= m_leftMovementBound
                    || directionControl.x > 0 && transform.position.x >= m_rightMovementBound)
                    return;

                transform.position += new Vector3(m_movementSpeed * directionControl.x * Time.deltaTime, 0, 0);
            }
        }
    }
}
