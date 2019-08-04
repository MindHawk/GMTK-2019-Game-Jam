using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIComponent : MonoBehaviour
{
    private MovementComponent _move;
    private WeaponComponent _weapon;

    public AIType _aiType;
    
    // Start is called before the first frame update
    void Start()
    {
        _move = GetComponent<MovementComponent>();
        _weapon = GetComponent<WeaponComponent>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (_aiType)
        {
            case AIType.SimpleUp:
                _move.Move(0.2f, 1);
                break;
            case AIType.SimpleDown:
                _move.Move(0.2f, -1);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        
        _weapon.FireProjectile();

        if (Math.Abs(transform.position.x) > 11 || Math.Abs(transform.position.y) > 7)
        {
            Destroy(gameObject);
        }
    }
}
