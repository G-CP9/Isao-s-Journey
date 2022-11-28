using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
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
    private bool canMove = true;
    private bool canInteract = false;
    

    //Player actions
    string flower;
    string thing;


    //The toolbar
    public ToolBarController toolBar;

    //Book
    public GameObject Book;
    bool book_open;

    //Box

    public BoxController box;
    bool box_open;

    //Bin
    public BinController bin;
    bool bin_open;


    //Player animations
    private Animator animator;


    public float moveSpeed = 1f;
    public float maxSpeed = 5f;

    public float idleFriction = 1.5f;
    Rigidbody2D rb;
    private Vector2 input = Vector2.zero;

    bool isPoison;

    //object
    public GameObject flower_object;

    



    private void Start()
    {
        toolBar = FindObjectOfType<ToolBarController>();
        box = FindObjectOfType<BoxController>();


        rb = GetComponent<Rigidbody2D>();

        Book.SetActive(false);

        


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
    //Get player's inputs
    void Update()
    {
        Inputs();
        
        
    }

    //Get new player's position after an input
    void OnMove(InputValue value)
    {
        input = value.Get<Vector2>();
    }

   
    //Animate the player with the correct animation
    void Animate()
    {
        animator.SetBool("isMoving", isMoving);
    }


    //Player's inputs
    void Inputs()
    {
        //If the button pressed is <<P>> & player isn't moving
        if (canInteract)
        {
            if ((Input.GetKeyUp(KeyCode.P)))
            {

                if(thing == "flower")
                {
                    if (toolBar.num_objects < 10)
                    {
                        Pick(thing);
                    }
                    else
                    {
                        Debug.Log("Inventario lleno");
                    }
                }

                else if(thing == "box")
                {
                    if (!box_open)
                    {
                        canMove = false;
                        box_open = true;
                        box.OpenState(box_open);

                    }
                    else
                    {
                        box_open = false;
                        box.OpenState(box_open);
                        canMove = true;
                        
                        
                    }
                }
                else if (thing == "bin")
                {
                    if (!bin_open)
                    {
                        canMove = false;
                        bin_open = true;
                        bin.OpenState(bin_open);

                    }
                    else
                    {
                        bin_open = false;
                        bin.OpenState(bin_open);
                        canMove = true;


                    }
                }

            }
            
        }

        //Pude abrir el libro en cualquier momento
        if (Input.GetKeyDown(KeyCode.B) && !box_open)
        {
            if (!book_open)
            {
                canMove = false;
                Book.SetActive(true);
                book_open = true;
            }
            else if(book_open)
            {
                canMove = true;
                Book.SetActive(false);
                book_open = false;
            }
        }
        if (isMoving) { thing = "Null"; }
        
    }



    private void OnCollisionStay2D(Collision2D collision)
    {

        Debug.Log(collision.gameObject.tag);
        //If the player is touching a Flower
        if ((collision.gameObject.tag == "Lavanda") || (collision.gameObject.tag == "Camomila") || (collision.gameObject.tag == "Calendula"))
        {
            //Thing is a flower
            thing = "flower";
            //Get what type of Flower
            flower = (collision.gameObject.tag).ToString();
            flower_object = collision.gameObject;


        }
        else if ((collision.gameObject.tag == "Box"))
        {
            thing = "box";
            
        }
        else if ((collision.gameObject.tag == "Bin"))
        {
            thing = "bin";

        }



        Debug.Log(thing);
        

    }

    private void Pick(string thing)
    {
        //Activate the <<Pick Flower animation>>
        
        if(thing == "flower")
        {
            //The player is picking a flower
            

            int i = Random.Range(1, 3);


            if (i == 2)
            {
                isPoison = true;
            }
            else
            {
                isPoison = false;
            }

            animator.SetTrigger("Pick");
        }
        if(thing == "box" && box.isThrowing == true)
        {
            animator.SetTrigger("Pick");
        }
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        canInteract = true;
        flower = "Null";
        thing = "Null";
    }


        //EVENTS
        //Block the movement when the player is picking or throwing
    void LockMovement()
    {
        canMove = false;

        canInteract = false; //Already interacting with something

    }

    //Unlock the movement when the player finish the pick animation
    void UnlockMovement()
    {
        if(thing == "flower")
        {
            Debug.Log(flower);
            Debug.Log(isPoison);
            toolBar.PickFlower(flower, isPoison);

            Destroy(flower_object);
        }

        
        canMove = true;
    }










}


