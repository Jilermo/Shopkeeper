using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    public enum Directions{
        up,
        down,
        left,
        right,
        stop
    }
    // How long before going to the next Animation
    float animationsDuration;

    //Controller in charge of setting directions
    CharacterController characterController;
    CharacterCustomization characterCustomization;

    int animationStartFrame;
    int animationEndFrame;
    int currentFrame;

    float elapsedTime;

    Directions currentDirection=Directions.up;

    
    Vector3 walkingDirection = Vector3.zero;

   //Speed for moving
    float speed;
    private void Awake()
    {
        animationsDuration = GlobalVariables.characterAnimationDuration;
        speed = GlobalVariables.charactersSpeed;
    }

    private void Start()
    {
        characterCustomization = GetComponent<CharacterCustomization>();
    }

    private void OnEnable()
    {
        characterController = GetComponent<CharacterController>();
        characterController.UP.AddListener(up);
        characterController.DOWN.AddListener(down);
        characterController.LEFT.AddListener(left);
        characterController.RIGHT.AddListener(right);
        characterController.STOP.AddListener(stop);
    }

    private void OnDisable()
    {
        characterController.UP.RemoveListener(up);
        characterController.DOWN.RemoveListener(down);
        characterController.LEFT.RemoveListener(left);
        characterController.RIGHT.RemoveListener(right);
        characterController.STOP.RemoveListener(stop);
    }

    public void up()
    {
        currentDirection = Directions.up;
        animationStartFrame = 10;
        animationEndFrame = 15;
        walkingDirection = Vector3.up;
        resetAnimationValues();
    }

    public void down()
    {   
        currentDirection = Directions.down;
        animationStartFrame = 22;
        animationEndFrame = 27;
        walkingDirection = Vector3.down;
        resetAnimationValues();
    }

    public void left()
    {
        currentDirection = Directions.left;
        animationStartFrame = 16;
        animationEndFrame = 21;
        walkingDirection = Vector3.left;
        resetAnimationValues();
    }

    public void right()
    {
        currentDirection = Directions.right;
        animationStartFrame = 4;
        animationEndFrame = 9;
        walkingDirection = Vector3.right;
        resetAnimationValues();
    }

    public void resetAnimationValues()
    {
        currentFrame = animationStartFrame;
        elapsedTime = Time.time;
    }

    public void stop()
    {
        switch (currentDirection)
        {
            case Directions.up:
                animationStartFrame = 1;
                animationEndFrame = 1;
                
                break;
            case Directions.down:

                animationStartFrame = 3;
                animationEndFrame = 3;
                break;
            case Directions.left:
                animationStartFrame = 2;
                animationEndFrame = 2;
                break;
            case Directions.right:
                animationStartFrame = 0;
                animationEndFrame = 0;
                break;
            default:
                break;
        }

        walkingDirection = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time-elapsedTime>animationsDuration)
        {
            transform.position += walkingDirection*speed;
            currentFrame += 1;
            if (currentFrame>animationEndFrame)
            {
                currentFrame = animationStartFrame;
            }
            characterCustomization.setNewFrame(currentFrame);
            elapsedTime = Time.time;
        }
    }

   
}
