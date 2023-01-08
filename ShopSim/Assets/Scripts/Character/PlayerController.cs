using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : CharacterController
{
    bool pressed = false;
    // Start is called before the first frame update
    void Start()
    {
        if (UP == null)
            UP = new UnityEvent();

        if (DOWN == null)
            DOWN = new UnityEvent();

        if (LEFT == null)
            LEFT = new UnityEvent();

        if (RIGHT == null)
            RIGHT = new UnityEvent();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && !pressed)
        {
            UP.Invoke();
            pressed = true;
        }
        else if (Input.GetKeyDown(KeyCode.A) && !pressed)
        {
            LEFT.Invoke();
            pressed = true;
        }
        else if (Input.GetKeyDown(KeyCode.S) && !pressed)
        {
            DOWN.Invoke();
            pressed = true;
        }
        else if (Input.GetKeyDown(KeyCode.D) && !pressed)
        {
            RIGHT.Invoke();
            pressed = true;
        }else if (!Input.anyKey && pressed)
        {
            STOP.Invoke();
            pressed = false;
        }
    }
}
