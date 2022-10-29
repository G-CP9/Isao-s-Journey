using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FlowerController : MonoBehaviour
{
    // Start is called before the first frame update
    //Detectamos si el jugador colisiona con un objeto

    private bool _isPickedUp = false;
    private bool ctrl;
    string flor;
    BoxCollider2D bd;

    //Vinculamos el personaje
    public PlayerScript PlayerScript;


    private void Start()
    {

        bd = GetComponent<BoxCollider2D>();
        PlayerScript = FindObjectOfType<PlayerScript>();   
        
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log(collision.gameObject.tag);

            if (ctrl && !_isPickedUp)
            {
                flor = (this.gameObject.tag).ToString();
                Debug.Log(flor);
                PlayerScript.UpdateScore(flor);
                transform.SetParent(collision.transform, true);
                _isPickedUp = true;
                Destroy(this.gameObject);

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
