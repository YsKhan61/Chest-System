using CS.UI;
using UnityEngine;

namespace CS.ChestSystem
{
    [CreateAssetMenu(fileName = "ChestData", menuName = "ScriptableObjects/ChestDataSO")]
    public class  ChestDataSO : ScriptableObject
    {
        [SerializeField, Tooltip("Chest Icon that is closed")]
        private Sprite m_ClosedIcon;
        public Sprite ClosedIcon => m_ClosedIcon;

        [SerializeField, Tooltip("Chest Icon that is open")]
        private Sprite m_OpenIcon;
        public Sprite OpenIcon => m_OpenIcon;

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
        private int m_SpawnChance;
        public int SpawnChance => m_SpawnChance;

        [SerializeField, Tooltip("Max coins needed to open in advanced!")]
        private int m_MaxCost;
        public int MaxCost => m_MaxCost;

        [SerializeField, Tooltip("Prefab of the chest view")]
        private ChestView m_Prefab;
        public ChestView Prefab => m_Prefab;
    }
}
