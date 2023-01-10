using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothStandCustomization : MonoBehaviour
{
    public SpriteRenderer eyes;
    public SpriteRenderer outfit;
    public SpriteRenderer hair;
    public SpriteRenderer accesory;


    Sprite bodySprites;
    Sprite eyesSprites;
    Sprite outfitSprites;
    Sprite hairSprites;
    Sprite accesorySprites;

    public int eyesIndex;
    public int outfitIndex;
    public int hairIndex;
    public int accesoryIndex;

    ClothStand clothStand;

    public bool notSave=false;
    public bool loaded=false;

    private void Start()
    {
        clothStand = GetComponent<ClothStand>();
        if (!loaded)
        {
            changeEyes(0);
            changeOutfit(0);
            changeHair(0);
            changeAccesory(0);
        }
    }

    public void changeClotheType(int _index, CharacterCustomization.ClothingType _clothingType)
    {
        switch (_clothingType)
        {
            case CharacterCustomization.ClothingType.eyes:
                changeEyes(_index);
                break;
            case CharacterCustomization.ClothingType.outfit:
                changeOutfit(_index);
                break;
            case CharacterCustomization.ClothingType.hair:
                changeHair(_index);
                break;
            case CharacterCustomization.ClothingType.accesory:
                changeAccesory(_index);
                break;
            default:
                break;
        }
    }

    public void changeEyes(int _number)
    {
        clothStand = GetComponent<ClothStand>();
        if (_number < GlobalVariables.numberOfEyes && _number >= 0)
        {
            Object[] sprites;
            sprites = Resources.LoadAll("Eyes/" + _number);
            eyes.sprite = (Sprite)sprites[4];
            eyesIndex = _number;
        }
        if (!notSave)
        {
            clothStand.saveClothStand();
        }
        
    }

    public void changeOutfit(int _number)
    {
        clothStand = GetComponent<ClothStand>();
        if (_number < GlobalVariables.numberOfOutfits && _number >= 0)
        {
            Object[] sprites;
            sprites = Resources.LoadAll("Outfits/" + _number);
            outfit.sprite = (Sprite)sprites[4];
            outfitIndex = _number;
        }
        if (!notSave)
        {
            clothStand.saveClothStand();
        }
        
    }

    public void changeHair(int _number)
    {
        clothStand = GetComponent<ClothStand>();
        if (_number < GlobalVariables.numberOfHairs && _number >= 0)
        {
            Object[] sprites;
            sprites = Resources.LoadAll("HairStyles/" + _number);
            hair.sprite = (Sprite)sprites[4];
            hairIndex = _number;
        }
        if (!notSave)
        {
            clothStand.saveClothStand();
        }

    }

    public void changeAccesory(int _number)
    {
        clothStand = GetComponent<ClothStand>();
        if (_number < GlobalVariables.numberOfAccesories && _number >= 0)
        {
            Object[] sprites;
            sprites = Resources.LoadAll("Accesories/" + _number);
            accesory.sprite = (Sprite)sprites[4];
            accesoryIndex = _number;
        }
        if (!notSave)
        {
            clothStand.saveClothStand();
        }
        
    }

}
