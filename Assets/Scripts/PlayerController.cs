using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    Transform target;
    PickupsManager pickupsManager;
    bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0f, 1f, 0f);
        navMeshAgent = GetComponent<NavMeshAgent>();
        pickupsManager = GameObject.FindObjectOfType<PickupsManager>();

    }

    // Update is called once per frame
    void Update()
    {
        isPaused = GameObject.Find("Pause").GetComponent<Pause>().isPaused;
        if(isPaused) return;
        Move();
        PickItemUp(target);
    }

    void Move(){

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        bool isHit = Physics.Raycast(ray, out hit);
        if(isHit){

            foreach (var item in pickupsManager.GetItemsOnScene())
            {
                item.GetComponent<Pickup>().TurnOffLabel();
            }
            if(IsTargetPickup(hit.transform)){

                hit.transform.GetComponent<Pickup>().SetLabel(); 
            }
            
            if(Input.GetMouseButton(0)){
                navMeshAgent.destination = hit.point;
                target = hit.transform;
            }
        }
    }

    void PickItemUp(Transform target){
        if(target != null && IsTargetPickup(target)){
            if(Vector3.Distance(target.position, transform.position) <= navMeshAgent.stoppingDistance){
                target.GetComponent<Pickup>().GetItem();
                Destroy(target.gameObject);
            }
        }
    }

    bool IsTargetPickup(Transform target){
        return target.GetComponent<Pickup>() != null;
    }

    public void SetDestination(Vector3 destination){
        navMeshAgent.destination = destination;
    }

}
