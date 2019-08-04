using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] float lifeTime;
    [SerializeField] float speed;
    [SerializeField] int damage = 1;
    public bool isEnemyBullet;
    void Start()
    {
        transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        var trans = transform;
        trans.position += trans.rotation * (Time.deltaTime * speed * Vector3.up);
        lifeTime -= Time.deltaTime;
        
        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }
        
        if (Math.Abs(transform.position.x) > 11 || Math.Abs(transform.position.y) > 7)
        {
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isEnemyBullet)
        {
            PlayerComponent player = other.GetComponent<PlayerComponent>();
            if (player != null)
            {
                Destroy(gameObject);
                Destroy(other.gameObject);
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
                Debug.Log("Hit");
                AIShip.TakeDamage(damage);
                Destroy(gameObject);
            }
            
            ProjectileController projectile = other.GetComponent<ProjectileController>();
            if (projectile != null)
            { //We've collided onto a projectile! 
                //If it's an enemy projectile, destroy this?
            }
        }
    }
}
