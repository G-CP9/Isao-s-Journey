using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableObject : MonoBehaviour
{
    public Transform SlingshotHead;
    public float angle;
    public float power;
    public float windAngle;
    public float windPower;
    private Rigidbody2D rb;
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;
    private bool onFlight;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        transform.position = SlingshotHead.position;
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
        onFlight = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !onFlight)
        {
            Throw();
        }
        if ((transform.position.y - objectHeight) < -screenBounds.y || (transform.position.x - objectWidth) < -screenBounds.x || (transform.position.x + objectWidth) > screenBounds.x)
        {
            onFlight = false;
        }
    }

    public void Throw()
    {
        onFlight = true;
        rb.gravityScale = 1;
        transform.position = SlingshotHead.position;
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
            onFlight = false;
        }
        if (other.gameObject.tag == "Platform")
        {
            rb.velocity = rb.velocity/2;
            onFlight = false;
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.tag == "Platform")
        {
            rb.velocity = new Vector2(0, 0);
            rb.angularVelocity = 0;
        }
    }
}
