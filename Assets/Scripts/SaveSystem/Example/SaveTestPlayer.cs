using UnityEngine;

namespace AOGSaveSystem
{
    [System.Serializable]
    public struct TestPlayerSaveData
    {
        public Vector3 position;
        public Quaternion rotation;
    }

    public partial struct SaveClass
    {
        public TestPlayerSaveData testPlayerData;
    }


    public class SaveTestPlayer : MonoBehaviour
    {
        void OnDataSave()
        {
            SaveManager.SaveData.testPlayerData.position = transform.position;
            SaveManager.SaveData.testPlayerData.rotation = transform.rotation;
        }

        void OnDataLoad()
        {
            transform.position = SaveManager.SaveData.testPlayerData.position;
            transform.rotation = SaveManager.SaveData.testPlayerData.rotation;
        }

        private void OnEnable()
        {
            SaveManager.BeforeSave += OnDataSave;
            SaveManager.AfterLoad += OnDataLoad;
        }
        private void OnDisable()
        {
            SaveManager.BeforeSave -= OnDataSave;
            SaveManager.AfterLoad -= OnDataLoad;
        }

        void Update()
        {

        }
    }
}