using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalVariables
{
    public class ClothStandSave
    {
        float x;
        float y;

        int clothStandType;

        int outfitIndex;
        int eyeIndex;
        int accesoryIndex;
        int hairstyleIndex;
        public ClothStandSave(float _x,float _y, int _clothStandType, int _outfitIndex, int _eyeIndex, int _accesoryIndex, int _hairstyleIndex)
        {
            x = _x;
            y = _y;
            clothStandType = _clothStandType;
            outfitIndex = _outfitIndex;
            eyeIndex = _eyeIndex;
            accesoryIndex = _accesoryIndex;
            hairstyleIndex = _hairstyleIndex;
        }
    }

    public class PlacedCommonObjects
    {
        float x;
        float y;

        int category;
        int index;
        
        public PlacedCommonObjects(int _x, int _y, int _category, int _index)
        {
            x = _x;
            y = _y;

            category = _category;
            index = _index;
        }
    }

    public class SaveData
    {
        public int numberOfCoins;
        public int popularityPoints;

        public int bodyIndex;
        public int outfitIndex;
        public int eyeIndex;
        public int accesoryIndex;
        public int hairstyleIndex;

        public List<ClothStandSave> clothStands;
        public List<PlacedCommonObjects> commonObjects;

        public List<int> unlockedBodies;
        public List<int> unlockedOutfits;
        public List<int> unlockedEyes;
        public List<int> unlockedAccesories;
        public List<int> unlockedHairstyles;

        public List<int> unlockedObjectCategories;

        public SaveData()
        {
            numberOfCoins = 1000;
            popularityPoints = 1;

            bodyIndex=0;
            outfitIndex = 0;
            eyeIndex = 0;
            accesoryIndex = 0;
            hairstyleIndex = 0;

            clothStands = new List<ClothStandSave>();
            commonObjects = new List<PlacedCommonObjects>();

            unlockedBodies= new List<int>();
            unlockedOutfits = new List<int>();
            unlockedEyes = new List<int>();
            unlockedAccesories = new List<int>();
            unlockedHairstyles = new List<int>();
            for (int i = 0; i < 3; i++)
            {
                unlockedBodies.Add(i);
                unlockedOutfits.Add(i);
                unlockedEyes.Add(i);
                unlockedAccesories.Add(i);
                unlockedHairstyles.Add(i);
            }

            unlockedObjectCategories= new List<int>();
            unlockedObjectCategories.Add(0);
            unlockedObjectCategories.Add(1);
            unlockedObjectCategories.Add(2);
        }

        public SaveData(int numberOfCoins, int popularityPoints, int bodyIndex, int outfitIndex, int eyeIndex, int accesoryIndex, int hairstyleIndex, List<ClothStandSave> clothStands, List<int> unlockedBodies, List<int> unlockedOutfits, List<int> unlockedEyes, List<int> unlockedAccesories, List<int> unlockedHairstyles, List<int> unlockedObjectCategories,List<PlacedCommonObjects> placedCommonObjects)
        {
            this.numberOfCoins = numberOfCoins;
            this.popularityPoints = popularityPoints;
            this.bodyIndex = bodyIndex;
            this.outfitIndex = outfitIndex;
            this.eyeIndex = eyeIndex;
            this.accesoryIndex = accesoryIndex;
            this.hairstyleIndex = hairstyleIndex;
            this.clothStands = clothStands;
            this.commonObjects = placedCommonObjects;
            this.unlockedBodies = unlockedBodies;
            this.unlockedOutfits = unlockedOutfits;
            this.unlockedEyes = unlockedEyes;
            this.unlockedAccesories = unlockedAccesories;
            this.unlockedHairstyles = unlockedHairstyles;
            this.unlockedObjectCategories = unlockedObjectCategories;
        }
    }

    public static SaveData saveData;
    public static readonly bool debug = true;
    public static readonly int numberOfBodies=9;
    public static readonly int numberOfEyes =7;
    public static readonly int numberOfOutfits =132;
    public static readonly int numberOfHairs =200;
    public static readonly int numberOfAccesories =84;
    public static readonly float charactersSpeed = 0.2f;
    public static readonly float characterAnimationDuration = 0.13f;
    public static bool controllingPlayer=true;
    public static bool placingObject = false;

    public static readonly int clothsPrices =50;

}
