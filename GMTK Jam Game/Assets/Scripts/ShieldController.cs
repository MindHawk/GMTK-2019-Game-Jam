using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour
{
    public bool isPlayerWeapon = true;
    public bool isActiveWeapon = false;

    void Start()
    {

    }

    void Update()
    {
        if (isPlayerWeapon && isActiveWeapon)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 1f;

            Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
            mousePos.x -= objectPos.x;
            mousePos.y -= objectPos.y;

            float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
        }
    }
}
