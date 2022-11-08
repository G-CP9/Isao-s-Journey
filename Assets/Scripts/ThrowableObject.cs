using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableObject : MonoBehaviour
{
    public Transform SlingshotHead;
    public float angle;
    public float power;
    private Rigidbody2D rb;
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;
    private bool turnFinished;
    private SlingshotMinigameManager minigame;

    void Start()
    {
        minigame = SlingshotMinigameManager.Instance;
        rb = GetComponent<Rigidbody2D>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
        minigame.StartTurn();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && minigame.canThrow)
        {
            Throw();
        }
        if ((transform.position.y - objectHeight) < -screenBounds.y || (transform.position.x - objectWidth) < -screenBounds.x || (transform.position.x + objectWidth) > screenBounds.x)
        {
            if (!turnFinished)
            {
                FinishTurn(false);
            }
        }
    }

    public void Throw()
    {
        minigame.canThrow = false;
        rb.gravityScale = 1;
        // slingshot throw
        float radAngle = angle * Mathf.Deg2Rad;
        float x = Mathf.Cos(radAngle) * power;
        float y = Mathf.Sin(radAngle) * power;
        // wind influence
        float windRadAngle = minigame.windAngle * Mathf.Deg2Rad;
        float windX = Mathf.Cos(windRadAngle) * minigame.windPower;
        float windY = Mathf.Sin(windRadAngle) * minigame.windPower;
        // throw
        rb.velocity = new Vector2(x + windX, y + windY);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            FinishTurn(false);
        }
        if (other.gameObject.tag == "Platform")
        {
            rb.velocity = rb.velocity/2;
            FinishTurn(true);
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.tag == "Platform")
        {
            StopObject();
        }
    }

    private void PlaceObject()
    {
        rb.gravityScale = 0;
        transform.position = SlingshotHead.position;
        StopObject();
    }

    private void StopObject() {
        rb.velocity = new Vector2(0, 0);
        rb.angularVelocity = 0;
    }

    public void StartTurn()
    {
        turnFinished = false;
        PlaceObject();
    }

    public void FinishTurn(bool success)
    {
        turnFinished = true;
        minigame.EndTurn(success);
    }

}
