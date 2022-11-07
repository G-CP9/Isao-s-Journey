using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableObject : MonoBehaviour
{
    [SerializeField] float _InitialVelocity;
    [SerializeField] float _Angle;
    [SerializeField] Transform _FirePoint;

    private void Start() {
        transform.position = _FirePoint.position;
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            float angle = _Angle * Mathf.Deg2Rad;
            StopAllCoroutines();
            StartCoroutine(Coroutine_Movement(_InitialVelocity, angle));
        }
    }

    IEnumerator Coroutine_Movement(float initialVelocity, float angle)
    {
        float time = 0;
        while (time < 100)
        {
            float x = initialVelocity * time * Mathf.Cos(angle);
            float y = initialVelocity * time * Mathf.Sin(angle) - (1f / 2f) * - Physics.gravity.y * Mathf.Pow(time, 2);
            transform.position = _FirePoint.position + new Vector3(x, y, 0);
            time += Time.deltaTime;
            yield return null;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Ground")
        {
            StopAllCoroutines();
        }
    }
}
