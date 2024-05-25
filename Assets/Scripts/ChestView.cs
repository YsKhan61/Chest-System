using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CS.UI
{
    /// <summary>
    /// This script is used to represent the view of the chest in UI
    /// </summary>
    public class ChestView : MonoBehaviour
    {
        [SerializeField, Tooltip("The button that shows up when there is no chest in the slot!")]
        private Button m_EmptySlotButton;

        [SerializeField, Tooltip("The button that shows up when there is a chest in the slot!")]
        private Button m_ChestSlotButton;

        [SerializeField, Tooltip("The image of the chest in the slot!")]
        private Image m_ChestImage;

        [SerializeField, Tooltip("The text that shows the time needed to open the chest!")]
        private TextMeshProUGUI m_TimeText;

        [SerializeField, Tooltip("The slider that shows the progress of the chest opening!")]
        private Slider m_ProgressSlider;

        [SerializeField, Tooltip("The text that shows the time left to open the chest!")]
        private TextMeshProUGUI m_TimeLeftText;

        [SerializeField, Tooltip("The status of the Chest!")]
        private TextMeshProUGUI m_StatusText;

        [SerializeField, Tooltip("The panel that shows the cost to open the chest in advance!")]
        private TextMeshProUGUI m_CostText;
    }
}