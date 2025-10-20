using System;
using UnityEngine;

public class SaveTestUIManager : MonoBehaviour
{
    private void OnEnable()
    {
        AOGSaveSystem.SaveManager.AfterSave += OnAfterSave;
        AOGSaveSystem.SaveManager.AfterLoad += OnAfterLoad;
    }

    private void OnAfterLoad()
    {
        Debug.Log("Game Loaded Successfully!");
    }

    private void OnAfterSave()
    {
        Debug.Log("Game Saved Successfully!");
    }

    public void SaveBtn()
    {
        AOGSaveSystem.SaveManager.SaveFileName = "TestSaveFile";
        AOGSaveSystem.SaveManager.Save();
    }

    public void LoadBtn()
    {
        AOGSaveSystem.SaveManager.Load();
    }
}
