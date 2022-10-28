using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetFlower : MonoBehaviour
{
    // Start is called before the first frame update
    //Detectamos si el jugador colisiona con un objeto

    private bool _isPickedUp = false;
    private bool ctrl;
    private BoxCollider2D bd;
    

    private void Start()
    {
        bd = GetComponent<BoxCollider2D>();

        
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
     
        Debug.Log(collision.gameObject);
        if(collision.gameObject.tag == "Player")
        {
            
            if (ctrl && !_isPickedUp)
            {
                transform.SetParent(collision.transform, true);
                _isPickedUp = true;
                Destroy(bd.gameObject);

            }

        }
        

        

    }




    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.P))
        {
            ctrl = true;
        }
        else if (Input.GetKeyUp(KeyCode.P))
        {
            ctrl = false;

            if (_isPickedUp)
            {
                transform.SetParent(null);
                _isPickedUp = false;
            }
        }
    }

   
}
