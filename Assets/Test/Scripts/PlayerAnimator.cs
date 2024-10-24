using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private const string _IsMoving = "IsMoving";
    private const float _MovementThreshold = 0.05f;

    [SerializeField] private Animator m_animator;
    [SerializeField] private PlayerController m_playerController;

    private void Update()
    {
        m_animator.SetBool(_IsMoving, m_playerController.DirectionInput.magnitude >= _MovementThreshold);
    }
}
