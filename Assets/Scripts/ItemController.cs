using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Implement item movement logic here
    private void Update()
    {
        // Add movement logic for items (e.g., moving left)
        // You can make items move automatically or in patterns
    }
}
