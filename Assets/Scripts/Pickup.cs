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

    public Transform SetItemName(RaycastHit hit){
        if(!textChild.gameObject.active){
            textChild.gameObject.SetActive(true);
        }
        textChild.rotation = Quaternion.LookRotation(textChild.position - Camera.main.transform.position);
        return textChild;
    }

    public void GetItem(){
        inventory.AddItem(prefab.name);
        Destroy(gameObject);
    }
}
