using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldCollisions : MonoBehaviour
{
    ElectricityPool electricityPool;
    public GameObject shield;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "EnemyOrbAttack")
        {
            electricityPool.mana += 0.2f;
        }
    }

}
