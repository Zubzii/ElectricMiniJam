using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 15;
    Rigidbody2D body;
    private float horizontalInput;
    private float verticalInput;
    private Vector3 originalScale;
    private Collider2D shieldCollider;
    public GameObject shield;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        originalScale = transform.localScale; 
        body.constraints = RigidbodyConstraints2D.FreezeRotation;
        shieldCollider = shield.GetComponent<Collider2D>();
    }

    void FixedUpdate()
    {
        if (!shieldCollider.enabled)
        {
            horizontalInput = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
            verticalInput = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

            //horizontalInput = Input.GetAxis("Horizontal") * moveSpeed;
            //verticalInput = Input.GetAxis("Vertical") * moveSpeed;

            body.velocity = new Vector2(horizontalInput, verticalInput);

            if (horizontalInput > 0)
            {
                transform.localScale = new Vector3(Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);
            }
            else if (horizontalInput < 0)
            {
                transform.localScale = new Vector3(-Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);
            }
        }
        else
        {
            body.velocity = Vector2.zero;
        }
    }
}
