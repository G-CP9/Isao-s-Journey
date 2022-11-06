using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawn : MonoBehaviour
{
    public List<GameObject> flowerToSpawn = new List<GameObject>();

    public bool isTimer;
    public float timeToSpawn;
    private float currentTimeToSpawn;

    public bool isRandomized;

    private void Start()
    {
        currentTimeToSpawn = timeToSpawn;
        SpawnObject();
    }

    public void SpawnObject()
    {

        int index = isRandomized ? Random.Range(0, flowerToSpawn.Count) : 0;
        if(flowerToSpawn.Count > 0)
        {
            Instantiate(flowerToSpawn[index], transform.position, transform.rotation);
        }
    }

    
}
