using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectButtonScript : MonoBehaviour
{
    public int index;
    public int categoryIndex;
    public BuyObjectsMenu buyObjectsMenu;

    Image mySprite;

    bool active;

    private void Start()
    {
        active = true;
        mySprite = GetComponent<Image>();
        if (!GlobalVariables.saveData.unlockedObjectCategories.Contains(categoryIndex))
        {
            active = false;
            mySprite.color = Color.black;
        }
    }

    public void Unlock()
    {
        active = true;
        mySprite.color = Color.white;
    }

    public void buyObject()
    {
        if (active)
        {
            if (GlobalVariables.saveData.getNumberOfCoins() >= GlobalVariables.objectsPrices)
            {
                GlobalVariables.saveData.setNumberOfCoins(GlobalVariables.saveData.getNumberOfCoins() - GlobalVariables.objectsPrices);
                
                buyObjectsMenu.BuyObject(index,categoryIndex);
            }
        }

    }

}
