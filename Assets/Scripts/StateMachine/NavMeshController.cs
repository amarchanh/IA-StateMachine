using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshController : MonoBehaviour
{

    [HideInInspector]
    public Transform pursuitEnemy;
    private NavMeshAgent navMeshAgent;

    void Awake() {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public void UpdateDestinyPointNavMeshAgent(Vector3 destinyPoint){
        navMeshAgent.destination = destinyPoint;
        navMeshAgent.Resume();  
    }
 
    public void UpdateDestinyPointNavMeshAgent() {
        UpdateDestinyPointNavMeshAgent(pursuitEnemy.position);
    }

    public void StopNavMeshAgent() {
        navMeshAgent.Stop();
    }

    public bool Arrive() {
        return navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance && !navMeshAgent.pathPending;
    }

}
