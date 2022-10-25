using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;

public class PlayerController : MonoBehaviour
{
   private Rigidbody2D rb;
   private Animator anim;
   public float hf = 0.0f;
   public float vf = 0.0f;

   public float movementSpeed = 5f;
   public Vector2 movement;

   

   private void Start()
   {
    rb = this.GetComponent<Rigidbody2D>();
    anim = this.GetComponent<Animator>();
    

   }

   private void Update()
   {
    
    movement.x = Input.GetAxisRaw("Horizontal");
    movement.y = Input.GetAxisRaw("Vertical");
    movement = movement.normalized;

    hf = movement.x > 0.01f ? movement.x : movement.x < -0.01f ? 1 : 0;
    vf = movement.y > 0.01f ? movement.y : movement.y < -0.01f ? 1 : 0;
    if (movement.x < -0.01f)
    {
        this.gameObject.transform.localScale = new Vector3(-1, 1, 1);
    } else
    {
        this.gameObject.transform.localScale = new Vector3(1, 1, 1);
    }

    anim.SetFloat("Horizontal", hf);
    anim.SetFloat("Vertical", movement.y);
    anim.SetFloat("Speed", vf);

    
   }

   private void FixedUpdate()
   {
    rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);
   }

}

