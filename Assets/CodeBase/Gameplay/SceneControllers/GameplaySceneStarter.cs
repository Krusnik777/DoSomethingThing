using CodeBase.Gameplay.Hero;
using CodeBase.Data;
using UnityEngine;
using UnityEngine.Events;

namespace CodeBase.Gameplay
{
    public class GameplaySceneStarter : SceneStarter
    {
        [SerializeField] private GameplayController m_gameplayController;
        [SerializeField] private HeroInput m_heroInput;

        public event UnityAction EventOnSceneLaunch;

        public override void LaunchScene()
        {
            EventOnSceneLaunch?.Invoke();
        }

        public void StartGame()
        {
            m_heroInput.enabled = true;

            if (GlobalController.Instance != null)
                m_gameplayController.Init(GlobalController.PlayerProgress);
            else
                m_gameplayController.Init(new PlayerProgress());
        }
    }
}
