using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingshotMinigameManager : MonoBehaviour
{
    public static SlingshotMinigameManager Instance;

    public ThrowableObject ThrowableObject;

    public int turn = 0;
    public bool canThrow = false;
    public float windAngle;
    public float windPower;
    public int points = 0;

    private void Awake() {
        Instance = this;
    }

    public void StartTurn()
    {
        turn++;
        ChangeWind();
        canThrow = true;
        print("Turn: " + turn);
        ThrowableObject.StartTurn();
    }

    public void ChangeWind()
    {
        windAngle = Random.Range(0f, 360f);
        windPower = Random.Range(0f, 10f);
    }

    public void EndTurn(bool success)
    {
        if (success)
        {
            points++;
            print("Points: " + points);
        }
        StartTurn();
    }
}
