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

        [SerializeField, Tooltip("The cost panel that shows the cost to open the chest in advance!")]
        private GameObject m_CostPanel;

        [SerializeField, Tooltip("The panel that shows the cost to open the chest in advance!")]
        private TextMeshProUGUI m_CostText;



        /// <summary>
        /// Set the sprite of the chest image
        /// </summary>
        public void SetChestImageSprite(Sprite sprite) => m_ChestImage.sprite = sprite;
    

        /// <summary>
        /// Set the time needed to open the chest
        /// </summary>
        public void SetTimeToUnlockText(string time) => m_TimeText.text = time;


        /// <summary>
        /// Set the time left to open the chest
        /// </summary>
        public void SetTimeLeftText(string time) => m_TimeLeftText.text = time;


        /// <summary>
        /// Set the progress of the slider
        /// </summary>
        public void SetProgressSlider(float value) => m_ProgressSlider.value = value;


        /// <summary>
        /// Toggle the time text
        /// </summary>
        public void ToggleTimeToUnlockText(bool value) => m_TimeText.gameObject.SetActive(value);


        /// <summary>
        /// Toggle the timer slider
        /// </summary>
        public void ToggleTimerSlider(bool value) => m_ProgressSlider.gameObject.SetActive(value);
    

        /// <summary>
        /// Toggle the cost panel
        /// </summary>
        /// <param name="value"></param>
        public void ToggleCostPanel(bool value) => m_CostPanel.SetActive(value);


        /// <summary>
        /// Set the current status of the chest
        /// </summary>
        public void SetStatus(string text) => m_StatusText.text = text;


        /// <summary>
        /// Set the cost text
        /// </summary>
        public void SetCostText(string costText) => m_CostText.text = costText;
    }
}