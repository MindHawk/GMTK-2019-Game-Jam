using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputComponent : MonoBehaviour
{
    private MovementComponent _move;
    private PlayerComponent _player;
    

        
    // Start is called before the first frame update
    void Start()
    {
        _move = GetComponent<MovementComponent>();
        _player = GetComponent<PlayerComponent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_player.actionsLockedToOne)
        {
            switch (_player.currentAction)
            {
                case Action.Switching:
                    if (Time.time - _player.timeStartedSwitchingAt > _player.switchDelay)
                    {
                        _player.currentAction = _player.switchingToAction;
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
            MoveAction();
            AttackAction();
            ShieldAction();
            ChargeAction();
        }
    }

    void ChargeAction()
    {
        _player.power += Time.deltaTime * _player.powerChargedPerSecond;
        if (_player.power > _player.maximumPower)
        {
            _player.power = _player.maximumPower;
        }
    }

    void UsePower()
    {
        _player.power -= _player.powerDrainedPerSystemPerSecond;
    }

    void MoveAction()
    {
        UsePower();
        float verticalAxis = Input.GetAxis("Vertical");
        float horizontalAxis = Input.GetAxis("Horizontal");
        if (verticalAxis != 0 || horizontalAxis != 0)
        {
            _move.Move(horizontalAxis, verticalAxis);
        }
    }

    void AttackAction()
    {
        UsePower();
    }

    void ShieldAction()
    {
        UsePower();
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
