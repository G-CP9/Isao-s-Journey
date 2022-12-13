using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    private void Awake()
    {
        transform.localScale = new Vector3(transform.localScale.x / transform.parent.localScale.x, 
            transform.localScale.y / transform.parent.localScale.y, transform.localScale.z / transform.parent.localScale.z);
    }

    void Update()
    {
        if (transform.position.x < -(Camera.main.orthographicSize * 2 * (16/9)))
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        VehicleController player = collision.gameObject.GetComponent<VehicleController>();

        if (player != null)
        {
            player.Hit(1);
            Destroy(gameObject);
        }
    }
}
