using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCWalkControl : MonoBehaviour
{
    public float speed;
    int vertical, horizontal;
    public bool upDown;

    Rigidbody2D rigidbody2d;
    Animator animator;
    AudioSource audioSource;

    public AudioClip step;

    void Start()
    {
        vertical = -1;
        horizontal = -1;
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
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

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    public void Step()
    {
        PlaySound(step);
    }
}
