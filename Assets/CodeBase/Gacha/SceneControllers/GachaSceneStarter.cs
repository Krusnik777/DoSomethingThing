using CodeBase.Gacha.Claw;
using UnityEngine;

namespace CodeBase.Gacha
{
    public class GachaSceneStarter : SceneStarter
    {
        [SerializeField] private GachaController m_gachaController;
        [SerializeField] private ClawInput m_clawInput;

        public override void LaunchScene()
        {
            // DO some greetings for example
        }

        public void StartGacha()
        {
            m_gachaController.Init();
            m_clawInput.enabled = true;
        }
    }
}
