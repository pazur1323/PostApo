using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    Inventory inventory;
    [SerializeField] GameObject prefab;
    bool canPick = false;
    bool gotItem = false;

    private void Start() {

        inventory = GameObject.FindObjectOfType<Inventory>();

    }

    // Naprawić żeby pojawiał się obiekt w liście w Inventory
    private void Update() {
        
        if(canPick){

            inventory.AddItem(prefab);
            gotItem = true;
            canPick = false;
        }
    }
    private void OnTriggerEnter(Collider other) {

        if(!gotItem) canPick = true;
        Destroy(gameObject);
        
    }
}
