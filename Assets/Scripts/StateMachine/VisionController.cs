using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class VisionController : MonoBehaviour
{

    public Transform Eyes;
    public float visionRange = 20f;
    public Vector3 offset = new Vector3(0f, 0.75f, 0f);
    
     private NavMeshController navMeshController;

    void Awake() {
        navMeshController = GetComponent<NavMeshController>();
    }
    public bool canSeePlayer(out RaycastHit hit, bool lookToPlayer = false) {

        Vector3 directionVector;
        if(lookToPlayer) {
            directionVector = (navMeshController.pursuitEnemy.position + offset) - Eyes.position;
        }
        else {
            directionVector = Eyes.forward;
        }

        return Physics.Raycast(Eyes.position, directionVector, out hit, visionRange) && hit.collider.CompareTag("Player");
    }
}
