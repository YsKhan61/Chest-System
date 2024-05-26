using CS.Utilities;
using System;
using TMPro;
using UnityEngine;

namespace CS.Utilities
{
    /// <summary>
    /// An UI script that displays data from a data container into a TextMeshProUGUI.
    /// </summary>
    /// <typeparam name="T">Type of the data container</typeparam>
    /// <typeparam name="U">Type of the struct</typeparam>
    public class ViewDataFromDataContainer<T, U> : MonoBehaviour where T : GenericDataContainerSO<U> where U : struct
    {
        [SerializeField, Tooltip("Text to display the data")]
        private TextMeshProUGUI m_Text;

        [SerializeField, Tooltip("The data container to read the data from")]
        private T m_DataContainer;

        private void OnEnable()
        {
            m_DataContainer.OnDataChanged += OnDataChanged;
        }

        private void OnDisable()
        {
            m_DataContainer.OnDataChanged -= OnDataChanged;
        }

        private void OnDataChanged()
        {
            m_Text.text = m_DataContainer.Data.ToString();
        }
    }

}
