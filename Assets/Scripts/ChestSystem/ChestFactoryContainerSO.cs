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
        /// <summary>
        /// Get the ChestController object from the factory of specified tag
        /// </summary>
        public ChestController GetChest(TagSO tag) => GetItem(tag);
    }
}
