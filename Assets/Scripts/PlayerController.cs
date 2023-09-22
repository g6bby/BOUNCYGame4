using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator playerAnim;
    public RuntimeAnimatorController animatorBounce;
    public RuntimeAnimatorController animatorIdle;
    private bool isCollidingWithItem = false;



    public float moveSpeed = 5.0f;
    public float bounceForce = 10.0f;

    public float minX, maxX, minY, maxY;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        rb.velocity = movement;

        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, minX, maxX);
        //clampedPosition.y = Mathf.Clamp(clampedPosition.y, minY, maxY);
        transform.position = clampedPosition;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            Vector2 bounceDirection = (collision.transform.position - transform.position).normalized;

            Rigidbody2D itemRb = collision.gameObject.GetComponent<Rigidbody2D>();
            itemRb.velocity = bounceDirection * bounceForce;

            playerAnim.runtimeAnimatorController = animatorBounce;

            isCollidingWithItem = true;

        }
    }

    private IEnumerator DelayedIdle()
    {
        yield return new WaitForSeconds(0.5f);

        if (isCollidingWithItem)
        {
            playerAnim.runtimeAnimatorController = animatorIdle;
        }
    }

     private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            StartCoroutine(DelayedIdle());

        }
    }
}

