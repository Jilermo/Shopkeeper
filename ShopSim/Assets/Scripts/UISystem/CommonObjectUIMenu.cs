using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonObjectUIMenu : UIMenuClass
{
    float x;
    float y;
    CommonObjectInteractable commonObjectInteractable;
    MainUIScript mainUIScript;
    public void OpenMenu(float _x, float _y, CommonObjectInteractable _commonObjectInteractable, MainUIScript _mainUIScript)
    {
        mainUIScript = _mainUIScript;
        x = _x;
        y = _y;
        commonObjectInteractable = _commonObjectInteractable;
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

    public void move()
    {
        commonObjectInteractable.getPlacedObject().move();
        closeAllMenus();
    }

    public void sell()
    {
        commonObjectInteractable.getPlacedObject().sell();
        closeAllMenus();
    }

    public override void closeAllMenus()
    {
        gameObject.SetActive(false);
    }
}
