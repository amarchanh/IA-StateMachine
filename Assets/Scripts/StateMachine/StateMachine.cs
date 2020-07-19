using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class StateMachine : MonoBehaviour
{

    private Dictionary<MonoBehaviour, Color> map = new Dictionary<MonoBehaviour, Color>();
    private MonoBehaviour currentState;

    public MonoBehaviour PatrolState;
    public MonoBehaviour AlertState;
    public MonoBehaviour PursuitState;
    public MonoBehaviour InititalState;
    public MeshRenderer meshRendererIndicator;

    // Start is called before the first frame update
    void Start()
    {
        map.Add(PatrolState, Color.green);
        map.Add(AlertState, Color.yellow);
        map.Add(PursuitState, Color.red);

        ActivateState(InititalState);
    }

    public void ActivateState(MonoBehaviour newState) {

        if (currentState != null)   currentState.enabled = false;
        currentState = newState;
        currentState.enabled = true;
        meshRendererIndicator.material.color = map[newState];
    }

}
