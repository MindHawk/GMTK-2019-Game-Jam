using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerDisplayController : MonoBehaviour
{
    [SerializeField] GameObject _player;
    [SerializeField] Sprite[] sprites = new Sprite[6];
    PlayerComponent playerComponent;
    Image _image;
    void Start()
    {
        playerComponent = _player.GetComponent<PlayerComponent>();
        _image = GetComponent<Image>();
    }

    void Update()
    {
        float _power = playerComponent.power;
        if (_power > 81)
        {
            _image.sprite = sprites[0];
        }
        else if (_power > 61)
        {
            _image.sprite = sprites[1];
        }
        else if (_power > 41)
        {
            _image.sprite = sprites[2];
        }
        else if (_power > 21)
        {
            _image.sprite = sprites[3];
        }
        else if (_power > 1)
        {
            _image.sprite = sprites[4];
        }
        else
        {
            _image.sprite = sprites[5];
        }
    }
}
