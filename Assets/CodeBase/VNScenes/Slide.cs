using UnityEngine;


namespace CodeBase.VNScenes
{
    [CreateAssetMenu]
    public class Slide : ScriptableObject
    {
        /// <summary>
        /// slide of showing slide in seconds
        /// </summary>
        public float slideTime = 5f;
        /// <summary>
        /// text of this slide
        /// </summary>
        [TextArea(1,5)] public string text;
        /// <summary>
        /// image of this slide
        /// </summary>
        public Sprite sprite;
    }
}