using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCWalkControl : MonoBehaviour
{
    public float speed;
    int vertical, horizontal;
    public bool upDown;
    bool moving;

    Rigidbody2D rigidbody2d;
    Animator animator;
    AudioSource audioSource;

    public AudioClip step;

    void Start()
    {
        horizontal = -1;
        vertical = -1;
        moving = true;
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;

        if (moving)
        {
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
        }

        rigidbody2d.MovePosition(position);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            moving = false;
            rigidbody2d.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
            animator.SetBool("Moving", moving);
        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            vertical = -vertical;
            horizontal = -horizontal;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            moving = true;
            if (upDown)
                rigidbody2d.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            else
                rigidbody2d.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
            animator.SetBool("Moving", moving);
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
