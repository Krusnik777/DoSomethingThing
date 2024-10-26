using CodeBase.Audio;
using CodeBase.Data;
using CodeBase.Settings;
using UnityEngine;
using UnityEngine.Events;

namespace CodeBase
{
    public class GlobalController : MonoBehaviour
    {
        public static GlobalController Instance { get; private set; }

        [SerializeField] private SceneLoader m_sceneLoader;
        [Header("SoundControllers")]
        [SerializeField] private SoundVolumeController m_soundVolumeController;
        [SerializeField] private SFXController m_sFXController;
        [SerializeField] private BGMController m_bGMController;
        [Header("LoadingCanvas")]
        [SerializeField] private GameObject m_loadingCanvas;

        private PlayerProgress playerProgress;

        public static PlayerProgress PlayerProgress => Instance.playerProgress;
        public static SoundVolumeController SoundVolumeController => Instance.m_soundVolumeController;
        public static SFXController SFXController => Instance.m_sFXController;
        public static BGMController BGMController => Instance.m_bGMController;

        private event UnityAction onStartMenuLoaded;
        private event UnityAction onNewSceneLoaded;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(this);
                return;
            }

            Instance = this;

            DontDestroyOnLoad(this);
        }

        private void Start()
        {
            Bootstrap();
        }

        private void Bootstrap()
        {
            m_soundVolumeController.Init();
            m_sFXController.Init();
            m_bGMController.Init();

            LoadStartScene();
        }

        public void LoadStartScene()
        {
            onStartMenuLoaded += OnStartMenuLoaded;

            m_loadingCanvas.SetActive(true);

            m_sceneLoader.Load(Constants.StartSceneName, onStartMenuLoaded);
        }

        public void LoadGachaScene()
        {
            onNewSceneLoaded += OnNewSceneLoaded;

            m_loadingCanvas.SetActive(true);

            m_sceneLoader.Load(Constants.GachaSceneName, onNewSceneLoaded);
        }

        public void LoadScene(string sceneName)
        {
            onNewSceneLoaded += OnNewSceneLoaded;

            m_loadingCanvas.SetActive(true);

            m_sceneLoader.Load(sceneName, onNewSceneLoaded);
        }

        private void OnNewSceneLoaded()
        {
            onNewSceneLoaded -= OnNewSceneLoaded;

            m_loadingCanvas.SetActive(false);

            if (SceneStarter.Instance != null) SceneStarter.Instance.LaunchScene();
        }

        private void OnStartMenuLoaded()
        {
            onStartMenuLoaded -= OnStartMenuLoaded;

            playerProgress = new PlayerProgress();

            m_bGMController.StartPlayStartMenuBGM();

            m_loadingCanvas.SetActive(false);
        }
    }
}
