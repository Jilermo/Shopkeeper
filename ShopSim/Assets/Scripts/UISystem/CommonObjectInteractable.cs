using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonObjectInteractable : InteractableObject
{
    PlacedObject placedObject;

    public CommonObjectInteractable(PlacedObject _placedObject)
    {
        placedObject = _placedObject;
        setInteractableObjectType(InteractableObject.InteractableObjectType.CommonObject);
    }

    public PlacedObject getPlacedObject()
    {
        return placedObject;
    }
}
