using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    public float projectileSpeed;
    
    private Rigidbody2D _rigidbody;

    private AudioSource[] audioSources;
    private AudioSource firstAudioSource;
    private AudioSource secondAudioSource;
    private bool hasCollided = false;
    
    void Start()
    {
        audioSources = GetComponents<AudioSource>();
        firstAudioSource = audioSources[0];
        secondAudioSource = audioSources[1];

        _rigidbody = GetComponent<Rigidbody2D>();
        secondAudioSource.Play();

        Vector3 forward = transform.rotation * Vector3.right;
        
        _rigidbody.velocity = forward * projectileSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Here is the tag! " + collision.tag);
        if (!hasCollided && (collision.CompareTag("Shield") || collision.CompareTag("Enemy") || collision.CompareTag("Environment")))
        {
            OnDestroyPlayerProjectile();
            hasCollided = true;
            _rigidbody.velocity = Vector3.zero;
        }

    }

    public void OnDestroyPlayerProjectile()
    {
        Destroy(gameObject);
        firstAudioSource.Stop();
        secondAudioSource.Play();
    }
}
