using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] float _lifeTime;
    [SerializeField] float _speed;
    private Transform _transform;
    void Start()
    {
        _transform = GetComponent<Transform>();
        _transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
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
