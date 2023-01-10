using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandButtonScript : MonoBehaviour
{
    public int index;
    public SelectClothStandMenu selectClothStandMenu;

    public void retrieveIndex()
    {
        if (GlobalVariables.saveData.numberOfCoins >= (50+(index*100)))
        {
            GlobalVariables.saveData.numberOfCoins = GlobalVariables.saveData.numberOfCoins - (50 + (index * 100));
            selectClothStandMenu.buyClothStand(index);
        }
       
    }
}
