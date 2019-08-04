using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualThrustComponent : MonoBehaviour
{
    public bool isActiveModule = true;
    SpriteRenderer spriteRenderer;
    TrailRenderer trailRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        trailRenderer = GetComponent<TrailRenderer>();
    }

    void Update()
    {
        if (isActiveModule)
        {
            Color spriteColor = spriteRenderer.color;
            spriteColor.a = 255;
            spriteRenderer.color = spriteColor;

            trailRenderer.emitting = true;
        }
        else
        {
            Color spriteColor = spriteRenderer.color;
            spriteColor.a = 0;
            spriteRenderer.color = spriteColor;

            trailRenderer.emitting = false;
        }
    }
}
