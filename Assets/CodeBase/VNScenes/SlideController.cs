using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace CodeBase.VNScenes
{
    public class SlideController : MonoBehaviour
    {
        /// <summary>
        /// defines the switch slide mode
        /// </summary>
        private enum SwitchSlideMode
        {
            /// <summary>
            /// switch by pressing any key
            /// </summary>
            player,
            /// <summary>
            /// switching by time
            /// </summary>
            time
        }

        [Header("General Settings")]
        [SerializeField] private Slide[] slides;
        [SerializeField] private string nextSceneName = "next scene name";
        [SerializeField] private SwitchSlideMode switchMode;
        [Header("Links")]
        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private Image background;


        private float timer;
        private int currentSlideIndex;

        private void Start()
        {
            currentSlideIndex = 0;
            Use(slides[currentSlideIndex]);
        }


        private void Update()
        {

            if (switchMode == SwitchSlideMode.time)
            {
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    currentSlideIndex++;
                    CheckNextSlide();
                }
            }
            if (switchMode == SwitchSlideMode.player)
            {
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    currentSlideIndex++;
                }
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    currentSlideIndex--;
                }
                currentSlideIndex = Mathf.Max(0, currentSlideIndex);
                CheckNextSlide();
            }

            
        }

        private void CheckNextSlide()
        {
            if (currentSlideIndex >= slides.Length)
            {
                LoadNextScene();
            }
            else
            {
                Use(slides[currentSlideIndex]);
            }
        }




        private void LoadNextScene()
        {
            SceneLoader.Instance?.LoadScene(nextSceneName);
        }



        /// <summary>
        /// apply current slide
        /// </summary>
        /// <param name="slide"></param>
        private void Use(Slide slide)
        {
            ResetTimer(slide.slideTime);
            text.text = slide.text;
            background.sprite = slide.sprite;

        }

        /// <summary>
        /// reset timer, set slide time
        /// </summary>
        /// <param name="slideTime"></param>
        private void ResetTimer(float slideTime)
        {
            timer = slideTime;
        }


    }
}