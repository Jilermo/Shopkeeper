using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothStandInteractable : InteractableObject
{
    ClothStandCustomization customization;
    ClothStand stand;
    
    public ClothStandInteractable(ClothStandCustomization _customization, ClothStand _stand)
    {
        customization = _customization;
        stand = _stand;
    }

    public ClothStandCustomization GetClothStandCustomization()
    {
        return customization;
    }

    public ClothStand getClothStand()
    {
        return stand;
    }
}
