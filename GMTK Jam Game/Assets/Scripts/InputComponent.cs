using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputComponent : MonoBehaviour
{
    private MovementComponent _move;
    private PlayerComponent _player;
    private WeaponComponent _weapon;
    private ShieldController _shield;
    private List<VisualThrustComponent> _thrusters;
    

        
    void Start()
    {
        _move = GetComponent<MovementComponent>();
        _player = GetComponent<PlayerComponent>();
        _weapon = GetComponentInChildren<WeaponComponent>();
        _shield = GetComponentInChildren<ShieldController>();

        _thrusters = new List<VisualThrustComponent>();
        foreach (VisualThrustComponent thrustComponent in GetComponentsInChildren<VisualThrustComponent>())
        {
            _thrusters.Add(thrustComponent);
        } 
    }

    void Update()
    {
        if (_player.actionsLockedToOne)
        {
            if (Input.GetKeyDown("1"))
            {
                _player.timeStartedSwitchingAt = Time.time;
                _player.currentAction = Action.Switching;
                _player.switchingToAction = Action.Charging;
                DisableEverything();
            }
            if (Input.GetKeyDown("2") & _player.power > 5)
            {
                _player.timeStartedSwitchingAt = Time.time;
                _player.currentAction = Action.Switching;
                _player.switchingToAction = Action.Moving;
                DisableEverything();
            }
            if (Input.GetKeyDown("3") & _player.power > 5)
            {
                _player.timeStartedSwitchingAt = Time.time;
                _player.currentAction = Action.Switching;
                _player.switchingToAction = Action.Attacking;
                DisableEverything();
            }
            if (Input.GetKeyDown("4") & _player.power > 5)
            {
                _player.timeStartedSwitchingAt = Time.time;
                _player.currentAction = Action.Switching;
                _player.switchingToAction = Action.Shielding;
                DisableEverything();
            }


            switch (_player.currentAction)
            {
                case Action.Switching:
                    if (Time.time - _player.timeStartedSwitchingAt > _player.switchDelay)
                    {
                        _player.currentAction = _player.switchingToAction;
                        switch (_player.currentAction)
                        {
                            case Action.Switching:
                                break;
                            case Action.Charging:
                                break;
                            case Action.Moving:
                                foreach (VisualThrustComponent thrustComponent in _thrusters)
                                {
                                    thrustComponent.isActiveModule = true;
                                }
                                break;
                            case Action.Attacking:
                                _weapon.isActiveWeapon = true;
                                break;
                            case Action.Shielding:
                                _shield.isActiveWeapon = true;
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }
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

    private void DisableEverything()
    {
        _weapon.isActiveWeapon = false;
        foreach (VisualThrustComponent thrustComponent in _thrusters)
        {
            thrustComponent.isActiveModule = false;
        }

        _shield.isActiveWeapon = false;
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
            _player.power -= Time.deltaTime * _player.powerDrainedPerSystemPerSecond ;
        }
        else if (_player.power < 0)
        {
            _player.power = 0;
            _player.timeStartedSwitchingAt = Time.time;
            _player.currentAction = Action.Switching;
            _player.switchingToAction = Action.Charging;
            DisableEverything();
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
