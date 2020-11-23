using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    Inventory inventory;
    Transform textChild;
    PickupsManager pickupsManager;

    private void Start() {
        
        inventory = GameObject.FindObjectOfType<Inventory>();
        textChild = transform.GetChild(0);
        textChild.gameObject.SetActive(false);
        pickupsManager = gameObject.GetComponentInParent<PickupsManager>();
    }

    private void Update() {
        textChild.rotation = Quaternion.LookRotation(textChild.position - Camera.main.transform.position);
    }

    public void SetLabel(){
        if(!textChild.gameObject.active){
            textChild.gameObject.SetActive(true);
        }
    }

    public void TurnOffLabel(){
        textChild.gameObject.SetActive(false);
    }

    public void GetItem(){
        inventory.AddItem(prefab.gameObject.name);
        // List<GameObject> pickupList = pickupsManager.GetItemsInScene();
        // if(pickupList.Contains(gameObject)){
        //     pickupList.Remove(gameObject);
        // }
        // return pickupList;

    }

}
