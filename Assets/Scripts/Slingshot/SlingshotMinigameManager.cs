using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SlingshotMinigameManager : MonoBehaviour
{
    public static SlingshotMinigameManager Instance;

    public ThrowableObject throwableObject;
    public ThrowInput throwInput;
    public Animator animator;
    public Wind Wind;
    public TextMeshProUGUI score;
    public TextMeshProUGUI throwResult;

    public int turn = 0;
    public bool canThrow = false;
    private float [] windAngleValues = {0f, 45f, 90f, 135f, 180f, 225f, 270f, 315f};
    public float [] windPowerValues; // must be 3 so it matches arrow colors
    public float windAngle;
    public float windPower;
    public float throwAngle;
    public float MAX_THROW_POWER;
    public float throwPower = 0;
    public int POINTS_TO_WIN;
    public int points = 0;

    private void Awake() {
        Instance = this;
    }

    private void Start()
    {
        score.text = points + "/" + POINTS_TO_WIN;
        throwInput.SetMaxPower();
        ChangeWind();
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
        throwResult.text = "";
        throwPower = 0;
        throwInput.SetPower();
        turn++;
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
            score.text = points + "/" + POINTS_TO_WIN;
            if (points == POINTS_TO_WIN)
            {
                throwResult.text = "HAS GANADO!";
                // TODO CAMBIAR DE ESCENA
            }
            else
            {
                throwResult.text = "¡BIEN!";
                ChangeWind();
            }
        }
        else
        {
            throwResult.text = "¡VUELVE A INTENTARLO!";
        }
        if (points != POINTS_TO_WIN)
        {
            Invoke("StartTurn", 2.0f);
        }
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
