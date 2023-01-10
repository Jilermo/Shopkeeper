using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject 
{
    public enum InteractableObjectType
    {
        ClothStand,
        CommonObject,
        userMenu
    }

    InteractableObjectType interactableObjectType;

    public void setInteractableObjectType(InteractableObjectType _interactableObjectType)
    {
        interactableObjectType = _interactableObjectType;
    }

    public InteractableObjectType getInteractableObjectType()
    {
        return interactableObjectType;
    }
}
