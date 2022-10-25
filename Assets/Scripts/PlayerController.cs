using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;

public class PlayerController : MonoBehaviour
{
   private Rigidbody2D rb2D;
   private Animator animator;

   public float speed = 2.0f;

   

   private void Start()
   {
    rb2D = GetComponent<Rigidbody2D>();
    animator = GetComponent<Animator>();

   }

   private void Update()
   {

    if(Input.GetKey(KeyCode.A))
    {
        animator.Play("Left");
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
    if(Input.GetKey(KeyCode.D))
    {
        GetComponent<Animator>().SetTrigger("D");
    }
    if(Input.GetKey(KeyCode.S))
    {
        GetComponent<Animator>().SetTrigger("S");
    }
    if(Input.GetKey(KeyCode.W))
    {
        GetComponent<Animator>().SetTrigger("W");
    }
    
   }
}

