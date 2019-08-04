using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComponent : MonoBehaviour
{
    public float power;
    public float maximumPower = 100f;
    
    public bool actionsLockedToOne = true;
    public Action currentAction;
    public Action switchingToAction;
    public float timeStartedSwitchingAt;
    public float switchDelay = 0.5f;
    public int score;

    public float powerChargedPerSecond = 5f;
    public float powerDrainedPerSystemPerSecond = 1.5f;

    [SerializeField] private GameObject _deathSound;
    [SerializeField] private List<GameObject> RestartScreen;
    [SerializeField] private GameObject _deathParticles;
    
    void Start()
    {
        currentAction = Action.Moving;
        power = maximumPower;
        score = 0;
    }

    void Update()
    {
    }

    private void OnDestroy()
    {
        GameObject ParticleEmitter = Instantiate(_deathParticles, transform);
        ParticleEmitter.transform.parent = null;

        foreach (GameObject gameObject in RestartScreen)
        {
            gameObject.SetActive(true);
        }

        GameObject SoundEmitter = Instantiate(_deathSound, transform, true);
        AudioSource audioSource = SoundEmitter.GetComponent<AudioSource>();
        audioSource.Play();
        SoundEmitter.transform.parent = null;
    }
}
