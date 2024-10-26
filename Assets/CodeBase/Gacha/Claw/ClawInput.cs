using UnityEngine;

namespace CodeBase.Gacha.Claw
{
    public class ClawInput : MonoBehaviour
    {
        [SerializeField] private ClawMovement m_clawMovement;

        private Vector3 _input;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_clawMovement.StartDescend();

                enabled = false;

                return;
            }

            _input = new Vector2(Input.GetAxisRaw("Horizontal"), 0);

            m_clawMovement.SetMoveDirection(_input);
        }
    }
}
