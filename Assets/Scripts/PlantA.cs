using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;





public class PlantA : MonoBehaviour
{
    // Start is called before the first frame update
    //Detectamos si el jugador colisiona con un objeto

    private bool _isPickedUp = false;
    private bool ctrl;
    string flor;

    //Vinculamos el personaje
    public ToolBarController toolBar;
    public PlayerScript playerScript;

    


    private void Start()
    {

        toolBar = FindObjectOfType<ToolBarController>();
        playerScript = FindObjectOfType<PlayerScript>();

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //Debug.Log(collision.gameObject.tag);

            if (ctrl && !_isPickedUp)
            {
                //Identificamos el tipo de flor que recogemos
                flor = (this.gameObject.tag).ToString();

                //Actualizamos el inventario
                toolBar.UpdateScore(flor);



                //Destruimos el objeto después de cogerlo
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
