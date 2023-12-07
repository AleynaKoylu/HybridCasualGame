using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UIElements;

public class JoystickManager : MonoBehaviour
{
    public RectTransform outJoystick, intoJoystick;
    Vector3 joystickTransform;
    public float moveValue;
    Vector3 move;
    public bool haveMove;
    public void ShowJoystick()
    {
        joystickTransform = Input.mousePosition;
        outJoystick.transform.position = joystickTransform;
        outJoystick.gameObject.SetActive(true);
        
    }
    public void HideJoystick()
    {
        outJoystick.gameObject.SetActive(false);
        haveMove = false;
        move = Vector3.zero;
    }
    public void MoveJoystick()
    {
        Vector3 currentPos = Input.mousePosition;
        Vector3 Distance = currentPos - joystickTransform;
        float canvasYScale=GetComponentInParent<Canvas>().GetComponent<RectTransform>().localScale.y;
        float moveMagnitude = Distance.magnitude * moveValue * canvasYScale;
        float joystickHalfWidth = outJoystick.rect.width / 2;
        float newWidth = joystickHalfWidth * canvasYScale;

        moveMagnitude = Mathf.Min(moveMagnitude, newWidth);
        move = Distance.normalized * moveMagnitude;
        Vector3 targetPos = joystickTransform + move;
        intoJoystick.transform.position = targetPos;
        haveMove = true;
    }
    public Vector3 MoveValue()
    {
        return move;
    }
}
