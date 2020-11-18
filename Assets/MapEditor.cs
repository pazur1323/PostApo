using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class MapEditor : MonoBehaviour
{
    public int gridSize = 10;

    private void Update() {
        Vector3 pos = GetPosition();
        transform.position = new Vector3(pos.x*gridSize, pos.y*gridSize, pos.z*gridSize);
        WritePositionInName();
    }
    
    Vector3 GetPosition()
    {
        return new Vector3(
                Mathf.RoundToInt(transform.position.x/gridSize),
                Mathf.RoundToInt(transform.position.y/gridSize),
                Mathf.RoundToInt(transform.position.z/gridSize)
                );
    }

    void WritePositionInName(){

        int x = (int)GetPosition().x;
        int y = (int)GetPosition().y;
        int z = (int)GetPosition().z;
        gameObject.name = "(" + x + ", " + y + ", " + z + ")";
    }

}
