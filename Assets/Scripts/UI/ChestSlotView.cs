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

        public enum State
        {
            Empty,
            Locked,
            Unlocking,
            Unlocked
        }


        [SerializeField, Tooltip("The button to access chest!")]
        private Button m_ChestSlotButton;

        [SerializeField, Tooltip("The text of the button")]
        private TextMeshProUGUI m_ChestSlotButtonText;


        private ChestService m_ChestService;
        private ChestController m_Chest;
        private State m_CurrentState;

        private float m_TimeElapsed;

        private void Update()
        {
            switch(m_CurrentState)
            {
                case State.Empty:

                    break;

                case State.Locked:
                    
                    break;

                case State.Unlocking:
                    if (m_TimeElapsed >= m_Chest.Data.OpenTime)
                    {
                        m_CurrentState = State.Unlocked;
                        m_Chest.EnterUnlockedState();
                        return;
                    }
                    m_TimeElapsed += Time.deltaTime;
                    m_Chest.UpdateTimer(m_TimeElapsed);
                    break;

                case State.Unlocked:
                    
                    break;
            }
        }

        /// <summary>
        /// Set the chest service
        /// </summary>
        public void SetChestService(ChestService service) => m_ChestService = service;

        /// <summary>
        /// Start the slot in empty state
        /// </summary>
        public void StartEmptyState()
        {
            m_CurrentState = State.Empty;
            m_ChestSlotButtonText.text = TAP_TO_GET;
            m_TimeElapsed = 0;
        }

        /// <summary>
        /// This method is called when the button is clicked
        /// </summary>
        public void OnChestSlotButtonClicked()
        {
            switch (m_CurrentState)
            {
                case State.Empty:
                    CreateChestAndLockIt();
                    m_ChestSlotButton.transform.SetAsLastSibling();
                    m_ChestSlotButtonText.text = "";
                    m_CurrentState = State.Locked;
                    break;

                case State.Locked:
                    m_Chest.EnterUnlockingState();
                    m_CurrentState = State.Unlocking;
                    break;

                case State.Unlocking:
                    break;

                case State.Unlocked:
                    m_ChestService.CollectChest(m_Chest);
                    m_Chest = null;
                    StartEmptyState();
                    break;
            }
        }

        /// <summary>
        /// This method is called to clear the slot
        /// </summary>
        public void CLearSlot()
        {
            m_Chest = null;
            m_ChestSlotButton.gameObject.SetActive(true);
        }

        private void CreateChestAndLockIt()
        {
            // Create
            m_Chest = m_ChestService.CreateChest();
            m_Chest.SpawnView(transform);

            // Lock
            m_Chest.EnterLockedState();
        }
    }
}