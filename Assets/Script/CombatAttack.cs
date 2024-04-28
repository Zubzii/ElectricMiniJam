using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatAttack : MonoBehaviour
{
    public Transform attackPosition;

    public GameObject projectile;
    
    private float cooldown;
    [SerializeField] public float recharge = 1f;

    private void Start()
    {
        cooldown = recharge;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && cooldown <= 0f)
        {
            cooldown = recharge;
            GameObject projectileInstance = Instantiate(projectile, attackPosition.position, attackPosition.rotation);
            projectileInstance.tag = "PlayerProjectile";
        }

        cooldown -= Time.deltaTime;
    }
}
