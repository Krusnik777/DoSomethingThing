using CodeBase.Gameplay.Hero;
using CodeBase.Data;
using UnityEngine;

namespace CodeBase.Gameplay
{
    public class GameplaySceneStarter : SceneStarter
    {
        [SerializeField] private GameplayController m_gameplayController;
        [SerializeField] private HeroInput m_heroInput;

        public override void LaunchScene()
        {
            // DO "DAY number" anim for example
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
