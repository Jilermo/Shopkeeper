using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AICharacterController : CharacterController
{
    bool pressed = false;
    public Transform characterPosition;
    TestFloorGrid floorGrid;
    List<FloorGridClass> currentPath;
    bool traversing = false;

    List<ClothStandInteractable> clothStands;
    List<CommonObjectInteractable> commonObjects;

    InteractableObject currentInteractable;

    bool leaving = false;
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
        clothStands = new List<ClothStandInteractable>();
        commonObjects = new List<CommonObjectInteractable>();
        if (GlobalVariables.saveData.clothStands.Count>0)
        {
            for (int i = 0; i < GlobalVariables.saveData.clothStands.Count; i++)
            {
                ClothStandInteractable clothStandInteractable= (ClothStandInteractable)floorGrid.floorGrid.GetGrid().GetGridObject(new Vector2(GlobalVariables.saveData.clothStands[i].x, GlobalVariables.saveData.clothStands[i].y)).interactible;
                float daysMod = GlobalVariables.saveData.numberOfDays * .01f;
                if (daysMod>0.3f)
                {
                    daysMod = 0.3f;
                }
                float _value = (GlobalVariables.saveData.getNumberOfPoints() / 100) + (clothStandInteractable.getClothStand().ClothStandIndex*0.2f)-daysMod;
                if ((_value>Random.value))
                {
                    clothStands.Add(clothStandInteractable);
                    if (clothStands.Count>3)
                    {
                        break;
                    }
                }
            }
            
        }
        Debug.Log("clotstand:" + clothStands.Count);
        if (GlobalVariables.saveData.commonObjects.Count > 0)
        {
            for (int i = 0; i < GlobalVariables.saveData.commonObjects.Count; i++)
            {
                CommonObjectInteractable _commonObjectInteractable = (CommonObjectInteractable)floorGrid.floorGrid.GetGrid().GetGridObject(new Vector2(GlobalVariables.saveData.clothStands[i].x, GlobalVariables.saveData.clothStands[i].y)).interactible;
                float daysMod = GlobalVariables.saveData.numberOfDays * .01f;
                if (daysMod > 0.3f)
                {
                    daysMod = 0.3f;
                }
                float _value = (GlobalVariables.saveData.getNumberOfPoints() / 100) + (_commonObjectInteractable.getPlacedObject().categoryIndex * 0.02f) - daysMod;
                if ((_value>Random.value))
                {
                    commonObjects.Add(_commonObjectInteractable);
                    if (commonObjects.Count > 2)
                    {
                        break;
                    }
                }
            }

        }
        Debug.Log("commonObjects:" + commonObjects.Count);
        getNextDestination();

    }

    // Update is called once per frame
    void Update()
    {

        if (traversing)
        {
            //Debug.Log("target="+ currentPath[0].getX()+","+ currentPath[0].getY() + "current= " + getCurrentCell().getX() + "," + getCurrentCell().getY());
            if (currentPath[0].getX() == getCurrentCell().getX() && currentPath[0].getY() == getCurrentCell().getY())
            {
                currentPath.RemoveAt(0);
                checkNextDirection();
            }
        }


    }

    public void getNextDestination()
    {
        if (clothStands.Count>0)
        {
            FloorGridClass floorGridClass = clothStands[0].getClothStand().getWalkableNeighbour();
            if (floorGridClass!=null)
            {
                Vector2 endPoint = floorGrid.floorGrid.GetGrid().getWorldPosition(floorGridClass.getX(), floorGridClass.getY());
                Vector2 startPoint = GetCharacterPosition();
                currentPath = floorGrid.FindPath(startPoint, endPoint);
                if (currentPath != null)
                {
                    currentInteractable = clothStands[0];
                    currentPath.RemoveAt(0);
                    checkNextDirection();
                }
                else
                {
                    clothStands.RemoveAt(0);
                    getNextDestination();
                }
            }
            else
            {
                clothStands.RemoveAt(0);
                getNextDestination();
            }

        }
        else if(commonObjects.Count > 0)
        {
            FloorGridClass floorGridClass = commonObjects[0].getPlacedObject().getWalkableNeighbour();
            if (floorGridClass != null)
            {
                Vector2 endPoint = floorGrid.floorGrid.GetGrid().getWorldPosition(floorGridClass.getX(), floorGridClass.getY());
                Vector2 startPoint = GetCharacterPosition();
                currentPath = floorGrid.FindPath(startPoint, endPoint);
                if (currentPath != null)
                {
                    currentInteractable = commonObjects[0];
                    currentPath.RemoveAt(0);
                    checkNextDirection();
                }
                else
                {
                    commonObjects.RemoveAt(0);
                    getNextDestination();
                }
            }
            else
            {
                commonObjects.RemoveAt(0);
                getNextDestination();
            }
        }
        else
        {
            leaving = true;
            Vector2 endPoint = floorGrid.floorGrid.GetGrid().getWorldPosition(17, 0);
            Vector2 startPoint = GetCharacterPosition();
            currentPath = floorGrid.FindPath(startPoint, endPoint);
            if (currentPath != null)
            {
                currentPath.RemoveAt(0);
                checkNextDirection();
            }
            else
            {
                Destroy(gameObject, 1f);
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
                currentDirection = getNextDirectio(getCurrentCell(), currentPath[0]);
                if (currentPath.Count>0)
                {
                    currentDirection = getNextDirectio(getCurrentCell(), currentPath[0]);
                }
                else
                {
                    currentDirection = CharacterAnimator.Directions.stop;

                }
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
                        StartCoroutine(startTraversingAgain());
                        break;
                    default:
                        break;
                }

            }
            else
            {
                STOP.Invoke();
                traversing = false;
                StartCoroutine(startTraversingAgain());
            }
        }
    }

    IEnumerator startTraversingAgain()
    {
        yield return new WaitForSeconds(2f);
        checkIfBuyOrPraise();
        yield return new WaitForSeconds(5f);
        if (!leaving)
        {
            getNextDestination();
        }
    }

    public void checkIfBuyOrPraise()
    {
        if (leaving)
        {
            Destroy(gameObject);
        }
        else if (currentInteractable.getInteractableObjectType()==InteractableObject.InteractableObjectType.ClothStand)
        {
            float daysMod = GlobalVariables.saveData.numberOfDays * .01f;
            if (daysMod > 0.3f)
            {
                daysMod = 0.3f;
            }
            ClothStandInteractable clothStandInteractable = (ClothStandInteractable)currentInteractable;
            float _value = (GlobalVariables.saveData.getNumberOfPoints() / 100) + (clothStandInteractable.getClothStand().ClothStandIndex * 0.1f) - daysMod;
            if ((_value>Random.value))
            {
                buyClothes(clothStandInteractable);
            }
            clothStands.RemoveAt(0);
        }
        else if (currentInteractable.getInteractableObjectType() == InteractableObject.InteractableObjectType.CommonObject)
        {
            float daysMod = GlobalVariables.saveData.numberOfDays * .01f;
            if (daysMod > 0.3f)
            {
                daysMod = 0.3f;
            }
            CommonObjectInteractable _commonObjectInteractable = (CommonObjectInteractable)currentInteractable;
            float _value = (GlobalVariables.saveData.getNumberOfPoints() / 100) + (_commonObjectInteractable.getPlacedObject().categoryIndex * 0.02f) - daysMod;
            if ((_value>Random.value))
            {
                GlobalVariables.saveData.setNumberOfPoints(GlobalVariables.saveData.getNumberOfPoints() + 2);
            }
            commonObjects.RemoveAt(0);
        }
    }

    public void buyClothes(ClothStandInteractable _clothStandInteractable)
    {
        GlobalVariables.saveData.setNumberOfCoins(GlobalVariables.saveData.getNumberOfCoins()+(GlobalVariables.clothsPrices*2));
        GlobalVariables.saveData.setNumberOfPoints(GlobalVariables.saveData.getNumberOfPoints() + 2);
        GetComponent<CharacterCustomization>().changeOutfit(_clothStandInteractable.GetClothStandCustomization().outfitIndex);
        GetComponent<CharacterCustomization>().changeEyes(_clothStandInteractable.GetClothStandCustomization().eyesIndex);
        GetComponent<CharacterCustomization>().changeHair(_clothStandInteractable.GetClothStandCustomization().hairIndex);
        GetComponent<CharacterCustomization>().changeAccesory(_clothStandInteractable.GetClothStandCustomization().accesoryIndex);
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
