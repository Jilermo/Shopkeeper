using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool dayPlaying=false;

    public TextMeshProUGUI coinstxt;
    public TextMeshProUGUI pointstxt;
    public TextMeshProUGUI timetxt;

    public GameObject startButton;

    public GameObject AICharacter;
    public Transform npcContainer;

    int coinsValue = 0;
    int pointsValue = 0;

    float startTime;
    float lastSpawn;

    public GameObject placeObjectPrefab;
    public Transform placeObjectTransform;

    public GameObject clothStandPrefab;
    public Transform clothStandTransform;

    private void Awake()
    {

        string _path = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "SaveData.json";
        if (System.IO.File.Exists(_path))
        {
            loadData();
        }
        else
        {
            GlobalVariables.saveData = new GlobalVariables.SaveData();
        }
        
        
    }
    


    // Update is called once per frame
    void Update()
    {
        if (GlobalVariables.saveData.getNumberOfCoins()!=coinsValue)
        {
            coinsValue = GlobalVariables.saveData.getNumberOfCoins();
            coinstxt.text = coinsValue.ToString();
        }

        if (GlobalVariables.saveData.getNumberOfPoints() != pointsValue)
        {
            pointsValue = GlobalVariables.saveData.getNumberOfPoints();
            pointstxt.text = pointsValue.ToString();
        }

        if (dayPlaying)
        {
            if (Time.time-startTime>120f)
            {
                dayPlaying = false;
                startButton.SetActive(true);
                GlobalVariables.placingObject = false;
            }
            timetxt.text = (120 - (Time.time - startTime)).ToString();

            if (Time.time-lastSpawn>20f)
            {
                lastSpawn = Time.time;
                spawnNPC();
            }
        }
    }

    public void startDay()
    {
        startButton.SetActive(false);
        dayPlaying = true;
        startTime = Time.time;
        GlobalVariables.placingObject = true;
        lastSpawn = Time.time;
        spawnNPC();
    }

    public void spawnNPC()
    {
        Instantiate(AICharacter,npcContainer);
    }

    public static void changedCoins(int _coins)
    {
        
    }

    public static void changedPopularityPoints(int _points)
    {
      
    }

    public void saveData()
    {
        string _path = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "SaveData.json";

        string json = JsonUtility.ToJson(GlobalVariables.saveData);

        using StreamWriter writer = new StreamWriter(_path);
        writer.Write(json);
    }

    public void loadData()
    {
        string _path = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "SaveData.json";
        using StreamReader reader = new StreamReader(_path);

        string json = reader.ReadToEnd();
        GlobalVariables.SaveData _saveData = JsonUtility.FromJson<GlobalVariables.SaveData>(json);
        GlobalVariables.saveData = _saveData;
        StartCoroutine(load(_saveData));

    }

    IEnumerator load(GlobalVariables.SaveData _saveData)
    {
        yield return new WaitForSeconds(0.2f);
        for (int i = 0; i < _saveData.commonObjects.Count; i++)
        {
            GameObject placedObject = Instantiate(placeObjectPrefab, placeObjectTransform);
            placedObject.GetComponent<PlacedObject>().placeObject(_saveData.commonObjects[i].x, _saveData.commonObjects[i].y, _saveData.commonObjects[i].index, _saveData.commonObjects[i].category, _saveData.commonObjects[i]);
        }

        for (int i = 0; i < _saveData.clothStands.Count; i++)
        {
            GameObject _clothStands = Instantiate(clothStandPrefab, clothStandTransform);
            _clothStands.GetComponent<ClothStand>().placeClothStand(_saveData.clothStands[i].x, _saveData.clothStands[i].y, _saveData.clothStands[i].clothStandType, _saveData.clothStands[i].outfitIndex, _saveData.clothStands[i].hairstyleIndex, _saveData.clothStands[i].eyeIndex, _saveData.clothStands[i].accesoryIndex, _saveData.clothStands[i]);
        }
    }

    public void reseSave()
    {
        string _path = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "SaveData.json";

        string json = JsonUtility.ToJson(new GlobalVariables.SaveData());

        using StreamWriter writer = new StreamWriter(_path);
        writer.Write(json);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
