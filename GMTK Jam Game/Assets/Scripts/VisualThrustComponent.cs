using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualThrustComponent : MonoBehaviour
{
    public bool isActiveModule = true;
    SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (isActiveModule)
        {
            Color spriteColor = spriteRenderer.color;
            spriteColor.a = 255;
            spriteRenderer.color = spriteColor;
        }
        else
        {
            Color spriteColor = spriteRenderer.color;
            spriteColor.a = 0;
            spriteRenderer.color = spriteColor;
        }
    }
}
