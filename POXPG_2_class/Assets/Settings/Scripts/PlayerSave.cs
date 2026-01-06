using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSave : MonoBehaviour
{
    
    
    public PlayerStats playerStats;
    public CollectCounter collectCounter;
   

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
        data.health = playerStats.GetHealth();
        data.coins = collectCounter.coins;
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
        if(playerStats != null)
        {
            playerStats.SetHealth(data.health);
        }

        if(collectCounter != null)
        {
            collectCounter.SetCoins(data.coins);
        }
        Debug.Log("Game Loaded");
    }
}
