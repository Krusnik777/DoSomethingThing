using CodeBase.Gacha.Claw;
using UnityEngine;
using UnityEngine.Events;

namespace CodeBase.Gacha
{
    public class GachaSceneStarter : SceneStarter
    {
        [SerializeField] private GachaController m_gachaController;
        [SerializeField] private ClawInput m_clawInput;

        public event UnityAction EventOnSceneLaunch;

        public override void LaunchScene()
        {
            GlobalController.BGMController.StartPlayGachaSceneBGM();

            EventOnSceneLaunch?.Invoke();
        }

        public void StartGacha()
        {
            m_gachaController.Init();
            m_clawInput.enabled = true;
        }
    }
}
