using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    Transform target;
    List<GameObject> pickups;
    bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0f, 1f, 0f);
        navMeshAgent = GetComponent<NavMeshAgent>();
        pickups = new List<GameObject>();
        foreach(var pickup in Object.FindObjectsOfType<Pickup>()){
            pickups.Add(pickup.gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        isPaused = GameObject.Find("Pause").GetComponent<Pause>().isPaused;
        if(isPaused) return;
        Move();
        pickups = PickItemUp(target);
    }

    void Move(){

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        bool isHit = Physics.Raycast(ray, out hit);
        if(isHit){

            foreach (var item in pickups)
            {
                item.GetComponent<Pickup>().TurnOffLabel();
            }
            if(IsTargetPickup(hit.transform)){

                hit.transform.GetComponent<Pickup>().SetLabel(); 
            }
            
            if(Input.GetMouseButtonDown(0)){
                navMeshAgent.destination = hit.point;
                target = hit.transform;
            }
        }
    }

    List<GameObject> PickItemUp(Transform target){
        if(target != null && IsTargetPickup(target)){
            if(Vector3.Distance(target.position, transform.position) <= navMeshAgent.stoppingDistance){
                List<GameObject> pickups =  new List<GameObject>();
                pickups = target.GetComponent<Pickup>().GetItem(pickups);
                Destroy(target.gameObject);
                return pickups;
            }
        }
        return pickups;
    }

    bool IsTargetPickup(Transform target){
        return target.GetComponent<Pickup>() != null;
    }

    public void SetDestination(Vector3 destination){
        navMeshAgent.destination = destination;
    }

}
