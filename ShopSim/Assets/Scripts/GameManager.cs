using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    bool dayPlaying=false;

    public TextMeshProUGUI coinstxt;
    public TextMeshProUGUI pointstxt;
    public TextMeshProUGUI timetxt;

    public GameObject startButton;

    int coinsValue = 0;
    int pointsValue = 0;
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


    }

    public void startDay()
    {
        startButton.SetActive(false);
        dayPlaying = true;
    }

    public static void changedCoins(int _coins)
    {
        
    }

    public static void changedPopularityPoints(int _points)
    {
      
    }

    
}
