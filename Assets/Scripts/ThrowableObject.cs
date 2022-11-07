using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableObject : MonoBehaviour
{
    public Transform slingshot;
    public float angle;
    public float power;
    public float windAngle;
    public float windPower;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Throw();
        }
    }

    private void FixedUpdate() {
        
    }

    public void Throw()
    {
        transform.position = slingshot.position;
        // slingshot throw
        float radAngle = angle * Mathf.Deg2Rad;
        float x = Mathf.Cos(radAngle) * power;
        float y = Mathf.Sin(radAngle) * power;
        // wind influence
        float windRadAngle = windAngle * Mathf.Deg2Rad;
        float windX = Mathf.Cos(windRadAngle) * windPower;
        float windY = Mathf.Sin(windRadAngle) * windPower;
        // throw
        rb.velocity = new Vector2(x + windX, y + windY);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            print("touchedGround");
        }
    }
}
