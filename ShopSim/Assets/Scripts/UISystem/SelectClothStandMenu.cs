using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectClothStandMenu : UIMenuClass
{
    public GameObject clothStandPrefab;

    MainUIScript mainUIScript;


    float x;
    float y;
    public void openMenu(float _x, float _y, MainUIScript _mainUIScript)
    {
        x = _x;
        y = _y;
        mainUIScript = _mainUIScript;
        gameObject.SetActive(true);
        if (_x > 4.5f)
        {
            transform.position = new Vector3(_x - 4f, 0f, 0f);
        }
        else
        {
            transform.position = new Vector3(_x + 4f, 0f, 0f);
        }

    }

    public override void closeAllMenus()
    {
        gameObject.SetActive(false);
    }

    public void buyClothStand(int index)
    {
        closeAllMenus();
        GameObject clothStand=Instantiate(clothStandPrefab,mainUIScript.placedObjectsParent);
        clothStand.GetComponent<ClothStand>().ClothStandIndex = index;
    }

}
