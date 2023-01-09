using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : CharacterController
{
    bool pressed = false;
    public Transform characterPosition;
    TestFloorGrid floorGrid;
    List<FloorGridClass> currentPath;
    bool traversing=false;

    // Start is called before the first frame update
    void Start()
    {
        floorGrid = GameObject.Find("FloorGrid").GetComponent<TestFloorGrid>();

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
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 startPoint = GetCharacterPosition();
            Vector2 endPoint = GetMouseWorldPosition();
            currentPath = floorGrid.FindPath(startPoint,endPoint);
            currentPath.RemoveAt(0);
            checkNextDirection();
            //grid.SetGridObject(GetMouseWorldPosition(),true);
        }

        if (traversing)
        {
            Debug.Log("target="+ currentPath[0].getX()+","+ currentPath[0].getY() + "current= " + getCurrentCell().getX() + "," + getCurrentCell().getY());
            if (currentPath[0].getX() == getCurrentCell().getX() && currentPath[0].getY() == getCurrentCell().getY())
            {
                traversing = false;
                currentPath.RemoveAt(0);
                checkNextDirection();
            }
        }

    }


    public Vector2 GetMouseWorldPosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    public Vector2 GetCharacterPosition()
    {
        return characterPosition.position;
    }

    public void checkNextDirection()
    {
        if (currentPath != null)
        {
            if (currentPath.Count > 0)
            {
                CharacterAnimator.Directions currentDirection;
                currentDirection=getNextDirectio(getCurrentCell(), currentPath[0]);
                traversing = true;
                switch (currentDirection)
                {
                    case CharacterAnimator.Directions.up:
                        UP.Invoke();
                        break;
                    case CharacterAnimator.Directions.down:
                        DOWN.Invoke();
                        break;
                    case CharacterAnimator.Directions.left:
                        LEFT.Invoke();
                        break;
                    case CharacterAnimator.Directions.right:
                        RIGHT.Invoke();
                        break;
                    case CharacterAnimator.Directions.stop:
                        STOP.Invoke();
                        traversing = false;
                        break;
                    default:
                        break;
                }

            }
            else
            {
                STOP.Invoke();
            }
        }
    }

    public CharacterAnimator.Directions getNextDirectio(FloorGridClass startGrid, FloorGridClass endGrid)
    {
        if (startGrid.getX() != endGrid.getX())
        {
            if (startGrid.getX() > endGrid.getX())
            {
                return CharacterAnimator.Directions.left;
                
            }
            else
            {
                return CharacterAnimator.Directions.right;
                
            }
        }
        else if (startGrid.getY() != endGrid.getY())
        {
            if (startGrid.getY() > endGrid.getY())
            {
                return CharacterAnimator.Directions.down;
            }
            else
            {
                return CharacterAnimator.Directions.up;
            }
        }
        else
        {
            return CharacterAnimator.Directions.stop;
        }
    }

    public FloorGridClass getCurrentCell()
    {
        Vector2Int currentFloorCell = floorGrid.floorGrid.GetGrid().GetXY(GetCharacterPosition());
        return floorGrid.floorGrid.GetGrid().GetGridObject(currentFloorCell.x, currentFloorCell.y);
    }
}
