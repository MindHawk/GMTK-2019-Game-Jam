using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldComponent : MonoBehaviour
{
    public bool isActiveWeapon;
    void Start()
    {
        
    }

    void Update()
    {
        GetComponent<BoxCollider2D>().enabled = isActiveWeapon;
        GetComponent<SpriteRenderer>().enabled = isActiveWeapon;
    }
}
