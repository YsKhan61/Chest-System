using CS.Factory;
using CS.Utilities;
using UnityEngine;

namespace CS.ChestSystem
{
    /// <summary>
    /// A container to store the ChestFactorySO objects
    /// </summary>
    [CreateAssetMenu(fileName = "ChestFactoryContainer", menuName = "ScriptableObjects/Factories/ChestFactoryContainerSO")]
    public class ChestFactoryContainerSO : FactoryContainerSO<ChestController> 
    {
        private bool m_IsInitialized;
        private int m_TotalWeight;

        /// <summary>
        /// Initialize the container by calculating the total weight of the factories
        /// It helps to get the random factory based on the spawn chance
        /// </summary>
        public void Initialize()
        {
            if (m_IsInitialized)
            {
                return;
            }

            foreach (ChestFactorySO factory in m_Factories)
            {
                m_TotalWeight += factory.SpawnChance;
            }

            m_IsInitialized = true;
        }

        /// <summary>
        /// Reset the container and its values
        /// </summary>
        public void ResetContainer()
        {
            m_IsInitialized = false;
            m_TotalWeight = 0;
        }

        /// <summary>
        /// Get the ChestController object from the factory of specified tag
        /// </summary>
        public ChestController GetChest(TagSO tag) => GetItem(tag);

        /// <summary>
        /// Get a random ChestController object from the factories based on the spawn chance
        /// </summary>
        /// <returns></returns>
        public ChestController GetRandomChest()
        {
            if (m_TotalWeight == 0)
            {
                Debug.LogError("Total weight is 0. Initialize the container first!");
                return null;
            }

            int random = Random.Range(0, 100);
            int currentWeight = 0;

            foreach (ChestFactorySO factory in m_Factories)
            {
                currentWeight += factory.SpawnChance;
                if (random < currentWeight)
                {
                    return factory.GetItem();
                }
            }

            // If no factory is found, return the first factory
            return m_Factories[0].GetItem();
        }
    }
}
