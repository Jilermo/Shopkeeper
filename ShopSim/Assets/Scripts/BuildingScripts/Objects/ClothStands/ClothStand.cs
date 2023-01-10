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

    // Start is called before the first frame update
    void Start()
    {
        clothStandCustomization = GetComponent<ClothStandCustomization>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprites[ClothStandIndex];

        sprite = spriteRenderer.sprite;

        floorGrid = GameObject.Find("FloorGrid").GetComponent<TestFloorGrid>();
        transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
        GlobalVariables.controllingPlayer = false;
        GlobalVariables.placingObject = true;

        interactable = new ClothStandInteractable(clothStandCustomization,this);
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
                saveClothStand();
            }
        }
    }

    public void saveClothStand()
    {
        quitClothStand();
        clothStandSave = new GlobalVariables.ClothStandSave(spriteRenderer.bounds.center.x, spriteRenderer.bounds.center.y, ClothStandIndex, clothStandCustomization.outfitIndex, clothStandCustomization.eyesIndex, clothStandCustomization.accesoryIndex, clothStandCustomization.hairIndex);
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
        quitClothStand();
    }
}
