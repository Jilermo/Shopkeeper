using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacterState : MonoBehaviour
{
    // How long before going to the next Animation
    public float animationsDuration;

    //Controller in charge of setting directions
    CharacterController characterController;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();

    }

    public void up()
    {

    }

    public void down()
    {

    }

    public void left()
    {

    }

    public void right()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
