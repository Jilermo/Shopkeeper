﻿public class FloorGridClass
{
    private Grid<FloorGridClass> grid;
    private int x;
    private int y;

    public int gCost;
    public int hCost;
    public int fCost;

    public FloorGridClass cameFrom;

    //public FloorGridClass(int _x, int _y)
    public FloorGridClass(Grid<FloorGridClass> _grid, int _x, int _y)
    {
        grid = _grid;
        x = _x;
        y = _y;
    }

    public void calculateFcost()
    {
        fCost = gCost + hCost;
    }

    public int getX()
    {
        return x;
    }

    public int getY()
    {
        return y;
    }

    public override string ToString()
    {
        return x + "," + y;
    }
}

