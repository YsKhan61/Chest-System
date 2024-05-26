using CS.ChestSystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace CS.UI
{
    /// <summary>
    /// This script is used to represent the view of the chest slot in UI
    /// If the slot is empty, When the button is clicked, it creates a chest in the slot
    /// </summary>
    public class ChestSlotView : MonoBehaviour
    {
        private const string TAP_TO_GET = "Tap to get!";

        /// <summary>
        /// States of the Chest Slot
        /// Empty - No chest in the slot
        /// Locked - Chest is in the slot but locked
        /// Unlocking - Chest is in the slot and unlocking
        /// UnlockingPaused - Chest is in the slot and unlocking but paused
        /// Unlocked - Chest is in the slot and unlocked and ready to collect
        /// </summary>
        public enum State
        {
            Empty,
            Locked,
            Unlocking,
            UnlockingPaused,
            Unlocked
        }


        [SerializeField, Tooltip("The button to access chest!")]
        private Button m_ChestSlotButton;

        [SerializeField, Tooltip("The text of the button")]
        private TextMeshProUGUI m_ChestSlotButtonText;

        private ChestController m_Chest;
        public ChestController Chest => m_Chest;

        private ChestService m_ChestService;
        private State m_CurrentState;
        private float m_TimeElapsed;


        private void Update()
        {
            switch (m_CurrentState)
            {
                case State.Unlocking:
                    if (m_TimeElapsed >= m_Chest.Data.OpenTime)
                    {
                        EnterUnlockedState();
                        return;
                    }
                    m_TimeElapsed += Time.deltaTime;
                    m_Chest.UpdateTimer(m_TimeElapsed);
                    m_Chest.UpdateCost(m_TimeElapsed);
                    break;
            }
        }


        /// <summary>
        /// Set the chest service
        /// </summary>
        public void SetChestService(ChestService service) => m_ChestService = service;


        /// <summary>
        /// Enter the Empty state
        /// </summary>
        public void EnterEmptyState()
        {
            m_CurrentState = State.Empty;
            m_ChestSlotButtonText.text = TAP_TO_GET;
            m_TimeElapsed = 0;
        }


        /// <summary>
        /// Enter the Unlocked state
        /// </summary>
        public void EnterUnlockedState()
        {
            m_CurrentState = State.Unlocked;
            m_Chest.EnterUnlockedState();

            UIAudioService.Instance.PlayAudio(UIAudioService.AudioType.ChestUnlocked);
        }


        /// <summary>
        /// Resume the unlocking of the chest
        /// </summary>
        public void ResumeUnlocking()
        {
            m_CurrentState = State.Unlocking;
        }


        /// <summary>
        /// This method is called when the button is clicked
        /// </summary>
        public void OnChestSlotButtonClicked()
        {
            UIAudioService.Instance.PlayAudio(UIAudioService.AudioType.Button);

            switch (m_CurrentState)
            {
                case State.Empty:
                    OnChestSlotButtonClickedOnEmptyState();
                    break;

                case State.Locked:
                    OnChestSlotButtonClickedOnLockedState();
                    break;

                case State.Unlocking:
                    OnChestSlotButtonClickedOnUnlockingState();
                    break;

                case State.Unlocked:
                    OnChestSlotButtonClickedOnUnlockedState();
                    break;
            }
        }


        private void CreateChestAndLockIt()
        {
            // Create
            m_Chest = m_ChestService.CreateChest();
            m_Chest.SpawnView(transform);

            // Lock
            m_Chest.EnterLockedState();
        }

        private void OnChestSlotButtonClickedOnEmptyState()
        {
            CreateChestAndLockIt();
            m_ChestSlotButton.transform.SetAsLastSibling();
            m_ChestSlotButtonText.text = "";
            m_CurrentState = State.Locked;
        }


        private void OnChestSlotButtonClickedOnLockedState()
        {
            if (m_ChestService.IsUnlockingChest)
                return;

            m_ChestService.SetUnlockingChestSlot(this);
            m_Chest.EnterUnlockingState();
            m_CurrentState = State.Unlocking;
        }

        private void OnChestSlotButtonClickedOnUnlockingState()
        {
            string message = $"Do you want to unlock the chest in advance for {m_Chest.CurrentCost} coins?";
            m_CurrentState = State.UnlockingPaused;
            m_ChestService.SetPopupQuerryToUnlockInAdvanced(message);
        }

        private void OnChestSlotButtonClickedOnUnlockedState()
        {
            m_ChestService.CollectChest(m_Chest);
            m_Chest = null;
            EnterEmptyState();
        }
    }

}