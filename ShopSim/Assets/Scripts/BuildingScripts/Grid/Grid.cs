using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid <TGridObjects>
{
    int width;
    int height;
    float cellSize;
    Vector2 originPosition;
    TGridObjects[,] gridarray;
    LineRenderer[,] lineArray;
    GameObject linePrefab;
    Transform linesParentTransform;

    public Grid(int _width, int _height, float _cellSize, Vector2 _originPosition, GameObject _linePrefab, Transform _linePrefabParent, System.Func<Grid<TGridObjects>,int,int,TGridObjects> createGridObject)
    {
        width = _width;
        height = _height;
        originPosition = _originPosition;
        cellSize = _cellSize;
        linePrefab = _linePrefab;
        linesParentTransform = _linePrefabParent;

        gridarray = new TGridObjects[width,height];
        lineArray = new LineRenderer[width, height];

        for (int c = 0; c < width; c++)
        {
            for (int r  = 0; r < height; r++)
            {
                gridarray[c, r] = createGridObject(this,c,r);
                createLinesArray(c,r);
            }
        }
    }

    public int getWidth()
    {
        return width;
    }

    public int getHeight()
    {
        return height;
    }

    public void createLinesArray(int _x, int _y)
    {
        
        Vector3 worldPos = getWorldPosition(_x, _y);
        float worldPosX = worldPos.x;
        float worldPosY = worldPos.y;
        GameObject line = GameObject.Instantiate(linePrefab, linesParentTransform);
        //GameObject line = Instantiate(linePrefab, linesParentTransform);
        LineRenderer lineRenderer = line.GetComponent<LineRenderer>();
        lineRenderer.positionCount = 5;
        lineRenderer.SetPosition(0, new Vector2(worldPosX, worldPosY));
        lineRenderer.SetPosition(1, new Vector2(worldPosX + cellSize, worldPosY));
        lineRenderer.SetPosition(2, new Vector2(worldPosX + cellSize, worldPosY + cellSize));
        lineRenderer.SetPosition(3, new Vector2(worldPosX, worldPosY + cellSize));
        lineRenderer.SetPosition(4, new Vector2(worldPosX, worldPosY));
        lineArray[_x, _y] = lineRenderer;
    }

    public Vector2 getWorldPosition(int _x, int _y)
    {
        return new Vector2(_x, _y) * cellSize + originPosition;
    }

    public Vector2Int GetXY(Vector2 _worldPosition)
    {
        return new Vector2Int(Mathf.FloorToInt((_worldPosition.x-originPosition.x)/cellSize), Mathf.FloorToInt((_worldPosition.y - originPosition.y) / cellSize));
    }

    public void SetGridObject(int _x, int _y, TGridObjects _value)
    {
        if (_x>=0 && _x<width && _y >= 0 && _y < height)
        {
            gridarray[_x, _y] = _value;
            debugText(_x + " " + _y + " value set to: " + _value?.ToString());
        }
    }

    public void SetGridObject(Vector2 _worldPosition, TGridObjects _value)
    {
        Vector2Int gridPosition = GetXY(_worldPosition);
        SetGridObject(gridPosition.x,gridPosition.y,_value);
    }

    public TGridObjects GetGridObject(int _x, int _y)
    {
        if (_x >= 0 && _x < width && _y >= 0 && _y < height)
        {
            debugText(_x + " " + _y + " value set to: " + gridarray[_x, _y]?.ToString());
            
            return gridarray[_x, _y];
        }
        else
        {
            return default(TGridObjects);
        }
    }

    public TGridObjects GetGridObject(Vector2 _worldPosition)
    {
        Vector2Int gridPosition = GetXY(_worldPosition);
        return GetGridObject(gridPosition.x, gridPosition.y);
    }

    private void debugText(string _text)
    {
        if (GlobalVariables.debug)
        {
            //Debug.Log(_text);
        }
    }

    public void setLineRenderColor(int _x, int _y, Color _color)
    {
        if (_x >= 0 && _x < width && _y >= 0 && _y < height)
        {
            lineArray[_x, _y].startColor=_color;
            lineArray[_x, _y].endColor = _color;
        }
    }

    public void setLineRenderLayerOrder(int _x, int _y, int _order)
    {
        if (_x >= 0 && _x < width && _y >= 0 && _y < height)
        {
            lineArray[_x, _y].sortingOrder = _order;
        }
    }
}
