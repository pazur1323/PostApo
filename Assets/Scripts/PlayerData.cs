using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public List<string> itemList;
    public float[] playerPosition;

    public PlayerData(PlayerController playerController){

        playerPosition = new float[3];
        playerPosition[0] = playerController.transform.position.x;
        playerPosition[1] = playerController.transform.position.y;
        playerPosition[2] = playerController.transform.position.z;

        itemList = playerController.GetComponent<Inventory>().GetItemList();
    }
}
