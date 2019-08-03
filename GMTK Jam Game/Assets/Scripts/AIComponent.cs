using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIComponent : MonoBehaviour
{
    private MovementComponent _move;
    private WeaponComponent _weapon;
    // Start is called before the first frame update
    void Start()
    {
        _move = GetComponent<MovementComponent>();
        _weapon = GetComponent<WeaponComponent>();
    }

    // Update is called once per frame
    void Update()
    {
        _move.Move(0.25f, 1);
        _weapon.FireProjectile();
    }
}
