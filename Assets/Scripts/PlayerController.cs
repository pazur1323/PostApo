using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    NavMeshAgent navMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0f, 1f, 0f);
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move(){

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        bool isHit = Physics.Raycast(ray, out hit);
        if(isHit){

            if(Input.GetMouseButtonDown(0)){
                navMeshAgent.destination = hit.point;
            }
        }
    }

    
}
