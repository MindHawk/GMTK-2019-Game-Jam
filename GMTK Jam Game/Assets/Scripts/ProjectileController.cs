﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] float _lifeTime;
    [SerializeField] float _speed;
    public bool isEnemyBullet;
    void Start()
    {
        transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        var trans = transform;
        trans.position += trans.rotation * (Time.deltaTime * _speed * Vector3.up);
        if(_lifeTime > 0)
        {
            _lifeTime -= Time.deltaTime;
        }
        else if (_lifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Triggered");
        if (isEnemyBullet)
        {
            PlayerComponent player = other.GetComponent<PlayerComponent>();
            if (player != null)
            {
                Destroy(gameObject);
            }

            ShieldComponent shield = other.GetComponent<ShieldComponent>();
            if (shield != null)
            { 
                Destroy(gameObject);
                
            }

            ProjectileController projectile = other.GetComponent<ProjectileController>();
            if (projectile != null)
            { 
                Destroy(gameObject);
            }
        }
        else
        {
            AIComponent AIShip = other.GetComponent<AIComponent>();
            if (AIShip != null)
            { //We've hit an enemy vessel!
                
            }
            
            ProjectileController projectile = other.GetComponent<ProjectileController>();
            if (projectile != null)
            { //We've collided onto a projectile! 
                //If it's an enemy projectile, destroy this?
            }
        }
    }
}
