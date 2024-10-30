using UnityEngine;

namespace CodeBase.Gacha.Claw
{
    public class ClawInput : MonoBehaviour
    {
        [SerializeField] private ClawMovement m_clawMovement;

        private Vector3 _input;

        private void OnEnable()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void OnDisable()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        private void Update()
        {
            if (Input.GetButtonDown("Cancel"))
            {
                GlobalController.Instance.LoadStartScene();

                return;
            }

            if (Input.GetButtonDown("Jump"))
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
