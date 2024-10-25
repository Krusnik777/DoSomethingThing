using UnityEngine;

namespace CodeBase.Gameplay.Hero
{
    public class HeroMovement : MonoBehaviour
    {
        [SerializeField] private CharacterController m_characterController;
        [SerializeField] private Transform m_viewTransform;
        [SerializeField] private float m_movementSpeed;
        [SerializeField] private bool m_doMovementByDirection = true;

        private Vector3 directionControl;
        public Vector3 DirectionControl => directionControl;

        public void SetMoveDirection(Vector3 moveDirection)
        {
            directionControl = moveDirection;
            if (m_doMovementByDirection) directionControl = directionControl.ToIsometric();
            directionControl.Normalize();
        }

        private void Update()
        {
            if (directionControl.magnitude > 0)
            {
                m_characterController.Move(directionControl * m_movementSpeed * Time.deltaTime);
                m_viewTransform.rotation = Quaternion.LookRotation(directionControl);
            }
            else
            {
                m_characterController.Move(Vector3.zero);
            }
        }
    }
}
