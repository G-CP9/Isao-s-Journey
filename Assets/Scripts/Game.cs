using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static Game Instance;

    public bool sound = true;

    private void Awake()
    {
        Instance = this;
    }
}
