using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public float pathRadius;

    public float attackRadius;

    public float stopRadius;

    public float moveSpeed;

    private bool isAttacking;
    private Transform player;
    private float cooldown;
    [SerializeField] public float recharge = 10f;
    private EnemyAttack _enemyAttack;
    private Vector3 toPlayer;
    
    // Start is called before the first frame update
    void Start()
    {
        // Find the player and get their transform
        player = GameObject.Find("Player").transform;
        
        // Grab the instance of the enemy attack that we can call its methods
        _enemyAttack = GetComponent<EnemyAttack>();

        cooldown = recharge;
    }

    // Update is called once per frame
    void Update()
    {
        toPlayer = player.position - transform.position;
        // print(Mathf.Atan2(toPlayer.y, toPlayer.x));
        if (toPlayer.magnitude <= attackRadius && cooldown <= 0f)
        {
            cooldown = recharge;
            _enemyAttack.attack(transform.position, Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(toPlayer.y, toPlayer.x) * Mathf.Rad2Deg)));
        }

        if (toPlayer.magnitude <= pathRadius && toPlayer.magnitude >= stopRadius)
        {
            toPlayer = toPlayer.normalized;
            transform.Translate(moveSpeed * Time.deltaTime * toPlayer);
        }

        cooldown -= Time.deltaTime;
    }
}
