namespace CodeBase
{
    public class Constants
    {
        public static string BootstrapSceneName = "BootstrapScene";

        public static string StartSceneName = "StartMenuScene";

        public static string VN_StartSceneName = "VN_StartScene";
        public static string VN_GameOverSceneName = "VN_GameOverScene";
        public static string VN_GameEndSceneName = "VN_GameEndScene";

        public static string GachaSceneName = "GachaScene";

        private static GameplaySceneNames gameplaySceneNames = new GameplaySceneNames();

        public static string GetSceneNameByDay(int day) => gameplaySceneNames.GetNextGameplayScene(day);
    }

    public class GameplaySceneNames
    {
        private string Gameplay1SceneName = "Day1GameplayScene";
        private string Gameplay2SceneName = "Day2GameplayScene";
        private string Gameplay3SceneName = "Day3GameplayScene";

        public string GetNextGameplayScene(int day)
        {
            string name = string.Empty;

            switch(day)
            {
                case 1 : name = Gameplay1SceneName;
                    break;
                case 2 : name = Gameplay2SceneName;
                    break;
                case 3 : name = Gameplay3SceneName;
                    break;
                default : name = Gameplay1SceneName;
                    break;
            }

            return name;
        }
    }
}
