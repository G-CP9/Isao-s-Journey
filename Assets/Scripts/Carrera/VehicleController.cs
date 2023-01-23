using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VehicleController : MonoBehaviour
{
    public float speed = 3.0f;
    float horizontal, vertical, wheelRotation = 0;
    int maxHealth = 3, currentHealth;
    bool isInvincible = false;
    float invincibleTimer, invincibleTime = 3.0f;

    Rigidbody2D rigidBody2d;
    Animator animator;
    AudioSource audioSource;
    public AudioSource carEngine;
    public UIHealthController UIHealth;
    public GameObject endText;
    public VirtualJoystick joystick;

    public AudioClip hit;
    void Start()
    {
        rigidBody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        currentHealth = maxHealth;
        invincibleTimer = invincibleTime;
    }

    void Update()
    {
        // PC
        /*horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");*/

        // Movil
        horizontal = joystick.Horizontal();
        vertical = joystick.Vertical();
        ChangeEnginePitch();

        if (!Endline.end)
        {
            if (horizontal == 1)
                wheelRotation += 720 * Time.deltaTime;
            else if (horizontal == -1)
                wheelRotation += 360 * Time.deltaTime;
            else
                wheelRotation += 540 * Time.deltaTime;
            gameObject.transform.GetChild(1).transform.rotation = Quaternion.Euler(0, 0, -wheelRotation);
            gameObject.transform.GetChild(2).transform.rotation = Quaternion.Euler(0, 0, -wheelRotation);
        }

        if(isInvincible)
        {
            invincibleTimer -= Time.deltaTime;

            if(invincibleTimer <= 0)
            {
                isInvincible = false;
                invincibleTimer = invincibleTime;
            }
        }
    }

    private void FixedUpdate()
    {
        if (!Endline.end)
        {
            Vector2 move = new Vector2(horizontal, vertical);
            Vector2 position = rigidBody2d.position;

            position += move * speed * Time.deltaTime;
            rigidBody2d.MovePosition(position);
        }
    }

    public void Hit(int damage)
    {
        if (!isInvincible)
        {
            PlaySound(hit);
            isInvincible = true;

            currentHealth = Mathf.Clamp(currentHealth - damage, 0, maxHealth);
            UIHealth.ChangeSprite(currentHealth);
            if (currentHealth <= 0)
            {
                Endline.end = true;
                joystick.gameObject.SetActive(false);
                endText.SetActive(true);
                Destroy(gameObject);
            }
            animator.SetTrigger("Hit");
        }
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    void ChangeEnginePitch()
    {
        if (horizontal > 0)
        {
            carEngine.pitch = 1.2f;
        }
        else if (horizontal < 0)
        {
            carEngine.pitch = 0.9f;
        }
        else
        {
            carEngine.pitch = 1;
        }
    }
}
