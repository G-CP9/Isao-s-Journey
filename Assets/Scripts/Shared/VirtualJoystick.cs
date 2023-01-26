using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class VirtualJoystick : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    private Image bg;
    private Image joystick;
    private Vector3 inputVector;

    private void Start()
    {
        bg = GetComponent<Image>();
        joystick = transform.GetChild(0).GetComponent<Image>();
    }

    public virtual void OnDrag(PointerEventData ped)
    {
        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(bg.rectTransform
                                                                    , ped.position
                                                                    , ped.pressEventCamera
                                                                    , out pos))
        {
            pos.x = (pos.x / bg.rectTransform.sizeDelta.x);
            pos.y = (pos.y / bg.rectTransform.sizeDelta.y);

            inputVector = new Vector3(pos.x * 2, 0, pos.y * 2);
            inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;

            // Mover imagen joystick
            joystick.rectTransform.anchoredPosition =
                new Vector3(inputVector.x * (bg.rectTransform.sizeDelta.x / 3)
                            , inputVector.z * (bg.rectTransform.sizeDelta.y / 3));
        }
    }

    public virtual void OnPointerDown(PointerEventData ped)
    {
        OnDrag(ped);
    }

    public virtual void OnPointerUp(PointerEventData ped)
    {
        inputVector = Vector3.zero;
        joystick.rectTransform.anchoredPosition = Vector3.zero;
    }

    public float Horizontal()
    {
        if (inputVector.x != 0)
            return inputVector.x;
        else
            return Input.GetAxis("Horizontal");
    }

    public float Vertical()
    {
        if (inputVector.z != 0)
            return inputVector.z;
        else
            return Input.GetAxis("Vertical");
    }

    public void Hide()
    {
        inputVector = Vector3.zero;
        joystick.rectTransform.anchoredPosition = Vector3.zero;
        this.gameObject.SetActive(false);
    }
}
