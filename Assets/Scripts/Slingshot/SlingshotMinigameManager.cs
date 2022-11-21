using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingshotMinigameManager : MonoBehaviour
{
    public static SlingshotMinigameManager Instance;

    public ThrowableObject throwableObject;
    public ThrowInput throwInput;
    public Animator animator;
    public Wind Wind;

    public int turn = 0;
    public bool canThrow = false;
    private float [] windAngleValues = {0f, 45f, 90f, 135f, 180f, 225f, 270f, 315f};
    public float [] windPowerValues; // must be 3 so it matches arrow colors
    public float windAngle;
    public float windPower;
    public float throwAngle;
    public float throwPower;
    public float MAX_THROW_POWER;
    public int points;

    private void Awake() {
        Instance = this;
    }

    private void Start()
    {
        throwPower = 0;
        points = 0;
        throwInput.SetMaxPower();
    }

    private void Update()
    {
        throwAngle += Input.GetAxisRaw("Vertical") * 20 * Time.deltaTime;
        if (throwAngle > 45f) throwAngle = 45f;
        else if (throwAngle < 0f) throwAngle = 0f;


        if (canThrow && Input.GetKey(KeyCode.Space))
        {
            throwPower += 10 * Time.deltaTime;
            if (throwPower > MAX_THROW_POWER) throwPower = MAX_THROW_POWER;
            throwInput.SetPower();
        } 
         else if (canThrow && Input.GetKeyUp(KeyCode.Space))
        {
            AnimateThrow();
        }
    }

    public void StartTurn()
    {
        throwPower = 0;
        throwInput.SetPower();
        turn++;
        ChangeWind();
        canThrow = true;
        throwableObject.StartTurn();
    }

    public void ChangeWind()
    {
        windAngle = windAngleValues[Random.Range(0, windAngleValues.Length)];
        windPower = windPowerValues[Random.Range(0, windPowerValues.Length)];
        Wind.UpdateDirection();
        Wind.UpdateColor();
    }

    public void EndTurn(bool success)
    {
        if (success)
        {
            points++;
        }
        Invoke("StartTurn", 2.0f);
    }

    public void AnimateThrow()
    {
        if (throwAngle < 16) animator.SetTrigger("ThrowLow");
        else if (throwAngle < 31) animator.SetTrigger("ThrowMedium");
        else animator.SetTrigger("ThrowHigh");
    }

    public void Throw()
    {
        throwableObject.Throw();
    }
}
