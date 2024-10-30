using UnityEngine;

namespace CodeBase.Gameplay.Hero
{
    public class HeroInput : MonoBehaviour
    {
        [SerializeField] private HeroMovement m_heroMovement;

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

            _input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

            m_heroMovement.SetMoveDirection(_input);
        }
    }
}