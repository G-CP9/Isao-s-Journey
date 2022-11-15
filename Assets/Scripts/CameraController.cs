using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*public class CameraController : MonoBehaviour
{

    Player player;
    public float FollowSpeed;
    public float yOffset = 1f;
    public Transform target;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        FollowSpeed = player.moveSpeed;
    }
    private void Update()
    {
        Vector3 newPos = new Vector3(target.position.x, target.position.y + yOffset, -5f);
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
    }
}*/

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    private void Update()
    {
        transform.position = new Vector3(
            Mathf.Clamp(player.position.x, -74.93f, 78.66f),
            Mathf.Clamp(player.position.y, -24.9f, 24.5f),
            transform.position.z);
    }

}