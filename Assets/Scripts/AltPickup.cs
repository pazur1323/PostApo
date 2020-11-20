using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltPickup : MonoBehaviour
{

    [SerializeField] GameObject prefab;
    Inventory inventory;
    Transform textTransform;
    bool alreadyPicked = false;
    bool canPick = false;

    private void Start() {
        
        inventory = GameObject.FindObjectOfType<Inventory>();
        textTransform = transform.GetChild(0);
        textTransform.gameObject.SetActive(false);

    }

    private void Update() {
        
        if(canPick){
            textTransform.gameObject.SetActive(true);
            textTransform.rotation = Quaternion.LookRotation(textTransform.position - Camera.main.transform.position);
            if(Input.GetKey(KeyCode.F)){
                canPick = false;
                if(!alreadyPicked){
                    alreadyPicked = true;
                    inventory.AddItem(prefab.name);
                    Destroy(gameObject);
                }
            }
        }
        else{
            textTransform.gameObject.SetActive(false);
        }
        
    }


    

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            Debug.Log("Enter");
            canPick = true;

        }
    }

    private void OnTriggerExit(Collider other) {
        Debug.Log("Exit");
        canPick = false;
    }
}
