using UnityEngine;

namespace CodeBase.Gameplay.Enemy
{
    public class EnemyAnimator : MonoBehaviour
    {
        private const string _IsMoving = "IsMoving";

        [SerializeField] private Animator m_animator;

        public void SetMove(bool move)
        {
            m_animator.SetBool(_IsMoving, move);
        }
    }
}
