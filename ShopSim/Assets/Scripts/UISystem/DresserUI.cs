using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DresserUI : UIMenuClass
{
    float x;
    float y;
    ClothStandInteractable clothStandInteractable;
    MainUIScript mainUIScript;
    public void OpenMenu(float _x, float _y,ClothStandInteractable _standInteractable,MainUIScript _mainUIScript)
    {
        mainUIScript = _mainUIScript;
        x = _x;
        y = _y;
        clothStandInteractable = _standInteractable;
        gameObject.SetActive(true);
        if (_x > 4.5f)
        {
            transform.position = new Vector3(_x - 2f, 0f, 0f);
        }
        else
        {
            transform.position = new Vector3(_x + 2f, 0f, 0f);
        }
    }

    public void OpenSlectClothesMenu()
    {
        mainUIScript.selectClothesMenu.openMenu(x, y, clothStandInteractable, mainUIScript);
        closeAllMenus();
    }

    public void move()
    {
        clothStandInteractable.getClothStand().move();
        closeAllMenus();
    }

    public void sell()
    {
        clothStandInteractable.getClothStand().sell();
        closeAllMenus();
    }

    public override void closeAllMenus()
    {
        gameObject.SetActive(false);
    }
}
