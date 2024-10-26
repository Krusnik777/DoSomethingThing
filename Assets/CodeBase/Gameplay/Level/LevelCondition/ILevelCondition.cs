using UnityEngine.Events;

namespace CodeBase.Gameplay.Level
{
    public interface ILevelCondition
    {
        public event UnityAction OnCompleted;
        public bool Completed { get; }
        public int TargetValue { get; }
        public void Init(GameplayController gameplayController);
    }
}
