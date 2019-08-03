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
        if (_power > 90)
        {
            _image.sprite = sprites[0];
        }
        else if (_power < 90 && _power > 75)
        {
            _image.sprite = sprites[1];
        }
        else if (_power < 75 && _power > 60)
        {
            _image.sprite = sprites[2];
        }
        else if (_power < 60 && _power > 45)
        {
            _image.sprite = sprites[3];
        }
        else if (_power < 45 && _power > 30)
        {
            _image.sprite = sprites[4];
        }
        else if (_power < 30)
        {
            _image.sprite = sprites[5];
        }
    }
}
