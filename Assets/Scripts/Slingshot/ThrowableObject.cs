using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableObject : MonoBehaviour
{
    public Transform SlingshotHead;
    private Rigidbody2D rb;
    private AudioSource audioSource;
    private SlingshotMinigameManager minigame;
    private bool turnFinished;
    
    public AudioClip hitSound;

    void Start()
    {
        minigame = SlingshotMinigameManager.Instance;
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        minigame.StartTurn();
    }

    public void Throw()
    {
        minigame.canThrow = false;
        rb.gravityScale = 1;
        // slingshot throw
        float radAngle = minigame.throwAngle * Mathf.Deg2Rad;
        float x = Mathf.Cos(radAngle) * minigame.throwPower;
        float y = Mathf.Sin(radAngle) * minigame.throwPower;
        // wind influence
        float windRadAngle = minigame.windAngle * Mathf.Deg2Rad;
        float windX = Mathf.Cos(windRadAngle) * minigame.windPower;
        float windY = Mathf.Sin(windRadAngle) * minigame.windPower;
        // throw
        rb.velocity = new Vector2(x + windX, y + windY);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Defeat")
        {
            FinishTurn(false);
        }
        else if (other.gameObject.tag == "Ground")
        {
            audioSource.PlayOneShot(hitSound);
            FinishTurn(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        audioSource.PlayOneShot(hitSound);
        FinishTurn(true);
    }

    private void PlaceObject()
    {
        rb.gravityScale = 0;
        transform.position = new Vector3(SlingshotHead.position.x, SlingshotHead.position.y, SlingshotHead.position.z+1);
        transform.rotation = Quaternion.identity;
        StopObject();
    }

    private void StopObject() {
        rb.velocity = new Vector2(0, 0);
        rb.angularVelocity = 0;
    }

    public void StartTurn()
    {
        PlaceObject();
        turnFinished = false;
    }

    public void FinishTurn(bool success)
    {
        if (!turnFinished)
        {
            minigame.EndTurn(success);
            turnFinished = true;
        }
    }

}
