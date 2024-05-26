using CS.Factory;
using UnityEngine;

namespace CS.ChestSystem
{
    /// <summary>
    /// This factory is responsible for creating Chest objects.
    /// It can create all types of Chest objects according to the ChestData given.
    /// </summary>
    [CreateAssetMenu(fileName = "ChestFactory", menuName = "ScriptableObjects/Factories/ChestFactorySO")]
    public class ChestFactorySO : FactorySO<ChestController>
    {
        [SerializeField, Tooltip("The ChestData to create the Chest objects")]
        private ChestDataSO m_ChestData;

        public override ChestController GetItem() => new ChestController(m_ChestData);
    }
}
