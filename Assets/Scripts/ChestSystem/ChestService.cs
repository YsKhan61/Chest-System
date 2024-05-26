using CS.UI;
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

        private void OnEnable()
        {
            m_ChestFactoryContainer.Initialize();
        }

        private void Start()
        {
            foreach (var chestSlotView in m_ChestSlotViews)
            {
                chestSlotView.SetChestService(this);
                chestSlotView.StartEmptyState();
            }
        }

        private void OnDisable()
        {
            m_ChestFactoryContainer.ResetContainer();
        }

        /// <summary>
        /// Get a random chest from the chest factory container
        /// </summary>
        public ChestController CreateChest() => m_ChestFactoryContainer.GetRandomChest();

        public void CollectChest(ChestController m_Chest)
        {
            Debug.Log("Chest Collected");
            m_Chest.Destroy();
        }
    }
}
