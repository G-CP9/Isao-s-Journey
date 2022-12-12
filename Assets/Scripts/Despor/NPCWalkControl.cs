using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCWalkControl : MonoBehaviour
{
    public float speed;
    public bool upDown;
    int vertical, horizontal;

    Rigidbody2D rigidbody2d;
    Animator animator;

    void Start()
    {
        horizontal = -1;
        vertical = -1;
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;

        if (upDown)
        {
            position.y += speed * vertical * Time.deltaTime;
            animator.SetFloat("Vertical", vertical);
        }
        else
        {
            position.x += speed * horizontal * Time.deltaTime;
            animator.SetFloat("Horizontal", horizontal);
        }

        rigidbody2d.MovePosition(position);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            vertical = -vertical;
            horizontal = -horizontal;
        }
    }
}
