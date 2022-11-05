using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;



public class PlayerScript : MonoBehaviour
{
    //Player Movement
    public float moveSpeed;
    private bool isMoving = false;
    private bool isPicking = false;
    private bool canMove = true;
    private Vector2 input;

    //Player actions
    private bool _isPickedUp = false;
    private bool ctrl;
    string flower;
    string thing;

    //Vinculamos la toolbar
    public ToolBarController toolBar;




    //Player animations
    private Animator animator;
   

    private void Start()
    {
        toolBar = FindObjectOfType<ToolBarController>();
            
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();

    }

   

    // Update is called once per frame
    void Update()
    {
        Inputs();
        Movement();
        Animate();
    }

    void Movement()
    {
        if (!isMoving && canMove == true)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            if (input.x != 0) input.y = 0;

            if (input != Vector2.zero )
            {
                animator.SetFloat("moveX", input.x);
                animator.SetFloat("moveY", input.y);

                var targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;

                StartCoroutine(Move(targetPos));
            }
        }
    }

    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;

        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;

        isMoving = false;
    }

    void Animate()
    {
        animator.SetBool("isMoving", isMoving);
    }


    void Inputs()
    {
        if(Input.GetKeyUp(KeyCode.P))
        {
            if(thing == "Flower")
            {
                animator.SetTrigger("PickFlower");
                isPicking = true;
            }
            
            
        }
        else
        {
            isPicking = false;

        }
    }

  

    private void OnCollisionStay2D(Collision2D collision)
    {
        
        if ((collision.gameObject.tag == "PlantA") || (collision.gameObject.tag == "PlantB") || (collision.gameObject.tag == "PlantC"))
        {
            Debug.Log(collision.gameObject.tag);
            thing = "Flower";
            if (isPicking)
            {
                //Identificamos el tipo de flor que recogemos
                flower = (collision.gameObject.tag).ToString();
                

                //Decidimos de forma aleatoria si la flor será venenosa
                int i = Random.Range(1,6);
                Debug.Log(i);
                if(i == 5)
                {
                    flower = "Poison";
                }

                //Actualizamos el inventario
                toolBar.UpdateScore(flower);

                //Destruimos el objeto después de cogerlo
                
                _isPickedUp = true;
                
                Destroy(collision.gameObject);
                
                
                
            }


        }

        

    }

    void LockMovement()
    {
        canMove = false;
    }

    void UnlockMovement()
    {
        canMove = true;
    }
}
