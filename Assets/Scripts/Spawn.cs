using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public int MAX_PLANTS;
    public int INITIAL_PLANTS;

    public GameObject Lavanda;
    public GameObject Camomila;

    public float respawnTime;
    public Vector2 size;

    private void Start()
    {
        for(int i = 0; i < INITIAL_PLANTS; i++)
        {
            spawnPlant();
        }
        StartCoroutine(spawnPlants());
    }

    IEnumerator spawnPlants()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            if (gameObject.transform.childCount < MAX_PLANTS) spawnPlant();
        }
    }

    private void spawnPlant()
    {
        GameObject plant = Instantiate(Lavanda);
        plant.transform.SetParent(gameObject.transform);
        Plant p = plant.GetComponent<Plant>();
        p.Spawn();
    }
}
