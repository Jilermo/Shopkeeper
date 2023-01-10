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

    public MainUIScript mainUIScript;

    bool controllingPlayer = false;
    // Start is called before the first frame update
    bool waitForInput = false;
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
       

        if (Input.GetMouseButtonDown(0) && GlobalVariables.controllingPlayer)
        {
            Vector2 startPoint = GetCharacterPosition();
            Vector2 endPoint = GetMouseWorldPosition();
            currentPath = floorGrid.FindPath(startPoint,endPoint);
            if (currentPath!=null)
            {
                currentPath.RemoveAt(0);
                checkNextDirection();
            }
            //grid.SetGridObject(GetMouseWorldPosition(),true);
        }

        if (traversing)
        {
            //Debug.Log("target="+ currentPath[0].getX()+","+ currentPath[0].getY() + "current= " + getCurrentCell().getX() + "," + getCurrentCell().getY());
            if (currentPath[0].getX() == getCurrentCell().getX() && currentPath[0].getY() == getCurrentCell().getY())
            {
                traversing = false;
                currentPath.RemoveAt(0);
                checkNextDirection();
            }
        }

        if (Input.GetMouseButtonDown(1) && !GlobalVariables.controllingPlayer && !waitForInput)
        {
            waitForInput = true;
            StartCoroutine(waitForInputI());
            mainUIScript.closeAlMenus();
            GlobalVariables.controllingPlayer = true;
        }

        //Open Menu's
        if (Input.GetMouseButtonDown(1) && GlobalVariables.controllingPlayer && !waitForInput)
       {
            waitForInput = true;
            StartCoroutine(waitForInputI());
           GlobalVariables.controllingPlayer = false;
           Vector2 clickPosition = GetMouseWorldPosition();
           Vector2Int floorGridXY = floorGrid.floorGrid.GetGrid().GetXY(clickPosition);
            if (floorGrid.floorGrid.checkifCellIsValid(floorGridXY.x, floorGridXY.y))
            {
                if (!floorGrid.floorGrid.GetGrid().GetGridObject(floorGridXY.x, floorGridXY.y).getWalkable())
                {
                    InteractableObject _interactable = floorGrid.floorGrid.GetGrid().GetGridObject(floorGridXY.x, floorGridXY.y).getInteractableObject();
                    mainUIScript.openMenu(clickPosition.x,clickPosition.y,_interactable);
                }
            }

            //grid.SetGridObject(GetMouseWorldPosition(),true);
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

    IEnumerator waitForInputI()
    {
        yield return new WaitForSeconds(0.2f);
        waitForInput = false;
    }
}
