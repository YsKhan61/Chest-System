using CS.UI;
using CS.Utilities;
using UnityEngine;


namespace CS.ChestSystem
{
    public class ChestService : MonoBehaviour
    {
        [SerializeField, Tooltip("Store references of all the Chest Slot Views")]
        private ChestSlotView[] m_ChestSlotViews;

        [SerializeField, Tooltip("The Chest Factory Contianer")]
        private ChestFactoryContainerSO m_ChestFactoryContainer;

        [SerializeField, Tooltip("The popup panel that shows some messages!")]
        private PopupView m_PopupView;

        [SerializeField, Tooltip("The Data Container for Coins")]
        private IntDataContainerSO m_CoinsContainer;

        [SerializeField, Tooltip("The Data Container for Gems")]
        private IntDataContainerSO m_GemsContainer;


        private ChestSlotView m_UnlockingChestSlot;
        public bool IsUnlockingChest => m_UnlockingChestSlot != null;

        private void OnEnable()
        {
            m_ChestFactoryContainer.Initialize();
        }

        private void Start()
        {
            ResetDatas();
            InitializeChestSlots();
        }

        private void OnDisable()
        {
            m_ChestFactoryContainer.ResetContainer();
        }


        /// <summary>
        /// Get a random chest from the chest factory container
        /// </summary>
        public ChestController CreateChest() => m_ChestFactoryContainer.GetRandomChest();

        
        /// <summary>
        /// Set the slot that is unlocking a chest
        /// </summary>
        public void SetUnlockingChestSlot(ChestSlotView slot) => m_UnlockingChestSlot = slot;


        /// <summary>
        /// Collect the chest and destroy it
        /// </summary>
        public void CollectChest(ChestController m_Chest)
        {
            m_PopupView.ShowMessage("Chest Collected!");

            UIAudioService.Instance.PlayAudio(UIAudioService.AudioType.ChestOpen);

            AddCoins(m_Chest);
            AddGems(m_Chest);

            m_Chest.Destroy();
            m_UnlockingChestSlot = null;
        }


        /// <summary>
        /// Set the popup panel to show a querry message to unlock the chest in advance
        /// </summary>
        /// <param name="message"></param>
        public void SetPopupQuerryToUnlockInAdvanced(string message)
        {
            m_PopupView.ShowQuerry(message);
            m_PopupView.OnQuerryButtonPressed -= OnUnlockInAdvanceQuerryResponded;
            m_PopupView.OnQuerryButtonPressed += OnUnlockInAdvanceQuerryResponded;
        }


        private void OnUnlockInAdvanceQuerryResponded(bool isConfirmed)
        {
            if (isConfirmed)
            {
                if (m_UnlockingChestSlot.Chest.CurrentCost > m_CoinsContainer.Data)
                {
                    m_PopupView.ShowMessage("Not enough coins!");
                    m_UnlockingChestSlot.ResumeUnlocking();
                    return;
                }

                m_CoinsContainer.SetData(m_CoinsContainer.Data - m_UnlockingChestSlot.Chest.CurrentCost);
                m_UnlockingChestSlot.EnterUnlockedState();
            }
            else
            {
                m_UnlockingChestSlot.ResumeUnlocking();
            }
        }

        private void AddCoins(ChestController chest)
        {
            int coins = Random.Range(chest.Data.CoinRange.x, chest.Data.CoinRange.y);
            AddItems(coins, m_CoinsContainer);
        }

        private void AddGems(ChestController chest)
        {
            int gems = Random.Range(chest.Data.GemRange.x, chest.Data.GemRange.y);
            AddItems(gems, m_GemsContainer);
        }

        private void AddItems(int data, IntDataContainerSO container)
        {
            data += container.Data;
            container.SetData(data);
        }

        private void ResetDatas()
        {
            m_CoinsContainer.SetData(0);
            m_GemsContainer.SetData(0);
        }

        private void InitializeChestSlots()
        {
            foreach (var chestSlotView in m_ChestSlotViews)
            {
                chestSlotView.SetChestService(this);
                chestSlotView.EnterEmptyState();
            }
        }
    }
}
