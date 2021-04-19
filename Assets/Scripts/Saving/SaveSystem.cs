using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[System.Serializable]
public static class SaveSystem
{
    public static GameData LoadData()
    {
        Debug.Log(Application.persistentDataPath);
        string path = Application.persistentDataPath + "/player.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            GameData data = formatter.Deserialize(stream) as GameData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.Log("Save file not found in " + path);
            return null;
        }
    }
    public static void SaveData(PlayerTags playerTags)
    {
        GameData data = new GameData(playerTags);

        if (LoadData() != null)
        {
            GameData oldData = LoadData();

            if (data.i_UnlockedLevels < oldData.i_UnlockedLevels)
            {
                data.i_UnlockedLevels = oldData.i_UnlockedLevels;
            }
        }

        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, data);
        // Debug.LogError(path);
        stream.Close();
    }

    public static void UnlockAllLevels(PlayerTags playerTags)
    {
        GameData data = new GameData(playerTags);

        data.i_UnlockedLevels = 17;

        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, data);
        // Debug.LogError(path);
        stream.Close();
    }

}
