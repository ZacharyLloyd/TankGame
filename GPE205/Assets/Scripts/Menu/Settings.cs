using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Settings : MonoBehaviour
{
    public static Settings settingsInstance;
    public bool isMulitplayerEnabled;
    public bool isMapRandom;
    public bool isMapSeeded;
    public bool isMapOfTheDay;
    public float musicVolume;
    public float sfxVolume;
    public int seed;
    public Slider musicSlider;
    public Slider sfxSlider;
    public Toggle multiplayerToggle;
    public Toggle seedMap;
    public TMP_InputField seedNumber;
    public Toggle randomMap;
    public Toggle mapOfTheDay;

    private void Awake()
    {
        #region Singleton
        //Using the singleton
        if (settingsInstance == null)
        {
            settingsInstance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        #endregion
        LoadSettings();
    }
    private void OnApplicationQuit()
    {
        SaveSettings();
    }
    //Save the settings using player prefs
    public void SaveSettings()
    {
        //Multiplayer save
        if(isMulitplayerEnabled == true)
        {
            PlayerPrefs.SetInt("Multiplayer", 1);
        }
        else
        {
            PlayerPrefs.SetInt("Multiplayer", 0);
        }
        //Map of the day save
        if(isMapOfTheDay == true)
        {
            PlayerPrefs.SetInt("Motd", 1);
        }
        else
        {
            PlayerPrefs.SetInt("Motd", 0);
        }
        //Random map save
        if(isMapRandom == true)
        {
            PlayerPrefs.SetInt("Random", 1);
        }
        else
        {
            PlayerPrefs.SetInt("Random", 0);
        }
        //Seed map save
        if(isMapSeeded == true)
        {
            PlayerPrefs.SetInt("SeedMap", 1);
        }
        else
        {
            PlayerPrefs.SetInt("SeedMap", 0);
        }
        //Music volume save
        PlayerPrefs.SetFloat("Music Volume", musicVolume);
        //Sfx volume save
        PlayerPrefs.SetFloat("SFX Volume", sfxVolume);
        //Seed number save
        PlayerPrefs.SetInt("Seed", int.Parse(seedNumber.text));
        //Save everything
        PlayerPrefs.Save();
    }
    //Load the settings that we saved with player prefs
    public void LoadSettings()
    {
        //Load multiplayer setting
        if(PlayerPrefs.GetInt("Multiplayer") == 1)
        {
            isMulitplayerEnabled = true;
        }
        else
        {
            isMulitplayerEnabled = false;
        }
        //Load map of the day setting
        if(PlayerPrefs.GetInt("Motd") == 1)
        {
            isMapOfTheDay = true;
        }
        else
        {
            isMapOfTheDay = false;
        }
        //Load Random map setting
        if(PlayerPrefs.GetInt("Random") == 1)
        {
            isMapRandom = true;
        }
        else
        {
            isMapRandom = false;
        }
        //Load seed map setting
        if(PlayerPrefs.GetInt("SeedMap") == 1)
        {
            isMapSeeded = true;
        }
        else
        {
            isMapSeeded = false;
        }
        //Load music volume
        musicVolume = PlayerPrefs.GetFloat("Music Volume");
        //Load sfx volume
        sfxVolume = PlayerPrefs.GetFloat("SFX Volume");
        //Load seed number
        seed = PlayerPrefs.GetInt("Seed");
        //Update UI on load
        UpdateUI();
    }
    //Update the UI to match the saved values
    public void UpdateUI()
    {
        //Update value set to music volume
        musicSlider.value = musicVolume;
        //Update value set to sfx value
        sfxSlider.value = sfxVolume;
        //Update text to seed value
        seedNumber.text = seed.ToString();
        //Update Multiplayer toggle
        if (PlayerPrefs.GetInt("Multiplayer") == 1)
        {
            isMulitplayerEnabled = true;        }
        else
        {
            isMulitplayerEnabled = false;
        }
        multiplayerToggle.isOn = isMulitplayerEnabled;
        //Update map of the day toggle
        if(PlayerPrefs.GetInt("Motd") == 1)
        {
            isMapOfTheDay = true;
        }
        else
        {
            isMapOfTheDay = false;
        }
        mapOfTheDay.isOn = isMapOfTheDay;
        //Update random map toggle
        if(PlayerPrefs.GetInt("Random") == 1)
        {
            isMapRandom = true;
        }
        else
        {
            isMapRandom = false;
        }
        randomMap.isOn = isMapRandom;
        //Update seed map toggle
        if(PlayerPrefs.GetInt("SeedMap") == 1)
        {
            isMapSeeded = true;
        }
        else
        {
            isMapSeeded = false;
        }
        seedMap.isOn = isMapSeeded;
    }
}
