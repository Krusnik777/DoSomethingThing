using UnityEngine;

namespace CodeBase
{
    public abstract class SceneStarter : MonoBehaviour
    {
        public static SceneStarter Instance;

        public abstract void LaunchScene();

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(this);
                return;
            }

            Instance = this;
        }
    }
}
