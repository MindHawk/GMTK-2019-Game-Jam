using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementComponent : MonoBehaviour
{
    public float speed = 1;
    // Horizontal and vertical are input axis, -1 to 1 
    public void Start()
    {
        if (GetComponent<AIComponent>() != null)
        {
            speed *= Random.Range(0.6f, 1.8f);
        }
    }

    public void Move(float horizontal, float vertical)
    {
        transform.position += new Vector3(horizontal * Time.deltaTime, vertical * Time.deltaTime) * speed;
    }
}
