using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearSoundClutter : MonoBehaviour
{
    [SerializeField] AudioSource _audioSource;
    void Start()
    {
        
    }
    void Update()
    {
        if (!_audioSource.isPlaying)
        {
            Destroy(gameObject);
        }
    }
}
