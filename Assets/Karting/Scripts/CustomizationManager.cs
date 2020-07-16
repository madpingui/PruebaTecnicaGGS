using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizationManager : MonoBehaviour
{
    //Resources to change the player
    [Header("Hats")]
    public GameObject[] HatsPrefabs;

    [Header("Wheels")]
    public GameObject[] WheelsPrefabs;
    private bool IsNormalWheels;
    
    [Header("Player")]
    [Header("Colors")]
    public Material PlayerMaterial;
    public Color[] PlayerColorsOptions;
    [Header("Car")]
    public Material CarMaterial;
    public Color[] CarColorsOptions;
    [Header("WheelsColor")]
    public Material WheelsMaterial;
    public Color[] WheelsColorsOptions;


    //Number of index in the array of each modification
    [HideInInspector]
    public int CurrentIndexHat;
    [HideInInspector]
    public int CurrentIndexPlayer;
    [HideInInspector]
    public int CurrentIndexCar;
    [HideInInspector]
    public int CurrentIndexWheels;

    private void OnEnable()
    {
        //Set lobby car modifications to the preferences of the user already saved

        if (PlayerPrefs.HasKey("indexHat"))
        {
            HatsPrefabs[PlayerPrefs.GetInt("indexHat") - 1].SetActive(true);
            CurrentIndexHat = PlayerPrefs.GetInt("indexHat");
        }

        PlayerMaterial.color = PlayerColorsOptions[PlayerPrefs.GetInt("indexPlayer")];
        CurrentIndexPlayer = PlayerPrefs.GetInt("indexPlayer")+1;

        CarMaterial.color = CarColorsOptions[PlayerPrefs.GetInt("indexCar")];
        CurrentIndexCar = PlayerPrefs.GetInt("indexCar") + 1;

        WheelsMaterial.color = WheelsColorsOptions[PlayerPrefs.GetInt("indexWheels")];
        CurrentIndexWheels = PlayerPrefs.GetInt("indexWheels") + 1;

        if(PlayerPrefs.GetInt("changeWheels") == 0)
        {
            WheelsPrefabs[0].SetActive(true);
            WheelsPrefabs[1].SetActive(false);
            IsNormalWheels = true;
        }
        else
        {
            WheelsPrefabs[0].SetActive(false);
            WheelsPrefabs[1].SetActive(true);
            IsNormalWheels = false;
        }
    }


    //Change hat by UI button
    public void ChangeHat()
    {
        foreach (var item in HatsPrefabs)
        {
            item.SetActive(false);
        }

        CurrentIndexHat++;

        if (CurrentIndexHat == 0)
            return;

        HatsPrefabs[CurrentIndexHat - 1].SetActive(true);

        if(CurrentIndexHat == HatsPrefabs.Length)
            CurrentIndexHat = -1;

        if(CurrentIndexHat == -1)
        {
            PlayerPrefs.DeleteKey("indexHat");
        }
        else
        {
            PlayerPrefs.SetInt("indexHat", CurrentIndexHat);
        }
        
    }

    //Change player color by UI button
    public void ChangePlayerColor()
    {
        if (CurrentIndexPlayer > PlayerColorsOptions.Length - 1)
            CurrentIndexPlayer = 0;

        PlayerMaterial.color = PlayerColorsOptions[CurrentIndexPlayer];

        PlayerPrefs.SetInt("indexPlayer", CurrentIndexPlayer);

        CurrentIndexPlayer++;
    }

    //Change car color by UI button
    public void ChangeCarColor()
    {
        if (CurrentIndexCar > CarColorsOptions.Length - 1)
            CurrentIndexCar = 0;

        CarMaterial.color = CarColorsOptions[CurrentIndexCar];
        
        PlayerPrefs.SetInt("indexCar", CurrentIndexCar);

        CurrentIndexCar++;
    }

    //Change wheels color by UI button
    public void ChangeWheelsColor()
    {
        if (CurrentIndexWheels > WheelsColorsOptions.Length - 1)
            CurrentIndexWheels = 0;

        WheelsMaterial.color = WheelsColorsOptions[CurrentIndexWheels];
        
        PlayerPrefs.SetInt("indexWheels", CurrentIndexWheels);

        CurrentIndexWheels++;
    }

    //Change wheels 3d model by UI button
    public void ChangeWheels()
    {
        IsNormalWheels = !IsNormalWheels;

        if (IsNormalWheels)
        {
            WheelsPrefabs[0].SetActive(true);
            WheelsPrefabs[1].SetActive(false);
            PlayerPrefs.SetInt("changeWheels", 0);
        }
        else
        {
            WheelsPrefabs[0].SetActive(false);
            WheelsPrefabs[1].SetActive(true);
            PlayerPrefs.SetInt("changeWheels", 1);
        }        
    }
}
