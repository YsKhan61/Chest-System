using CS.Factory;
using CS.UI;
using System;
using UnityEngine;
using Object = UnityEngine.Object;


namespace CS.ChestSystem
{
    public class ChestController : IFactoryItem
    {
        private const string UNLOCK = "Unlock";
        private const string COLLECT = "Collect";

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
            m_View.ToggleTimeToUnlockText(true);
            m_View.SetTimeToUnlockText($"{m_Data.OpenTime / 3600}:{(m_Data.OpenTime % 3600) / 60}:{m_Data.OpenTime % 60}");
            m_View.ToggleTimerSlider(false);
            m_View.ToggleCostPanel(false);
            m_View.SetStatus(UNLOCK);
        }


        public void UpdateTimer(float timeElapsed)
        {
            float timeLeft = m_Data.OpenTime - timeElapsed;
            m_View.SetProgressSlider(timeElapsed / m_Data.OpenTime);
            
            TimeSpan timeSpan = TimeSpan.FromSeconds(timeLeft);
            string formattedTime = string.Format("{0:D2}:{1:D2}:{2:D2}",
                (int)timeSpan.TotalHours,
                timeSpan.Minutes,
                timeSpan.Seconds);
            m_View.SetTimeLeftText(formattedTime);

        }

        public void EnterUnlockingState()
        {
            m_View.ToggleTimeToUnlockText(false);
            m_View.ToggleTimerSlider(true);
            m_View.ToggleCostPanel(true);
            m_View.SetCostText(m_Data.MaxCost.ToString());
        }


        public void EnterUnlockedState()
        {
            m_View.SetChestImageSprite(m_Data.OpenIcon);
            m_View.ToggleTimeToUnlockText(false);
            m_View.ToggleTimerSlider(false);
            m_View.ToggleCostPanel(false);
            m_View.SetStatus(COLLECT);
        }

        public void Destroy()
        {
            Object.Destroy(m_View.gameObject);
        }
    }
}
