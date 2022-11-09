using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingshotMinigameManager : MonoBehaviour
{
    public static SlingshotMinigameManager Instance;

    public ThrowableObject ThrowableObject;

    public int turn = 0;
    public bool canThrow = false;
    private float [] windAngleValues = {0f, 45f, 90f, 135f, 180f, 225f, 270f, 315f};
    private float [] windPowerValues = {3f, 5f, 7f};
    public float windAngle;
    public float windPower;
    public float throwAngle;
    public float throwPower;
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
        windAngle = windAngleValues[Random.Range(0, windAngleValues.Length)];
        windPower = windPowerValues[Random.Range(0, windPowerValues.Length)];
    }

    public void EndTurn(bool success)
    {
        if (success)
        {
            points++;
            print("NICE!");
        }
        else
        {
            print("MEH!");
        }
        Invoke("StartTurn", 2.0f);
    }
}
