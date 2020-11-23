using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Inventory inventory;
    PlayerController playerController;
    PickupsManager pickupsManager;
    Pause pause;

    private void Start() {
        inventory = GetComponent<Inventory>();
        playerController = GetComponent<PlayerController>();
        pickupsManager = GameObject.FindObjectOfType<PickupsManager>();
        pause = GameObject.FindObjectOfType<Pause>();
    }

    public List<string> GetInventory(){
        return inventory.GetItemList();
    }

    public void SavePlayer(){
        pause.DisplaySaveInfo();
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
        inventory.SetInventory(data.inventory);


    }
}
