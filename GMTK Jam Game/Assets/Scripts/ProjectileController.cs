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
}
