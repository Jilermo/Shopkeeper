using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacedObject : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Sprite sprite;

    public Color invalidColor;
    public Color validColor;

    TestFloorGrid floorGrid;

    bool placed = false;

    InteractableObject interactable;

    public int index;
    public int categoryIndex;

    GlobalVariables.PlacedCommonObjects commonObjectSave;

    public bool loaded = false;

    // Start is called before the first frame update
    void Start()
    {
        floorGrid = GameObject.Find("FloorGrid").GetComponent<TestFloorGrid>();
        if (!loaded)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
            GlobalVariables.controllingPlayer = false;
            GlobalVariables.placingObject = true;
            floorGrid.setGridVisibility(true);
        }
        else
        {
            placed = true;
        }

        
        spriteRenderer = GetComponent<SpriteRenderer>();
        sprite = spriteRenderer.sprite;
        interactable = new CommonObjectInteractable(this);
    }

    public void placeObject(float _x,float _y,int _categoryIndex, int _index, GlobalVariables.PlacedCommonObjects _commonObjectSave)
    {
        commonObjectSave = _commonObjectSave;
        transform.position = new Vector3(_x,_y,0f);
        spriteRenderer = GetComponent<SpriteRenderer>();
        floorGrid = GameObject.Find("FloorGrid").GetComponent<TestFloorGrid>();
        Object[] sprites;
        sprites = Resources.LoadAll("Building/Objects/" + _categoryIndex + "/" + _index);
        GetComponent<SpriteRenderer>().sprite = (Sprite)sprites[1];
        sprite = spriteRenderer.sprite;
        Vector3 _xmin = spriteRenderer.bounds.min;
        Vector3 _xmax = spriteRenderer.bounds.max;
        interactable = new CommonObjectInteractable(this);
        floorGrid.floorGrid.setCellsWalkable(new Vector2(_xmin.x, _xmax.x), new Vector2(_xmin.y, _xmax.y), false, interactable);
        loaded = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!placed)
        {
            transform.position = GetMouseWorldPosition();
            if (CheckIfGridIsValid())
            {
                spriteRenderer.color = validColor;
            }
            else
            {
                spriteRenderer.color = invalidColor;
            }
        }

        if (Input.GetMouseButtonDown(0) && !placed)
        {
            if (CheckIfGridIsValid())
            {
                placed = true;
                Vector3 _xmin = spriteRenderer.bounds.min;
                Vector3 _xmax = spriteRenderer.bounds.max;
                floorGrid.floorGrid.setCellsWalkable(new Vector2(_xmin.x, _xmax.x), new Vector2(_xmin.y, _xmax.y), false, interactable);
                GlobalVariables.controllingPlayer = true;
                GlobalVariables.placingObject = false;
                floorGrid.setGridVisibility(false);
                saveClothStand();
            }
        }
    }

    public void saveClothStand()
    {
        quitClothStand();
        commonObjectSave = new GlobalVariables.PlacedCommonObjects(spriteRenderer.bounds.center.x, spriteRenderer.bounds.center.y, index, categoryIndex);
        GlobalVariables.saveData.commonObjects.Add(commonObjectSave);
    }

    public void quitClothStand()
    {
        if (commonObjectSave != null)
        {
            if (GlobalVariables.saveData.commonObjects.Contains(commonObjectSave))
            {
                GlobalVariables.saveData.commonObjects.Remove(commonObjectSave);
            }
        }
    }


    public bool CheckIfGridIsValid()
    {
        Vector3 _xmin = spriteRenderer.bounds.min;
        Vector3 _xmax = spriteRenderer.bounds.max;
        return floorGrid.floorGrid.isWalwable(new Vector2(_xmin.x, _xmax.x), new Vector2(_xmin.y, _xmax.y));
    }

    public Vector2 GetMouseWorldPosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    public void move()
    {
        GlobalVariables.controllingPlayer = false;
        GlobalVariables.placingObject = true;
        Vector3 _xmin = spriteRenderer.bounds.min;
        Vector3 _xmax = spriteRenderer.bounds.max;
        floorGrid.floorGrid.setCellsNotWalkable(new Vector2(_xmin.x, _xmax.x), new Vector2(_xmin.y, _xmax.y));
        placed = false;
        floorGrid.setGridVisibility(true);
        quitClothStand();
    }

    public void sell()
    {
        GlobalVariables.saveData.setNumberOfCoins(GlobalVariables.objectsPrices+ GlobalVariables.saveData.getNumberOfCoins());
        Vector3 _xmin = spriteRenderer.bounds.min;
        Vector3 _xmax = spriteRenderer.bounds.max;
        floorGrid.floorGrid.setCellsNotWalkable(new Vector2(_xmin.x, _xmax.x), new Vector2(_xmin.y, _xmax.y));
        quitClothStand();
        Destroy(gameObject);
    }

    public FloorGridClass getWalkableNeighbour()
    {
        Vector3 _xmin = spriteRenderer.bounds.min;
        Vector3 _xmax = spriteRenderer.bounds.max;
        return floorGrid.floorGrid.checkForNeighbours(new Vector2(_xmin.x, _xmax.x), new Vector2(_xmin.y, _xmax.y));
    }

}
