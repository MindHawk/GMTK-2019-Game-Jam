using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputComponent : MonoBehaviour
{
    private MovementComponent _move;
    private PlayerComponent _player;
    private WeaponComponent _weapon;
    

        
    void Start()
    {
        _move = GetComponent<MovementComponent>();
        _player = GetComponent<PlayerComponent>();
        _weapon = GetComponentInChildren<WeaponComponent>();
    }

    void Update()
    {
        Debug.Log(_player.power);
        if (_player.actionsLockedToOne)
        {
            if (Input.GetKeyDown("1"))
            {
                _player.currentAction = Action.Switching;
                _player.switchingToAction = Action.Charging;
            }
            if (Input.GetKeyDown("2"))
            {
                _player.currentAction = Action.Switching;
                _player.switchingToAction = Action.Moving;
            }
            if (Input.GetKeyDown("3"))
            {
                _player.currentAction = Action.Switching;
                _player.switchingToAction = Action.Attacking;
            }
            if (Input.GetKeyDown("4"))
            {
                _player.currentAction = Action.Switching;
                _player.switchingToAction = Action.Shielding;
            }


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
        if (_player.power > 0)
        {
            _player.power -= _player.powerDrainedPerSystemPerSecond * Time.deltaTime;
        }
        else if (_player.power < 0)
        {
            _player.power = 0;
        }
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
        if (Input.GetAxis("Fire1") > 0)
        {
            _weapon.FireProjectile();
            UsePower();
        }

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
