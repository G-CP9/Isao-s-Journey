using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Return_origin : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector2 originalPos;

    public Vector2 position;

    void Start()
    {
        originalPos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
        if (position != originalPos)
        {
            this.gameObject.transform.position = originalPos;
        }
    }
}
