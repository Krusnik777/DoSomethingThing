using UnityEngine.Events;

namespace CodeBase.Gameplay.Hero
{
    public interface IAttack
    {
        public float Cooldown { get; }
        public float Radius { get; }
        public bool ReadyToAttack { get; }
        public bool InCooldown { get; }

        public event UnityAction EventOnCooldownStart;
    }
}
