using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DresserUI : UIMenuClass
{
    float x;
    float y;
    ClothStandInteractable clothStandInteractable;
    public SelectClothesMenu SelectClothesMenu;
    public void OpenMenu(float _x, float _y,ClothStandInteractable _standInteractable)
    {
        x = _x;
        y = _y;
        clothStandInteractable = _standInteractable;
        gameObject.SetActive(true);
        if (_x > 4.5f)
        {
            transform.position = new Vector3(_x - 2f, _y, 0f);
        }
        else
        {
            transform.position = new Vector3(_x + 2f, _y, 0f);
        }
    }

    public void OpenSlectClothesMenu()
    {
        SelectClothesMenu.openMenu(x,y,clothStandInteractable);
        closeAllMenus();
    }

    public void move()
    {
        clothStandInteractable.getClothStand().move();
        closeAllMenus();
    }

    public override void closeAllMenus()
    {
        gameObject.SetActive(false);
    }
}
