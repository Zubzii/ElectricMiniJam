using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public GameObject projectile;
    // Update is called once per frame
    void Update()
    {
        
    }

    public void attack(Vector3 origin, Quaternion direction)
    {
        GameObject bolt = Instantiate(projectile, origin, direction);
        bolt.tag = "Projectile";
    }
}
