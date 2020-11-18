using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<GameObject> itemList;

    private void Start() {
        
        itemList = new List<GameObject>();
    }

    public void AddItem(GameObject gameObject){

        itemList.Add(gameObject);
    }

}
