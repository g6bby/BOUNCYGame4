using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Animator playerAnim;
    public RuntimeAnimatorController animatorBounce;
    public RuntimeAnimatorController animatorIdle;
    private bool isCollidingWithItem = false;

    public int score = 0;
    public int lives = 3;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;

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
        transform.position = clampedPosition;

        GameObject[] items = GameObject.FindGameObjectsWithTag("Item");

        foreach (GameObject item in items)
        {
            float yPosition = item.transform.position.y;
            
            if (yPosition > 7)
            {
                score++;
                scoreText.text = "SCORE: " + score.ToString();

                Destroy(item);
            }

            if (yPosition < -7)
            {
                lives--;
                livesText.text = "LIVES: " + lives.ToString();

                Destroy(item);
            }
        }

        if (lives == 0)
        {
            SceneManager.LoadScene("GameOver");

        }
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
