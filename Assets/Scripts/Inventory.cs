using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<string> itemList;

    private void Start() {
        
        itemList = new List<string>();
    }

    public void AddItem(string name){

        itemList.Add(name);
            
    }

}
