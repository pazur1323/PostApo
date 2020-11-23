using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupsManager : MonoBehaviour
{
    public List<GameObject> GetItemsOnScene(){
        List<GameObject> pickups = new List<GameObject>(); 
        foreach(var pickup in Object.FindObjectsOfType<Pickup>()){
            pickups.Add(pickup.gameObject);
        }
        return pickups;
    }

}
