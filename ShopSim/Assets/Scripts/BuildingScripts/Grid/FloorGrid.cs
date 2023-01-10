using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class FloorGrid
{
    int width;
    int height;
    float size;
    Vector2 originPosition;
    public GameObject linePrefab;
    public Transform linesParentTransform;

    Grid<FloorGridClass> grid;


    public FloorGrid(int _width,int _height,float _size,Vector2 _originPosition,GameObject _linePefab,Transform _linesParentTransform)
    {
        width = _width;
        height = _height;
        size = _size;
        originPosition = _originPosition;
        linePrefab = _linePefab;
        linesParentTransform = _linesParentTransform;
        grid = new Grid<FloorGridClass>(width, height, size, originPosition, linePrefab, linesParentTransform, (Grid<FloorGridClass> _grid, int _x, int _y) => new FloorGridClass(_grid, _x, _y));
    }

    public Grid<FloorGridClass> GetGrid()
    {
        return grid;
    }

    public bool checkifCellIsValid(int _x, int _y)
    {
        if (_x >= 0 && _x < width && _y >= 0 && _y < height)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public List<FloorGridClass> FindPath(int startX,int startY, int endX, int endY)
    {
        if (!checkifCellIsValid(startX, startY))
        {
            return null;
        }
        if (!checkifCellIsValid(endX, endY))
        {
            return null;
        }
        

        List<FloorGridClass> openList= new List<FloorGridClass>();
        List<FloorGridClass> closeList = new List<FloorGridClass>();

        FloorGridClass startNode = grid.GetGridObject(startX,startY);
        FloorGridClass endNode = grid.GetGridObject(endX, endY);

        if (!endNode.getWalkable())
        {
            return null;
        }

        for (int c = 0; c < grid.getWidth(); c++)
        {
            for (int r = 0; r < grid.getHeight(); r++)
            {
                FloorGridClass pathNode = grid.GetGridObject(c,r);
                pathNode.gCost = int.MaxValue;
                pathNode.calculateFcost();
                pathNode.cameFrom = null;
            }
        }

        startNode.gCost = 0;
        startNode.hCost = CalculateDistance(new Vector2Int(startX,startY), new Vector2Int(endX, endY));
        startNode.calculateFcost();

        openList.Add(startNode);
        while (openList.Count > 0)
        {
            FloorGridClass currentFloorGrid = GetLowestFCostNode(openList);
            if (currentFloorGrid==endNode)
            {
                return CalculatedPath(endNode);
            }

            openList.Remove(currentFloorGrid);
            closeList.Add(currentFloorGrid);

            foreach (var floorGrid in GetNeighboursList(currentFloorGrid))
            {
                if (closeList.Contains(floorGrid)) continue;
                if (!floorGrid.getWalkable())
                {
                    closeList.Add(floorGrid);
                    continue;
                }

                int tentativeGcost = currentFloorGrid.gCost + CalculateDistance(new Vector2Int(currentFloorGrid.getX(), currentFloorGrid.getY()), new Vector2Int(floorGrid.getX(), floorGrid.getY()));
                if (tentativeGcost<floorGrid.gCost)
                {
                    floorGrid.cameFrom = currentFloorGrid;
                    floorGrid.gCost = tentativeGcost;
                    floorGrid.hCost = CalculateDistance(new Vector2Int(floorGrid.getX(), floorGrid.getY()), new Vector2Int(endNode.getX(), endNode.getY()));
                    floorGrid.calculateFcost();
                    if (!openList.Contains(floorGrid))
                    {
                        openList.Add(floorGrid);
                    }
                }
            }
        }

        return null;
    }

    private List<FloorGridClass> GetNeighboursList(FloorGridClass _currentFloorGrid)
    {
        List<FloorGridClass> neighbours=new List<FloorGridClass>();
        if (_currentFloorGrid.getX()-1>=0)
        {
            neighbours.Add(grid.GetGridObject(_currentFloorGrid.getX() - 1, _currentFloorGrid.getY()));
        }
        if (_currentFloorGrid.getX() + 1 < grid.getWidth())
        {
            neighbours.Add(grid.GetGridObject(_currentFloorGrid.getX() + 1, _currentFloorGrid.getY()));
        }
        if (_currentFloorGrid.getY() - 1 >= 0)
        {
            neighbours.Add(grid.GetGridObject(_currentFloorGrid.getX(), _currentFloorGrid.getY() - 1));
        }
        if (_currentFloorGrid.getY() + 1 < grid.getHeight())
        {
            neighbours.Add(grid.GetGridObject(_currentFloorGrid.getX(), _currentFloorGrid.getY()+1));
        }
        return neighbours;
    }

    private List<FloorGridClass> CalculatedPath(FloorGridClass endNode)
    {
        List<FloorGridClass> path = new List<FloorGridClass>();
        //path.Add(endNode);
        FloorGridClass _currentFloorGrid = endNode;
        while (_currentFloorGrid!=null)
        {
            path.Add(_currentFloorGrid);
            _currentFloorGrid = _currentFloorGrid.cameFrom;
        }
        path.Reverse();
        return path;
    }

    private int CalculateDistance(Vector2Int a, Vector2Int b)
    {
        int distanceX = Mathf.Abs(a.x-b.x);
        int distanceY = Mathf.Abs(a.y - b.y);
        return distanceX+distanceY;
    }

    private FloorGridClass GetLowestFCostNode(List<FloorGridClass> _floorGridList)
    {
        FloorGridClass lowestFCostNode = _floorGridList[0];
        for (int i = 0; i <_floorGridList.Count; i++)
        {
            if (_floorGridList[i].fCost<lowestFCostNode.fCost)
            {
                lowestFCostNode = _floorGridList[i];
            }
        }
        return lowestFCostNode;
    }

    public bool isWalwable(Vector2 _x, Vector2 _y)
    {
        float _stepX = size / 2;
        float _stepY = size / 2;
        int _stepsX = Mathf.CeilToInt(Mathf.Abs(_x.x-_x.y)/_stepX);
        int _stepsY = Mathf.CeilToInt(Mathf.Abs(_y.x - _y.y) / _stepY);

        if (_x.x > _x.y)
        {
            _stepX = -_stepX;
        }
        if (_y.x > _y.y)
        {
            _stepY = -_stepY;
        }

        for (int c = 0; c < _stepsX; c++)
        {
            for (int r = 0; r < _stepsY; r++)
            {
                float _xToCheck = _x.x + _stepX * c;
                if (_xToCheck>_x.y)
                {
                    _xToCheck = _x.y;
                }
                float _yToCheck = _y.x + _stepY * r;
                if (_yToCheck > _y.y)
                {
                    _yToCheck = _y.y;
                }
                Vector2 _worldPos = new Vector2(_xToCheck, _yToCheck);
                Vector2Int _cellPosition = grid.GetXY(_worldPos);
                if (!checkifCellIsValid(_cellPosition.x, _cellPosition.y))
                {
                    return false;
                }
                if (!grid.GetGridObject(_cellPosition.x, _cellPosition.y).getWalkable())
                {
                    return false;
                }

                
                //grid.GetGridObject()
            }
        }
        return true;
    }

    public bool setCellsWalkable(Vector2 _x, Vector2 _y,bool _walkable)
    {
        if (!isWalwable(_x, _y))
        {
            return false;
        }
        
        float _step = size / 2;
        int _stepsX = Mathf.CeilToInt(Mathf.Abs(_x.x - _x.y) / _step);
        int _stepsY = Mathf.CeilToInt(Mathf.Abs(_y.x - _y.y) / _step);

        for (int c = 0; c < _stepsX; c++)
        {
            for (int r = 0; r < _stepsX; r++)
            {
                float _xToCheck = _x.x + size * c;
                if (_xToCheck > _x.y)
                {
                    _xToCheck = _x.y;
                }
                float _yToCheck = _y.x + size * r;
                if (_yToCheck > _y.y)
                {
                    _yToCheck = _y.y;
                }
                Vector2 _worldPos = new Vector2(_xToCheck, _yToCheck);
                Vector2Int _cellPosition = grid.GetXY(_worldPos);

                grid.GetGridObject(_cellPosition.x, _cellPosition.y).setWalkable(_walkable);
                //grid.GetGridObject()
            }
        }

        return true;
    }
}
