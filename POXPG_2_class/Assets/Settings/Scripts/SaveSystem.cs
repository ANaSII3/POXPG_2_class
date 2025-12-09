using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    private static string fileName = "savegame.json";

    private static string GetPath()
    {
        return Path.Combine(Application.persistentDataPath, fileName);

    }

    public static void Save(SaveData data)
    {
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(GetPath(), json);
        Debug.Log("Game saved to " + GetPath());
    }

    public static SaveData Load()
    {
        string path = GetPath();
        if (!File.Exists(path))
        {
            Debug.Log("Brak zapisu gry");
            return null;
        }
        string json = File.ReadAllText(path);
        SaveData data = JsonUtility.FromJson<SaveData>(json);
        Debug.Log("Game loaded from " + path);
        return data;
    }
}
