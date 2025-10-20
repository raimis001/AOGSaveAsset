using System;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;


namespace AOGSaveSystem
{
    static public class SaveManager
    {
        public static SaveClass SaveData;
        public static string SaveFileName = "savefile.sav";

        public static Action BeforeSave;
        public static Action AfterSave;
        public static Action BeforeLoad;
        public static Action AfterLoad;


        //static string saveFilePath => Path.Combine(Application.persistentDataPath, SaveFileName);
        static string saveFilePath => Path.Combine(Application.streamingAssetsPath, SaveFileName);

        public static async void Save() => await SaveTask();
        public static bool Load() => LoadTask();

        private static async Task SaveTask()
        {
            BeforeSave?.Invoke();

            string saveText = GetSaveText();
            await File.WriteAllTextAsync(saveFilePath, saveText);

            AfterSave?.Invoke();
        }

        private static bool LoadTask()
        {
            if (!File.Exists(saveFilePath))
            {
                Debug.LogWarning($"Save file not found at {saveFilePath}");
                return false;
            }

            BeforeLoad?.Invoke();

            string stringData = File.ReadAllText(saveFilePath);
            SetSaveData(stringData);

            AfterLoad?.Invoke();
            return true;
        }

        private static string GetSaveText()
        {
            return JsonUtility.ToJson(SaveData);
        }

        private static void SetSaveData(string stringData)
        {
            SaveData = JsonUtility.FromJson<SaveClass>(stringData);
        }
    }
}