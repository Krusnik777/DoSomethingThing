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
            GlobalController.BGMController.StartPlayStartSceneBGM();

            EventOnSceneLaunch?.Invoke();
        }

        public void StartGame()
        {
            m_heroInput.enabled = true;

            GlobalController.BGMController.StartPlayRandomBGM();

            if (GlobalController.Instance != null)
                m_gameplayController.Init(GlobalController.PlayerProgress);
            else
                m_gameplayController.Init(new PlayerProgress());
        }
    }
}
