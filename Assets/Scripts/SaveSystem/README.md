# AOG SaveSystem asset

This repository is a collection of assets designed to integrate the AOG Save Sistem for Unity

## Platforms Supported
- Unity minimum version 2019.4.X LTS

## Development

**Any contributions to this repository need to be done using Unity 2019.4.X LTS**

This unity version was chosen as it is Long Term Supported and provides compatibility with all targeted platfroms.

There is no reason why this asset could not be used by earlier versions of Unity, but those don't easily support all of our targeted platforms.

## Installation

Sorry now its not working from custom package, just copy https://github.com/raimis001/AOGSaveAsset/blob/main/Assets/Scripts/SaveSystem/SaveManager.cs to your scripts folder

`Add custom Unity package from Git url:
`https://github.com/raimis001/AOGSaveAsset.git?path=/Assets/Scripts/SaveSystem


## How to use

### Save path

You can change save path location as you wish in SaveManager.cs

Some examples
```C#
   static string saveFilePath => Path.Combine(Application.persistentDataPath, SaveFileName);
   static string saveFilePath => Path.Combine(Application.streamingAssetsPath, SaveFileName);
```

Change fileName in your code

```C#
	AOGSaveSystem.SaveManager.SaveFileName = "TestSaveFile.sav";
```

### Using partial save data handler

```C#
//Create partial class for saving data
namespace AOGSaveSystem
{
    [System.Serializable]
    public struct PlayerSaveData
    {
        public Vector3 position;
        public Quaternion rotation;
    }

    public partial struct SaveClass
    {
        public PlayerSaveData playerData;
    }
}
```

```C#
//Using save handler before save data and load data after load 
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
}
```
### Save/Load functions

```C#
//Use any interface save and load data
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
	//If needed change save file name
    AOGSaveSystem.SaveManager.SaveFileName = "TestSaveFile.sav";

	//Async data save
    AOGSaveSystem.SaveManager.Save();
}

public void LoadBtn()
{
    AOGSaveSystem.SaveManager.Load();
}

```


### Use example scripts

SaveTestPlayer.cs
SaveTestUIManager.cs


