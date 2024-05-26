using CS.Utilities;
using UnityEngine;

namespace CS.UI
{
    [RequireComponent(typeof(AudioSource))]
    public class UIAudioService : GenericSingleton<UIAudioService>
    {
        public enum AudioType
        {
            Button,
            ChestOpen,
            Success,
            Fail,
            Popup,
            ChestUnlocked
        }

        [SerializeField, Tooltip("The audio clip that plays the button sound!")]
        private AudioClip m_ButtonClip;

        [SerializeField, Tooltip("The audio clip that plays when the chest is unlocked!")]
        private AudioClip m_ChestUnlockedClip;

        [SerializeField, Tooltip("The audio clip that plays the chest open sound!")]
        private AudioClip m_ChestOpenClip;

        [SerializeField, Tooltip("The audio clip that plays the success sound!")]
        private AudioClip m_SuccessClip;

        [SerializeField, Tooltip("The audio clip that plays the fail sound!")]
        private AudioClip m_FailClip;

        [SerializeField, Tooltip("The audio clip that plays for popup")]
        private AudioClip m_PopupClip;


        private AudioSource m_AudioSource;

        private void Awake()
        {
            m_AudioSource = GetComponent<AudioSource>();
            m_AudioSource.loop = false;
            m_AudioSource.playOnAwake = false;
        }

        public void PlayAudio(AudioType type)
        {
            switch (type)
            {
                case AudioType.Button:
                    m_AudioSource.PlayOneShot(m_ButtonClip);
                    break;
                case AudioType.ChestUnlocked:
                    m_AudioSource.PlayOneShot(m_ChestUnlockedClip);
                    break;
                case AudioType.ChestOpen:
                    m_AudioSource.PlayOneShot(m_ChestOpenClip);
                    break;
                case AudioType.Success:
                    m_AudioSource.PlayOneShot(m_SuccessClip);
                    break;
                case AudioType.Fail:
                    m_AudioSource.PlayOneShot(m_FailClip);
                    break;
                case AudioType.Popup:
                    m_AudioSource.PlayOneShot(m_PopupClip);
                    break;
            }
        }
    }

}