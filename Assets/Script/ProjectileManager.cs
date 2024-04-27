using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    public float projectileSpeed;
    
    private Rigidbody2D _rigidbody;
    
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        
        Vector3 forward = transform.rotation * Vector3.right;
        
        _rigidbody.velocity = forward * projectileSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.tag);
        if (collision.CompareTag("Enemy") || collision.CompareTag("Environment"))
        {
            print("HERE");
            Destroy(gameObject);
        }
    }
}
