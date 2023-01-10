using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFloorGrid : MonoBehaviour
{
    int width = 33;
    int height = 15;
    float size = 0.474f;
    Vector2 originPosition = new Vector2(-8.01f, -3.395f);
    public GameObject linePrefab;
    public Transform linesParentTransform;

    public FloorGrid floorGrid;
    Grid<FloorGridClass> grid;

    public PlayerController player;

    public GameObject lineGridContainer;

    private void Awake()
    {
        floorGrid = new FloorGrid(width, height, size, originPosition, linePrefab, linesParentTransform, player);
        grid = floorGrid.GetGrid();
    }

    void Start()
    {
        //grid = new Grid<FloorGridClass>(width, height, size, originPosition, linePrefab, linesParentTransform, (x, y) => new FloorGridClass());
        
    }

   

    public List<FloorGridClass> FindPath(Vector2 _start, Vector2 _end)
    {
        Vector2Int startNode = grid.GetXY(_start);
        Vector2Int endNode = grid.GetXY(_end);
        return  floorGrid.FindPath(startNode.x, startNode.y, endNode.x, endNode.y); ;
    }

    public void setGridVisibility(bool _visibility)
    {
        lineGridContainer.SetActive(_visibility);
    }
}
