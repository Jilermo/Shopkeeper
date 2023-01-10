using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

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
    private void Awake()
    {
        GlobalVariables.saveData = new GlobalVariables.SaveData();
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
        Debug.Log(json);
    }
}
