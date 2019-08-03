using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundComponent : MonoBehaviour
{
    public float backgroundSpeed = 0.5f;

    // Update is called once per frame
    void Update()
    {
        transform.position += backgroundSpeed * Time.deltaTime * Vector3.left;
        if (transform.position.x < - 14)
        {
            transform.position = new Vector3(-4, 0, 0);
        } 
    }
}
