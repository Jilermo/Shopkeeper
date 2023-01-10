using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalVariables
{
    [System.Serializable]
    public class ClothStandSave
    {
        public float x;
        public float y;

        public int clothStandType;

        public int outfitIndex;
        public int eyeIndex;
        public int accesoryIndex;
        public int hairstyleIndex;
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

    [System.Serializable]
    public class PlacedCommonObjects
    {
        public float x;
        public float y;

        public int category;
        public int index;
        
        public PlacedCommonObjects(float _x, float _y, int _category, int _index)
        {
            x = _x;
            y = _y;

            category = _category;
            index = _index;
        }
    }

    [System.Serializable]
    public class SaveData
    {
        public int numberOfDays;
        private int numberOfCoins;
        private int popularityPoints;

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
            numberOfDays = 0;
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

            GameManager.changedCoins(numberOfCoins);
            GameManager.changedPopularityPoints(popularityPoints);
        }

        public SaveData(int _numberOfDays,int numberOfCoins, int popularityPoints, int bodyIndex, int outfitIndex, int eyeIndex, int accesoryIndex, int hairstyleIndex, List<ClothStandSave> clothStands, List<int> unlockedBodies, List<int> unlockedOutfits, List<int> unlockedEyes, List<int> unlockedAccesories, List<int> unlockedHairstyles, List<int> unlockedObjectCategories,List<PlacedCommonObjects> placedCommonObjects)
        {
            numberOfDays = _numberOfDays;
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

        public int getNumberOfCoins()
        {
            return numberOfCoins;
        }

        public void setNumberOfCoins(int _number)
        {
            numberOfCoins=_number;
            
        }

        public int getNumberOfPoints()
        {
            return popularityPoints;
        }

        public void setNumberOfPoints(int _points)
        {
            popularityPoints = _points;
            
        }
    }

    public static SaveData saveData;
    public static readonly List<int> numberOfObjects= new List<int> { 122,158,555,75,249,46,209,77,29,240,28,102,343,123,483,344,532,131,80,451,170};
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
    public static readonly int objectsPrices = 25;
    public static readonly int categoryBuyPrice = 200;

}
