using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponComponent : MonoBehaviour
{
    [SerializeField] private GameObject _projectile;

    private float _lastFiredAt = 0;
    
    public bool isActive = true;
    public float delayBetweenShots = 0.5f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 1f;

            Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
            mousePos.x -= objectPos.x;
            mousePos.y -= objectPos.y;

            float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
        }
    }

    public void FireProjectile()
    {
        if (_lastFiredAt + delayBetweenShots < Time.time)
        {
            _lastFiredAt = Time.time;
            Instantiate(_projectile, transform);
        }
    }
}
