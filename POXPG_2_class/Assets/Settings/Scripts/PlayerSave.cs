using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerSave : MonoBehaviour
{
    public int health = 100;
    public int coins = 0;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            Save();
        }
        if(Input.GetKeyDown(KeyCode.L))
        {
            Load();
        }
    }
    public void Save()
    {
        SaveData data = new SaveData();
        data.health = health;
        data.coins = coins;
        data.position = new float[]
        {
            transform.position.x,
            transform.position.y,
            transform.position.z
        };
        SaveSystem.Save(data);
        Debug.Log("Game Saved");
    }
    public void Load()
    {
        SaveData data = SaveSystem.Load();
        if (data == null)
        {
            return;
        }
        transform.position = new Vector3(
            data.position[0],
            data.position[1],
            data.position[2]
        );
        health = data.health;
        coins = data.coins;
        Debug.Log("Game Loaded");
    }
}
