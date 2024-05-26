using CS.Factory;
using CS.UI;
using UnityEngine;


namespace CS.ChestSystem
{
    public class ChestController : IFactoryItem
    {
        private ChestDataSO m_Data;
        public ChestDataSO Data => m_Data;

        private ChestView m_View;


        public ChestController(ChestDataSO data) => m_Data = data;

        /// <summary>
        /// Spawn the view of the chest in the given parent
        /// </summary>
        /// <param name="parent"></param>
        public void SpawnView(Transform parent)
        {
            m_View = Object.Instantiate(m_Data.Prefab, parent);
        }

        public void EnterLockedState()
        {
            m_View.SetChestImageSprite(m_Data.ClosedIcon);
            m_View.SetTimer($"{m_Data.OpenTime / 3600}:{(m_Data.OpenTime % 3600) / 60}:{m_Data.OpenTime % 60}");
            m_View.ToggleTimerSlider(false);
        }

        public void UpdateTimer(float timeElapsed)
        {
            float timeLeft = m_Data.OpenTime - timeElapsed;
            m_View.SetTimer($"{timeLeft / 3600}:{timeLeft % 3600 / 60}:{timeLeft % 60}");
        }

        public void EnterUnlockedState()
        {
            m_View.SetChestImageSprite(m_Data.OpenIcon);
            m_View.SetTimer("Opened");
            m_View.ToggleTimerSlider(false);
        }
    }
}
