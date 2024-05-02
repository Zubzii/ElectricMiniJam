using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatAttack : MonoBehaviour
{
    public Transform attackPosition;

    public GameObject projectile;
    public GameObject shield;
    private Collider2D shieldCollider;
    
    private float cooldown;
    [SerializeField] public float recharge = 1f;

    private void Start()
    {
        cooldown = recharge;
        shieldCollider = shield.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (shieldCollider.enabled == false && Input.GetMouseButtonDown(0) && cooldown <= 0f)
        {
            cooldown = recharge;
            GameObject projectileInstance = Instantiate(projectile, attackPosition.position, attackPosition.rotation);
            projectileInstance.tag = "PlayerProjectile";
        }

        cooldown -= Time.deltaTime;
    }
}
