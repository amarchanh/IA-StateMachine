using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertState : MonoBehaviour
{

    private StateMachine stateMachine;
    private NavMeshController navMeshController;
    private VisionController visionController;
    private float searchingTime;

    public Color stateColor = Color.yellow;
    public float searchRotationVelocity = 120f;
    public float searchTime = 4f;

    // Start is called before the first frame update
    void Awake(){
        stateMachine = GetComponent<StateMachine>();
        navMeshController = GetComponent<NavMeshController>();
        visionController = GetComponent<VisionController>();
    }

    void OnEnable() {
        navMeshController.StopNavMeshAgent();
        searchingTime = 0f;
    }
    // Update is called once per frame
    void Update() {
        RaycastHit hit;
        if(visionController.canSeePlayer(out hit)) {
            navMeshController.pursuitEnemy = hit.transform;

            stateMachine.ActivateState(stateMachine.PursuitState);
            return;
        }

        transform.Rotate(0f, searchRotationVelocity * Time.deltaTime ,0f);
        searchingTime += Time.deltaTime;
        if(searchingTime > searchTime ) {
            stateMachine.ActivateState(stateMachine.PatrolState);
            return;
        }
    }
}
