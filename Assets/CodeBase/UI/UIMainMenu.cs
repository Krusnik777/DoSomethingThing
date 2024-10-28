using CodeBase;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace CodeBase.UI
{
    public class UIMainMenu : MonoBehaviour
    {
        public void StartGame()
        {
            SceneLoader.Instance.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }


        /// <summary>
        /// quit game
        /// </summary>
        public void QuitGame()
        {
            SceneLoader.Instance.QuitGame();
        }
    }
}