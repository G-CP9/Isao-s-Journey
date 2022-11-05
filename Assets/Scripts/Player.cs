using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using Random = UnityEngine.Random;




public class Player : MonoBehaviour
{
    bool IsMoving
    { 
        set{
            isMoving = value;
            animator.SetBool("isMoving", isMoving);
        }
    }

    //Player Movement
    bool isMoving = false;
    private bool isPicking = false;
    private bool canMove = true;
    private bool canInteract = true;
    

    //Player actions
    string flower;
    string thing;

    //Vinculamos la toolbar
    public ToolBarController toolBar;




    //Player animations
    private Animator animator;


    public float moveSpeed = 1f;
    public float maxSpeed = 5f;

    public float idleFriction = 1.5f;
    Rigidbody2D rb;
    private Vector2 input = Vector2.zero;
    





    private void Start()
    {
        toolBar = FindObjectOfType<ToolBarController>();

        rb = GetComponent<Rigidbody2D>();

    }

    private void FixedUpdate()
    {
        if(input != Vector2.zero && canMove == true)
        {
            animator.SetFloat("moveX", input.x);
            animator.SetFloat("moveY", input.y);
            rb.velocity = Vector2.ClampMagnitude(rb.velocity + (input * moveSpeed * Time.deltaTime), maxSpeed);
            IsMoving = true;
        }
        else
        {
            rb.velocity = Vector2.Lerp(rb.velocity, Vector2.zero, idleFriction);
            IsMoving = false;
        }




    }

    private void Awake()
    {
        animator = GetComponent<Animator>();

    }



    // Update is called once per frame
    void Update()
    {
        Inputs();
    }

    void OnMove(InputValue value)
    {
        input = value.Get<Vector2>();
    }

   

    void Animate()
    {
        animator.SetBool("isMoving", isMoving);
    }


    void Inputs()
    {
        if (Input.GetKeyUp(KeyCode.P))
        {
            if (thing == "flower")
            {
                animator.SetTrigger("PickFlower");
                isPicking = true;
            }


        }
        else if(isMoving)
        {
            isPicking = false;

        }
    }



    private void OnCollisionStay2D(Collision2D collision)
    {
        

        if ((collision.gameObject.tag == "PlantA") || (collision.gameObject.tag == "PlantB") || (collision.gameObject.tag == "PlantC"))
        {
            Debug.Log(collision.gameObject.tag);
            thing = "flower";
            if (isPicking)
            {

                //Identificamos el tipo de flor que recogemos
                flower = (collision.gameObject.tag).ToString();
                

                //Decidimos de forma aleatoria si la flor será venenosa
                int i = Random.Range(1, 4);
                Debug.Log(i);
                if (i == 2)
                {
                    flower = "Poison";
                }

                //Actualizamos el inventario
                toolBar.UpdateScore(flower);

                //Destruimos el objeto después de cogerlo

                

                Destroy(collision.gameObject);

                

            }


        }



    }

    void LockMovement()
    {
        canMove = false;
        canInteract = true;
    }

    void UnlockMovement()
    {
        canMove = true;
        canInteract=false;
    }

 

    
} 
