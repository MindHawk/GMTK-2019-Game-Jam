using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyIn10Seconds : MonoBehaviour
{
    [SerializeField] float lifeTime = 10f;

    // Update is called once per frame
    void Update()
    {
        lifeTime -= Time.deltaTime;
        
        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }
}
