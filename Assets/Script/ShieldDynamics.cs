using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldDynamics : MonoBehaviour
{
    public GameObject shield;

    public Collider2D shieldCollider;

    public float rotationSpeed;

    public float amplitude;
    public float period;
    
    // Start is called before the first frame update
    void Start()
    {
        shieldCollider = shield.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (shieldCollider.enabled)
        {
            shield.transform.localScale = Vector3.one + (shield.transform.localScale * Mathf.Sin(period * Time.deltaTime * Mathf.Rad2Deg));
            shield.transform.Rotate(0f, 0f, transform.rotation.z + (rotationSpeed * Time.deltaTime));
            
            print(Quaternion.Euler(0f, 0f, rotationSpeed * Time.deltaTime));
            print(shield.transform.rotation);
        }
    }
}
