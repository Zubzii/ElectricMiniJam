using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatAttack : MonoBehaviour
{
    public Transform attackPosition;

    public GameObject projectile;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            print("HERE IS THE ROTATION: " + Quaternion.Angle(attackPosition.rotation, Quaternion.identity));
            Instantiate(projectile, attackPosition.position, attackPosition.rotation);
        }
    }
}
