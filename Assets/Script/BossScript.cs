using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossScript : MonoBehaviour
{
    
    public float pathRadius;

    public float attackRadius;

    public float stopRadius;

    public float moveSpeed;

    private bool isAttacking;
    private Transform player;
    private float cooldown;
    [SerializeField] public float recharge = 5f;
    private EnemyAttack _enemyAttack;
    private Vector3 toPlayer;

    public int health = 1000;
    public int damageMultiplier = 50;

    private GameObject leftLeg;
    private GameObject rightLeg;

    private float yMax = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        // Find the player and get their transform
        player = GameObject.Find("Player").transform;
        
        // Grab the instance of the enemy attack that we can call its methods
        _enemyAttack = GetComponent<EnemyAttack>();
        
        cooldown = recharge;

        leftLeg = GameObject.Find("left_leg");
        rightLeg = GameObject.Find("right_leg");
    }

    // Update is called once per frame
    void Update()
    {
        toPlayer = player.position - transform.position;
        if (toPlayer.magnitude <= attackRadius && cooldown <= 0f)
        {
            cooldown = recharge;
            _enemyAttack.attack(transform.position, Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(toPlayer.y, toPlayer.x) * Mathf.Rad2Deg)));
        }

        if (toPlayer.magnitude <= pathRadius && toPlayer.magnitude >= stopRadius)
        {
            if (toPlayer.x < 0)
            {
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else
            {
                transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            transform.Translate(moveSpeed * Time.deltaTime * toPlayer);
        }

        cooldown -= Time.deltaTime;

        if (health <= 0)
        {
            SceneManager.LoadScene(3);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerProjectile"))
        {
            print("enemy health: " + health);
            health -= damageMultiplier;
            Destroy(collision.gameObject);
        }
    }
}
