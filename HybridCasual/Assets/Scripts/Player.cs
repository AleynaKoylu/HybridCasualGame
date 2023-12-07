using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject Joystick;
    JoystickManager joystickManager;
    public float speed;
    public float roatateSpeed;
    CharacterController characterController;
    Vector3 move;
    public Animator animator;
   
    void Start()
    {
        joystickManager = Joystick.GetComponent<JoystickManager>();
        characterController=GetComponent<CharacterController>();
    }

   
    void Update()
    {
        if (joystickManager.haveMove == true)
        {
            
            MovePlayer();
            animator.SetBool("Run", true);
            transform.forward = move.normalized;

        }
        else 
        {
            animator.SetBool("Run", false);
        }
        
    }
    void MovePlayer()
    {
         move=joystickManager.MoveValue()*speed * Time.deltaTime/Screen.width;
        move.z = move.y;
        move.y = 0;
        characterController.Move(move);
        
    }
}
