using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCustomization : MonoBehaviour
{
    public enum ClothingType
    {
        body,
        eyes,
        outfit,
        hair,
        accesory
    }
    
    public SpriteRenderer body;
    public SpriteRenderer eyes;
    public SpriteRenderer outfit;
    public SpriteRenderer hair;
    public SpriteRenderer accesory;


    Sprite[] bodySprites=new Sprite[28];
    Sprite[] eyesSprites = new Sprite[28];
    Sprite[] outfitSprites = new Sprite[28];
    Sprite[] hairSprites = new Sprite[28];
    Sprite[] accesorySprites = new Sprite[28];

    private void Awake()
    {

    }

    private void Start()
    {
        changeBody(GlobalVariables.saveData.bodyIndex);
        changeEyes(GlobalVariables.saveData.eyeIndex);
        changeOutfit(GlobalVariables.saveData.outfitIndex);
        changeHair(GlobalVariables.saveData.hairstyleIndex);
        changeAccesory(GlobalVariables.saveData.accesoryIndex);
    }


    public void changeBody(int _number)
    {
        if (_number< GlobalVariables.numberOfBodies && _number >=0)
        {
            Object[] sprites;
            //sprites = Resources.LoadAll("0");
            sprites = Resources.LoadAll("Bodies/" + _number);
            for (int i = 1; i < sprites.Length; i++)
            {
                bodySprites[i - 1] = (Sprite)sprites[i];
            }
            //bodySprites = (Sprite[])sprites;
            body.sprite = bodySprites[4];
            GlobalVariables.saveData.bodyIndex = _number;
        }
    }

    public void changeEyes(int _number)
    {
        if (_number < GlobalVariables.numberOfEyes && _number >= 0)
        {
            Object[] sprites;
            sprites = Resources.LoadAll("Eyes/" + _number);
            for (int i = 1; i < sprites.Length; i++)
            {
                eyesSprites[i - 1] = (Sprite)sprites[i];
            }
            eyes.sprite = eyesSprites[4];
            GlobalVariables.saveData.eyeIndex = _number;
        }
    }

    public void changeOutfit(int _number)
    {
        if (_number < GlobalVariables.numberOfOutfits && _number >= 0)
        {
            Object[] sprites;
            sprites = Resources.LoadAll("Outfits/" + _number);
            for (int i = 1; i < sprites.Length; i++)
            {
                outfitSprites[i - 1] = (Sprite)sprites[i];
            }
            outfit.sprite = outfitSprites[4];
            GlobalVariables.saveData.outfitIndex = _number;
        }
    }

    public void changeHair(int _number)
    {
        if (_number < GlobalVariables.numberOfHairs && _number >= 0)
        {
            Object[] sprites;
            sprites = Resources.LoadAll("HairStyles/" + _number);
            for (int i = 1; i < sprites.Length; i++)
            {
                hairSprites[i - 1] = (Sprite)sprites[i];
            }
            hair.sprite = hairSprites[4];
            GlobalVariables.saveData.hairstyleIndex = _number;
        }
    }

    public void changeAccesory(int _number)
    {
        if (_number < GlobalVariables.numberOfAccesories && _number >= 0)
        {
            Object[] sprites;
            sprites = Resources.LoadAll("Accesories/" + _number);
            for (int i = 1; i < sprites.Length; i++)
            {
                accesorySprites[i - 1] = (Sprite)sprites[i];
            }
            accesory.sprite = accesorySprites[4];
            GlobalVariables.saveData.accesoryIndex = _number;
        }
    }

    public void setNewFrame(int frame)
    {
        body.sprite = bodySprites[frame];
        eyes.sprite = eyesSprites[frame];
        outfit.sprite = outfitSprites[frame];
        hair.sprite = hairSprites[frame];
        accesory.sprite = accesorySprites[frame];
    }

    public void changeClotheType(int _index, CharacterCustomization.ClothingType _clothingType)
    {
        switch (_clothingType)
        {
            case CharacterCustomization.ClothingType.body:
                changeBody(_index);
                break;
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

    public void spawnRandomClothes()
    {
        changeBody(Random.Range(0, GlobalVariables.numberOfBodies));
        changeEyes(Random.Range(0, GlobalVariables.numberOfEyes));
        changeOutfit(Random.Range(0, GlobalVariables.numberOfOutfits));
        changeHair(Random.Range(0, GlobalVariables.numberOfHairs));
        changeAccesory(Random.Range(0, GlobalVariables.numberOfAccesories));
    }
}
