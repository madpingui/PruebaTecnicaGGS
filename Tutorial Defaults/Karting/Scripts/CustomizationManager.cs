using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizationManager : MonoBehaviour
{
    public GameObject[] hatsPrefabs;

    public Material playerMat;
    public Color[] playerColorsOptions;  
    
    public Material carMat;
    public Color[] carColorsOptions;
    
    public Material wheelsMat;
    public Color[] wheelsColorsOptions;

    [HideInInspector]
    public int indexHat;
    [HideInInspector]
    public int indexPlayer;
    [HideInInspector]
    public int indexCar;
    [HideInInspector]
    public int indexWheels;

    public static CustomizationManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != null)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(this);
    }

    public void ChangeHat()
    {
        foreach (var item in hatsPrefabs)
        {
            item.SetActive(false);
        }        

        if (indexHat > hatsPrefabs.Length - 1)
        {
            indexHat = 0;
            return;
        }    

        hatsPrefabs[indexHat].SetActive(true);

        indexHat++;
    }

    public void ChangePlayerColor()
    {
        if (indexPlayer > playerColorsOptions.Length - 1)
            indexPlayer = 0;

        playerMat.color = playerColorsOptions[indexPlayer];

        indexPlayer++;
    }

    public void ChangeCarColor()
    {
        if (indexCar > carColorsOptions.Length - 1)
            indexCar = 0;

        carMat.color = carColorsOptions[indexCar];

        indexCar++;
    }

    public void ChangeWheelsColor()
    {
        if (indexWheels > wheelsColorsOptions.Length - 1)
            indexWheels = 0;

        wheelsMat.color = wheelsColorsOptions[indexWheels];

        indexWheels++;
    }
}
