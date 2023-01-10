using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothStandCustomization : MonoBehaviour
{
    public SpriteRenderer eyes;
    public SpriteRenderer outfit;
    public SpriteRenderer hair;
    public SpriteRenderer accesory;

    int numberOfBodies;
    int numberOfEyes;
    int numberOfOutfits;
    int numberOfHairs;
    int numberOfAccesories;

    Sprite bodySprites;
    Sprite eyesSprites;
    Sprite outfitSprites;
    Sprite hairSprites;
    Sprite accesorySprites;

    private void Awake()
    {
        numberOfBodies = GlobalVariables.numberOfBodies;
        numberOfEyes = GlobalVariables.numberOfEyes;
        numberOfOutfits = GlobalVariables.numberOfOutfits;
        numberOfHairs = GlobalVariables.numberOfHairs;
        numberOfAccesories = GlobalVariables.numberOfAccesories;
    }

    private void Start()
    {
        changeEyes(0);
        changeOutfit(0);
        changeHair(0);
        changeAccesory(0);
    }


    public void changeEyes(int _number)
    {
        if (_number < numberOfEyes && _number >= 0)
        {
            Object[] sprites;
            sprites = Resources.LoadAll("Eyes/" + _number);
            eyes.sprite = (Sprite)sprites[4];
        }
    }

    public void changeOutfit(int _number)
    {
        if (_number < numberOfOutfits && _number >= 0)
        {
            Object[] sprites;
            sprites = Resources.LoadAll("Outfits/" + _number);
            outfit.sprite = (Sprite)sprites[4];
        }
    }

    public void changeHair(int _number)
    {
        if (_number < numberOfHairs && _number >= 0)
        {
            Object[] sprites;
            sprites = Resources.LoadAll("HairStyles/" + _number);
            hair.sprite = (Sprite)sprites[4];
        }
    }

    public void changeAccesory(int _number)
    {
        if (_number < numberOfAccesories && _number >= 0)
        {
            Object[] sprites;
            sprites = Resources.LoadAll("Accesories/" + _number);
            accesory.sprite = (Sprite)sprites[4];
        }
    }

}
