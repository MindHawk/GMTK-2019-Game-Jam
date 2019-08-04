using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplayController : MonoBehaviour
{
    [SerializeField] Text _scoreText;
    [SerializeField] PlayerComponent _player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _scoreText.text = "Score: " + _player.score;
    }
}
