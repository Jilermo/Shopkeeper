using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCustomization : MonoBehaviour
{
    
    public SpriteRenderer body;
    public SpriteRenderer eyes;
    public SpriteRenderer outfit;
    public SpriteRenderer hair;
    public SpriteRenderer accesory;

    int numberOfBodies;
    int numberOfEyes;
    int numberOfOutfits;
    int numberOfHairs;
    int numberOfAccesories;

    Sprite[] bodySprites=new Sprite[28];
    Sprite[] eyesSprites = new Sprite[28];
    Sprite[] outfitSprites = new Sprite[28];
    Sprite[] hairSprites = new Sprite[28];
    Sprite[] accesorySprites = new Sprite[28];

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
        changeBody(Random.Range(0, numberOfBodies));
        changeEyes(Random.Range(0, numberOfEyes));
        changeOutfit(Random.Range(0, numberOfOutfits));
        changeHair(Random.Range(0, numberOfHairs));
        changeAccesory(Random.Range(0, numberOfAccesories));
    }


    public void changeBody(int _number)
    {
        if (_number<numberOfBodies && _number >=0)
        {
            Object[] sprites;
            //sprites = Resources.LoadAll("0");
            sprites = Resources.LoadAll("Bodies/" + _number);
            for (int i = 1; i < sprites.Length; i++)
            {
                bodySprites[i - 1] = (Sprite)sprites[i];
            }
            //bodySprites = (Sprite[])sprites;
            body.sprite = bodySprites[3];
        }
    }

    public void changeEyes(int _number)
    {
        if (_number < numberOfEyes && _number >= 0)
        {
            Object[] sprites;
            sprites = Resources.LoadAll("Eyes/" + _number);
            for (int i = 1; i < sprites.Length; i++)
            {
                eyesSprites[i - 1] = (Sprite)sprites[i];
            }
            eyes.sprite = eyesSprites[3];
        }
    }

    public void changeOutfit(int _number)
    {
        if (_number < numberOfOutfits && _number >= 0)
        {
            Object[] sprites;
            sprites = Resources.LoadAll("Outfits/" + _number);
            for (int i = 1; i < sprites.Length; i++)
            {
                outfitSprites[i - 1] = (Sprite)sprites[i];
            }
            outfit.sprite = outfitSprites[3];
        }
    }

    public void changeHair(int _number)
    {
        if (_number < numberOfHairs && _number >= 0)
        {
            Object[] sprites;
            sprites = Resources.LoadAll("HairStyles/" + _number);
            for (int i = 1; i < sprites.Length; i++)
            {
                hairSprites[i - 1] = (Sprite)sprites[i];
            }
            hair.sprite = hairSprites[3];
        }
    }

    public void changeAccesory(int _number)
    {
        if (_number < numberOfAccesories && _number >= 0)
        {
            Object[] sprites;
            sprites = Resources.LoadAll("Accesories/" + _number);
            for (int i = 1; i < sprites.Length; i++)
            {
                accesorySprites[i - 1] = (Sprite)sprites[i];
            }
            accesory.sprite = accesorySprites[3];
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

}
