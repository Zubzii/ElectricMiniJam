using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShieldCollisions : MonoBehaviour
{
    public ElectricityPool electricityPool;
    public GameObject shield;
    [SerializeField] public float rechargeRate = 0.05f;
    public AudioSource audioSource;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            if (electricityPool.mana <= 1)
            {
                electricityPool.mana += rechargeRate;
            }
            audioSource.Play();
            Destroy(collision.gameObject);

        }
    }



}

