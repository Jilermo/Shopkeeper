using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectClothesMenu : UIMenuClass
{
    InteractableObject interactableObject;
    CharacterCustomization.ClothingType currentClothingType;
    int currentPage;

    public GameObject spriteButtonPrefab;
    public Transform contentParentTransform;

    public List<GameObject> clothesButtons;

    public void openMenu(float _x, float _y, InteractableObject _interactable)
    {
        gameObject.SetActive(true);
        if (_x>4.5f)
        {
            transform.position = new Vector3(_x - 4f, _y, 0f);
        }
        else
        {
            transform.position = new Vector3(_x + 4f, _y, 0f);
        }
        
        interactableObject = _interactable;

        switch (interactableObject.getInteractableObjectType())
        {
            case InteractableObject.InteractableObjectType.ClothStand:
                fillMenu(CharacterCustomization.ClothingType.outfit);
                break;
            case InteractableObject.InteractableObjectType.CommonObject:
                break;
            default:
                break;
        }
    }

    public override void closeAllMenus()
    {
        gameObject.SetActive(false);
        destroyAllButtons();
    }

    public void destroyAllButtons()
    {
        if (clothesButtons != null)
        {
            for (int i = 0; i < clothesButtons.Count; i++)
            {
                Destroy(clothesButtons[i]);
            }
        }
        clothesButtons = new List<GameObject>();
    }

    public void ChangeInteractableClothe(int _index, CharacterCustomization.ClothingType _clothingType)
    {
        switch (interactableObject.getInteractableObjectType())
        {
            case InteractableObject.InteractableObjectType.ClothStand:
                ClothStandInteractable _clothStandInteractable = (ClothStandInteractable)interactableObject;
                _clothStandInteractable.GetClothStandCustomization().changeClotheType(_index,_clothingType);
                break;
            case InteractableObject.InteractableObjectType.CommonObject:
                break;
            default:
                break;
        }

    }

    public void fillMenu(CharacterCustomization.ClothingType _clothingType)
    {
        currentPage = 0;
        currentClothingType = _clothingType;
        int _numberOfCells;
        switch (_clothingType)
        {
            case CharacterCustomization.ClothingType.body:
                destroyAllButtons();
                _numberOfCells = 30;
                if (GlobalVariables.numberOfBodies < 30)
                {
                    _numberOfCells = GlobalVariables.numberOfBodies;
                }
                for (int i = 0; i < _numberOfCells; i++)
                {
                    Object[] sprites;
                    sprites = Resources.LoadAll("Bodies/" + i);
                    GameObject clothButton = Instantiate(spriteButtonPrefab, contentParentTransform);
                    clothButton.GetComponent<Image>().sprite = (Sprite)sprites[4];
                    ClothButtonScript _clothButtonScript = clothButton.GetComponent<ClothButtonScript>();
                    _clothButtonScript.clothIndex = i;
                    _clothButtonScript.clothesMenu = this;
                    clothesButtons.Add(clothButton);
                }
                break;
            case CharacterCustomization.ClothingType.eyes:
                destroyAllButtons();
                _numberOfCells = 30;
                if (GlobalVariables.numberOfEyes < 30)
                {
                    _numberOfCells = GlobalVariables.numberOfEyes;
                }
                for (int i = 0; i < _numberOfCells; i++)
                {
                    Object[] sprites;
                    sprites = Resources.LoadAll("Eyes/" + i);
                    GameObject clothButton = Instantiate(spriteButtonPrefab, contentParentTransform);
                    clothButton.GetComponent<Image>().sprite = (Sprite)sprites[4];
                    ClothButtonScript _clothButtonScript = clothButton.GetComponent<ClothButtonScript>();
                    _clothButtonScript.clothIndex = i;
                    _clothButtonScript.clothesMenu = this;
                    clothesButtons.Add(clothButton);
                }
                break;
            case CharacterCustomization.ClothingType.outfit:
                destroyAllButtons();
                _numberOfCells = 30;
                if (GlobalVariables.numberOfOutfits < 30)
                {
                    _numberOfCells = GlobalVariables.numberOfOutfits;
                }
                for (int i = 0; i < _numberOfCells; i++)
                {
                    Object[] sprites;
                    sprites = Resources.LoadAll("Outfits/" + i);                    
                    GameObject clothButton = Instantiate(spriteButtonPrefab,contentParentTransform);
                    clothButton.GetComponent<Image>().sprite = (Sprite)sprites[4];
                    ClothButtonScript _clothButtonScript = clothButton.GetComponent<ClothButtonScript>();
                    _clothButtonScript.clothIndex = i;
                    _clothButtonScript.clothesMenu = this;
                    clothesButtons.Add(clothButton);
                }

                break;
            case CharacterCustomization.ClothingType.hair:
                destroyAllButtons();
                _numberOfCells = 30;
                if (GlobalVariables.numberOfHairs < 30)
                {
                    _numberOfCells = GlobalVariables.numberOfHairs;
                }
                for (int i = 0; i < _numberOfCells; i++)
                {
                    Object[] sprites;
                    sprites = Resources.LoadAll("HairStyles/" + i);
                    GameObject clothButton = Instantiate(spriteButtonPrefab, contentParentTransform);
                    clothButton.GetComponent<Image>().sprite = (Sprite)sprites[4];
                    ClothButtonScript _clothButtonScript = clothButton.GetComponent<ClothButtonScript>();
                    _clothButtonScript.clothIndex = i;
                    _clothButtonScript.clothesMenu = this;
                    clothesButtons.Add(clothButton);
                }
                break;
            case CharacterCustomization.ClothingType.accesory:
                destroyAllButtons();
                _numberOfCells = 30;
                if (GlobalVariables.numberOfAccesories < 30)
                {
                    _numberOfCells = GlobalVariables.numberOfAccesories;
                }
                for (int i = 0; i < _numberOfCells; i++)
                {
                    Object[] sprites;
                    sprites = Resources.LoadAll("Accesories/" + i);
                    GameObject clothButton = Instantiate(spriteButtonPrefab, contentParentTransform);
                    clothButton.GetComponent<Image>().sprite = (Sprite)sprites[4];
                    ClothButtonScript _clothButtonScript = clothButton.GetComponent<ClothButtonScript>();
                    _clothButtonScript.clothIndex = i;
                    _clothButtonScript.clothesMenu = this;
                    clothesButtons.Add(clothButton);
                }
                break;
            default:
                break;
        }
    }

    public void nextPage()
    {
        int _numberOfCells;
        switch (currentClothingType)
        {
            case CharacterCustomization.ClothingType.body:

                if (GlobalVariables.numberOfBodies > 30 * (currentPage + 1))
                {
                    currentPage += 1;
                    destroyAllButtons();
                    _numberOfCells = 30 * (currentPage + 1);
                    if (GlobalVariables.numberOfBodies < 30 * (currentPage + 1))
                    {
                        _numberOfCells = GlobalVariables.numberOfBodies;
                    }
                    for (int i = 30 * (currentPage); i < _numberOfCells; i++)
                    {
                        Object[] sprites;
                        sprites = Resources.LoadAll("Bodies/" + i);
                        GameObject clothButton = Instantiate(spriteButtonPrefab, contentParentTransform);
                        clothButton.GetComponent<Image>().sprite = (Sprite)sprites[4];
                        ClothButtonScript _clothButtonScript = clothButton.GetComponent<ClothButtonScript>();
                        _clothButtonScript.clothIndex = i;
                        _clothButtonScript.clothesMenu = this;
                        clothesButtons.Add(clothButton);
                    }
                }
                break;
            case CharacterCustomization.ClothingType.eyes:
                if (GlobalVariables.numberOfEyes > 30*(currentPage+1))
                {
                    currentPage += 1;
                    destroyAllButtons();
                    _numberOfCells = 30 * (currentPage + 1);
                    if (GlobalVariables.numberOfEyes < 30 * (currentPage + 1))
                    {
                        _numberOfCells = GlobalVariables.numberOfEyes;
                    }
                    for (int i = 30 * (currentPage); i < _numberOfCells; i++)
                    {
                        Object[] sprites;
                        sprites = Resources.LoadAll("Eyes/" + i);
                        GameObject clothButton = Instantiate(spriteButtonPrefab, contentParentTransform);
                        clothButton.GetComponent<Image>().sprite = (Sprite)sprites[4];
                        ClothButtonScript _clothButtonScript = clothButton.GetComponent<ClothButtonScript>();
                        _clothButtonScript.clothIndex = i;
                        _clothButtonScript.clothesMenu = this;
                        clothesButtons.Add(clothButton);
                    }
                }
                break;
            case CharacterCustomization.ClothingType.outfit:

                if (GlobalVariables.numberOfOutfits > 30 * (currentPage + 1))
                {
                    currentPage += 1;
                    destroyAllButtons();
                    _numberOfCells = 30 * (currentPage + 1);

                    if (GlobalVariables.numberOfOutfits < 30 * (currentPage + 1))
                    {
                        _numberOfCells = GlobalVariables.numberOfOutfits;
                    }
                    for (int i = 30 * (currentPage); i < _numberOfCells; i++)
                    {
                        Object[] sprites;
                        sprites = Resources.LoadAll("Outfits/" + i);
                        GameObject clothButton = Instantiate(spriteButtonPrefab, contentParentTransform);
                        clothButton.GetComponent<Image>().sprite = (Sprite)sprites[4];
                        ClothButtonScript _clothButtonScript = clothButton.GetComponent<ClothButtonScript>();
                        _clothButtonScript.clothIndex = i;
                        _clothButtonScript.clothesMenu = this;
                        clothesButtons.Add(clothButton);
                    }
                }
                break;
            case CharacterCustomization.ClothingType.hair:

                if (GlobalVariables.numberOfHairs > 30 * (currentPage + 1))
                {
                    currentPage += 1;
                    destroyAllButtons();
                    _numberOfCells = 30 * (currentPage + 1);
                    if (GlobalVariables.numberOfHairs < 30 * (currentPage + 1))
                    {
                        _numberOfCells = GlobalVariables.numberOfHairs;
                    }
                    for (int i = 30 * (currentPage); i < _numberOfCells; i++)
                    {
                        Object[] sprites;
                        sprites = Resources.LoadAll("HairStyles/" + i);
                        GameObject clothButton = Instantiate(spriteButtonPrefab, contentParentTransform);
                        clothButton.GetComponent<Image>().sprite = (Sprite)sprites[4];
                        ClothButtonScript _clothButtonScript = clothButton.GetComponent<ClothButtonScript>();
                        _clothButtonScript.clothIndex = i;
                        _clothButtonScript.clothesMenu = this;
                        clothesButtons.Add(clothButton);
                    }
                }

                break;
            case CharacterCustomization.ClothingType.accesory:

                if (GlobalVariables.numberOfAccesories > 30 * (currentPage + 1))
                {
                    currentPage += 1;
                    destroyAllButtons();
                    _numberOfCells = 30 * (currentPage + 1);
                    if (GlobalVariables.numberOfAccesories < 30 * (currentPage + 1))
                    {
                        _numberOfCells = GlobalVariables.numberOfAccesories;
                    }
                    for (int i = 30 * (currentPage); i < _numberOfCells; i++)
                    {
                        Object[] sprites;
                        sprites = Resources.LoadAll("Accesories/" + i);
                        GameObject clothButton = Instantiate(spriteButtonPrefab, contentParentTransform);
                        clothButton.GetComponent<Image>().sprite = (Sprite)sprites[4];
                        ClothButtonScript _clothButtonScript = clothButton.GetComponent<ClothButtonScript>();
                        _clothButtonScript.clothIndex = i;
                        _clothButtonScript.clothesMenu = this;
                        clothesButtons.Add(clothButton);
                    }
                }
                break;
            default:
                break;
        }
    }

    public void prevPage()
    {
        int _numberOfCells;
        switch (currentClothingType)
        {
            case CharacterCustomization.ClothingType.body:
                if (currentPage>0)
                {
                    currentPage -= 1;
                    destroyAllButtons();
                    _numberOfCells = 30 * (currentPage + 1);
                    if (GlobalVariables.numberOfBodies < 30 * (currentPage + 1))
                    {
                        _numberOfCells = GlobalVariables.numberOfBodies;
                    }
                    for (int i = 30 * (currentPage); i < _numberOfCells; i++)
                    {
                        Object[] sprites;
                        sprites = Resources.LoadAll("Bodies/" + i);
                        GameObject clothButton = Instantiate(spriteButtonPrefab, contentParentTransform);
                        clothButton.GetComponent<Image>().sprite = (Sprite)sprites[4];
                        ClothButtonScript _clothButtonScript = clothButton.GetComponent<ClothButtonScript>();
                        _clothButtonScript.clothIndex = i;
                        _clothButtonScript.clothesMenu = this;
                        clothesButtons.Add(clothButton);
                    }
                }
   
                break;
            case CharacterCustomization.ClothingType.eyes:
                if (currentPage > 0)
                {
                    currentPage -= 1;
                    destroyAllButtons();
                    _numberOfCells = 30 * (currentPage + 1);
                    if (GlobalVariables.numberOfEyes < 30 * (currentPage + 1))
                    {
                        _numberOfCells = GlobalVariables.numberOfEyes;
                    }
                    for (int i = 30 * (currentPage); i < _numberOfCells; i++)
                    {
                        Object[] sprites;
                        sprites = Resources.LoadAll("Eyes/" + i);
                        GameObject clothButton = Instantiate(spriteButtonPrefab, contentParentTransform);
                        clothButton.GetComponent<Image>().sprite = (Sprite)sprites[4];
                        ClothButtonScript _clothButtonScript = clothButton.GetComponent<ClothButtonScript>();
                        _clothButtonScript.clothIndex = i;
                        _clothButtonScript.clothesMenu = this;
                        clothesButtons.Add(clothButton);
                    }
                }
                break;
            case CharacterCustomization.ClothingType.outfit:
                if (currentPage > 0)
                {
                    currentPage -= 1;
                    destroyAllButtons();
                    _numberOfCells = 30 * (currentPage + 1);
                    if (GlobalVariables.numberOfOutfits < 30 * (currentPage + 1))
                    {
                        _numberOfCells = GlobalVariables.numberOfOutfits;
                    }
                    for (int i = 30 * (currentPage); i < _numberOfCells; i++)
                    {
                        Object[] sprites;
                        sprites = Resources.LoadAll("Outfits/" + i);
                        GameObject clothButton = Instantiate(spriteButtonPrefab, contentParentTransform);
                        clothButton.GetComponent<Image>().sprite = (Sprite)sprites[4];
                        ClothButtonScript _clothButtonScript = clothButton.GetComponent<ClothButtonScript>();
                        _clothButtonScript.clothIndex = i;
                        _clothButtonScript.clothesMenu = this;
                        clothesButtons.Add(clothButton);
                    }
                }
   
                break;
            case CharacterCustomization.ClothingType.hair:
                if (currentPage > 0)
                {
                    currentPage -= 1;
                    destroyAllButtons();
                    _numberOfCells = 30 * (currentPage + 1);
                    if (GlobalVariables.numberOfHairs < 30 * (currentPage + 1))
                    {
                        _numberOfCells = GlobalVariables.numberOfHairs;
                    }
                    for (int i = 30 * (currentPage); i < _numberOfCells; i++)
                    {
                        Object[] sprites;
                        sprites = Resources.LoadAll("HairStyles/" + i);
                        GameObject clothButton = Instantiate(spriteButtonPrefab, contentParentTransform);
                        clothButton.GetComponent<Image>().sprite = (Sprite)sprites[4];
                        ClothButtonScript _clothButtonScript = clothButton.GetComponent<ClothButtonScript>();
                        _clothButtonScript.clothIndex = i;
                        _clothButtonScript.clothesMenu = this;
                        clothesButtons.Add(clothButton);
                    }
                }

                break;
            case CharacterCustomization.ClothingType.accesory:
                if (currentPage > 0)
                {
                    currentPage -= 1;
                    destroyAllButtons();
                    _numberOfCells = 30 * (currentPage + 1);
                    if (GlobalVariables.numberOfAccesories < 30 * (currentPage + 1))
                    {
                        _numberOfCells = GlobalVariables.numberOfAccesories;
                    }
                    for (int i = 30 * (currentPage); i < _numberOfCells; i++)
                    {
                        Object[] sprites;
                        sprites = Resources.LoadAll("Accesories/" + i);
                        GameObject clothButton = Instantiate(spriteButtonPrefab, contentParentTransform);
                        clothButton.GetComponent<Image>().sprite = (Sprite)sprites[4];
                        ClothButtonScript _clothButtonScript = clothButton.GetComponent<ClothButtonScript>();
                        _clothButtonScript.clothIndex = i;
                        _clothButtonScript.clothesMenu = this;
                        clothesButtons.Add(clothButton);
                    }
                }
                break;
            default:
                break;
        }
    }

    public void nextCategory()
    {
        switch (interactableObject.getInteractableObjectType())
        {
            case InteractableObject.InteractableObjectType.ClothStand:
                switch (currentClothingType)
                {
                    case CharacterCustomization.ClothingType.body:
                        currentClothingType = CharacterCustomization.ClothingType.outfit;
                        fillMenu(CharacterCustomization.ClothingType.outfit);
                        break;
                    case CharacterCustomization.ClothingType.eyes:
                        currentClothingType = CharacterCustomization.ClothingType.outfit;
                        fillMenu(CharacterCustomization.ClothingType.outfit);
                        break;
                    case CharacterCustomization.ClothingType.outfit:
                        currentClothingType = CharacterCustomization.ClothingType.hair;
                        fillMenu(CharacterCustomization.ClothingType.hair);
                        break;
                    case CharacterCustomization.ClothingType.hair:
                        currentClothingType = CharacterCustomization.ClothingType.accesory;
                        fillMenu(CharacterCustomization.ClothingType.accesory);
                        break;
                    case CharacterCustomization.ClothingType.accesory:
                        currentClothingType = CharacterCustomization.ClothingType.eyes;
                        fillMenu(CharacterCustomization.ClothingType.eyes);
                        break;
                    default:
                        break;
                }
                break;
            case InteractableObject.InteractableObjectType.CommonObject:
                break;
            default:
                break;
        }
    }

    public void prevCategory()
    {
        switch (interactableObject.getInteractableObjectType())
        {
            case InteractableObject.InteractableObjectType.ClothStand:
                switch (currentClothingType)
                {
                    case CharacterCustomization.ClothingType.body:
                        currentClothingType = CharacterCustomization.ClothingType.outfit;
                        fillMenu(CharacterCustomization.ClothingType.outfit);
                        break;
                    case CharacterCustomization.ClothingType.eyes:
                        currentClothingType = CharacterCustomization.ClothingType.accesory;
                        fillMenu(CharacterCustomization.ClothingType.accesory);
                        break;
                    case CharacterCustomization.ClothingType.outfit:
                        currentClothingType = CharacterCustomization.ClothingType.eyes;
                        fillMenu(CharacterCustomization.ClothingType.eyes);
                        break;
                    case CharacterCustomization.ClothingType.hair:
                        currentClothingType = CharacterCustomization.ClothingType.outfit;
                        fillMenu(CharacterCustomization.ClothingType.outfit);
                        break;
                    case CharacterCustomization.ClothingType.accesory:
                        currentClothingType = CharacterCustomization.ClothingType.hair;
                        fillMenu(CharacterCustomization.ClothingType.hair);
                        break;
                    default:
                        break;
                }
                break;
            case InteractableObject.InteractableObjectType.CommonObject:
                break;
            default:
                break;
        }
    }


    public void selectCloth(int _clothIndex)
    {
        ChangeInteractableClothe(_clothIndex, currentClothingType);
    }

   
}
