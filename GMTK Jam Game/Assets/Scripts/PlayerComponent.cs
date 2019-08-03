using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComponent : MonoBehaviour
{
    public float power;
    public float maximumPower = 100f;
    
    public bool actionsLockedToOne = true;
    public Action currentAction;
    public Action switchingToAction;
    public float timeStartedSwitchingAt;
    public float switchDelay = 0.5f;

    public float powerChargedPerSecond = 5f;
    public float powerDrainedPerSystemPerSecond = 1.5f;
    
    void Start()
    {
        currentAction = Action.Moving;
        power = maximumPower;
    }

    void Update()
    {
    }
}
