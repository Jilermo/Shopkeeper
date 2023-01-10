using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserMenuUI : UIMenuClass
{
    float x;
    float y;
    UserMenuInteractable userMenuInteractable;

    MainUIScript mainUIScript;
    public void OpenMenu(float _x, float _y, UserMenuInteractable _userMenuInteractable,MainUIScript _mainUIScript)
    {
        mainUIScript = _mainUIScript;
        x = _x;
        y = _y;
        userMenuInteractable = _userMenuInteractable;
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

    public void OpenSelectClothsMenu()
    {
        mainUIScript.selectClothesMenu.openMenu(x, y, userMenuInteractable,mainUIScript);
        closeAllMenus();
    }

    public void OpenClothsStandMenu()
    {
        mainUIScript.selectClothStandMenu.openMenu(x, y, mainUIScript);
        closeAllMenus();
    }

    public void OpenBuyObjectsMenu()
    {
        mainUIScript.buyObjectsMenu.openMenu(x, y, mainUIScript);
        closeAllMenus();
    }

    public override void closeAllMenus()
    {
        gameObject.SetActive(false);
    }
}
