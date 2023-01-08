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
        if (Input.GetKeyDown(KeyCode.W))
        {
            UP.Invoke();
            pressed = true;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            LEFT.Invoke();
            pressed = true;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            DOWN.Invoke();
            pressed = true;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            RIGHT.Invoke();
            pressed = true;
        }
        else if (!Input.anyKey && pressed)
        {
            STOP.Invoke();
            pressed = false;
        }
    }
}
