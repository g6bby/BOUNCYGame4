using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float minX, maxX, minY, maxY;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Implement item movement logic here
    private void Update()
    {
        // Add movement logic for items (e.g., moving left)
        // You can make items move automatically or in patterns
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, minX, maxX);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, minY, maxY);
        transform.position = clampedPosition;

        if (clampedPosition.y > 10 || clampedPosition.y < -10)
        {
            Destroy(gameObject);

        }
    }


}
