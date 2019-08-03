using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputComponent : MonoBehaviour
{
    private MovementComponent move;
    
    public bool actionsLockedToOne = false;
    public Action currentAction;
    public Action switchingToAction;
    public float timeSwitchedAt;
    public float switchDelay;
        
    // Start is called before the first frame update
    void Start()
    {
        move = GetComponent<MovementComponent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (actionsLockedToOne)
        {
            switch (currentAction)
            {
                case Action.Switching:
                    if (Time.time - timeSwitchedAt > switchDelay)
                    {
                        currentAction = switchingToAction;
                    }
                    break;
                case Action.Charging:
                    ChargeAction();
                    break;
                case Action.Moving:
                    MoveAction();
                    break;
                case Action.Attacking:
                    AttackAction();
                    break;
                case Action.Shielding:
                    ShieldAction();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        else
        {
            ChargeAction();
            MoveAction();
            AttackAction();
            ShieldAction();
        }
    }

    void ChargeAction()
    {
        
    }

    void MoveAction()
    {
        float verticalAxis = Input.GetAxis("Vertical");
        float horizontalAxis = Input.GetAxis("Horizontal");
        if (verticalAxis != 0 || horizontalAxis != 0)
        {
            move.Move(horizontalAxis, verticalAxis);
        }
    }

    void AttackAction()
    {
        
    }

    void ShieldAction()
    {
        
    }

    void CheckSwitching()
    {
        
    } 
    
    void CheckCharging()
    {
        
    }

    void CheckMoving()
    {
        
    }

    void CheckAttacking()
    {
        
    }

    void CheckShielding()
    {
        
    }
}
