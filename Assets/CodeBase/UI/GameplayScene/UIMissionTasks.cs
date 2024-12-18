using CodeBase.Gameplay.Level;
using System;
using TMPro;
using UnityEngine;

namespace CodeBase.UI
{
    public class UIMissionTasks : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI m_defeatEnemiesTaskText;
        [SerializeField] private TextMeshProUGUI m_surviveTaskText;
        [SerializeField] private GameObject m_levelConditions;

        public void Setup()
        {
            var conditions = m_levelConditions.GetComponentsInChildren<ILevelCondition>();

            for (int i = 0; i < conditions.Length; i++)
            {
                if (conditions[i] is DefeatEnemiesCondition)
                {
                    m_defeatEnemiesTaskText.text = $"�������� ������: {conditions[i].TargetValue}";
                    m_defeatEnemiesTaskText.gameObject.SetActive(true);
                }

                if (conditions[i] is TimeCondition)
                {
                    var time = TimeSpan.FromSeconds(conditions[i].TargetValue);
                    m_surviveTaskText.text = $"������ ������������ �����: {time.ToString(@"mm\:ss")}";
                    m_surviveTaskText.gameObject.SetActive(true);
                }
            }
        }

    }
}
