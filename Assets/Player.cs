using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Inventory inventory;
    PlayerController playerController;

    private void Start() {
        inventory = GetComponent<Inventory>();
        playerController = GetComponent<PlayerController>();
    }

    public List<string> GetInventory(){
        return inventory.GetItemList();
    }
    public void SavePlayer(){
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer(){
        PlayerData data = new PlayerData(this);
        data = SaveSystem.LoadPlayer();
        transform.position = new Vector3(
                                data.playerPos[0],
                                data.playerPos[1],
                                data.playerPos[2]
                            );
        playerController.SetDestination(transform.position);
    }
}
