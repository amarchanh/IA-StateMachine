using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PursuitState : MonoBehaviour
{

    private StateMachine stateMachine;
    private NavMeshController navMeshController;
    private VisionController visionController;

    // Start is called before the first frame update
    void Awake(){
        stateMachine = GetComponent<StateMachine>();
        navMeshController = GetComponent<NavMeshController>();
        visionController = GetComponent<VisionController>();
    }

    // Update is called once per frame
    void Update() {
        RaycastHit hit;
        if(!visionController.canSeePlayer(out hit, true)) {
            stateMachine.ActivateState(stateMachine.AlertState);

            return;
        }
        
        navMeshController.UpdateDestinyPointNavMeshAgent();
    }
}
