using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    public float projectileSpeed;
    
    private Rigidbody2D _rigidbody;

    private AudioSource audioSource;

    private bool hasCollided = false;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();


        _rigidbody = GetComponent<Rigidbody2D>();
        audioSource.Play();

        Vector3 forward = transform.rotation * Vector3.right;
        
        _rigidbody.velocity = forward * projectileSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Environment"))
        {
            Destroy(gameObject);
            _rigidbody.velocity = Vector3.zero;
        }

    }
}
