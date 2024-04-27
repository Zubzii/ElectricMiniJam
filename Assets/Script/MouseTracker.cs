using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTracker : MonoBehaviour
{
    public Transform attackPosition;

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        var attackPos = Camera.main.WorldToScreenPoint(attackPosition.position);
        
        float angle = Mathf.Atan2(mousePos.y - attackPos.y, mousePos.x - attackPos.x) * Mathf.Rad2Deg;
        
        attackPosition.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
