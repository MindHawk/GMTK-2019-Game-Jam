using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComponent : MonoBehaviour
{
    public float power;
    public float maximumPower = 100f;
    
    public bool actionsLockedToOne = false;
    public Action currentAction;
    public Action switchingToAction;
    public float timeStartedSwitchingAt;
    public float switchDelay = 0.5f;

    public float powerChargedPerSecond = 5f;
    public float powerDrainedPerSystemPerSecond = 1.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        currentAction = Action.Moving;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
