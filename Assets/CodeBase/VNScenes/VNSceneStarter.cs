using UnityEngine;

namespace CodeBase.VNScenes
{
    public class VNSceneStarter : SceneStarter
    {
        [SerializeField] private SlideController m_slideController;

        public override void LaunchScene()
        {
            // DO SOMETHING - for example setup music
            m_slideController.enabled = true;
        }
    }
}
