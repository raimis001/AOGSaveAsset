using UnityEngine;
using AOGSaveSystem;

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
        public TestPlayerSaveData playerData;
    }
}

public class SaveTestPlayer : MonoBehaviour
{
    void OnDataSave()
    {
        SaveManager.SaveData.playerData.position = transform.position;
        SaveManager.SaveData.playerData.rotation = transform.rotation;
    }

    void OnDataLoad()
    {
        transform.position = SaveManager.SaveData.playerData.position;
        transform.rotation = SaveManager.SaveData.playerData.rotation;
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
