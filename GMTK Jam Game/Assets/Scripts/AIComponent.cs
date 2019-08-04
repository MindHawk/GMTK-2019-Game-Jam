using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIComponent : MonoBehaviour
{
    private MovementComponent _move;
    private WeaponComponent _weapon;
    [SerializeField] private int _health = 3;
    [SerializeField] private int _scoreValue = 100;
    [SerializeField] private GameObject _deathSound;

    public AIType aiType;

    public float direction = 1;

    private float _x;
    
    // Start is called before the first frame update
    void Start()
    {
        _move = GetComponent<MovementComponent>();
        _weapon = GetComponent<WeaponComponent>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (aiType)
        {
            case AIType.Simple:
                _move.Move(0.2f, direction);
                break;
            case AIType.Wavy:
                _move.Move(_x, direction);
                _x += 3f * Time.deltaTime;
                if (_x > 2)
                {
                    _x = -2;
                }
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        
        _weapon.FireProjectile();

        if (Math.Abs(transform.position.x) > 10.5f || Math.Abs(transform.position.y) > 6.5f)
        {
            Destroy(gameObject);
        }

        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage (int damageAmount)
    {
        _health -= damageAmount;
    }

    private void OnDestroy()
    {
        if (_health <= 0)
        {
            GameObject SoundEmitter = Instantiate(_deathSound, transform, true);
            AudioSource audioSource = SoundEmitter.GetComponent<AudioSource>();
            audioSource.Play();
            SoundEmitter.transform.parent = null;

            PlayerComponent player = FindObjectOfType<PlayerComponent>();
            player.score += _scoreValue;
        }
    }
}
