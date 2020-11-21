using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    Inventory inventory;
    Transform textChild;
    private void Start() {
        
        inventory = GameObject.FindObjectOfType<Inventory>();
        textChild = transform.GetChild(0);
        textChild.gameObject.SetActive(false);
    }

    public Transform SetItemName(){
        if(!textChild.gameObject.active){
            textChild.gameObject.SetActive(true);
        }
        textChild.rotation = Quaternion.LookRotation(textChild.position - Camera.main.transform.position);
        return textChild;
    }

    public List<GameObject> GetItem(List<GameObject> pickupList){
        inventory.AddItem(prefab.name);
        if(pickupList.Contains(gameObject)){
            pickupList.Remove(gameObject);
        }
        return pickupList;

    }
}
