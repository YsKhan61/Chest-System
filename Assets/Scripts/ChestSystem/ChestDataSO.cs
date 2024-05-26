using UnityEngine;

namespace CS.ChestSystem
{
    [CreateAssetMenu(fileName = "ChestData", menuName = "ScriptableObjects/ChestDataSO")]
    public class  ChestDataSO : ScriptableObject
    {
        [SerializeField, Tooltip("The min and max amount of coins that can be found in the chest")]
        private Vector2Int m_CoinRange;
        public Vector2Int CoinRange => m_CoinRange;

        [SerializeField, Tooltip("The min and max amount of gems that can be found in the chest")]
        private Vector2Int m_GemRange;
        public Vector2Int GemRange => m_GemRange;

        [SerializeField, Tooltip("Time in seconds it takes to open the chest")]
        private int m_OpenTime;
        public int OpenTime => m_OpenTime;

        [SerializeField, Tooltip("Spawn chance of the chest")]
        private float m_SpawnChance;
        public float SpawnChance => m_SpawnChance;
    }
}
