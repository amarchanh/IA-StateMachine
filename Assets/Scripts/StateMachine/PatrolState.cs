using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PatrolState : MonoBehaviour
{

    public Transform[] WayPoints;
    public Color StateColor =  Color.green;
    private NavMeshController navMeshController;
    private int nextWayPoint;
    private StateMachine stateMachine;
    private VisionController visionController;


    void Awake() {
        navMeshController = GetComponent<NavMeshController>();
        stateMachine = GetComponent<StateMachine>();
        visionController = GetComponent<VisionController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Comprueba si ve al jugador
        RaycastHit hit;
        if(visionController.canSeePlayer(out hit)) {
            navMeshController.pursuitEnemy = hit.transform;

            stateMachine.ActivateState(stateMachine.PursuitState);
            return;
        }
        if(navMeshController.Arrive()) {
            nextWayPoint = (nextWayPoint + 1) % WayPoints.Length;
            UpdateDestinyWayPoint();
        }
    }

    void OnEnable() {
        UpdateDestinyWayPoint();
    }

    private void  UpdateDestinyWayPoint() {
         navMeshController.UpdateDestinyPointNavMeshAgent(WayPoints[nextWayPoint].position);
    }

    public void OnTriggerEnter(Collider other) {
       
        if(other.gameObject.CompareTag("Player") && enabled) {
            stateMachine.ActivateState(stateMachine.AlertState);
        }
    }
}
