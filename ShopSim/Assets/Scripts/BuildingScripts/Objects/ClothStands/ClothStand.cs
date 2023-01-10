using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothStand : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Sprite sprite;

    public Color invalidColor;
    public Color validColor;

    TestFloorGrid floorGrid;

    bool placed = false;

    InteractableObject interactable;
    ClothStandCustomization clothStandCustomization;

    public int ClothStandIndex;
    public List<Sprite> sprites;

    GlobalVariables.ClothStandSave clothStandSave;

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
        clothStandCustomization = GetComponent<ClothStandCustomization>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprites[ClothStandIndex];

        sprite = spriteRenderer.sprite;

       
        
        interactable = new ClothStandInteractable(clothStandCustomization,this);
    }

    public void placeClothStand(float _x, float _y, int _index, int _outfitIndex, int _HairIndex, int _eyeIndex, int _accesoryIndex, GlobalVariables.ClothStandSave _clothStandSave)
    {
        clothStandSave = _clothStandSave;
        ClothStandIndex = _index;
        clothStandCustomization = GetComponent<ClothStandCustomization>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprites[ClothStandIndex];
        transform.position = new Vector3(_x, _y, 0f);
        clothStandCustomization.loaded = true;
        clothStandCustomization.notSave = true;
        clothStandCustomization.changeOutfit(_outfitIndex);
        clothStandCustomization.changeHair(_HairIndex);
        clothStandCustomization.changeEyes(_eyeIndex);
        clothStandCustomization.changeAccesory(_accesoryIndex);
        clothStandCustomization.notSave = false;
        floorGrid = GameObject.Find("FloorGrid").GetComponent<TestFloorGrid>();
        sprite = spriteRenderer.sprite;
        Vector3 _xmin = spriteRenderer.bounds.min;
        Vector3 _xmax = spriteRenderer.bounds.max;
        interactable = new ClothStandInteractable(clothStandCustomization, this);
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
                spriteRenderer.sprite = sprites[ClothStandIndex];
                floorGrid.setGridVisibility(false);
                saveClothStand();
            }
        }
    }

    public void saveClothStand()
    {
        quitClothStand();
        clothStandSave = new GlobalVariables.ClothStandSave(transform.position.x, transform.position.y, ClothStandIndex, clothStandCustomization.outfitIndex, clothStandCustomization.eyesIndex, clothStandCustomization.accesoryIndex, clothStandCustomization.hairIndex);
        GlobalVariables.saveData.clothStands.Add(clothStandSave);
    }

    public void quitClothStand()
    {
        if (clothStandSave != null)
        {
            if (GlobalVariables.saveData.clothStands.Contains(clothStandSave))
            {
                GlobalVariables.saveData.clothStands.Remove(clothStandSave);
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

        GlobalVariables.saveData.setNumberOfCoins(GlobalVariables.saveData.getNumberOfCoins() + (50 + (ClothStandIndex * 100))) ;
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
