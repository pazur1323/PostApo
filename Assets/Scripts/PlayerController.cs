using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    Transform pickupInfo;
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
        if(target != null && IsTargetPickup(target)){
            if(Vector3.Distance(target.position, transform.position) <= navMeshAgent.stoppingDistance){
                pickups = target.GetComponent<Pickup>().GetItem(pickups);
                Destroy(target.gameObject);
            }
        }
    }

    void Move(){

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        bool isHit = Physics.Raycast(ray, out hit);
        if(isHit){

            DisplayPickupInfo(hit);
            
            if(Input.GetMouseButtonDown(0)){
                navMeshAgent.destination = hit.point;
                target = hit.transform;
            }
        }
    }

    bool IsTargetPickup(Transform target){
        return target.GetComponent<Pickup>() != null;
    }

    void DisplayPickupInfo(RaycastHit hit){
        if(IsTargetPickup(hit.transform)){
            foreach (var item in pickups)
            {
                    
                GameObject child = item.transform.GetChild(0).gameObject;
                child.active = false;
            }
                
            Pickup pickup = hit.transform.GetComponent<Pickup>();
            pickupInfo = pickup.SetItemName();
        }
        else if(pickupInfo != null){

            pickupInfo.gameObject.SetActive(false);
        }
    }

    public void SavePlayer(){
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer(){
        PlayerData data = new PlayerData(this);
        data = SaveSystem.LoadPlayer();
        transform.position = new Vector3(
                                data.playerPosition[0],
                                data.playerPosition[1],
                                data.playerPosition[2]
                            );
        navMeshAgent.destination = transform.position;
    }
}
