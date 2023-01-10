using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothButtonScript : MonoBehaviour
{
    public int clothIndex;
    public SelectClothesMenu clothesMenu;

    public bool active;
    
    public void retrieveClothIndex()
    {
        clothesMenu.selectCloth(clothIndex);
    }
}
