using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClothButtonScript : MonoBehaviour
{
    public int clothIndex;
    public CharacterCustomization.ClothingType clothingType;
    public SelectClothesMenu clothesMenu;

    Image mySprite;

    bool active;

    private void Start()
    {
        active = true;
        mySprite = GetComponent<Image>();
        switch (clothingType)
        {
            case CharacterCustomization.ClothingType.body:
                if (!GlobalVariables.saveData.unlockedBodies.Contains(clothIndex))
                {
                    active = false;
                    mySprite.color = Color.black;
                }
                break;
            case CharacterCustomization.ClothingType.eyes:
                if (!GlobalVariables.saveData.unlockedEyes.Contains(clothIndex))
                {
                    active = false;
                    mySprite.color = Color.black;
                }
                break;
            case CharacterCustomization.ClothingType.outfit:
                if (!GlobalVariables.saveData.unlockedOutfits.Contains(clothIndex))
                {
                    active = false;
                    mySprite.color = Color.black;
                }
                break;
            case CharacterCustomization.ClothingType.hair:
                if (!GlobalVariables.saveData.unlockedHairstyles.Contains(clothIndex))
                {
                    active = false;
                    mySprite.color = Color.black;
                }
                break;
            case CharacterCustomization.ClothingType.accesory:
                if (!GlobalVariables.saveData.unlockedAccesories.Contains(clothIndex))
                {
                    active = false;
                    mySprite.color = Color.black;
                }
                break;
            default:
                break;
        }
    }

    public void retrieveClothIndex()
    {
        if (!active)
        {
            if (GlobalVariables.saveData.getNumberOfCoins()>=GlobalVariables.clothsPrices)
            {

                GlobalVariables.saveData.setNumberOfCoins(GlobalVariables.saveData.getNumberOfCoins() - GlobalVariables.clothsPrices);
                active = true;
                mySprite.color = Color.white;
                addToSaveData();
            }
        }
        else
        {
            clothesMenu.selectCloth(clothIndex);
        }
        
    }

    public void addToSaveData()
    {
        switch (clothingType)
        {
            case CharacterCustomization.ClothingType.body:
                GlobalVariables.saveData.unlockedBodies.Add(clothIndex);
                break;
            case CharacterCustomization.ClothingType.eyes:
                GlobalVariables.saveData.unlockedEyes.Add(clothIndex);
            break;
            case CharacterCustomization.ClothingType.outfit:
                GlobalVariables.saveData.unlockedOutfits.Add(clothIndex);
                break;
            case CharacterCustomization.ClothingType.hair:
                GlobalVariables.saveData.unlockedHairstyles.Add(clothIndex);
                break;
            case CharacterCustomization.ClothingType.accesory:
                GlobalVariables.saveData.unlockedAccesories.Add(clothIndex);
                break;
            default:
                break;
        }
    }
}
