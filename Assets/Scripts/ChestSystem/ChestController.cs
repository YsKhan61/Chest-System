using CS.Factory;


namespace CS.ChestSystem
{
    public class ChestController : IFactoryItem
    {
        private ChestDataSO m_Data;

        public ChestController(ChestDataSO data)
        {
            m_Data = data;
        }
    }

}
