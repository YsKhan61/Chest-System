using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CS.UI
{
    /// <summary>
    /// The class that represents the view of the popup panel in UI
    /// </summary>
    public class PopupView : MonoBehaviour
    {
        /// Used to set the animation's bool of the popup panel
        private const string PANEL_DOWN = "Panel_Down";


        [SerializeField, Tooltip("The text UI to display the message")]
        private TextMeshProUGUI m_MessageText;

        [SerializeField, Tooltip("The button to cancel the popup querry.")]
        private Button m_CancelButton;

        [SerializeField, Tooltip("The button to close the popup")]
        private Button m_OkButton;

        [SerializeField, Tooltip("The button to accept the popup querry")]
        private Button m_ConfirmButton;

        [SerializeField, Tooltip("The animator of this popup view")]
        private Animator m_Animator;


        /// <summary>
        /// This action is invoked when the querry buttons of popup panel is pressed.
        /// The parameter is true if the confirm button is pressed, false if the cancel button is pressed.
        /// </summary>
        public Action<bool> OnQuerryButtonPressed;

        /// <summary>
        /// This action is invoked when the OK button of popup panel is pressed.
        /// </summary>
        public Action OnOKButtonPressed;


        /// <summary>
        /// This method is called to set a querry message(yes/no) to the popup panel.
        /// It will show the confirm and cancel button.
        /// On the confirm button pressed, the OnQuerryButtonPressed action will be invoked with true parameter.
        /// On the cancel button pressed, the OnQuerryButtonPressed action will be invoked with false parameter.
        /// </summary>
        /// <param name="message">the querry message to display</param>
        public void ShowQuerry(string message)
        {
            m_Animator.SetBool(PANEL_DOWN, true);
            m_CancelButton.gameObject.SetActive(true);
            m_OkButton.gameObject.SetActive(false);
            m_ConfirmButton.gameObject.SetActive(true);
            m_MessageText.text = message;

            UIAudioService.Instance.PlayAudio(UIAudioService.AudioType.Popup);
        }


        /// <summary>
        /// This method is called to set a message to the popup panel.
        /// It will show the OK button.
        /// On the OK button pressed, the OnOKButtonPressed action will be invoked.
        /// </summary>
        /// <param name="message">the message to display</param>
        public void ShowMessage(string message)
        {
            m_Animator.SetBool(PANEL_DOWN, true);
            m_CancelButton.gameObject.SetActive(false);
            m_OkButton.gameObject.SetActive(true);
            m_ConfirmButton.gameObject.SetActive(false);
            m_MessageText.text = message;

            UIAudioService.Instance.PlayAudio(UIAudioService.AudioType.Popup);
        }


        /// <summary>
        /// Invoked from the confirm and cancel button's OnButtonPressed in inspector UI
        /// </summary>
        /// <param name="isConfirmed"></param>
        public void QuerryButtonPressed(bool isConfirmed)
        {
            m_Animator.SetBool(PANEL_DOWN, false);
            m_MessageText.text = "";
            OnQuerryButtonPressed?.Invoke(isConfirmed);

            UIAudioService.Instance.PlayAudio(UIAudioService.AudioType.Popup);
        }


        /// <summary>
        /// Invoked from the OK button's OnButtonPressed in inspector UI
        /// </summary>
        public void OKButtonPressed()
        {
            m_Animator.SetBool(PANEL_DOWN, false);
            m_MessageText.text = "";
            OnOKButtonPressed?.Invoke();

            UIAudioService.Instance.PlayAudio(UIAudioService.AudioType.Popup);
        }
    }
}

