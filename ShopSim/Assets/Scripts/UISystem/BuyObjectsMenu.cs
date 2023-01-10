using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyObjectsMenu : UIMenuClass
{
    InteractableObject interactableObject;
    int categoryIndex;
    int currentPage;

    int totalCathegories=21;
    public GameObject buyButton;

    public GameObject spriteButtonPrefab;
    public Transform contentParentTransform;

    public GameObject objectPrefab;

    public List<GameObject> objectsButtons;

    MainUIScript mainUIScript;

    float x;
    float y;
    public void openMenu(float _x, float _y, MainUIScript _mainUIScript)
    {
        buyButton.SetActive(false);
        x = _x;
        y = _y;
        mainUIScript = _mainUIScript;
        gameObject.SetActive(true);
        if (_x > 4.5f)
        {
            transform.position = new Vector3(_x - 4f, 0f, 0f);
        }
        else
        {
            transform.position = new Vector3(_x + 4f, 0f, 0f);
        }

        fillMenu(0);
    }

    public void fillMenu(int _categoryIndex)
    {
        buyButton.SetActive(false);
        currentPage = 0;
        categoryIndex = _categoryIndex;
        destroyAllButtons();
        int _numberOfCells = 30;
        if (GlobalVariables.numberOfObjects[_categoryIndex] < 30)
        {
            _numberOfCells = GlobalVariables.numberOfObjects[_categoryIndex];
        }
        for (int i = 0; i < _numberOfCells; i++)
        {
            Object[] sprites;
            sprites = Resources.LoadAll("Building/Objects/" + _categoryIndex + "/" + i);
            
            if (sprites.Length>1)
            {
                GameObject ObjectButton = Instantiate(spriteButtonPrefab, contentParentTransform);
                ObjectButton.GetComponent<Image>().sprite = (Sprite)sprites[1];
                ObjectButtonScript _objectButtonScript = ObjectButton.GetComponent<ObjectButtonScript>();
                _objectButtonScript.index = i;
                _objectButtonScript.categoryIndex = categoryIndex;
                _objectButtonScript.buyObjectsMenu = this;
                objectsButtons.Add(ObjectButton);
            }
        }

        if (!GlobalVariables.saveData.unlockedObjectCategories.Contains(_categoryIndex))
        {
            buyButton.SetActive(true);
        }
    }

    public void buyCategory()
    {
        if (GlobalVariables.saveData.getNumberOfCoins() >= GlobalVariables.categoryBuyPrice)
        {
            GlobalVariables.saveData.setNumberOfCoins(GlobalVariables.saveData.getNumberOfCoins() - GlobalVariables.categoryBuyPrice);
            unlockCategory();
        }
    }

    public void unlockCategory()
    {
        GlobalVariables.saveData.unlockedObjectCategories.Add(categoryIndex);
        for (int i = 0; i < objectsButtons.Count; i++)
        {
            objectsButtons[i].GetComponent<ObjectButtonScript>().Unlock();
        }
        buyButton.SetActive(false);
    }

    public void nextPage()
    {
        int _numberOfCells;
        if (GlobalVariables.numberOfObjects[categoryIndex] > 30 * (currentPage + 1))
        {
            currentPage += 1;
            destroyAllButtons();
            _numberOfCells = 30 * (currentPage + 1);
            if (GlobalVariables.numberOfObjects[categoryIndex] < 30 * (currentPage + 1))
            {
                _numberOfCells = GlobalVariables.numberOfObjects[categoryIndex];
            }
            for (int i = 30 * (currentPage); i < _numberOfCells; i++)
            {
                Object[] sprites;
                sprites = Resources.LoadAll("Building/Objects/" + categoryIndex + "/" + i);
                
                if (sprites.Length > 1)
                {
                    GameObject ObjectButton = Instantiate(spriteButtonPrefab, contentParentTransform);
                    ObjectButton.GetComponent<Image>().sprite = (Sprite)sprites[1];
                    ObjectButtonScript _objectButtonScript = ObjectButton.GetComponent<ObjectButtonScript>();
                    _objectButtonScript.index = i;
                    _objectButtonScript.categoryIndex = categoryIndex;
                    _objectButtonScript.buyObjectsMenu = this;
                    objectsButtons.Add(ObjectButton);
                }
                
            }
        }
    }

    public void prevPage()
    {
        int _numberOfCells;
        if (currentPage > 0)
        {
            currentPage -= 1;
            destroyAllButtons();
            _numberOfCells = 30 * (currentPage + 1);
            if (GlobalVariables.numberOfObjects[categoryIndex] < 30 * (currentPage + 1))
            {
                _numberOfCells = GlobalVariables.numberOfObjects[categoryIndex];
            }
            for (int i = 30 * (currentPage); i < _numberOfCells; i++)
            {
                Object[] sprites;
                sprites = Resources.LoadAll("Building/Objects/" + categoryIndex + "/" + i);
                
                if (sprites.Length > 1)
                {
                    GameObject ObjectButton = Instantiate(spriteButtonPrefab, contentParentTransform);
                    ObjectButton.GetComponent<Image>().sprite = (Sprite)sprites[1];
                    ObjectButtonScript _objectButtonScript = ObjectButton.GetComponent<ObjectButtonScript>();
                    _objectButtonScript.index = i;
                    _objectButtonScript.categoryIndex = categoryIndex;
                    _objectButtonScript.buyObjectsMenu = this;
                    objectsButtons.Add(ObjectButton);
                }
            }
        }
        
    }

    public void nextCategory()
    {
        categoryIndex += 1;
        if (categoryIndex>=(totalCathegories-1))
        {
            categoryIndex = 0;
        }
        fillMenu(categoryIndex);
        
    }

    public void prevCategory()
    {
        categoryIndex -= 1;
        if (categoryIndex < 0)
        {
            categoryIndex = totalCathegories-1;
        }
        fillMenu(categoryIndex);
    }

    public void BuyObject(int _index, int _categoryIndex)
    {
        closeAllMenus();
        GameObject _placedObject = Instantiate(objectPrefab, mainUIScript.placedObjectsParent);
        Object[] sprites;
        sprites = Resources.LoadAll("Building/Objects/" + _categoryIndex + "/" + _index);
        _placedObject.GetComponent<SpriteRenderer>().sprite = (Sprite)sprites[1];
        _placedObject.GetComponent<PlacedObject>().index = _index;
        _placedObject.GetComponent<PlacedObject>().categoryIndex = _categoryIndex;
    }

    public override void closeAllMenus()
    {
        gameObject.SetActive(false);
        destroyAllButtons();
    }

    public void destroyAllButtons()
    {
        if (objectsButtons != null)
        {
            for (int i = 0; i < objectsButtons.Count; i++)
            {
                Destroy(objectsButtons[i]);
            }
        }
        objectsButtons = new List<GameObject>();
    }
}
