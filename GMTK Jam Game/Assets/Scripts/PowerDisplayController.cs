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
        if (_power == 100)
        {
            _image.sprite = sprites[0];
        }
        else if (_power < 100 && _power > 80)
        {
            _image.sprite = sprites[1];
        }
        else if (_power < 80 && _power > 60)
        {
            _image.sprite = sprites[2];
        }
        else if (_power < 60 && _power > 40)
        {
            _image.sprite = sprites[3];
        }
        else if (_power < 40 && _power > 20)
        {
            _image.sprite = sprites[4];
        }
        else if (_power < 20)
        {
            _image.sprite = sprites[5];
        }
    }
}
