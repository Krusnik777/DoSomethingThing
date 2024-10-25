using UnityEngine;

namespace CodeBase.Gameplay.Hero
{
    public class HeroInput : MonoBehaviour
    {
        [SerializeField] private HeroMovement m_heroMovement;

        private Vector3 _input;

        private void Update()
        {
            _input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

            m_heroMovement.SetMoveDirection(_input);
        }
    }
}