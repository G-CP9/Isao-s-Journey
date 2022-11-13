using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    Player player;
    GameObject parent;
    Bounds bounds;
    bool collidingWithPlayer = false;
    List<string> objetos = new List<string>()
    {
        "Lavanda",
        "Camomila",
        "PlantC",
        "Box",
        "Bin",
        "Wall"
    };
    string obstaculo;

    public void Spawn()
    {
        parent = gameObject.transform.parent.gameObject;
        bounds = parent.GetComponent<SpriteRenderer>().bounds;
        FindLocation();
    }

    public void FindLocation()
    {
        float posX = Random.Range((bounds.center.x - bounds.size.x / 2), (bounds.center.x + bounds.size.x / 2));
        float posY = Random.Range((bounds.center.y - bounds.size.y / 2), (bounds.center.y + bounds.size.y / 2));
        gameObject.transform.position = new Vector2(posX, posY);
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        obstaculo = (other.gameObject.tag).ToString();
        if (obstaculo == "Lavanda")
        {
            FindLocation();
        }
        else if (obstaculo == "Player")
        {
            collidingWithPlayer = true;
            player = other.gameObject.GetComponent<Player>();
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            collidingWithPlayer = false;
        }
    }



}
