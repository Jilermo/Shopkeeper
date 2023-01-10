using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUIScript : UIMenuClass
{
    public Transform placedObjectsParent;

    public DresserUI dresserUI;
    public SelectClothesMenu selectClothesMenu;
    public UserMenuUI userMenuUI;
    public SelectClothStandMenu selectClothStandMenu;
    List <UIMenuClass> allMenus;

    private void Start()
    {
        allMenus = new List<UIMenuClass>();
        allMenus.Add(dresserUI);
        allMenus.Add(selectClothesMenu);
        allMenus.Add(userMenuUI);
        allMenus.Add(selectClothStandMenu);
    }

    public void openMenu(float _x, float _y,InteractableObject _interactable)
    {
        switch (_interactable.getInteractableObjectType())
        {
            case InteractableObject.InteractableObjectType.ClothStand:
                dresserUI.OpenMenu(_x,_y,(ClothStandInteractable)_interactable,this);
                break;
            case InteractableObject.InteractableObjectType.CommonObject:
                break;
            case InteractableObject.InteractableObjectType.userMenu:
                userMenuUI.OpenMenu(_x, _y, (UserMenuInteractable)_interactable,this);
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
