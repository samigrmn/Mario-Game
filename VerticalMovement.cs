using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed=3;
    public float minHeight = 1;
    public float maxHeight = 8;

    void Start()
    {
        rb.velocity = new Vector2(0, -speed);
    }

    // Update is called once per frame
    void Update()
    {
        Physics2D.queriesStartInColliders = false;
        RaycastHit2D hit = Physics2D.Raycast(gameObject.transform.position, Vector2.down, 8);

        
        
            if (hit.distance <= minHeight)
            {
                rb.velocity = new Vector2(0, speed);

            }
            else if (hit.distance >= maxHeight)
            {
                rb.velocity = new Vector2(0, -speed);
            }
        
    }
}