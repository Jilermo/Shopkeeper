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

    public int numberOfBodies;
    public int numberOfEyes;
    public int numberOfOutfits;
    public int numberOfHairs;
    public int numberOfAccesories;



    public void changeBody(int _number)
    {
        if (_number<numberOfBodies && _number >=0)
        {
            Object[] sprites;
            sprites = Resources.LoadAll("Tiles/Castillo");
            
        }
    }

    public void changeEyes()
    {

    }

    public void changeOutfit()
    {

    }

    public void changeHair()
    {

    }

    public void changeAccesory()
    {

    }


}
