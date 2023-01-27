using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SlingshotMinigameManager : MonoBehaviour
{
    public static SlingshotMinigameManager Instance;

    public ThrowableObject throwableObject;
    public ThrowInput throwInput;
    public Animator animator;
    public Wind Wind;
    public TextMeshProUGUI score;
    public TextMeshProUGUI throwResult;
    public ButtonPressed upButton;
    public ButtonPressed downButton;
    public ButtonPressed throwButton;
    public GameObject book;

    public int turn = 0;
    public bool canThrow = false;
    private float [] windAngleValues = {0f, 45f, 90f, 135f, 180f, 225f, 270f, 315f};
    public float [] windPowerValues; // must be 3 so it matches arrow colors
    public float windAngle;
    public float windPower;
    public float throwAngle;
    public float MAX_THROW_POWER;
    public float throwPower;
    public int POINTS_TO_WIN;
    public int points;
    public bool openBook;

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
        if (upButton.isPressed)
        {
            throwAngle += 20 * Time.deltaTime;
        }
        if (downButton.isPressed)
        {
            throwAngle -= 20 * Time.deltaTime;
        }
        throwAngle += Input.GetAxisRaw("Vertical") * 20 * Time.deltaTime;
        if (throwAngle > 45f) throwAngle = 45f;
        else if (throwAngle < 0f) throwAngle = 0f;


        if (canThrow && (Input.GetKey(KeyCode.Space) || throwButton.isPressed))
        {
            throwPower += 10 * Time.deltaTime;
            if (throwPower > MAX_THROW_POWER) throwPower = MAX_THROW_POWER;
            throwInput.SetPower();
        } 
         else if (canThrow && (Input.GetKeyUp(KeyCode.Space) || throwButton.buttonReleased))
        {
            throwButton.buttonReleased = false;
            AnimateThrow();
        }
    }

    public void StartTurn()
    {
        throwResult.text = "";
        throwPower = 0;
        throwInput.Show();
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
        throwInput.Hide();
        if (success)
        {
            points++;
            score.text = points + "/" + POINTS_TO_WIN;
            if (points == POINTS_TO_WIN)
            {
                throwResult.text = "¡HAS GANADO!";
                Invoke("SwapScene", 2.0f);
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

    public void SwapScene()
    {
        SceneManager.LoadScene(sceneName:"Montovo2");
    }

    public void ToggleInstructionsManual()
    {
        openBook = !openBook;
        book.SetActive(openBook);
    }
}
