using CS.ChestSystem;
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
        public enum State
        {
            Empty,
            Locked,
            Unlocking,
            Unlocked
        }


        [SerializeField, Tooltip("The button that shows up when there is no chest in the slot!")]
        private Button m_EmptySlotButton;

        [SerializeField, Tooltip("The Chest Factory Contianer")]
        private ChestFactoryContainerSO m_ChestFactoryContainer;

        private ChestController m_Chest;
        private State m_CurrentState;

        private float m_TimeElapsed;

        private void OnEnable()
        {
            m_ChestFactoryContainer.Initialize();
            m_CurrentState = State.Empty;
        }

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

        private void OnDisable()
        {
            m_ChestFactoryContainer.ResetContainer();
        }

        /// <summary>
        /// This method is called when the button is clicked
        /// </summary>
        public void OnEmptySlotButtonClicked()
        {
            CreateChestAndLockIt();
            m_EmptySlotButton.gameObject.SetActive(false);
            m_CurrentState = State.Locked;
        }

        /// <summary>
        /// This method is called to clear the slot
        /// </summary>
        public void CLearSlot()
        {
            m_Chest = null;
            m_EmptySlotButton.gameObject.SetActive(true);
        }

        private void CreateChestAndLockIt()
        {
            // Create
            m_Chest = m_ChestFactoryContainer.GetRandomChest();
            m_Chest.SpawnView(transform);

            // Lock
            m_Chest.EnterLockedState();
        }
    }
}