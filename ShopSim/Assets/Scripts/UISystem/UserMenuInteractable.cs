using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserMenuInteractable : InteractableObject
{
    CharacterCustomization characterCustomization;

    public UserMenuInteractable(CharacterCustomization _characterCustomization)
    {
        characterCustomization = _characterCustomization;
        setInteractableObjectType(InteractableObjectType.userMenu);
    }

    public CharacterCustomization GetCharacterCustomization()
    {
        return characterCustomization;
    }
}
