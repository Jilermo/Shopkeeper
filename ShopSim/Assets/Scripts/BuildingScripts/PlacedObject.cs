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

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        sprite = spriteRenderer.sprite;
        floorGrid = GameObject.Find("FloorGrid").GetComponent<TestFloorGrid>();
        transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
        GlobalVariables.controllingPlayer = false;
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
                transform.position = GetMouseWorldPosition();
                placed = true;
                Vector3 _xmin = spriteRenderer.bounds.min;
                Vector3 _xmax = spriteRenderer.bounds.max;
                floorGrid.floorGrid.setCellsWalkable(new Vector2(_xmin.x, _xmax.x), new Vector2(_xmin.y, _xmax.y), false);
                GlobalVariables.controllingPlayer = true;
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

}
