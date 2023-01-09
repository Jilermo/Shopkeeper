using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFloorGrid : MonoBehaviour
{
    int width = 21;
    int height = 12;
    float size = 0.474f;
    Vector2 originPosition = new Vector2(-5.152f, -2f);
    public GameObject linePrefab;
    public Transform linesParentTransform;

    public FloorGrid floorGrid;
    Grid<FloorGridClass> grid;

    void Start()
    {
        //grid = new Grid<FloorGridClass>(width, height, size, originPosition, linePrefab, linesParentTransform, (x, y) => new FloorGridClass());
        floorGrid = new FloorGrid(width, height, size, originPosition, linePrefab, linesParentTransform);
        grid = floorGrid.GetGrid();
    }

   

    public List<FloorGridClass> FindPath(Vector2 _start, Vector2 _end)
    {
        Vector2Int startNode = grid.GetXY(_start);
        Vector2Int endNode = grid.GetXY(_end);
        return  floorGrid.FindPath(startNode.x, startNode.y, endNode.x, endNode.y); ;
    }

    
}