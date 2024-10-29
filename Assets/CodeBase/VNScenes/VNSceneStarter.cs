using UnityEngine;

namespace CodeBase.VNScenes
{
    public class VNSceneStarter : SceneStarter
    {
        [SerializeField] private SlideController m_slideController;
        [SerializeField] private int m_sceneNumber;

        public override void LaunchScene()
        {
            GlobalController.BGMController.StartPlayVNTheme(m_sceneNumber);
            m_slideController.enabled = true;
        }
    }
}
