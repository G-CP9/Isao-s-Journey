using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public float moveSpeed;
    private bool isMoving;
    private Vector2 input;

    private Animator animator;

    //Toolbar
    public Text Blue_flowers;
    int num_blue;
    public GameObject Icon_B; //icono de la flor azul

    public Text Pink_flowers;
    int num_pink;
    public GameObject Icon_P; //icono de la flor azul

    private void Start()
    {
        //Ocultamos Botones
        Icon_B.SetActive(false);
        Icon_P.SetActive(false);

    }

    private void Awake()
    {
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!isMoving)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            if (input.x != 0) input.y = 0;

            if (input != Vector2.zero)
            {
                animator.SetFloat("moveX", input.x);
                animator.SetFloat("moveY", input.y);

                var targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;

                StartCoroutine(Move(targetPos));
            }
        }

        animator.SetBool("isMoving", isMoving);
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

    public void UpdateScore(string item)
    {
        if (item == "Blue")
        {
            Debug.Log("Ha entrado, guarra");
            num_blue += 1;
            Debug.Log(num_blue);
            Blue_flowers.text = "x" + num_blue.ToString();

            if (num_blue == 1)
            {
                Icon_B.SetActive(true);
            }
        }
        if (item == "Pink")
        {
            num_pink++;
            Pink_flowers.text = "x" + num_pink.ToString();

            if (num_pink == 1)
            {
                Icon_P.SetActive(true);
            }

        }

    }




}
