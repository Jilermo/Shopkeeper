using UnityEngine;

public class FloorGridClass
{
    private Grid<FloorGridClass> grid;
    private int x;
    private int y;

    public int gCost;
    public int hCost;
    public int fCost;

    bool isWalkable = true;

    public FloorGridClass cameFrom;

    public InteractableObject interactible;

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

    public void setWalkable(bool _walkable,InteractableObject _interactable)
    {
        isWalkable = _walkable;
        if (_walkable)
        {
            grid.setLineRenderColor(x,y,Color.green);
            grid.setLineRenderLayerOrder(x, y, 1);
            quitInteractableObject();
        }
        else
        {
            grid.setLineRenderColor(x, y, Color.red);
            grid.setLineRenderLayerOrder(x,y,2);
            setInteractableObject(_interactable);
        }
    }

    public bool getWalkable()
    {
        return isWalkable;
    }

    public void setInteractableObject(InteractableObject _interactable)
    {
        interactible = _interactable;
    }

    public InteractableObject getInteractableObject()
    {
        return interactible;
    }

    public void quitInteractableObject()
    {
        interactible = null;
    }
}


