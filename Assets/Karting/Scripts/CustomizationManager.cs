using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizationManager : MonoBehaviour
{
    [Header("Hats")]
    public GameObject[] hatsPrefabs;


    [Header("Wheels")]
    public GameObject[] wheelsPrefabs;
    private bool isNormalWheels;


    [Header("Player")]
    [Header("Colors")]
    public Material playerMat;
    public Color[] playerColorsOptions;
    [Header("Car")]
    public Material carMat;
    public Color[] carColorsOptions;
    [Header("WheelsColor")]
    public Material wheelsMat;
    public Color[] wheelsColorsOptions;


    //Number of index in the array of each mod
    [HideInInspector]
    public int indexHat;
    [HideInInspector]
    public int indexPlayer;
    [HideInInspector]
    public int indexCar;
    [HideInInspector]
    public int indexWheels;

    private void OnEnable()
    {
        //Set lobby car modifications to the preferences of the user

        if (PlayerPrefs.HasKey("indexHat"))
        {
            hatsPrefabs[PlayerPrefs.GetInt("indexHat") - 1].SetActive(true);
            indexHat = PlayerPrefs.GetInt("indexHat");
        }

        playerMat.color = playerColorsOptions[PlayerPrefs.GetInt("indexPlayer")];
        indexPlayer = PlayerPrefs.GetInt("indexPlayer")+1;

        carMat.color = carColorsOptions[PlayerPrefs.GetInt("indexCar")];
        indexCar = PlayerPrefs.GetInt("indexCar") + 1;

        wheelsMat.color = wheelsColorsOptions[PlayerPrefs.GetInt("indexWheels")];
        indexWheels = PlayerPrefs.GetInt("indexWheels") + 1;

        if(PlayerPrefs.GetInt("changeWheels") == 0)
        {
            wheelsPrefabs[0].SetActive(true);
            wheelsPrefabs[1].SetActive(false);
            isNormalWheels = true;
        }
        else
        {
            wheelsPrefabs[0].SetActive(false);
            wheelsPrefabs[1].SetActive(true);
            isNormalWheels = false;
        }
    }

    public void ChangeHat()
    {
        foreach (var item in hatsPrefabs)
        {
            item.SetActive(false);
        }

        indexHat++;

        if (indexHat == 0)
            return;

        hatsPrefabs[indexHat - 1].SetActive(true);

        if(indexHat == hatsPrefabs.Length)
            indexHat = -1;

        PlayerPrefs.SetInt("indexHat", indexHat);
    }

    public void ChangePlayerColor()
    {
        if (indexPlayer > playerColorsOptions.Length - 1)
            indexPlayer = 0;

        playerMat.color = playerColorsOptions[indexPlayer];

        PlayerPrefs.SetInt("indexPlayer", indexPlayer);

        indexPlayer++;
    }

    public void ChangeCarColor()
    {
        if (indexCar > carColorsOptions.Length - 1)
            indexCar = 0;

        carMat.color = carColorsOptions[indexCar];
        
        PlayerPrefs.SetInt("indexCar", indexCar);

        indexCar++;
    }

    public void ChangeWheelsColor()
    {
        if (indexWheels > wheelsColorsOptions.Length - 1)
            indexWheels = 0;

        wheelsMat.color = wheelsColorsOptions[indexWheels];
        
        PlayerPrefs.SetInt("indexWheels", indexWheels);

        indexWheels++;
    }

    public void ChangeWheels()
    {
        isNormalWheels = !isNormalWheels;

        if (isNormalWheels)
        {
            wheelsPrefabs[0].SetActive(true);
            wheelsPrefabs[1].SetActive(false);
            PlayerPrefs.SetInt("changeWheels", 0);
        }
        else
        {
            wheelsPrefabs[0].SetActive(false);
            wheelsPrefabs[1].SetActive(true);
            PlayerPrefs.SetInt("changeWheels", 1);
        }        
    }
}
