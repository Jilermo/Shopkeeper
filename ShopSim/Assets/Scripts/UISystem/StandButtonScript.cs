using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandButtonScript : MonoBehaviour
{
    public int index;
    public SelectClothStandMenu selectClothStandMenu;

    public void retrieveIndex()
    {
        if (GlobalVariables.saveData.getNumberOfCoins() >= (50+(index*100)))
        {
            GlobalVariables.saveData.setNumberOfCoins(GlobalVariables.saveData.getNumberOfCoins() - (50 + (index * 100)));
            
            selectClothStandMenu.buyClothStand(index);
        }
       
    }
}
