using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    Transform textChild;
    Transform target;

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
        if(target != null && IsTargetPickup(target)){
            if(Vector3.Distance(target.position, transform.position) <= navMeshAgent.stoppingDistance){
                target.GetComponent<Pickup>().GetItem();
            }
        }
    }

    void Move(){

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        bool isHit = Physics.Raycast(ray, out hit);
        if(isHit){

            if(IsTargetPickup(hit.transform)){
                Pickup pickup = hit.transform.GetComponent<Pickup>();
                textChild = pickup.SetItemName(hit);
            }
            else if(textChild != null){

                textChild.gameObject.SetActive(false);
            }
            

            
            if(Input.GetMouseButtonDown(0)){
                navMeshAgent.destination = hit.point;
                target = hit.transform;
            }
        }
    }

    bool IsTargetPickup(Transform target){
        return target.GetComponent<Pickup>() != null;
    }

    
}
