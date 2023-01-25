using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigidBody;
    Animator animator;
    AudioSource audioSource;
    public float moveSpeed;
    private Vector2 moveDirection;
    private Vector2 lastMoveDirection;
    public bool talked;
    public bool canMove;

    private float moveX;
    private float moveY;

    public AudioClip step;
    public VirtualJoystick joystick;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        talked = false;
        lastMoveDirection = new Vector2(0, -1);
    }

    void Update()
    {
        ProcessInputs();
        Animate();
    }

    void FixedUpdate() {
        Move();
    }


    void ProcessInputs()
    {
        // PC
        /*moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");*/

        // Movil
        moveX = joystick.Horizontal();
        moveY = joystick.Vertical();
    }

    void Move()
    {
        if (canMove)
        {
            if ((moveX == 0 && moveY == 0) && moveDirection.x != 0 || moveDirection.y != 0) lastMoveDirection = moveDirection;
            moveDirection = new Vector2(moveX, moveY).normalized;
            rigidBody.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        }
    }

    void Animate()
    {
        animator.SetFloat("Horizontal", moveDirection.x);
        animator.SetFloat("Vertical", moveDirection.y);
        animator.SetFloat("Magnitude", moveDirection.magnitude);
        animator.SetFloat("LastHorizontal", lastMoveDirection.x);
        animator.SetFloat("LastVertical", lastMoveDirection.y);
    }

    public bool PickUp()
    {
        if (moveX == 0 && moveY == 0)
        {
            animator.SetTrigger("PickUp");
            return true;
        }
        else return false;
    }

    public void LockMovement()
    {
        canMove = false;
        rigidBody.velocity = new Vector2(0, 0);
        lastMoveDirection = moveDirection;
        moveDirection = new Vector2(0, 0);
    }

    public void UnlockMovement()
    {
        canMove = true;
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
