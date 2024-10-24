using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceShooter;
using UnityEngine.SceneManagement;


namespace CodeBase
{
    public class SceneLoader : MonoSingleton<SceneLoader>
    {
        /// <summary>
        /// load scene by name
        /// </summary>
        /// <param name="sceneName"></param>
        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
        /// <summary>
        /// load scene by index
        /// </summary>
        /// <param name="sceneName"></param>
        public void LoadScene(int index)
        {
            SceneManager.LoadScene(index);
        }



        /// <summary>
        /// quit game
        /// </summary>
        public void QuitGame()
        {
            Application.Quit();
        }

    }
}