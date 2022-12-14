using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject food;
    int n_food;

    private void Start()
    {
        n_food = 0;
    }
    private void Update()
    {
        while(n_food < 5)
        {
            GameObject food_refill = GameObject.Instantiate(food);
            food_refill.transform.SetParent(gameObject.transform);
            Food_controller f = food_refill.GetComponent<Food_controller>();
            f.Spawn();
        }
    }

   
}
