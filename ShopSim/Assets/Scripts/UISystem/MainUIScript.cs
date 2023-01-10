using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUIScript : UIMenuClass
{
    public DresserUI dresserUI;
    public SelectClothesMenu selectClothesMenu;
    List <UIMenuClass> allMenus;

    private void Start()
    {
        allMenus = new List<UIMenuClass>();
        allMenus.Add(dresserUI);
        allMenus.Add(selectClothesMenu);
    }

    public void openMenu(float _x, float _y,InteractableObject _interactable)
    {
        switch (_interactable.getInteractableObjectType())
        {
            case InteractableObject.InteractableObjectType.ClothStand:
                dresserUI.OpenMenu(_x,_y,(ClothStandInteractable)_interactable);
                break;
            case InteractableObject.InteractableObjectType.CommonObject:
                break;
            default:
                break;
        }
        
    }

    public void closeAlMenus()
    {
        foreach (var menu in allMenus)
        {
            menu.closeAllMenus();
        }
    }
}
