using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BinController : MonoBehaviour
{

    // Start is called before the first frame update
    //Detectamos si el jugador colisiona con un objeto

    /* BoxCollider2D bin;
    public GameObject TextBox;

    public GameObject key_icons;
    private bool interact = false;
    private bool ctrl;

    private int key;
    




    private void Start()
    {

        bin = GetComponent<BoxCollider2D>();
        TextBox.SetActive(false);
        key_icons.SetActive(false);

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ctrl = true;

        }
        else if (Input.GetKeyUp(KeyCode.P))
        {
            ctrl = false;
            if (interact)
            {
                transform.SetParent(null);
                interact = false;
            }
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Player")
        {
            Debug.Log(ctrl);
            Debug.Log(interact);

            if (ctrl && !interact)
            {
                Debug.Log("SE DEBERIA ACTIVAR AAAAA");
                interact = true;
                Mostrar_texto(interact);


            }
        }
    }

    private void Mostrar_texto(bool indicador)
    {
        TextBox.SetActive(true);
        key_icons.SetActive(true);
        throw (key);

    }

    private void throw_()
    {

    }
    */


}
